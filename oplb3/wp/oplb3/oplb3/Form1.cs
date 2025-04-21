using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace oplb3
{
    public partial class Form1 : Form
    {
        private Canvas canvas;
        private CommandHistory history = new CommandHistory();
        private bool drawing = false;
        private Pen pen = new Pen(Color.Black, 3);
        private List<Point> cpoints = new List<Point>();

        public Form1()
        {
            InitializeComponent();
            canvas = new Canvas(pictureBox);

            trackBar1.Minimum = 1;
            trackBar1.Maximum = 20;
            trackBar1.Value = (int)pen.Width;

            SetupEventHandlers();
            UpdateButtons();
        }

        private void SetupEventHandlers()
        {
            pictureBox.MouseDown += PictureBox_MouseDown;
            pictureBox.MouseUp += PictureBox_MouseUp;
            pictureBox.MouseMove += PictureBox_MouseMove;

            btnClear.Click += BtnClear_Click;
            btnUndo.Click += BtnUndo_Click;
            btnRedo.Click += BtnRedo_Click;

            button1.Click += ColorButton_Click;
            button2.Click += ColorButton_Click;
            button3.Click += ColorButton_Click;
            button4.Click += ColorButton_Click;
            button5.Click += ColorButton_Click;
            button6.Click += ColorButton_Click;
            button7.Click += ColorButton_Click;
            button8.Click += ColorButton_Click;
            button9.Click += ColorButton_Click;
            button10.Click += ColorButton_Click;
            button11.Click += ColorButton_Click;
            button12.Click += ColorButton_Click;
            button13.Click += ColorButton_Click;
            button14.Click += ColorButton_Click;
            button15.Click += ColorButton_Click;
            button16.Click += ColorButton_Click;
            button17.Click += ColorButton_Click;
            button18.Click += ColorButton_Click;

            trackBar1.Scroll += TrackBar1_Scroll;

            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drawing = true;
                cpoints.Clear();
                cpoints.Add(e.Location);
                canvas.StartDrawing();
            }
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                pen.Color = clickedButton.BackColor;
            }
        }
        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing && e.Button == MouseButtons.Left)
            {
                cpoints.Add(e.Location);
                canvas.DrawTempLine(pen, cpoints);
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                drawing = false;
                if (cpoints.Count > 1)
                {
                    var command = new DrawLineCommand(canvas, new Pen(pen.Color, pen.Width), new List<Point>(cpoints));
                    history.Execute(command);
                }
                cpoints.Clear();
                UpdateButtons();
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            var command = new ClearCanvasCommand(canvas);
            history.Execute(command);
            UpdateButtons();
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            history.Undo();
            UpdateButtons();
        }

        private void BtnRedo_Click(object sender, EventArgs e)
        {
            history.Redo();
            UpdateButtons();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z) BtnUndo_Click(null, null);
            if (e.Control && e.KeyCode == Keys.Y) BtnRedo_Click(null, null);
        }

        private void UpdateButtons()
        {
            btnUndo.Enabled = history.CanUndo;
            btnRedo.Enabled = history.CanRedo;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
            saveFileDialog1.Title = "Сохранить изображение";
            saveFileDialog1.DefaultExt = "png";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                ImageFormat format = ImageFormat.Png;

                switch (Path.GetExtension(filePath).ToLower())
                {
                    case ".jpg":
                    case ".jpeg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }

                Bitmap image = canvas.GetBitmap();
                image.Save(filePath, format);
            }
        }
    }

    public class Canvas
    {
        private Graphics graphics;
        private Bitmap bitmap;
        private Bitmap stbitmap;
        private PictureBox picture;

        public Canvas(PictureBox pictureBox)
        {
            picture = pictureBox;
            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            picture.Image = bitmap;
        }

        public Bitmap GetBitmap()
        {
            return (Bitmap)bitmap.Clone();
        }

        public void Restore(Bitmap backup)
        {
            graphics.DrawImage(backup, Point.Empty);
            picture.Image = bitmap;
        }


        public void StartDrawing()
        {
            stbitmap = (Bitmap)bitmap.Clone();
        }

        public void DrawTempLine(Pen pen, List<Point> points)
        {
            var tempbit = (Bitmap)stbitmap.Clone();
            using (var g = Graphics.FromImage(tempbit))
            {
                if (points.Count > 1)
                {
                    g.DrawLines(pen, points.ToArray());
                }
            }
            picture.Image = tempbit;
        }

        public void DrawLine(Pen pen, List<Point> points)
        {
            if (points.Count > 1)
            {
                graphics.DrawLines(pen, points.ToArray());
                picture.Image = bitmap;
            }
        }

        public void Clear()
        {
            graphics.Clear(Color.White);
            picture.Image = bitmap;
        }
    }

}