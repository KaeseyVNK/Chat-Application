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
            this.pcbDanhBa = new Chat_Application.RoundPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDanhBa)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbDanhBa
            // 
            this.pcbDanhBa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pcbDanhBa.Location = new System.Drawing.Point(18, 18);
            this.pcbDanhBa.Name = "pcbDanhBa";
            this.pcbDanhBa.Size = new System.Drawing.Size(60, 36);
            this.pcbDanhBa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbDanhBa.TabIndex = 0;
            this.pcbDanhBa.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pcbDanhBa);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(339, 73);
            ((System.ComponentModel.ISupportInitialize)(this.pcbDanhBa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundPictureBox pcbDanhBa;
        private System.Windows.Forms.Label label1;
    }
}
