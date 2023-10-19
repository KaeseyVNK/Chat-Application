namespace Chat_Application
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbDangnhap = new System.Windows.Forms.TextBox();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_LogIn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDangkyForm = new System.Windows.Forms.Button();
            this.txbRepeatPassword = new System.Windows.Forms.TextBox();
            this.txbDangKyPassword = new System.Windows.Forms.TextBox();
            this.txbDangkyTen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbShowpassword = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbEmailquenmatkhau = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnGetpassword = new System.Windows.Forms.Button();
            this.txbttkQuenmatkhau = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.guna2WinProgressIndicator1 = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            this.pcbDangKy = new Chat_Application.RoundPictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDangKy)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "Đăng Nhập";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(188, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 53);
            this.button2.TabIndex = 1;
            this.button2.Text = "Đăng Ký";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(130, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đăng Nhập";
            // 
            // txbDangnhap
            // 
            this.txbDangnhap.Location = new System.Drawing.Point(154, 143);
            this.txbDangnhap.Name = "txbDangnhap";
            this.txbDangnhap.Size = new System.Drawing.Size(197, 20);
            this.txbDangnhap.TabIndex = 3;
            // 
            // txbPassword
            // 
            this.txbPassword.Location = new System.Drawing.Point(154, 184);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(197, 20);
            this.txbPassword.TabIndex = 4;
            this.txbPassword.UseSystemPasswordChar = true;
            this.txbPassword.TextChanged += new System.EventHandler(this.txbPassword_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên Tài Khoản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mật Khẩu";
            // 
            // btn_LogIn
            // 
            this.btn_LogIn.Location = new System.Drawing.Point(54, 259);
            this.btn_LogIn.Name = "btn_LogIn";
            this.btn_LogIn.Size = new System.Drawing.Size(229, 55);
            this.btn_LogIn.TabIndex = 7;
            this.btn_LogIn.Text = "Đăng Nhập";
            this.btn_LogIn.UseVisualStyleBackColor = true;
            this.btn_LogIn.Click += new System.EventHandler(this.btn_LogIn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbEmail);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pcbDangKy);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnDangkyForm);
            this.panel1.Controls.Add(this.txbRepeatPassword);
            this.panel1.Controls.Add(this.txbDangKyPassword);
            this.panel1.Controls.Add(this.txbDangkyTen);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(10, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 349);
            this.panel1.TabIndex = 8;
            // 
            // txbEmail
            // 
            this.txbEmail.Location = new System.Drawing.Point(145, 170);
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(175, 20);
            this.txbEmail.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Email";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "Repeat Password";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tên Tài Khoản";
            // 
            // btnDangkyForm
            // 
            this.btnDangkyForm.Location = new System.Drawing.Point(55, 291);
            this.btnDangkyForm.Name = "btnDangkyForm";
            this.btnDangkyForm.Size = new System.Drawing.Size(229, 55);
            this.btnDangkyForm.TabIndex = 9;
            this.btnDangkyForm.Text = "Đăng Ký Tài Khoản";
            this.btnDangkyForm.UseVisualStyleBackColor = true;
            this.btnDangkyForm.Click += new System.EventHandler(this.btnDangkyForm_Click);
            // 
            // txbRepeatPassword
            // 
            this.txbRepeatPassword.Location = new System.Drawing.Point(145, 252);
            this.txbRepeatPassword.Name = "txbRepeatPassword";
            this.txbRepeatPassword.Size = new System.Drawing.Size(175, 20);
            this.txbRepeatPassword.TabIndex = 8;
            this.txbRepeatPassword.UseSystemPasswordChar = true;
            // 
            // txbDangKyPassword
            // 
            this.txbDangKyPassword.Location = new System.Drawing.Point(145, 215);
            this.txbDangKyPassword.Name = "txbDangKyPassword";
            this.txbDangKyPassword.Size = new System.Drawing.Size(175, 20);
            this.txbDangKyPassword.TabIndex = 7;
            this.txbDangKyPassword.UseSystemPasswordChar = true;
            // 
            // txbDangkyTen
            // 
            this.txbDangkyTen.Location = new System.Drawing.Point(145, 124);
            this.txbDangkyTen.Name = "txbDangkyTen";
            this.txbDangkyTen.Size = new System.Drawing.Size(175, 20);
            this.txbDangkyTen.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(125, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Đăng Ký";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cbShowpassword
            // 
            this.cbShowpassword.AutoSize = true;
            this.cbShowpassword.Location = new System.Drawing.Point(154, 223);
            this.cbShowpassword.Name = "cbShowpassword";
            this.cbShowpassword.Size = new System.Drawing.Size(102, 17);
            this.cbShowpassword.TabIndex = 9;
            this.cbShowpassword.Text = "Show Password";
            this.cbShowpassword.UseVisualStyleBackColor = true;
            this.cbShowpassword.CheckedChanged += new System.EventHandler(this.cbShowpassword_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(130, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Quên Mật Khẩu ?";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            this.label6.MouseLeave += new System.EventHandler(this.label6_MouseLeave);
            this.label6.MouseHover += new System.EventHandler(this.label6_MouseHover);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txbEmailquenmatkhau);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.btnGetpassword);
            this.panel2.Controls.Add(this.txbttkQuenmatkhau);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Location = new System.Drawing.Point(12, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(353, 349);
            this.panel2.TabIndex = 11;
            this.panel2.Visible = false;
            // 
            // txbEmailquenmatkhau
            // 
            this.txbEmailquenmatkhau.Location = new System.Drawing.Point(145, 101);
            this.txbEmailquenmatkhau.Name = "txbEmailquenmatkhau";
            this.txbEmailquenmatkhau.Size = new System.Drawing.Size(175, 20);
            this.txbEmailquenmatkhau.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 20);
            this.label10.TabIndex = 16;
            this.label10.Text = "Email";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 20);
            this.label13.TabIndex = 12;
            this.label13.Text = "Tên Tài Khoản";
            // 
            // btnGetpassword
            // 
            this.btnGetpassword.Location = new System.Drawing.Point(55, 143);
            this.btnGetpassword.Name = "btnGetpassword";
            this.btnGetpassword.Size = new System.Drawing.Size(229, 55);
            this.btnGetpassword.TabIndex = 9;
            this.btnGetpassword.Text = "Lấy Password";
            this.btnGetpassword.UseVisualStyleBackColor = true;
            this.btnGetpassword.Click += new System.EventHandler(this.btnGetpassword_Click);
            // 
            // txbttkQuenmatkhau
            // 
            this.txbttkQuenmatkhau.Location = new System.Drawing.Point(145, 55);
            this.txbttkQuenmatkhau.Name = "txbttkQuenmatkhau";
            this.txbttkQuenmatkhau.Size = new System.Drawing.Size(175, 20);
            this.txbttkQuenmatkhau.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Cursor = System.Windows.Forms.Cursors.Default;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(102, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(151, 25);
            this.label14.TabIndex = 3;
            this.label14.Text = "Quên Mật Khẩu";
            // 
            // guna2WinProgressIndicator1
            // 
            this.guna2WinProgressIndicator1.CircleSize = 1F;
            this.guna2WinProgressIndicator1.Location = new System.Drawing.Point(133, 348);
            this.guna2WinProgressIndicator1.Name = "guna2WinProgressIndicator1";
            this.guna2WinProgressIndicator1.Size = new System.Drawing.Size(74, 74);
            this.guna2WinProgressIndicator1.TabIndex = 18;
            this.guna2WinProgressIndicator1.Visible = false;
            // 
            // pcbDangKy
            // 
            this.pcbDangKy.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pcbDangKy.Location = new System.Drawing.Point(97, 28);
            this.pcbDangKy.Name = "pcbDangKy";
            this.pcbDangKy.Size = new System.Drawing.Size(156, 93);
            this.pcbDangKy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbDangKy.TabIndex = 15;
            this.pcbDangKy.TabStop = false;
            this.pcbDangKy.Click += new System.EventHandler(this.pcbDangKy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 432);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbShowpassword);
            this.Controls.Add(this.btn_LogIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2WinProgressIndicator1);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.txbDangnhap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDangKy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbDangnhap;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_LogIn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDangkyForm;
        private System.Windows.Forms.TextBox txbRepeatPassword;
        private System.Windows.Forms.TextBox txbDangKyPassword;
        private System.Windows.Forms.TextBox txbDangkyTen;
        private System.Windows.Forms.Label label4;
        private RoundPictureBox pcbDangKy;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbShowpassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbEmailquenmatkhau;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnGetpassword;
        private System.Windows.Forms.TextBox txbttkQuenmatkhau;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator guna2WinProgressIndicator1;
    }
}

