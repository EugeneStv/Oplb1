using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using Microsoft.Win32;
using oplb2;
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
        public LibVLC mlibVLC;
        public LibVLCSharp.Shared.MediaPlayer mPlayer;
        private Timer timertb;
        private bool isFullscreen = false;
        private FormBorderStyle pfbstyle;
        private Rectangle pbstyle;
        private DockStyle pdcstyle; 
        private AnchorStyles panchor; 

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
            pbstyle = this.Bounds;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (mPlayer.IsPlaying)
            {
                tTimeline.Maximum = 800;
                tTimeline.Value = (int)(mPlayer.Position * 800);
            }
        }

        private void tTimeline_Scroll(object sender, EventArgs e)
        {
            if (mPlayer.IsPlaying)
            {
                mPlayer.Position = tTimeline.Value / 800f;
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
                pdcstyle = panel1.Dock; 
                panchor = panel1.Anchor;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.Bounds = Screen.PrimaryScreen.Bounds;
                menuStrip1.Visible = false;
                panel1.Dock = DockStyle.Fill;
                panel1.BringToFront();
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
                menuStrip1.Visible = true;
                panel1.Dock = pdcstyle; 
                panel1.Anchor = panchor;
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
                Stbt.Text = "Play";
            }
            else
            {
                mPlayer.Play();
                Stbt.Text = "Pause"; 
            }
        }

        private void открытьURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.SetActiveTab(1);
            form2.ShowDialog();
        }

        private void открытьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.SetActiveTab(0);
            form2.ShowDialog();
        }
    }
}