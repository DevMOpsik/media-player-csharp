using System;
using System.Windows.Forms;
using MediaPlayer.Models;
using System.Collections.Generic;

namespace MediaPlayer.Forms
{
    public partial class MainForm : Form
    {
        private List<Track> _playlist = new List<Track>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Аудио|*.mp3;*.wav" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var track = new Track(ofd.FileName);
                    _playlist.Add(track);
                    lstPlaylist.Items.Add(track);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstPlaylist.SelectedIndex >= 0)
            {
                _playlist.RemoveAt(lstPlaylist.SelectedIndex);
                lstPlaylist.Items.RemoveAt(lstPlaylist.SelectedIndex);
            }
        }

        private void btnPause_Click(object sender, EventArgs e) { MessageBox.Show("Pause (заглушка)"); }
private void btnPlay_Click(object sender, EventArgs e) 
        { 
            MessageBox.Show("Воспроизведение (заглушка)");
            eqControl.StartAnimation(); // Включаем анимацию эквалайзера
        }

        private void btnStop_Click(object sender, EventArgs e) 
        { 
            MessageBox.Show("Стоп (заглушка)");
            eqControl.StopAnimation(); // Выключаем анимацию
        }
        private void trkVolume_Scroll(object sender, EventArgs e)
        {
            lblVolume.Text = $"Громкость: {trkVolume.Value}%";
        }
    }
}
