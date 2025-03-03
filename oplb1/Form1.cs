using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace oplb1
{
    public partial class Form1 : Form
    {
        private LibVLC mlibVLC;
        private LibVLCSharp.Shared.MediaPlayer mPlayer;
        private Timer timertb;
        private string filePath;
        private IFilmFactory filmFactory;
        private bool isFullscreen = false;
        private FormBorderStyle pfbstyle;
        private Rectangle pbstyle;

        public Form1()
        {
            InitializeComponent();

            Core.Initialize();
            mlibVLC = new LibVLC();
            mPlayer = new LibVLCSharp.Shared.MediaPlayer(mlibVLC);

            var videoView = new VideoView
            {
                Dock = DockStyle.Fill, 
                MediaPlayer = mPlayer
            };
            panel1.Controls.Add(videoView);

            
            timertb = new Timer { Interval = 1000 };
            timertb.Tick += Timer_Tick;
            timertb.Start();

        }
      
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (mPlayer.IsPlaying)
            {
                tTimeline.Maximum = (int)mPlayer.Length;
                tTimeline.Value = (int)mPlayer.Time;
            }
        }

        private void tTimeline_Scroll(object sender, EventArgs e)
        {
            if (mPlayer.IsPlaying)
            {
                mPlayer.Time = tTimeline.Value;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            mPlayer?.Stop();
            mPlayer?.Dispose();
            mlibVLC?.Dispose();
            base.OnFormClosing(e);
        }

        private void FSbt_Click(object sender, EventArgs e)
        {
            if (!isFullscreen)
            {
                pfbstyle = this.FormBorderStyle;
                pbstyle = this.Bounds;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.Bounds = Screen.PrimaryScreen.Bounds;
                panel1.Dock = DockStyle.Fill;
                panel1.BringToFront();
                panel2.Dock = DockStyle.Bottom;
                panel2.BringToFront();
                panel2.Visible = true;
                tTimeline.Width = panel2.Width;
                isFullscreen = true;
            }
            else
            {
                this.FormBorderStyle = pfbstyle;
                this.WindowState = FormWindowState.Normal;
                this.Bounds = pbstyle;
                panel1.Dock = DockStyle.None;
                panel2.Dock = DockStyle.None;
                tTimeline.Width = panel2.Width;
                panel2.Visible = true;
                isFullscreen = false;
            }
        }
       
        private void Vlmsc_Scroll(object sender, EventArgs e)
        {
            mPlayer.Volume = Vlmsc.Value;
        }

        private void Stbt_Click(object sender, EventArgs e)
        {
            if (mPlayer.IsPlaying)
            {
                mPlayer.Pause();
            }
            else
            {
                mPlayer.Play();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\tyzty\Downloads\Peaky Blinders\1\Video";
            openFileDialog1.Filter = "Video Files|*.mp4;*.avi;*.mkv;";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                label1.Text = System.IO.Path.GetFileName(filePath);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath)) return;
            if (mPlayer.IsPlaying) mPlayer.Stop();

            var media = new Media(mlibVLC, filePath);
            mPlayer.Media = media;


            filmFactory = (IFilmFactory)comboBox1.SelectedItem;
            var audio = filmFactory.CreateAudio();
            var subtitle = filmFactory.CreateSubtitle();

            audio.ApplyAudio(mPlayer, filePath);
            subtitle.ApplySubtitle(mPlayer, filePath);


            mPlayer.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath)) return;
            if (mPlayer.IsPlaying) mPlayer.Stop();

            var media = new Media(mlibVLC, filePath);
            mPlayer.Media = media;


            string slang = comboBox1.SelectedItem.ToString();


            AudSub.Audio(slang, mPlayer, filePath);
            AudSub.Subtitle(slang, mPlayer, filePath);


            mPlayer.Play();
        }
    }
}