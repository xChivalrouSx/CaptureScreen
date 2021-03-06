﻿using System.Drawing;
using System.IO;

namespace CaptureScreen
{
    partial class CaptureArea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaptureArea));
            this.SuspendLayout();
            // 
            // CaptureArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BackgroundImage = new Bitmap(Directory.GetCurrentDirectory() + "/../../Images/CaptureArea.PNG");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(884, 525);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaptureArea";
            this.Opacity = 0.25D;
            this.Text = "CaptureArea";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CaptureArea_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CaptureScreen_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CaptureScreen_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CaptureScreen_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}