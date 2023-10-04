namespace Chat_Application
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMenu = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDoithongtin = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlDoiThongTin = new System.Windows.Forms.Panel();
            this.txbDoipassword = new System.Windows.Forms.TextBox();
            this.txbNhaplaipassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbDoiEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCapnhat = new System.Windows.Forms.Button();
            this.userControl11 = new Chat_Application.UserControl1();
            this.pcbProfile = new Chat_Application.RoundPictureBox();
            this.pcbDoiThongTin = new Chat_Application.RoundPictureBox();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlDoiThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDoiThongTin)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.pcbProfile);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 453);
            this.panel1.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.userControl11);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 94);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(244, 356);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(774, 0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(26, 25);
            this.btnMenu.TabIndex = 5;
            this.btnMenu.Text = "...";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnThoat);
            this.pnlMenu.Controls.Add(this.btnDoithongtin);
            this.pnlMenu.Location = new System.Drawing.Point(619, 22);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(181, 148);
            this.pnlMenu.TabIndex = 6;
            this.pnlMenu.Visible = false;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnThoat.Location = new System.Drawing.Point(0, 37);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(181, 39);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click_1);
            // 
            // btnDoithongtin
            // 
            this.btnDoithongtin.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDoithongtin.Location = new System.Drawing.Point(0, 0);
            this.btnDoithongtin.Name = "btnDoithongtin";
            this.btnDoithongtin.Size = new System.Drawing.Size(181, 39);
            this.btnDoithongtin.TabIndex = 8;
            this.btnDoithongtin.Text = "Đổi Thông Tin";
            this.btnDoithongtin.UseVisualStyleBackColor = false;
            this.btnDoithongtin.Click += new System.EventHandler(this.btnDoithongtin_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pnlDoiThongTin
            // 
            this.pnlDoiThongTin.Controls.Add(this.btnCapnhat);
            this.pnlDoiThongTin.Controls.Add(this.label4);
            this.pnlDoiThongTin.Controls.Add(this.txbDoiEmail);
            this.pnlDoiThongTin.Controls.Add(this.label2);
            this.pnlDoiThongTin.Controls.Add(this.pcbDoiThongTin);
            this.pnlDoiThongTin.Controls.Add(this.label9);
            this.pnlDoiThongTin.Controls.Add(this.label8);
            this.pnlDoiThongTin.Controls.Add(this.txbNhaplaipassword);
            this.pnlDoiThongTin.Controls.Add(this.txbDoipassword);
            this.pnlDoiThongTin.Location = new System.Drawing.Point(253, 22);
            this.pnlDoiThongTin.Name = "pnlDoiThongTin";
            this.pnlDoiThongTin.Size = new System.Drawing.Size(547, 425);
            this.pnlDoiThongTin.TabIndex = 26;
            this.pnlDoiThongTin.Visible = false;
            // 
            // txbDoipassword
            // 
            this.txbDoipassword.Location = new System.Drawing.Point(223, 218);
            this.txbDoipassword.Name = "txbDoipassword";
            this.txbDoipassword.Size = new System.Drawing.Size(175, 20);
            this.txbDoipassword.TabIndex = 19;
            this.txbDoipassword.UseSystemPasswordChar = true;
            // 
            // txbNhaplaipassword
            // 
            this.txbNhaplaipassword.Location = new System.Drawing.Point(223, 255);
            this.txbNhaplaipassword.Name = "txbNhaplaipassword";
            this.txbNhaplaipassword.Size = new System.Drawing.Size(175, 20);
            this.txbNhaplaipassword.TabIndex = 20;
            this.txbNhaplaipassword.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(84, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(84, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Repeat Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Email";
            // 
            // txbDoiEmail
            // 
            this.txbDoiEmail.Location = new System.Drawing.Point(223, 173);
            this.txbDoiEmail.Name = "txbDoiEmail";
            this.txbDoiEmail.Size = new System.Drawing.Size(175, 20);
            this.txbDoiEmail.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(171, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 25);
            this.label4.TabIndex = 27;
            this.label4.Text = "Thay Đổi Thông Tin";
            // 
            // btnCapnhat
            // 
            this.btnCapnhat.Location = new System.Drawing.Point(223, 295);
            this.btnCapnhat.Name = "btnCapnhat";
            this.btnCapnhat.Size = new System.Drawing.Size(153, 48);
            this.btnCapnhat.TabIndex = 28;
            this.btnCapnhat.Text = "Cập Nhật";
            this.btnCapnhat.UseVisualStyleBackColor = true;
            this.btnCapnhat.Click += new System.EventHandler(this.btnCapnhat_Click);
            // 
            // userControl11
            // 
            this.userControl11.Icon = null;
            this.userControl11.Location = new System.Drawing.Point(3, 3);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(241, 73);
            this.userControl11.TabIndex = 0;
            this.userControl11.Title = null;
            // 
            // pcbProfile
            // 
            this.pcbProfile.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pcbProfile.Location = new System.Drawing.Point(47, 3);
            this.pcbProfile.Name = "pcbProfile";
            this.pcbProfile.Size = new System.Drawing.Size(93, 58);
            this.pcbProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbProfile.TabIndex = 1;
            this.pcbProfile.TabStop = false;
            // 
            // pcbDoiThongTin
            // 
            this.pcbDoiThongTin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pcbDoiThongTin.Location = new System.Drawing.Point(176, 55);
            this.pcbDoiThongTin.Name = "pcbDoiThongTin";
            this.pcbDoiThongTin.Size = new System.Drawing.Size(156, 93);
            this.pcbDoiThongTin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbDoiThongTin.TabIndex = 24;
            this.pcbDoiThongTin.TabStop = false;
            this.pcbDoiThongTin.Click += new System.EventHandler(this.pcbDoiThongTin_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlDoiThongTin);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlDoiThongTin.ResumeLayout(false);
            this.pnlDoiThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDoiThongTin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private RoundPictureBox pcbProfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private UserControl1 userControl11;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnDoithongtin;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnlDoiThongTin;
        private System.Windows.Forms.Button btnCapnhat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbDoiEmail;
        private System.Windows.Forms.Label label2;
        private RoundPictureBox pcbDoiThongTin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbNhaplaipassword;
        private System.Windows.Forms.TextBox txbDoipassword;
    }
}