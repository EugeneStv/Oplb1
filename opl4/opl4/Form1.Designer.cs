namespace opl4
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
        private void InitializeUI()
        {
            listFiles.AllowDrop = true;
            listFiles.SelectionMode = SelectionMode.MultiExtended;
            listFiles.KeyDown += ListFiles_KeyDown;
            listFiles.DragOver += ListFiles_DragOver;
            listFiles.DragDrop += ListFiles_DragDrop;
            listFiles.DoubleClick += ListFiles_DoubleClick;

            InitializeContextMenu();
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            listFiles = new ListBox();
            cmbProviders = new ComboBox();
            btnConnect = new Button();
            btnRefresh = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // listFiles
            // 
            listFiles.AllowDrop = true;
            listFiles.DrawMode = DrawMode.OwnerDrawVariable;
            listFiles.FormattingEnabled = true;
            listFiles.HorizontalExtent = 50;
            listFiles.HorizontalScrollbar = true;
            listFiles.ItemHeight = 32;
            listFiles.Location = new Point(30, 114);
            listFiles.Name = "listFiles";
            listFiles.SelectionMode = SelectionMode.MultiExtended;
            listFiles.Size = new Size(370, 484);
            listFiles.TabIndex = 0;
            listFiles.DrawItem += ListFiles_DrawItem;
            // 
            // cmbProviders
            // 
            cmbProviders.FormattingEnabled = true;
            cmbProviders.Location = new Point(30, 32);
            cmbProviders.Name = "cmbProviders";
            cmbProviders.Size = new Size(176, 28);
            cmbProviders.TabIndex = 1;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(249, 32);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(151, 29);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Подключение";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(30, 81);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(96, 29);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // button1
            // 
            button1.Location = new Point(249, 81);
            button1.Name = "button1";
            button1.Size = new Size(151, 29);
            button1.TabIndex = 5;
            button1.Text = "Создать папку";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 617);
            Controls.Add(button1);
            Controls.Add(btnRefresh);
            Controls.Add(btnConnect);
            Controls.Add(cmbProviders);
            Controls.Add(listFiles);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "CloudManager";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listFiles;
        private ComboBox cmbProviders;
        private Button btnConnect;
        private Button btnRefresh;
        private Button button1;
    }
}
