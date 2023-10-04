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
            this.userControl11 = new Chat_Application.UserControl1();
            this.pcbProfile = new Chat_Application.RoundPictureBox();
            this.btnMenu = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnXemthongtin = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDoithongtin = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlDoiThongTin = new System.Windows.Forms.Panel();
            this.cbShowpassword = new System.Windows.Forms.CheckBox();
            this.txbOldpassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCapnhat = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txbDoiEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pcbDoiThongTin = new Chat_Application.RoundPictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txbNhaplaipassword = new System.Windows.Forms.TextBox();
            this.txbDoipassword = new System.Windows.Forms.TextBox();
            this.pnlThongTin = new System.Windows.Forms.Panel();
            this.txbpnlEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pcbpnlThongTinTaiKhoan = new Chat_Application.RoundPictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbpnlTentaikhoan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbProfile)).BeginInit();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlDoiThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDoiThongTin)).BeginInit();
            this.pnlThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbpnlThongTinTaiKhoan)).BeginInit();
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
            this.pnlMenu.Controls.Add(this.btnXemthongtin);
            this.pnlMenu.Controls.Add(this.btnThoat);
            this.pnlMenu.Controls.Add(this.btnDoithongtin);
            this.pnlMenu.Location = new System.Drawing.Point(619, 22);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(181, 148);
            this.pnlMenu.TabIndex = 6;
            this.pnlMenu.Visible = false;
            // 
            // btnXemthongtin
            // 
            this.btnXemthongtin.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnXemthongtin.Location = new System.Drawing.Point(0, 3);
            this.btnXemthongtin.Name = "btnXemthongtin";
            this.btnXemthongtin.Size = new System.Drawing.Size(181, 39);
            this.btnXemthongtin.TabIndex = 29;
            this.btnXemthongtin.Text = "Xem Thông Tin";
            this.btnXemthongtin.UseVisualStyleBackColor = false;
            this.btnXemthongtin.Click += new System.EventHandler(this.btnXemthongtin_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnThoat.Location = new System.Drawing.Point(0, 79);
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
            this.btnDoithongtin.Location = new System.Drawing.Point(0, 40);
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
            this.pnlDoiThongTin.Controls.Add(this.cbShowpassword);
            this.pnlDoiThongTin.Controls.Add(this.txbOldpassword);
            this.pnlDoiThongTin.Controls.Add(this.label6);
            this.pnlDoiThongTin.Controls.Add(this.btnCapnhat);
            this.pnlDoiThongTin.Controls.Add(this.label4);
            this.pnlDoiThongTin.Controls.Add(this.txbDoiEmail);
            this.pnlDoiThongTin.Controls.Add(this.label2);
            this.pnlDoiThongTin.Controls.Add(this.pcbDoiThongTin);
            this.pnlDoiThongTin.Controls.Add(this.label9);
            this.pnlDoiThongTin.Controls.Add(this.label8);
            this.pnlDoiThongTin.Controls.Add(this.txbNhaplaipassword);
            this.pnlDoiThongTin.Controls.Add(this.txbDoipassword);
            this.pnlDoiThongTin.Location = new System.Drawing.Point(258, 21);
            this.pnlDoiThongTin.Name = "pnlDoiThongTin";
            this.pnlDoiThongTin.Size = new System.Drawing.Size(547, 425);
            this.pnlDoiThongTin.TabIndex = 26;
            this.pnlDoiThongTin.Visible = false;
            // 
            // cbShowpassword
            // 
            this.cbShowpassword.AutoSize = true;
            this.cbShowpassword.Location = new System.Drawing.Point(300, 332);
            this.cbShowpassword.Name = "cbShowpassword";
            this.cbShowpassword.Size = new System.Drawing.Size(102, 17);
            this.cbShowpassword.TabIndex = 31;
            this.cbShowpassword.Text = "Show Password";
            this.cbShowpassword.UseVisualStyleBackColor = true;
            this.cbShowpassword.CheckedChanged += new System.EventHandler(this.cbShowpassword_CheckedChanged);
            // 
            // txbOldpassword
            // 
            this.txbOldpassword.Location = new System.Drawing.Point(223, 221);
            this.txbOldpassword.Name = "txbOldpassword";
            this.txbOldpassword.Size = new System.Drawing.Size(175, 20);
            this.txbOldpassword.TabIndex = 30;
            this.txbOldpassword.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(88, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Old Password";
            // 
            // btnCapnhat
            // 
            this.btnCapnhat.Location = new System.Drawing.Point(204, 355);
            this.btnCapnhat.Name = "btnCapnhat";
            this.btnCapnhat.Size = new System.Drawing.Size(153, 48);
            this.btnCapnhat.TabIndex = 28;
            this.btnCapnhat.Text = "Cập Nhật";
            this.btnCapnhat.UseVisualStyleBackColor = true;
            this.btnCapnhat.Click += new System.EventHandler(this.btnCapnhat_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(174, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 25);
            this.label4.TabIndex = 27;
            this.label4.Text = "Thay Đổi Thông Tin";
            // 
            // txbDoiEmail
            // 
            this.txbDoiEmail.Location = new System.Drawing.Point(223, 173);
            this.txbDoiEmail.Name = "txbDoiEmail";
            this.txbDoiEmail.Size = new System.Drawing.Size(175, 20);
            this.txbDoiEmail.TabIndex = 26;
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
            // pcbDoiThongTin
            // 
            this.pcbDoiThongTin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pcbDoiThongTin.Location = new System.Drawing.Point(199, 73);
            this.pcbDoiThongTin.Name = "pcbDoiThongTin";
            this.pcbDoiThongTin.Size = new System.Drawing.Size(156, 93);
            this.pcbDoiThongTin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbDoiThongTin.TabIndex = 24;
            this.pcbDoiThongTin.TabStop = false;
            this.pcbDoiThongTin.Click += new System.EventHandler(this.pcbDoiThongTin_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(88, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Repeat Password";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(88, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Password";
            // 
            // txbNhaplaipassword
            // 
            this.txbNhaplaipassword.Location = new System.Drawing.Point(227, 301);
            this.txbNhaplaipassword.Name = "txbNhaplaipassword";
            this.txbNhaplaipassword.Size = new System.Drawing.Size(175, 20);
            this.txbNhaplaipassword.TabIndex = 20;
            this.txbNhaplaipassword.UseSystemPasswordChar = true;
            // 
            // txbDoipassword
            // 
            this.txbDoipassword.Location = new System.Drawing.Point(227, 264);
            this.txbDoipassword.Name = "txbDoipassword";
            this.txbDoipassword.Size = new System.Drawing.Size(175, 20);
            this.txbDoipassword.TabIndex = 19;
            this.txbDoipassword.UseSystemPasswordChar = true;
            // 
            // pnlThongTin
            // 
            this.pnlThongTin.Controls.Add(this.txbpnlEmail);
            this.pnlThongTin.Controls.Add(this.label5);
            this.pnlThongTin.Controls.Add(this.pcbpnlThongTinTaiKhoan);
            this.pnlThongTin.Controls.Add(this.label7);
            this.pnlThongTin.Controls.Add(this.txbpnlTentaikhoan);
            this.pnlThongTin.Controls.Add(this.label3);
            this.pnlThongTin.Location = new System.Drawing.Point(256, 19);
            this.pnlThongTin.Name = "pnlThongTin";
            this.pnlThongTin.Size = new System.Drawing.Size(544, 419);
            this.pnlThongTin.TabIndex = 27;
            this.pnlThongTin.Visible = false;
            // 
            // txbpnlEmail
            // 
            this.txbpnlEmail.Location = new System.Drawing.Point(254, 224);
            this.txbpnlEmail.Name = "txbpnlEmail";
            this.txbpnlEmail.Size = new System.Drawing.Size(175, 20);
            this.txbpnlEmail.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(115, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Email";
            // 
            // pcbpnlThongTinTaiKhoan
            // 
            this.pcbpnlThongTinTaiKhoan.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pcbpnlThongTinTaiKhoan.Location = new System.Drawing.Point(206, 82);
            this.pcbpnlThongTinTaiKhoan.Name = "pcbpnlThongTinTaiKhoan";
            this.pcbpnlThongTinTaiKhoan.Size = new System.Drawing.Size(156, 93);
            this.pcbpnlThongTinTaiKhoan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbpnlThongTinTaiKhoan.TabIndex = 21;
            this.pcbpnlThongTinTaiKhoan.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(115, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "Tên Tài Khoản";
            // 
            // txbpnlTentaikhoan
            // 
            this.txbpnlTentaikhoan.Location = new System.Drawing.Point(254, 178);
            this.txbpnlTentaikhoan.Name = "txbpnlTentaikhoan";
            this.txbpnlTentaikhoan.Size = new System.Drawing.Size(175, 20);
            this.txbpnlTentaikhoan.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(201, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 25);
            this.label3.TabIndex = 18;
            this.label3.Text = "Thông Tin Tài Khoản";
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
            this.Controls.Add(this.pnlThongTin);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbProfile)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlDoiThongTin.ResumeLayout(false);
            this.pnlDoiThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDoiThongTin)).EndInit();
            this.pnlThongTin.ResumeLayout(false);
            this.pnlThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbpnlThongTinTaiKhoan)).EndInit();
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
        private System.Windows.Forms.Panel pnlThongTin;
        private System.Windows.Forms.Button btnXemthongtin;
        private System.Windows.Forms.TextBox txbpnlEmail;
        private System.Windows.Forms.Label label5;
        private RoundPictureBox pcbpnlThongTinTaiKhoan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbpnlTentaikhoan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbOldpassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbShowpassword;
    }
}