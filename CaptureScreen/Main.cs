using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaptureScreen.Classes;

namespace CaptureScreen
{
    public partial class MainForm : Form
    {

        #region[ - DLL Imports - ]

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr handle, ref Rectangle rect);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        #endregion

        private struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        private Capture _captureScreen;
        private CaptureArea _captureArea;


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PutProcessToCombo(cb_processes);
            rb_current.Checked = true;
        }

        #region[ - Event Handlers - ]

        private void btn_capture_Click(object sender, EventArgs e)
        {
            _captureScreen = new Capture();
            _captureArea = new CaptureArea();

            if(rb_current.Checked == true)
            {
                _captureScreen.CaptureCurrentScreen(this);
            }
            else if(rb_select.Checked == true)
            {
                if(_captureArea.ShowDialog() == DialogResult.OK)
                {
                    Rectangle rect = _captureArea.ResultRect;
                    _captureScreen.CaptureArea(this, rect);
                }

                _captureArea.Dispose();
            }
            else if(rb_application.Checked == true && cb_processes.SelectedItem != null)
            {
                IntPtr hwnd = FindWindow(null, cb_processes.SelectedItem.ToString());

                if (!IsAppMinimized(hwnd))
                {
                    _captureScreen.CaptureWindow(hwnd, cb_processes.SelectedItem.ToString());
                }
                else
                {
                    MessageBox.Show("Error: Application is minimized.");
                }
            }
            else if(rb_application.Checked == true && cb_processes.SelectedItem == null)
            {
                MessageBox.Show("Please select an applicatiom from list.");
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            PutProcessToCombo(cb_processes);
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton.Name.Equals(rb_application.Name))
            {
                ActivateProcessSelection();
            }
            else
            {
                DeactivateProcessSelection();
            }
        }

        #endregion

        #region[ - Private Methods - ]

        private void ActivateProcessSelection()
        {
            cb_processes.Enabled = true;
            btn_refresh.Enabled = true;
        }
        
        private void DeactivateProcessSelection()
        {
            cb_processes.Enabled = false;
            btn_refresh.Enabled = false;
        }

        private void PutProcessToCombo(ComboBox combo)
        {
            combo.Items.Clear();

            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                if (!String.IsNullOrEmpty(p.MainWindowTitle))
                {
                    combo.Items.Add(p.MainWindowTitle);
                }
            }
            combo.DropDownWidth = DropDownWidth(combo);
        }

        private int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0;
            int temp = 0;
            Label labelForTest = new Label();

            foreach (var obj in myCombo.Items)
            {
                labelForTest.Text = obj.ToString();
                temp = labelForTest.PreferredWidth;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            labelForTest.Dispose();
            return maxWidth;
        }

        private bool IsAppMinimized(IntPtr hwnd)
        {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            GetWindowPlacement(hwnd, ref placement);

            // Normal: 1, Minimized: 2, Maximized: 3
            return placement.showCmd == 2;
        }

        #endregion

    }
}
