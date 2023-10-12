namespace Chat_Application
{
    partial class User2
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
            this.label1 = new System.Windows.Forms.Label();
            this.pcbDanhBa = new Chat_Application.RoundPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDanhBa)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pcbDanhBa
            // 
            this.pcbDanhBa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pcbDanhBa.Location = new System.Drawing.Point(3, 22);
            this.pcbDanhBa.Name = "pcbDanhBa";
            this.pcbDanhBa.Size = new System.Drawing.Size(20, 20);
            this.pcbDanhBa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbDanhBa.TabIndex = 1;
            this.pcbDanhBa.TabStop = false;
            // 
            // User2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pcbDanhBa);
            this.Name = "User2";
            this.Size = new System.Drawing.Size(325, 48);
            this.Load += new System.EventHandler(this.User2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbDanhBa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundPictureBox pcbDanhBa;
        private System.Windows.Forms.Label label1;
    }
}
