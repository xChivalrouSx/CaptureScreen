using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureScreen
{
    public partial class CaptureArea : Form
    {
        public Rectangle ResultRect { get; set; }

        private bool _canDraw;
        private int _startX, _startY;

        private Rectangle _rect;

        public CaptureArea()
        {
            InitializeComponent();
        }

        private void CaptureScreen_MouseDown(object sender, MouseEventArgs e)
        {
            // Allow to draw
            _canDraw = true;

            // Get start points
            _startX = e.X;
            _startY = e.Y;
        }

        private void CaptureScreen_MouseUp(object sender, MouseEventArgs e)
        {
            // Not allow to draw
            _canDraw = false;

            // Save rectangle and close dialog
            ResultRect = _rect;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CaptureScreen_MouseMove(object sender, MouseEventArgs e)
        {
            // Check if can draw or not
            if (!_canDraw) return;

            // X,Y should be the minimum between the start X,Y and the current X,Y
            int x = Math.Min(_startX, e.X);
            int y = Math.Min(_startY, e.Y);

            // Width of rectangle should be the maximum between the start X and current X minus the minimum of start X and current X
            int width = Math.Max(_startX, e.X) - Math.Min(_startX, e.X);

            // Height of rectangle should be the maximum between the start Y and current Y minus the minimum of start Y and current Y
            int height = Math.Max(_startY, e.Y) - Math.Min(_startY, e.Y);

            // Set the rectangle
            _rect = new Rectangle(x, y, width, height);

            // Draw the rectangle
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Create new pen to draw [Color: red, Width: 2]
            using (Pen pen = new Pen(Color.Red, 2))
            {
                // Draw the rectangle
                e.Graphics.DrawRectangle(pen, _rect);
            }
        }


    }
}
