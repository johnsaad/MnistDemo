using Mnist.LeNet;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Mnist.DesktopApp
{
    public partial class MainWindow : Form
    {
        /// <summary>
        /// Deafult Pen width.
        /// </summary>
        private const float PenWidth = 30;
        
        /// <summary>
        /// Model wrapper for inference.
        /// </summary>
        private Model _model;

        /// <summary>
        /// Stores all the drawing data.
        /// </summary>
        private Shapes _drawingShapes = new Shapes();

        /// <summary>
        /// Is the mouse currently down (PAINTING).
        /// </summary>
        private bool _isPainting = false;

        /// <summary>
        /// Is the mouse currently down (ERASEING).
        /// </summary>
        private bool _hasPainted = false;

        /// <summary>
        /// Last Position, used to cut down on repative data.
        /// </summary>
        private Point _lastPosition = new Point(0, 0);

        /// <summary>
        /// Record the shapes so they can be drawn sepratley.
        /// </summary>
        private int _shapeCount = 0;

        /// <summary>
        /// Record the mouse position.
        /// </summary>
        private Point _mouseLocation = new Point(0, 0);

        /// <summary>
        /// Draw the mouse if over panel.
        /// </summary>
        private bool _isMouseIn = false;

        public MainWindow()
        {
            InitializeComponent();
            imagePanel.GetType().GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(imagePanel, new object[] { ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true });
            _model = new Model();
        }

        private void imagePanel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //If we're painting...
            //set it to mouse down, illatrate the shape being drawn and reset the last position
            _isPainting = true;
            _hasPainted = false;
            _shapeCount++;
            _lastPosition = new Point(0, 0);
        }

        protected void imagePanel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _mouseLocation = e.Location;
            //PAINTING
            if (_isPainting)
            {
                //check its not at the same place it was last time, saves on recording more data.
                if (_lastPosition != e.Location)
                {
                    //set this position as the last positon
                    _lastPosition = e.Location;
                    //store the position, width, colour and shape relation data
                    _drawingShapes.NewShape(_lastPosition, PenWidth, Color.Black, _shapeCount);
                }
            }
            //refresh the panel so it will be forced to re-draw.
            imagePanel.Refresh();
        }

        private void imagePanel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_isPainting)
            {
                //Finished Painting.
                _isPainting = false;
                _hasPainted = true;
            }
        }

        private void imagePanel_Paint(object sender, PaintEventArgs e)
        {
            //Apply a smoothing mode to smooth out the line.
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //DRAW THE LINES
            for (int i = 0; i < _drawingShapes.NumberOfShapes() - 1; i++)
            {
                Shape T = _drawingShapes.GetShape(i);
                Shape T1 = _drawingShapes.GetShape(i + 1);
                //make sure shape the two ajoining shape numbers are part of the same shape
                if (T.ShapeNumber == T1.ShapeNumber)
                {
                    //create a new pen with its width and colour
                    Pen p = new Pen(T.Colour, T.Width);
                    p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    //draw a line between the two ajoining points
                    e.Graphics.DrawLine(p, T.Location, T1.Location);
                    //get rid of the pen when finished
                    p.Dispose();
                }
            }
            //If mouse is on the panel, draw the mouse
            if (_isMouseIn)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Gray, 0.5f), _mouseLocation.X - (PenWidth / 2), _mouseLocation.Y - (PenWidth / 2), PenWidth, PenWidth);
            }
        }

        private void imagePanel_MouseEnter(object sender, EventArgs e)
        {
            //Hide the mouse cursor and tell the re-drawing function to draw the mouse
            Cursor.Hide();
            _isMouseIn = true;
        }

        private void imagePanel_MouseLeave(object sender, EventArgs e)
        {
            //show the mouse, tell the re-drawing function to stop drawing it and force the panel to re-draw.
            Cursor.Show();
            _isMouseIn = false;
            imagePanel.Refresh();
        }

        private void recognizeButton_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, recognizeButton.ClientRectangle,
                SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset);
        }

        private void recognizeButton_Click(object sender, EventArgs e)
        {
            this.numberLabel.Text = "";
            if (!_hasPainted)
            {
                MessageBox.Show("Please write a digit.");
                return;
            }

            try
            {
                Bitmap bmp = ImageUtils.PanelToBitmap(this.imagePanel);
                var newBmp = ImageUtils.ResizeImage(bmp, new Size(Model.ImageSize, Model.ImageSize));
                var data = ImageUtils.ConvertToGrayScaleArray(newBmp);

                float[] result = _model.Predict(data);
                numberLabel.Text = GetMaxIndex(result).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numberLabel.Text = "NA";
            }
        }

        private long GetMaxIndex(float[] array)
        {
            var min = array[0];
            var index = 0;
            for (var i = 1; i < array.Length; i++)
            {
                if (array[i] > min)
                {
                    min = array[i];
                    index = i;
                }
            }
            return index;
        }

        private void clearButton_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, clearButton.ClientRectangle,
                SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            _drawingShapes = new Shapes();
            imagePanel.Refresh();
            numberLabel.Text = "";
            _hasPainted = false;
        }
    }
}
