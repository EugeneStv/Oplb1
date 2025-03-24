using LibVLCSharp.Shared;
using Microsoft.Win32;
using oplb1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oplb2
{
    public partial class Form2 : Form
    {
        private string filePath;
        private Form1 mainForm;


        public Form2(Form1 parentForm)
        {
            InitializeComponent();
            mainForm = parentForm;
        }
        public void SetActiveTab(int tabIndex)
        {
            tabControl1.SelectedIndex = tabIndex;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\tyzty\Downloads\Peaky Blinders\1\Video";
            openFileDialog1.Filter = "Video Files|*.mp4;*.avi;*.mkv;";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                label2.Text = System.IO.Path.GetFileName(filePath);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (mainForm.mPlayer.IsPlaying)
            {
                mainForm.mPlayer.Stop();
            }

            Media npmedia = null;

            if (tabControl1.SelectedIndex == 0) 
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    return;
                }

                npmedia = new LFile(filePath).LoadMedia(mainForm.mlibVLC);
            }
            else if (tabControl1.SelectedIndex == 1) 
            {
                string url = textBox1.Text.Trim();
                if (string.IsNullOrEmpty(url))
                {
                    return;
                }

                npmedia = new Media(mainForm.mlibVLC, new Uri(new UrlM(url).MediaUrl()));
            }

            if (npmedia != null)
            {
                mainForm.mPlayer.Media = npmedia;
                mainForm.mPlayer.Play();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (mainForm.mPlayer.IsPlaying)
            {
                mainForm.mPlayer.Stop();
            }

            IMediaSource source = null;

            if (tabControl1.SelectedIndex == 0) 
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    return;
                }

                source = new LocalFile(filePath);
            }
            else if (tabControl1.SelectedIndex == 1) 
            {
                string url = textBox1.Text.Trim();
                if (string.IsNullOrEmpty(url))
                {
                    return;
                }

                source = new UrlAdapter(url);
            }

            if (source != null)
            {
                mainForm.mPlayer.Media = source.LoadMedia(mainForm.mlibVLC);
                mainForm.mPlayer.Play();
            }
        }
    }
}
