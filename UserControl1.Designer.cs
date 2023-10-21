namespace Chat_Application
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.pcbStatus = new Chat_Application.RoundPictureBox();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.pcbDanhBa = new Chat_Application.RoundPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDanhBa)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // pcbStatus
            // 
            this.pcbStatus.Location = new System.Drawing.Point(64, 62);
            this.pcbStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pcbStatus.Name = "pcbStatus";
            this.pcbStatus.Size = new System.Drawing.Size(28, 22);
            this.pcbStatus.TabIndex = 2;
            this.pcbStatus.TabStop = false;
            // 
            // pcbDanhBa
            // 
            this.pcbDanhBa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pcbDanhBa.Location = new System.Drawing.Point(4, 4);
            this.pcbDanhBa.Margin = new System.Windows.Forms.Padding(4);
            this.pcbDanhBa.Name = "pcbDanhBa";
            this.pcbDanhBa.Size = new System.Drawing.Size(88, 80);
            this.pcbDanhBa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbDanhBa.TabIndex = 0;
            this.pcbDanhBa.TabStop = false;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pcbStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pcbDanhBa);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(285, 90);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDanhBa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private RoundPictureBox pcbStatus;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private RoundPictureBox pcbDanhBa;
    }
}
