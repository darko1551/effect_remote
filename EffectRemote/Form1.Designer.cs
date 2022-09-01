namespace EffectRemote
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.outputDevicesList = new System.Windows.Forms.ListBox();
            this.selectDeviceBtn = new System.Windows.Forms.Button();
            this.mouseCoordinatesLbl = new System.Windows.Forms.Label();
            this.savedCoordinatesLbl = new System.Windows.Forms.Label();
            this.chordLbl = new System.Windows.Forms.Label();
            this.majorMinorLbl = new System.Windows.Forms.Label();
            this.calibrateAutoPitchBtn = new System.Windows.Forms.Button();
            this.calibratePitchProofBtn = new System.Windows.Forms.Button();
            this.circlePctr = new System.Windows.Forms.PictureBox();
            this.exitBtn = new System.Windows.Forms.Button();
            this.minimiseButton = new System.Windows.Forms.Button();
            this.dragPnl = new System.Windows.Forms.Panel();
            this.logoPctr = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.circlePctr)).BeginInit();
            this.dragPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPctr)).BeginInit();
            this.SuspendLayout();
            // 
            // outputDevicesList
            // 
            this.outputDevicesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(43)))), ((int)(((byte)(56)))));
            this.outputDevicesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputDevicesList.ForeColor = System.Drawing.Color.White;
            this.outputDevicesList.FormattingEnabled = true;
            this.outputDevicesList.ItemHeight = 20;
            this.outputDevicesList.Location = new System.Drawing.Point(12, 55);
            this.outputDevicesList.Name = "outputDevicesList";
            this.outputDevicesList.Size = new System.Drawing.Size(358, 80);
            this.outputDevicesList.TabIndex = 1;
            this.outputDevicesList.DoubleClick += new System.EventHandler(this.outputDevicesList_DoubleClick);
            // 
            // selectDeviceBtn
            // 
            this.selectDeviceBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(43)))), ((int)(((byte)(56)))));
            this.selectDeviceBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(145)))), ((int)(((byte)(141)))));
            this.selectDeviceBtn.FlatAppearance.BorderSize = 0;
            this.selectDeviceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectDeviceBtn.ForeColor = System.Drawing.Color.White;
            this.selectDeviceBtn.Location = new System.Drawing.Point(380, 55);
            this.selectDeviceBtn.Name = "selectDeviceBtn";
            this.selectDeviceBtn.Size = new System.Drawing.Size(159, 120);
            this.selectDeviceBtn.TabIndex = 2;
            this.selectDeviceBtn.Text = "Select Device";
            this.selectDeviceBtn.UseVisualStyleBackColor = false;
            this.selectDeviceBtn.Click += new System.EventHandler(this.selectDeviceBtn_Click);
            this.selectDeviceBtn.MouseEnter += new System.EventHandler(this.selectDeviceBtn_MouseEnter);
            this.selectDeviceBtn.MouseLeave += new System.EventHandler(this.selectDeviceBtn_MouseLeave);
            // 
            // mouseCoordinatesLbl
            // 
            this.mouseCoordinatesLbl.AutoSize = true;
            this.mouseCoordinatesLbl.ForeColor = System.Drawing.Color.White;
            this.mouseCoordinatesLbl.Location = new System.Drawing.Point(12, 192);
            this.mouseCoordinatesLbl.Name = "mouseCoordinatesLbl";
            this.mouseCoordinatesLbl.Size = new System.Drawing.Size(135, 20);
            this.mouseCoordinatesLbl.TabIndex = 4;
            this.mouseCoordinatesLbl.Text = "Mouse coordinates";
            this.mouseCoordinatesLbl.Visible = false;
            // 
            // savedCoordinatesLbl
            // 
            this.savedCoordinatesLbl.AutoSize = true;
            this.savedCoordinatesLbl.ForeColor = System.Drawing.Color.White;
            this.savedCoordinatesLbl.Location = new System.Drawing.Point(12, 238);
            this.savedCoordinatesLbl.Name = "savedCoordinatesLbl";
            this.savedCoordinatesLbl.Size = new System.Drawing.Size(133, 20);
            this.savedCoordinatesLbl.TabIndex = 5;
            this.savedCoordinatesLbl.Text = "Saved Coordinates";
            this.savedCoordinatesLbl.Visible = false;
            // 
            // chordLbl
            // 
            this.chordLbl.BackColor = System.Drawing.Color.Transparent;
            this.chordLbl.Font = new System.Drawing.Font("Segoe UI", 80F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chordLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(106)))), ((int)(((byte)(82)))));
            this.chordLbl.Location = new System.Drawing.Point(12, 192);
            this.chordLbl.Name = "chordLbl";
            this.chordLbl.Size = new System.Drawing.Size(526, 526);
            this.chordLbl.TabIndex = 6;
            this.chordLbl.Text = "C";
            this.chordLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chordLbl.Click += new System.EventHandler(this.chordLbl_Click);
            this.chordLbl.DoubleClick += new System.EventHandler(this.chordLbl_DoubleClick);
            // 
            // majorMinorLbl
            // 
            this.majorMinorLbl.AutoSize = true;
            this.majorMinorLbl.BackColor = System.Drawing.Color.Transparent;
            this.majorMinorLbl.Font = new System.Drawing.Font("Segoe UI", 70F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.majorMinorLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(145)))), ((int)(((byte)(141)))));
            this.majorMinorLbl.Location = new System.Drawing.Point(46, 698);
            this.majorMinorLbl.Name = "majorMinorLbl";
            this.majorMinorLbl.Size = new System.Drawing.Size(450, 155);
            this.majorMinorLbl.TabIndex = 7;
            this.majorMinorLbl.Text = "MAJOR";
            this.majorMinorLbl.Click += new System.EventHandler(this.majorMinorLbl_Click);
            this.majorMinorLbl.DoubleClick += new System.EventHandler(this.majorMinorLbl_DoubleClick);
            // 
            // calibrateAutoPitchBtn
            // 
            this.calibrateAutoPitchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(43)))), ((int)(((byte)(56)))));
            this.calibrateAutoPitchBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(145)))), ((int)(((byte)(141)))));
            this.calibrateAutoPitchBtn.FlatAppearance.BorderSize = 0;
            this.calibrateAutoPitchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calibrateAutoPitchBtn.ForeColor = System.Drawing.Color.White;
            this.calibrateAutoPitchBtn.Location = new System.Drawing.Point(192, 142);
            this.calibrateAutoPitchBtn.Name = "calibrateAutoPitchBtn";
            this.calibrateAutoPitchBtn.Size = new System.Drawing.Size(178, 33);
            this.calibrateAutoPitchBtn.TabIndex = 9;
            this.calibrateAutoPitchBtn.Text = "Calibrate AutoPitch";
            this.calibrateAutoPitchBtn.UseVisualStyleBackColor = false;
            this.calibrateAutoPitchBtn.Click += new System.EventHandler(this.AutoPitchCalibrateBtn_Click);
            this.calibrateAutoPitchBtn.MouseEnter += new System.EventHandler(this.calibrateAutoPitchBtn_MouseEnter);
            this.calibrateAutoPitchBtn.MouseLeave += new System.EventHandler(this.calibrateAutoPitchBtn_MouseLeave);
            // 
            // calibratePitchProofBtn
            // 
            this.calibratePitchProofBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(43)))), ((int)(((byte)(56)))));
            this.calibratePitchProofBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(145)))), ((int)(((byte)(141)))));
            this.calibratePitchProofBtn.FlatAppearance.BorderSize = 0;
            this.calibratePitchProofBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calibratePitchProofBtn.ForeColor = System.Drawing.Color.White;
            this.calibratePitchProofBtn.Location = new System.Drawing.Point(12, 142);
            this.calibratePitchProofBtn.Name = "calibratePitchProofBtn";
            this.calibratePitchProofBtn.Size = new System.Drawing.Size(174, 33);
            this.calibratePitchProofBtn.TabIndex = 10;
            this.calibratePitchProofBtn.Text = "Calibrate PitchProof";
            this.calibratePitchProofBtn.UseVisualStyleBackColor = false;
            this.calibratePitchProofBtn.Click += new System.EventHandler(this.calibratePitchProofBtn_Click);
            this.calibratePitchProofBtn.MouseEnter += new System.EventHandler(this.calibratePitchProofBtn_MouseEnter);
            this.calibratePitchProofBtn.MouseLeave += new System.EventHandler(this.calibratePitchProofBtn_MouseLeave);
            // 
            // circlePctr
            // 
            this.circlePctr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.circlePctr.Image = ((System.Drawing.Image)(resources.GetObject("circlePctr.Image")));
            this.circlePctr.Location = new System.Drawing.Point(12, 192);
            this.circlePctr.Name = "circlePctr";
            this.circlePctr.Size = new System.Drawing.Size(526, 526);
            this.circlePctr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.circlePctr.TabIndex = 11;
            this.circlePctr.TabStop = false;
            // 
            // exitBtn
            // 
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.ForeColor = System.Drawing.Color.White;
            this.exitBtn.Location = new System.Drawing.Point(502, 12);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(40, 29);
            this.exitBtn.TabIndex = 12;
            this.exitBtn.Text = "X";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            this.exitBtn.MouseLeave += new System.EventHandler(this.exitBtn_MouseLeave);
            this.exitBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.exitBtn_MouseMove);
            // 
            // minimiseButton
            // 
            this.minimiseButton.FlatAppearance.BorderSize = 0;
            this.minimiseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimiseButton.ForeColor = System.Drawing.Color.White;
            this.minimiseButton.Location = new System.Drawing.Point(456, 12);
            this.minimiseButton.Name = "minimiseButton";
            this.minimiseButton.Size = new System.Drawing.Size(40, 29);
            this.minimiseButton.TabIndex = 13;
            this.minimiseButton.Text = "_";
            this.minimiseButton.UseVisualStyleBackColor = true;
            this.minimiseButton.Click += new System.EventHandler(this.minimiseButton_Click);
            this.minimiseButton.MouseEnter += new System.EventHandler(this.minimiseButton_MouseEnter);
            this.minimiseButton.MouseLeave += new System.EventHandler(this.minimiseButton_MouseLeave);
            // 
            // dragPnl
            // 
            this.dragPnl.Controls.Add(this.logoPctr);
            this.dragPnl.Controls.Add(this.minimiseButton);
            this.dragPnl.Controls.Add(this.exitBtn);
            this.dragPnl.Location = new System.Drawing.Point(0, 0);
            this.dragPnl.Name = "dragPnl";
            this.dragPnl.Size = new System.Drawing.Size(550, 49);
            this.dragPnl.TabIndex = 14;
            this.dragPnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dragPnl_MouseDown);
            this.dragPnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dragPnl_MouseMove);
            this.dragPnl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dragPnl_MouseUp);
            // 
            // logoPctr
            // 
            this.logoPctr.Image = ((System.Drawing.Image)(resources.GetObject("logoPctr.Image")));
            this.logoPctr.Location = new System.Drawing.Point(12, 3);
            this.logoPctr.Name = "logoPctr";
            this.logoPctr.Size = new System.Drawing.Size(183, 40);
            this.logoPctr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPctr.TabIndex = 14;
            this.logoPctr.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(550, 934);
            this.Controls.Add(this.majorMinorLbl);
            this.Controls.Add(this.chordLbl);
            this.Controls.Add(this.calibratePitchProofBtn);
            this.Controls.Add(this.calibrateAutoPitchBtn);
            this.Controls.Add(this.savedCoordinatesLbl);
            this.Controls.Add(this.mouseCoordinatesLbl);
            this.Controls.Add(this.selectDeviceBtn);
            this.Controls.Add(this.outputDevicesList);
            this.Controls.Add(this.circlePctr);
            this.Controls.Add(this.dragPnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "EffectRemote";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.circlePctr)).EndInit();
            this.dragPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPctr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox outputDevicesList;
        private System.Windows.Forms.Button selectDeviceBtn;
        private System.Windows.Forms.Label mouseCoordinatesLbl;
        private System.Windows.Forms.Label savedCoordinatesLbl;
        private System.Windows.Forms.Label chordLbl;
        private System.Windows.Forms.Label majorMinorLbl;
        private System.Windows.Forms.Button calibrateAutoPitchBtn;
        private System.Windows.Forms.Button calibratePitchProofBtn;
        private System.Windows.Forms.PictureBox circlePctr;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button minimiseButton;
        private System.Windows.Forms.Panel dragPnl;
        private System.Windows.Forms.PictureBox logoPctr;
    }
}
