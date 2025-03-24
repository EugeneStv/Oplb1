namespace oplb2
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new System.Windows.Forms.TabControl();
            FILEP = new System.Windows.Forms.TabPage();
            button1 = new System.Windows.Forms.Button();
            URL = new System.Windows.Forms.TabPage();
            textBox1 = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            button3 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            tabControl1.SuspendLayout();
            FILEP.SuspendLayout();
            URL.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(FILEP);
            tabControl1.Controls.Add(URL);
            tabControl1.Location = new System.Drawing.Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(537, 146);
            tabControl1.TabIndex = 15;
            // 
            // FILEP
            // 
            FILEP.Controls.Add(label2);
            FILEP.Controls.Add(button1);
            FILEP.Location = new System.Drawing.Point(4, 29);
            FILEP.Name = "FILEP";
            FILEP.Padding = new System.Windows.Forms.Padding(3);
            FILEP.Size = new System.Drawing.Size(529, 113);
            FILEP.TabIndex = 0;
            FILEP.Text = "Файл";
            FILEP.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(6, 67);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(102, 29);
            button1.TabIndex = 4;
            button1.Text = "Обзор...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // URL
            // 
            URL.Controls.Add(label1);
            URL.Controls.Add(textBox1);
            URL.Location = new System.Drawing.Point(4, 29);
            URL.Name = "URL";
            URL.Padding = new System.Windows.Forms.Padding(3);
            URL.Size = new System.Drawing.Size(529, 113);
            URL.TabIndex = 1;
            URL.Text = "URL";
            URL.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(24, 51);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(472, 27);
            textBox1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(383, 161);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(101, 20);
            label4.TabIndex = 19;
            label4.Text = "Без адаптера";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(15, 161);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(67, 20);
            label3.TabIndex = 18;
            label3.Text = "Адаптер";
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(381, 184);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(151, 31);
            button3.TabIndex = 17;
            button3.Text = "Воспроизвести";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(15, 184);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(151, 29);
            button2.TabIndex = 16;
            button2.Text = "Воспроизвести ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(24, 18);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(171, 20);
            label1.TabIndex = 1;
            label1.Text = "Введите сетевой адрес:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 25);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(194, 20);
            label2.TabIndex = 5;
            label2.Text = "Нет загруженного фильма";
            // 
            // Form2
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(553, 222);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(tabControl1);
            Name = "Form2";
            Text = "Источник";
            tabControl1.ResumeLayout(false);
            FILEP.ResumeLayout(false);
            FILEP.PerformLayout();
            URL.ResumeLayout(false);
            URL.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage FILEP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage URL;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}