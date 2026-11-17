using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace MediaPlayer.Controls
{
    public class EqualizerControl : Control
    {
        private int[] _barHeights = new int[10];
        private Random _random = new Random();
        private bool _isRunning;

        public EqualizerControl()
        {
            // Включаем двойную буферизацию для плавной отрисовки (из методички)
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;
        }

        public async void StartAnimation()
        {
            if (_isRunning) return;
            _isRunning = true;

            while (_isRunning)
            {
                // Длительная операция в фоновом потоке (Task.Run)
                await Task.Run(() =>
                {
                    for (int i = 0; i < _barHeights.Length; i++)
                    {
                        _barHeights[i] = _random.Next(10, this.Height - 10);
                    }
                });

                // Обновляем интерфейс из главного потока
                this.Invoke(new Action(() => this.Invalidate()));
                
                await Task.Delay(100); // Пауза между кадрами
            }
        }

        public void StopAnimation()
        {
            _isRunning = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int barWidth = this.Width / _barHeights.Length;
            Brush brush = new LinearGradientBrush(
                this.ClientRectangle, 
                Color.Cyan, 
                Color.Magenta, 
                LinearGradientMode.Vertical);

            for (int i = 0; i < _barHeights.Length; i++)
            {
                int x = i * barWidth;
                int y = this.Height - _barHeights[i];
                g.FillRectangle(brush, x + 2, y, barWidth - 4, _barHeights[i]);
            }
        }
    }
}
