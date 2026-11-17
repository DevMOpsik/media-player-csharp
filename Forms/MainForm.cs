using System;
using System.Windows.Forms;
using System.Collections.Generic;
using MediaPlayer.Models;
using MediaPlayer.Services;

namespace MediaPlayer.Forms
{
    public partial class MainForm : Form
    {
        private List<Track> _playlist = new List<Track>();
        private bool _isEnglish = false;

        public MainForm()
        {
            InitializeComponent();
            _playlist = PlaylistService.Load();
            lstPlaylist.Items.AddRange(_playlist.ToArray());
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

        private void btnPlay_Click(object sender, EventArgs e) { MessageBox.Show("Play (заглушка)"); eqControl.StartAnimation(); }
        private void btnPause_Click(object sender, EventArgs e) { MessageBox.Show("Pause (заглушка)"); }
        private void btnStop_Click(object sender, EventArgs e) { MessageBox.Show("Stop (заглушка)"); eqControl.StopAnimation(); }

        private void trkVolume_Scroll(object sender, EventArgs e)
        {
            lblVolume.Text = _isEnglish ? $"Volume: {trkVolume.Value}%" : $"Громкость: {trkVolume.Value}%";
        }

        private void btnLang_Click(object sender, EventArgs e)
        {
            _isEnglish = !_isEnglish;
            if (_isEnglish)
            {
                this.Text = "Media Player"; btnAdd.Text = "Add"; btnRemove.Text = "Remove";
                lblVolume.Text = $"Volume: {trkVolume.Value}%";
            }
            else
            {
                this.Text = "Медиаплеер"; btnAdd.Text = "Добавить"; btnRemove.Text = "Удалить";
                lblVolume.Text = $"Громкость: {trkVolume.Value}%";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            PlaylistService.Save(_playlist);
            base.OnFormClosing(e);
        }
    }
}
