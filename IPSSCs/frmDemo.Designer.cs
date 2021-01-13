namespace IPSS
{
    partial class frmDemo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDemo));
            this.grpCamera = new System.Windows.Forms.GroupBox();
            this.btnStartScan = new System.Windows.Forms.Button();
            this.cbCamera = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.picCamera = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerProgressbar = new System.Windows.Forms.Timer(this.components);
            this.lblMessage = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdImage = new System.Windows.Forms.RadioButton();
            this.rdCamera = new System.Windows.Forms.RadioButton();
            this.grpImage = new System.Windows.Forms.GroupBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnGetPlate = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.grpCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCamera
            // 
            this.grpCamera.Controls.Add(this.btnStartScan);
            this.grpCamera.Controls.Add(this.cbCamera);
            this.grpCamera.Controls.Add(this.label1);
            this.grpCamera.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCamera.Location = new System.Drawing.Point(0, 167);
            this.grpCamera.Name = "grpCamera";
            this.grpCamera.Size = new System.Drawing.Size(541, 70);
            this.grpCamera.TabIndex = 0;
            this.grpCamera.TabStop = false;
            this.grpCamera.Visible = false;
            // 
            // btnStartScan
            // 
            this.btnStartScan.Enabled = false;
            this.btnStartScan.Location = new System.Drawing.Point(365, 24);
            this.btnStartScan.Name = "btnStartScan";
            this.btnStartScan.Size = new System.Drawing.Size(75, 23);
            this.btnStartScan.TabIndex = 5;
            this.btnStartScan.Text = "Start scan";
            this.btnStartScan.UseVisualStyleBackColor = true;
            // 
            // cbCamera
            // 
            this.cbCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamera.FormattingEnabled = true;
            this.cbCamera.Location = new System.Drawing.Point(200, 26);
            this.cbCamera.Name = "cbCamera";
            this.cbCamera.Size = new System.Drawing.Size(121, 21);
            this.cbCamera.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select camera";
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.ForeColor = System.Drawing.Color.Red;
            this.txtResult.Location = new System.Drawing.Point(324, 15);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(177, 32);
            this.txtResult.TabIndex = 3;
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // picCamera
            // 
            this.picCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCamera.Location = new System.Drawing.Point(0, 237);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(541, 343);
            this.picCamera.TabIndex = 1;
            this.picCamera.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(21, 56);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(480, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerProgressbar
            // 
            this.timerProgressbar.Enabled = true;
            this.timerProgressbar.Interval = 10;
            this.timerProgressbar.Tick += new System.EventHandler(this.timerProgressbar_Tick);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Green;
            this.lblMessage.Location = new System.Drawing.Point(67, 404);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(382, 31);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "Loading camera, please wait...";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtResult);
            this.groupBox2.Controls.Add(this.rdImage);
            this.groupBox2.Controls.Add(this.rdCamera);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(541, 89);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select source image";
            // 
            // rdImage
            // 
            this.rdImage.AutoSize = true;
            this.rdImage.Location = new System.Drawing.Point(181, 25);
            this.rdImage.Name = "rdImage";
            this.rdImage.Size = new System.Drawing.Size(79, 17);
            this.rdImage.TabIndex = 1;
            this.rdImage.TabStop = true;
            this.rdImage.Text = "From image";
            this.rdImage.UseVisualStyleBackColor = true;
            this.rdImage.CheckedChanged += new System.EventHandler(this.rdImage_CheckedChanged);
            // 
            // rdCamera
            // 
            this.rdCamera.AutoSize = true;
            this.rdCamera.Location = new System.Drawing.Point(47, 25);
            this.rdCamera.Name = "rdCamera";
            this.rdCamera.Size = new System.Drawing.Size(86, 17);
            this.rdCamera.TabIndex = 0;
            this.rdCamera.TabStop = true;
            this.rdCamera.Text = "From camera";
            this.rdCamera.UseVisualStyleBackColor = true;
            this.rdCamera.CheckedChanged += new System.EventHandler(this.rdCamera_CheckedChanged);
            // 
            // grpImage
            // 
            this.grpImage.Controls.Add(this.btnSelect);
            this.grpImage.Controls.Add(this.btnGetPlate);
            this.grpImage.Controls.Add(this.txtFilePath);
            this.grpImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpImage.Location = new System.Drawing.Point(0, 89);
            this.grpImage.Name = "grpImage";
            this.grpImage.Size = new System.Drawing.Size(541, 78);
            this.grpImage.TabIndex = 7;
            this.grpImage.TabStop = false;
            this.grpImage.Text = "Image path";
            this.grpImage.Visible = false;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(371, 30);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(26, 23);
            this.btnSelect.TabIndex = 8;
            this.btnSelect.Text = "...";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnGetPlate
            // 
            this.btnGetPlate.Enabled = false;
            this.btnGetPlate.Location = new System.Drawing.Point(413, 30);
            this.btnGetPlate.Name = "btnGetPlate";
            this.btnGetPlate.Size = new System.Drawing.Size(122, 23);
            this.btnGetPlate.TabIndex = 7;
            this.btnGetPlate.Text = "Get license plate";
            this.btnGetPlate.UseVisualStyleBackColor = true;
            this.btnGetPlate.Click += new System.EventHandler(this.btnGetPlate_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(47, 32);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(317, 20);
            this.txtFilePath.TabIndex = 6;
            // 
            // frmDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(541, 580);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.picCamera);
            this.Controls.Add(this.grpCamera);
            this.Controls.Add(this.grpImage);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDemo";
            this.Text = "Phần mềm nhận dạng biển số - http://thigiacmaytinh.com";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDemo_FormClosed);
            this.Load += new System.EventHandler(this.frmDemo_Load);
            this.grpCamera.ResumeLayout(false);
            this.grpCamera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpImage.ResumeLayout(false);
            this.grpImage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCamera;
        private System.Windows.Forms.PictureBox picCamera;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerProgressbar;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdImage;
        private System.Windows.Forms.RadioButton rdCamera;
        private System.Windows.Forms.GroupBox grpImage;
        private System.Windows.Forms.Button btnGetPlate;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnStartScan;
        private System.Windows.Forms.ComboBox cbCamera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelect;
    }
}