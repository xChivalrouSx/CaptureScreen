namespace CaptureScreen
{
    partial class MainForm
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
            this.btn_capture = new System.Windows.Forms.Button();
            this.cb_processes = new System.Windows.Forms.ComboBox();
            this.lbl = new System.Windows.Forms.Label();
            this.rb_current = new System.Windows.Forms.RadioButton();
            this.rb_application = new System.Windows.Forms.RadioButton();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.rb_select = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btn_capture
            // 
            this.btn_capture.Location = new System.Drawing.Point(12, 177);
            this.btn_capture.Name = "btn_capture";
            this.btn_capture.Size = new System.Drawing.Size(281, 23);
            this.btn_capture.TabIndex = 0;
            this.btn_capture.Text = "Capture";
            this.btn_capture.UseVisualStyleBackColor = true;
            this.btn_capture.Click += new System.EventHandler(this.btn_capture_Click);
            // 
            // cb_processes
            // 
            this.cb_processes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_processes.Enabled = false;
            this.cb_processes.FormattingEnabled = true;
            this.cb_processes.Location = new System.Drawing.Point(15, 114);
            this.cb_processes.Name = "cb_processes";
            this.cb_processes.Size = new System.Drawing.Size(164, 21);
            this.cb_processes.TabIndex = 3;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(12, 18);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(73, 13);
            this.lbl.TabIndex = 4;
            this.lbl.Text = "Caption Type:";
            // 
            // rb_current
            // 
            this.rb_current.AutoSize = true;
            this.rb_current.Location = new System.Drawing.Point(15, 45);
            this.rb_current.Name = "rb_current";
            this.rb_current.Size = new System.Drawing.Size(96, 17);
            this.rb_current.TabIndex = 5;
            this.rb_current.TabStop = true;
            this.rb_current.Text = "Current Screen";
            this.rb_current.UseVisualStyleBackColor = true;
            this.rb_current.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rb_application
            // 
            this.rb_application.AutoSize = true;
            this.rb_application.Location = new System.Drawing.Point(15, 91);
            this.rb_application.Name = "rb_application";
            this.rb_application.Size = new System.Drawing.Size(77, 17);
            this.rb_application.TabIndex = 6;
            this.rb_application.TabStop = true;
            this.rb_application.Text = "Application";
            this.rb_application.UseVisualStyleBackColor = true;
            this.rb_application.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Enabled = false;
            this.btn_refresh.Location = new System.Drawing.Point(185, 114);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(111, 21);
            this.btn_refresh.TabIndex = 7;
            this.btn_refresh.Text = "Refresh Processes";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // rb_select
            // 
            this.rb_select.AutoSize = true;
            this.rb_select.Location = new System.Drawing.Point(15, 68);
            this.rb_select.Name = "rb_select";
            this.rb_select.Size = new System.Drawing.Size(80, 17);
            this.rb_select.TabIndex = 8;
            this.rb_select.TabStop = true;
            this.rb_select.Text = "Select Area";
            this.rb_select.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 218);
            this.Controls.Add(this.rb_select);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.rb_application);
            this.Controls.Add(this.rb_current);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.cb_processes);
            this.Controls.Add(this.btn_capture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "CaptureScreen";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_capture;
        private System.Windows.Forms.ComboBox cb_processes;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.RadioButton rb_current;
        private System.Windows.Forms.RadioButton rb_application;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.RadioButton rb_select;
    }
}

