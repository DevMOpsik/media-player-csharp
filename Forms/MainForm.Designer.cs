using System.Windows.Forms;
namespace MediaPlayer.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListBox lstPlaylist;
        private Button btnPlay, btnPause, btnStop, btnAdd, btnRemove, btnLang;
        private TrackBar trkVolume;
        private Label lblVolume;
        public MediaPlayer.Controls.EqualizerControl eqControl;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lstPlaylist = new ListBox();
            this.btnPlay = new Button(); this.btnPause = new Button(); this.btnStop = new Button();
            this.btnAdd = new Button(); this.btnRemove = new Button(); this.btnLang = new Button();
            this.trkVolume = new TrackBar(); this.lblVolume = new Label();
            this.eqControl = new MediaPlayer.Controls.EqualizerControl();

            this.ClientSize = new System.Drawing.Size(384, 500);
            this.Text = "Медиаплеер";
            this.Name = "MainForm";

            this.lstPlaylist.Location = new System.Drawing.Point(12, 12); this.lstPlaylist.Size = new System.Drawing.Size(360, 200);
            
            this.btnAdd.Text = "Добавить"; this.btnAdd.Location = new System.Drawing.Point(12, 220); this.btnAdd.Click += this.btnAdd_Click;
            this.btnRemove.Text = "Удалить"; this.btnRemove.Location = new System.Drawing.Point(90, 220); this.btnRemove.Click += this.btnRemove_Click;
            
            this.btnPlay.Text = "▶ Play"; this.btnPlay.Location = new System.Drawing.Point(12, 260); this.btnPlay.Click += this.btnPlay_Click;
            this.btnPause.Text = "⏸ Pause"; this.btnPause.Location = new System.Drawing.Point(100, 260); this.btnPause.Click += this.btnPause_Click;
            this.btnStop.Text = "⏹ Stop"; this.btnStop.Location = new System.Drawing.Point(190, 260); this.btnStop.Click += this.btnStop_Click;
            this.btnLang.Text = "EN / RU"; this.btnLang.Location = new System.Drawing.Point(280, 260); this.btnLang.Size = new System.Drawing.Size(90, 23); this.btnLang.Click += this.btnLang_Click;

            this.trkVolume.Location = new System.Drawing.Point(12, 300); this.trkVolume.Minimum = 0; this.trkVolume.Maximum = 100; this.trkVolume.Value = 50; this.trkVolume.TickFrequency = 10; this.trkVolume.Scroll += this.trkVolume_Scroll;
            this.lblVolume.Text = "Громкость: 50%"; this.lblVolume.Location = new System.Drawing.Point(200, 300);

            this.eqControl.Location = new System.Drawing.Point(12, 330); this.eqControl.Size = new System.Drawing.Size(360, 150);

            this.Controls.Add(this.lblVolume); this.Controls.Add(this.trkVolume); this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause); this.Controls.Add(this.btnPlay); this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd); this.Controls.Add(this.btnLang); this.Controls.Add(this.lstPlaylist); this.Controls.Add(this.eqControl);
        }
    }
}
