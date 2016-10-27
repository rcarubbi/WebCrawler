namespace Carubbi.GetFile.UI
{
    partial class frmGetFile
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
            this.btnRequisitar = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.txtPastaDe = new System.Windows.Forms.TextBox();
            this.txtPastaAte = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lblDestino = new System.Windows.Forms.Label();
            this.lblPastaDe = new System.Windows.Forms.Label();
            this.lblPastaAte = new System.Windows.Forms.Label();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.lblLinks = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRequisitar
            // 
            this.btnRequisitar.Location = new System.Drawing.Point(441, 94);
            this.btnRequisitar.Name = "btnRequisitar";
            this.btnRequisitar.Size = new System.Drawing.Size(75, 23);
            this.btnRequisitar.TabIndex = 0;
            this.btnRequisitar.Text = "Requisitar";
            this.btnRequisitar.UseVisualStyleBackColor = true;
            this.btnRequisitar.Click += new System.EventHandler(this.btnRequisitar_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(123, 35);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(393, 20);
            this.txtUrl.TabIndex = 1;
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(123, 63);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(393, 20);
            this.txtDestino.TabIndex = 2;
            // 
            // txtPastaDe
            // 
            this.txtPastaDe.Location = new System.Drawing.Point(123, 91);
            this.txtPastaDe.Name = "txtPastaDe";
            this.txtPastaDe.Size = new System.Drawing.Size(100, 20);
            this.txtPastaDe.TabIndex = 3;
            // 
            // txtPastaAte
            // 
            this.txtPastaAte.Location = new System.Drawing.Point(262, 91);
            this.txtPastaAte.Name = "txtPastaAte";
            this.txtPastaAte.Size = new System.Drawing.Size(100, 20);
            this.txtPastaAte.TabIndex = 4;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(72, 38);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(20, 13);
            this.lblUrl.TabIndex = 6;
            this.lblUrl.Text = "Url";
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Location = new System.Drawing.Point(72, 66);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(43, 13);
            this.lblDestino.TabIndex = 7;
            this.lblDestino.Text = "Destino";
            // 
            // lblPastaDe
            // 
            this.lblPastaDe.AutoSize = true;
            this.lblPastaDe.Location = new System.Drawing.Point(72, 94);
            this.lblPastaDe.Name = "lblPastaDe";
            this.lblPastaDe.Size = new System.Drawing.Size(49, 13);
            this.lblPastaDe.TabIndex = 8;
            this.lblPastaDe.Text = "Pasta de";
            // 
            // lblPastaAte
            // 
            this.lblPastaAte.AutoSize = true;
            this.lblPastaAte.Location = new System.Drawing.Point(234, 94);
            this.lblPastaAte.Name = "lblPastaAte";
            this.lblPastaAte.Size = new System.Drawing.Size(22, 13);
            this.lblPastaAte.TabIndex = 9;
            this.lblPastaAte.Text = "até";
            // 
            // lstLog
            // 
            this.lstLog.FormattingEnabled = true;
            this.lstLog.Location = new System.Drawing.Point(75, 187);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(441, 303);
            this.lstLog.TabIndex = 11;
            // 
            // lblLinks
            // 
            this.lblLinks.Location = new System.Drawing.Point(615, 504);
            this.lblLinks.Name = "lblLinks";
            this.lblLinks.Size = new System.Drawing.Size(64, 30);
            this.lblLinks.TabIndex = 12;
            this.lblLinks.DoubleClick += new System.EventHandler(this.lblLinks_DoubleClick);
            // 
            // frmGetFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 530);
            this.Controls.Add(this.lblLinks);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.lblPastaAte);
            this.Controls.Add(this.lblPastaDe);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.txtPastaAte);
            this.Controls.Add(this.txtPastaDe);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.btnRequisitar);
            this.Name = "frmGetFile";
            this.Text = "GetFile 2.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRequisitar;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.TextBox txtPastaDe;
        private System.Windows.Forms.TextBox txtPastaAte;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.Label lblPastaDe;
        private System.Windows.Forms.Label lblPastaAte;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Label lblLinks;
    }
}

