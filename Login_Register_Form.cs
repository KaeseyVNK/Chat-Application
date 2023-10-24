using BusChatApplication;
using DalChatApplication.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Application
{
    public partial class Login_Register_Form : Form
    {
        private LoginService loginservice = new LoginService();
        string filename = "";
        OpenFileDialog dlg = new OpenFileDialog();

        List<Image> images = new List<Image>();
        string[] location = new string[25];

        public Login_Register_Form()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            location[0] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_1.jpg";
            location[1] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_2.jpg";
            location[2] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_4.jpg";
            location[3] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_5.jpg";
            location[4] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_6.jpg";
            location[5] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_7.jpg";
            location[6] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_8.jpg";
            location[7] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_9.jpg";
            location[8] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_10.jpg";
            location[9] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_11.jpg";
            location[10] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_12.jpg";
            location[11] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_13.jpg";
            location[12] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_14.jpg";
            location[13] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_15.jpg";
            location[14] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_16.jpg";
            location[15] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_17.jpg";
            location[16] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_18.jpg";
            location[17] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_19.jpg";
            location[18] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_20.jpg";
            location[19] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_21.jpg";
            location[20] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_22.jpg";
            location[21] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_23.jpg";
            location[22] = @"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_user_24.jpg";
            tounage();
        }

        private void tounage()
        {
            for (int i = 0; i < 23; i++)
            {
                Bitmap bitmap = new Bitmap(location[i]);
                images.Add(bitmap);
            }
            images.Add(Properties.Resources.debut);
        }

        


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txbttkQuenmatkhau.Text == "")
            {
                errorProvider1.SetError(txbttkQuenmatkhau, "Chưa Điền Tên Tài Khoản !");
                return;
            }
            else
            {
                errorProvider1.SetError(txbttkQuenmatkhau, string.Empty);
            }
            if (txbEmailquenmatkhau.Text == "")
            {
                errorProvider1.SetError(txbEmailquenmatkhau, "Chưa Điền Email !");
                return;
            }
            else
            {
                errorProvider1.SetError(txbEmailquenmatkhau, string.Empty);
            }
            ContextChatDB context = new ContextChatDB();
            Login dblogin = context.Logins.FirstOrDefault(p => p.Username == txbttkQuenmatkhau.Text && p.Email == txbEmailquenmatkhau.Text);
            if (dblogin != null)
            {
                MessageBox.Show("Password của bạn là : " + dblogin.Password, " Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                errorProvider1.SetError(txbttkQuenmatkhau, "Kiểm tra");
                errorProvider1.SetError(txbEmailquenmatkhau, "Kiểm tra");
                MessageBox.Show("Không tìm thấy người dùng xin hãy kiểm tra lại", " Thông Báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtDangNhap.Text == "")
            {
                errorProvider1.SetError(txtDangNhap, "Chưa Điền Tên Tài Khoản !");
                return;
            }
            else
            {
                errorProvider1.SetError(txtDangNhap, string.Empty);
            }
            if (txtPassword.Text == "")
            {
                errorProvider1.SetError(txtPassword, "Chưa Điền Password !");
                return;
            }
            else
            {
                errorProvider1.SetError(txtPassword, string.Empty);
            }
            ContextChatDB context = new ContextChatDB();
            Login dbBanned = loginservice.FindBanned(txtDangNhap.Text, txtPassword.Text);
            Login dblogin = context.Logins.FirstOrDefault(p => p.Password.Equals(txtPassword.Text) && p.Username.Equals(txtDangNhap.Text));
            Login dbadmin = loginservice.FindAdmin(txtDangNhap.Text, txtPassword.Text);
            var listuser = context.Logins.ToList();
            if (dbBanned != null)
            {
                string a = dblogin.Username;
                string b = txtDangNhap.Text;
                string c = dblogin.Password;
                string d = txtPassword.Text;
                if (c.Equals(d) && a.Equals(b))
                {
                    MessageBox.Show("Người dùng đã bị giới hạn quyền truy cập xin hãy liên hệ Admin", " Thông Báo", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    MessageBox.Show("Đăng Nhập Không Thành Công !", " Thông Báo", MessageBoxButtons.OK);
                }
            }
            if (dblogin != null)
            {
                string a = dblogin.Username;
                string b = txtDangNhap.Text;
                string c = dblogin.Password;
                string d = txtPassword.Text;
                if (c.Equals(d) && a.Equals(b))
                {
                    MessageBox.Show("Đăng Nhập Thành Công !", " Thông Báo", MessageBoxButtons.OK);
                    Chat_Form form2 = new Chat_Form();
                    this.Visible = false;
                    dblogin.UserStatus = true;
                    context.SaveChanges();
                    form2.usernames = txtDangNhap.Text;
                    form2.Show();
                    if (dbadmin != null)
                    {
                        Form3 form3 = new Form3();
                        form3.usernames = txtDangNhap.Text;
                        form3.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Đăng Nhập Không Thành Công !", " Thông Báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Đăng Nhập Không Thành Công !", " Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txbDangNhap_TextChanged(object sender, EventArgs e)
        {
            if (txtDangNhap.Text.Length > 0 && txtDangNhap.Text.Length <= 15)
            {
                pictureBox1.Image = images[txtDangNhap.Text.Length - 1];
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (txtDangNhap.Text.Length <= 0)
                pictureBox1.Image = Properties.Resources.debut;
            else
                pictureBox1.Image = images[22];
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txbDangNhap_Click(object sender, EventArgs e)
        {
            if (txtDangNhap.Text.Length > 0)
                pictureBox1.Image = images[txtDangNhap.Text.Length - 1];
            else
                pictureBox1.Image = Properties.Resources.debut;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            Bitmap bmpass = new Bitmap(@"E:\Kien_WnFm\DoAn_Chat_Application\Chat-Application\animation\textbox_password.png");
            pictureBox1.Image = bmpass;
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            PanelQuenMatKhau.BringToFront();
        }

        private void linkLabel2_Click(object sender, EventArgs e)
        {
            panelDangKy.BringToFront();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelDangNhap.BringToFront();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelDangNhap.BringToFront();
        }

        private void btnDangkyForm_Click(object sender, EventArgs e)
        {
            try
            {
                var email = new EmailAddressAttribute();
                if (txbDangkyTen.Text == "")
                {
                    errorProvider1.SetError(txbDangkyTen, "Chưa Điền Tên Đăng Ký");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txbDangkyTen, string.Empty);
                }
                if (txbEmail.Text == "")
                {
                    errorProvider1.SetError(txbEmail, "Chưa Nhập Email");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txbEmail, string.Empty);
                }
                if (email.IsValid(txbEmail.Text) == false)
                {
                    errorProvider1.SetError(txbEmail, "Email sai cú pháp xin hãy xem lại");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txbEmail, string.Empty);
                }
                if (txbDangKyPassword.Text == "")
                {
                    errorProvider1.SetError(txbDangKyPassword, "Chưa Điền Password Đăng Ký");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txbDangKyPassword, string.Empty);
                }
                if (txbRepeatPassword.Text == "")
                {
                    errorProvider1.SetError(txbRepeatPassword, "Chưa Nhập Lại Password");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txbRepeatPassword, string.Empty);
                }
                if (txbDangKyPassword.Text != txbRepeatPassword.Text)
                {
                    errorProvider1.SetError(txbRepeatPassword, "Mật Khẩu Không Trùng Khớp");
                    return;
                }
                if(rbNam.Checked == false && rbNu.Checked == false && rbNonBinary.Checked == false)
                {
                    errorProvider1.SetError(rbNonBinary, "Chưa Chọn Giới Tính");
                    return;
                }
                else
                {
                    errorProvider1.SetError(rbNonBinary, string.Empty);
                }
                ContextChatDB context = new ContextChatDB();
                Login l = new Login();
                l.Username = txbDangkyTen.Text;
                l.Password = txbDangKyPassword.Text;
                l.ConfirmPass = txbDangKyPassword.Text;
                l.Email = txbEmail.Text;
                if (filename == "")
                {
                    l.image = "user-icon.png";
                }
                else
                {
                    l.image = filename.ToString();
                }
                l.IDPermission = 1;
                ThemHinhAnh(l.image);
                if (rbNam.Checked == true)
                {
                    l.Gender = "Nam";
                }
                if (rbNu.Checked == true)
                {
                    l.Gender = "Nữ";
                }
                if (rbNonBinary.Checked == true)
                {
                    l.Gender = "Non Binary";
                }
                l.DateofBirth = dtpDateofBirth.Value;
                loginservice.InsertLogin(l);
                MessageBox.Show("Đăng Ký Thành công !", " Thông Báo", MessageBoxButtons.OK);
                Login_Register_Form_Load(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemHinhAnh(string Imagename)
        {
            if (string.IsNullOrEmpty(Imagename))
            {
                pcbDangKy.Image = null;
            }
            else
            {
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string imagepath = Path.Combine(parentDirectory, "Images", Imagename);
                pcbDangKy.Image = Image.FromFile(imagepath);
                pcbDangKy.Refresh();
            }
        }

        private void pcbDangKy_Click(object sender, EventArgs e)
        {
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filename = Path.GetFileName(dlg.FileName);
                var image = Image.FromFile(dlg.FileName);
                pcbDangKy.Image = image;
            }
        }

        private void Login_Register_Form_Load(object sender, EventArgs e)
        {
            panelDangNhap.BringToFront();
        }
    }
}
