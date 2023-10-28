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
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.pcbDanhBa = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2AnimateWindow2 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.pcbStatus = new Chat_Application.RoundPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDanhBa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pcbDanhBa
            // 
            this.pcbDanhBa.BackColor = System.Drawing.Color.Transparent;
            this.pcbDanhBa.Enabled = false;
            this.pcbDanhBa.FillColor = System.Drawing.Color.DarkGray;
            this.pcbDanhBa.ImageRotate = 0F;
            this.pcbDanhBa.Location = new System.Drawing.Point(4, 4);
            this.pcbDanhBa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pcbDanhBa.Name = "pcbDanhBa";
            this.pcbDanhBa.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pcbDanhBa.Size = new System.Drawing.Size(85, 79);
            this.pcbDanhBa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbDanhBa.TabIndex = 5;
            this.pcbDanhBa.TabStop = false;
            // 
            // pcbStatus
            // 
            this.pcbStatus.Enabled = false;
            this.pcbStatus.Location = new System.Drawing.Point(72, 62);
            this.pcbStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pcbStatus.Name = "pcbStatus";
            this.pcbStatus.Size = new System.Drawing.Size(17, 21);
            this.pcbStatus.TabIndex = 4;
            this.pcbStatus.TabStop = false;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pcbStatus);
            this.Controls.Add(this.pcbDanhBa);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(285, 90);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbDanhBa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pcbDanhBa;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow2;
        private RoundPictureBox pcbStatus;
    }
}
