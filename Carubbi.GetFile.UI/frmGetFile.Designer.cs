﻿namespace Carubbi.GetFile.UI
{
    partial class FrmGetFile
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
            this.btnDownload = new System.Windows.Forms.Button();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.lblPastaDe = new System.Windows.Forms.Label();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.lblLinks = new System.Windows.Forms.Label();
            this.cboSource = new System.Windows.Forms.ComboBox();
            this.lblTerm = new System.Windows.Forms.Label();
            this.txtTerm = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Location = new System.Drawing.Point(488, 99);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(112, 38);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // txtDestination
            // 
            this.txtDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestination.Location = new System.Drawing.Point(122, 60);
            this.txtDestination.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(478, 26);
            this.txtDestination.TabIndex = 2;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(378, 105);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(102, 26);
            this.txtQuantity.TabIndex = 3;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(24, 21);
            this.lblSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(60, 20);
            this.lblSource.TabIndex = 6;
            this.lblSource.Text = "Source";
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(24, 63);
            this.lblDestination.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(90, 20);
            this.lblDestination.TabIndex = 7;
            this.lblDestination.Text = "Destination";
            // 
            // lblPastaDe
            // 
            this.lblPastaDe.AutoSize = true;
            this.lblPastaDe.Location = new System.Drawing.Point(302, 108);
            this.lblPastaDe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPastaDe.Name = "lblPastaDe";
            this.lblPastaDe.Size = new System.Drawing.Size(68, 20);
            this.lblPastaDe.TabIndex = 8;
            this.lblPastaDe.Text = "Quantity";
            // 
            // lstLog
            // 
            this.lstLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 20;
            this.lstLog.Location = new System.Drawing.Point(2, 153);
            this.lstLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(639, 524);
            this.lstLog.TabIndex = 11;
            // 
            // lblLinks
            // 
            this.lblLinks.Location = new System.Drawing.Point(922, 775);
            this.lblLinks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLinks.Name = "lblLinks";
            this.lblLinks.Size = new System.Drawing.Size(96, 46);
            this.lblLinks.TabIndex = 12;
            // 
            // cboSource
            // 
            this.cboSource.FormattingEnabled = true;
            this.cboSource.Location = new System.Drawing.Point(122, 18);
            this.cboSource.Name = "cboSource";
            this.cboSource.Size = new System.Drawing.Size(478, 28);
            this.cboSource.TabIndex = 13;
            // 
            // lblTerm
            // 
            this.lblTerm.AutoSize = true;
            this.lblTerm.Location = new System.Drawing.Point(24, 108);
            this.lblTerm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTerm.Name = "lblTerm";
            this.lblTerm.Size = new System.Drawing.Size(45, 20);
            this.lblTerm.TabIndex = 15;
            this.lblTerm.Text = "Term";
            // 
            // txtTerm
            // 
            this.txtTerm.Location = new System.Drawing.Point(122, 102);
            this.txtTerm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTerm.Name = "txtTerm";
            this.txtTerm.Size = new System.Drawing.Size(172, 26);
            this.txtTerm.TabIndex = 14;
            // 
            // FrmGetFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 693);
            this.Controls.Add(this.lblTerm);
            this.Controls.Add(this.txtTerm);
            this.Controls.Add(this.cboSource);
            this.Controls.Add(this.lblLinks);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.lblPastaDe);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.btnDownload);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmGetFile";
            this.Text = "GetFile 2.0";
            this.Load += new System.EventHandler(this.FrmGetFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Label lblPastaDe;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Label lblLinks;
        private System.Windows.Forms.ComboBox cboSource;
        private System.Windows.Forms.Label lblTerm;
        private System.Windows.Forms.TextBox txtTerm;
    }
}

