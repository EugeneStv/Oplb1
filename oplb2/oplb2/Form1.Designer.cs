using System.Windows.Forms;

namespace oplb1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            Vlmsc = new TrackBar();
            Stbt = new Button();
            FSbt = new Button();
            tTimeline = new TrackBar();
            openFileDialog1 = new OpenFileDialog();
            panel2 = new Panel();
            menuStrip1 = new MenuStrip();
            медиаToolStripMenuItem = new ToolStripMenuItem();
            открытьФайлToolStripMenuItem = new ToolStripMenuItem();
            открытьURLToolStripMenuItem = new ToolStripMenuItem();
            открытьURLToolStripMenuItem1 = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)Vlmsc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tTimeline).BeginInit();
            panel2.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Location = new System.Drawing.Point(0, 28);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(901, 446);
            panel1.TabIndex = 0;
            // 
            // Vlmsc
            // 
            Vlmsc.Location = new System.Drawing.Point(74, 27);
            Vlmsc.Maximum = 100;
            Vlmsc.Name = "Vlmsc";
            Vlmsc.Size = new System.Drawing.Size(130, 56);
            Vlmsc.TabIndex = 0;
            Vlmsc.Value = 100;
            Vlmsc.Scroll += Vlmsc_Scroll;
            // 
            // Stbt
            // 
            Stbt.Location = new System.Drawing.Point(3, 42);
            Stbt.Name = "Stbt";
            Stbt.Size = new System.Drawing.Size(65, 29);
            Stbt.TabIndex = 1;
            Stbt.Text = "Play";
            Stbt.UseVisualStyleBackColor = true;
            Stbt.Click += Stbt_Click;
            // 
            // FSbt
            // 
            FSbt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FSbt.Location = new System.Drawing.Point(811, 42);
            FSbt.Name = "FSbt";
            FSbt.Size = new System.Drawing.Size(78, 29);
            FSbt.TabIndex = 2;
            FSbt.Text = "Full";
            FSbt.UseVisualStyleBackColor = true;
            FSbt.Click += FSbt_Click;
            // 
            // tTimeline
            // 
            tTimeline.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tTimeline.Location = new System.Drawing.Point(3, 0);
            tTimeline.Maximum = 100;
            tTimeline.Name = "tTimeline";
            tTimeline.Size = new System.Drawing.Size(895, 56);
            tTimeline.TabIndex = 3;
            tTimeline.TickStyle = TickStyle.None;
            tTimeline.Scroll += tTimeline_Scroll;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel2
            // 
            panel2.Controls.Add(Stbt);
            panel2.Controls.Add(Vlmsc);
            panel2.Controls.Add(FSbt);
            panel2.Controls.Add(tTimeline);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(0, 480);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(901, 86);
            panel2.TabIndex = 13;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { медиаToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(901, 28);
            menuStrip1.TabIndex = 14;
            menuStrip1.Text = "menuStrip1";
            // 
            // медиаToolStripMenuItem
            // 
            медиаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьФайлToolStripMenuItem, открытьURLToolStripMenuItem });
            медиаToolStripMenuItem.Name = "медиаToolStripMenuItem";
            медиаToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            медиаToolStripMenuItem.Text = "Медиа";
            // 
            // открытьФайлToolStripMenuItem
            // 
            открытьФайлToolStripMenuItem.Name = "открытьФайлToolStripMenuItem";
            открытьФайлToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            открытьФайлToolStripMenuItem.Text = "Открыть файл...";
            открытьФайлToolStripMenuItem.Click += открытьФайлToolStripMenuItem_Click;
            // 
            // открытьURLToolStripMenuItem
            // 
            открытьURLToolStripMenuItem.Name = "открытьURLToolStripMenuItem";
            открытьURLToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            открытьURLToolStripMenuItem.Text = "Открыть URL...";
            открытьURLToolStripMenuItem.Click += открытьURLToolStripMenuItem_Click;
            // 
            // открытьURLToolStripMenuItem1
            // 
            открытьURLToolStripMenuItem1.Name = "открытьURLToolStripMenuItem1";
            открытьURLToolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(901, 566);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Медиапроигрыватель";
            ((System.ComponentModel.ISupportInitialize)Vlmsc).EndInit();
            ((System.ComponentModel.ISupportInitialize)tTimeline).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar Vlmsc;
        private System.Windows.Forms.Button Stbt;
        private System.Windows.Forms.Button FSbt;
        private System.Windows.Forms.TrackBar tTimeline;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Panel panel2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem медиаToolStripMenuItem;
        private ToolStripMenuItem открытьФайлToolStripMenuItem;
        private ToolStripMenuItem открытьURLToolStripMenuItem;
        private ToolStripMenuItem открытьURLToolStripMenuItem1;
    }
}

