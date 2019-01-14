using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureScreen.Classes
{
    class Capture
    {

        #region[ - DLL Imports - ]

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr handle, ref Rectangle rect);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        #endregion

        #region[ - Public Methods - ]

        public void CaptureWindow(IntPtr handle, string title)
        {
            // Get the size of the window to capture
            Rectangle rect = new Rectangle();
            GetWindowRect(handle, ref rect);

            // GetWindowRect returns Top/Left and Bottom/Right, so fix it
            rect.Width = rect.Width - rect.X;
            rect.Height = rect.Height - rect.Y;

            // Create a bitmap to draw the capture into
            using (Bitmap bitmap = new Bitmap(rect.Width, rect.Height))
            {
                // Use PrintWindow to draw the window into our bitmap
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    IntPtr hdc = g.GetHdc();
                    if (!PrintWindow(handle, hdc, 0))
                    {
                        int error = Marshal.GetLastWin32Error();
                        var exception = new System.ComponentModel.Win32Exception(error);
                        Debug.WriteLine("ERROR: " + error + ": " + exception.Message);
                        
                        // TODO: Throw the exception?
                    }
                    g.ReleaseHdc(hdc);
                }

                SaveCapturedScreen(bitmap);
            }
        }

        public void CaptureCurrentScreen(Form activeForm)
        {
            activeForm.WindowState = FormWindowState.Minimized;
            activeForm.Visible = false;
            
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }

                SaveCapturedScreen(bitmap);
            }

            activeForm.Visible = true;
        }

        public void CaptureArea(Form activeForm, Rectangle rect)
        {
            activeForm.WindowState = FormWindowState.Minimized;
            activeForm.Visible = false;

            try
            {
                using (Bitmap bitmap = new Bitmap(rect.Width, rect.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size, CopyPixelOperation.SourceCopy);
                    }

                    SaveCapturedScreen(bitmap);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            activeForm.Visible = true;
        }

        #endregion

        #region[ - Private Methods - ]

        private void SaveCapturedScreen(Bitmap bitmap)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png";
            ImageFormat format = ImageFormat.Png;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".png":
                        format = ImageFormat.Png;
                        break;
                }
                bitmap.Save(sfd.FileName, format);
            }
        }

        #endregion

    }
}
