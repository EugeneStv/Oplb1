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
            EnglishFilmFactory englishFilmFactory2 = new EnglishFilmFactory();
            RussianFilmFactory russianFilmFactory2 = new RussianFilmFactory();
            panel1 = new Panel();
            Vlmsc = new TrackBar();
            Stbt = new Button();
            FSbt = new Button();
            tTimeline = new TrackBar();
            openFileDialog1 = new OpenFileDialog();
            button1 = new Button();
            button2 = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            button3 = new Button();
            label3 = new Label();
            label4 = new Label();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)Vlmsc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tTimeline).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new System.Drawing.Point(22, 52);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(664, 422);
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
            FSbt.Location = new System.Drawing.Point(571, 42);
            FSbt.Name = "FSbt";
            FSbt.Size = new System.Drawing.Size(78, 29);
            FSbt.TabIndex = 2;
            FSbt.Text = "Full";
            FSbt.UseVisualStyleBackColor = true;
            FSbt.Click += FSbt_Click;
            // 
            // tTimeline
            // 
            tTimeline.Location = new System.Drawing.Point(3, 0);
            tTimeline.Maximum = 100;
            tTimeline.Name = "tTimeline";
            tTimeline.Size = new System.Drawing.Size(664, 56);
            tTimeline.TabIndex = 3;
            tTimeline.TickStyle = TickStyle.None;
            tTimeline.Scroll += tTimeline_Scroll;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(722, 23);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(151, 29);
            button1.TabIndex = 4;
            button1.Text = "Выбрать фильм";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(722, 179);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(151, 29);
            button2.TabIndex = 5;
            button2.Text = "Воспроизвести ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { englishFilmFactory2, russianFilmFactory2 });
            comboBox1.Location = new System.Drawing.Point(722, 95);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(151, 28);
            comboBox1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(22, 23);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(194, 20);
            label1.TabIndex = 8;
            label1.Text = "Нет загруженного фильма";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            label2.Location = new System.Drawing.Point(722, 64);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(57, 28);
            label2.TabIndex = 9;
            label2.Text = "Язык";
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(722, 276);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(151, 31);
            button3.TabIndex = 10;
            button3.Text = "Воспроизвести";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(722, 156);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(160, 20);
            label3.TabIndex = 11;
            label3.Text = "Абстрактная фабрика";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(722, 253);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(129, 20);
            label4.TabIndex = 12;
            label4.Text = "Без абс. фабрики";
            // 
            // panel2
            // 
            panel2.Controls.Add(Stbt);
            panel2.Controls.Add(Vlmsc);
            panel2.Controls.Add(FSbt);
            panel2.Controls.Add(tTimeline);
            panel2.Location = new System.Drawing.Point(22, 480);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(661, 86);
            panel2.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(901, 566);
            Controls.Add(panel2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)Vlmsc).EndInit();
            ((System.ComponentModel.ISupportInitialize)tTimeline).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Button button3;
        private Label label3;
        private Label label4;
        private Panel panel2;
    }
}

