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
using System.Windows.Forms.VisualStyles;
using Chat_Application.Model;
namespace Chat_Application
{
    public partial class Form1 : Form
    {
        string filename = "";
        OpenFileDialog dlg = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            closeform();
            button1.BackColor = Color.Gray;
            button2.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            closeform();
            panel1.Visible = true;
            button2.BackColor = Color.Gray;
            button1.BackColor = Color.White;
        }
        private void closeform()
        {
            panel1.Visible = false;
            panel2.Visible = false;
        }
        private void btnDangkyForm_Click(object sender, EventArgs e)
        {
            try
            {
                var email = new EmailAddressAttribute();
                if (pcbDangKy.Image == null)
                {
                    MessageBox.Show("Xin hãy thêm ảnh", " Thông Báo", MessageBoxButtons.OK);
                }
                if(txbDangkyTen.Text == "")
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
                if(email.IsValid(txbEmail.Text) == false)
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
                if(txbDangKyPassword.Text != txbRepeatPassword.Text)
                {
                    errorProvider1.SetError(txbRepeatPassword, "Mật Khẩu Không Trùng Khớp");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txbRepeatPassword, string.Empty);
                }
                ContextChatDB context = new ContextChatDB();
                Login l = new Login();
                l.Username = txbDangkyTen.Text;
                l.Password = txbDangKyPassword.Text;
                l.ConfirmPass = txbDangKyPassword.Text;
                l.Email = txbEmail.Text;
                l.image = filename.ToString();
                l.IDPermission = 1;
                ThemHinhAnh(l.image);
                context.Logins.Add(l);
                context.SaveChanges();
                MessageBox.Show("Đăng Ký Thành công !", " Thông Báo", MessageBoxButtons.OK);
                Form1_Load(sender, e);
                
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

        private void Form1_Load(object sender, EventArgs e)
        {
            closeform();
        }

        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            if (txbDangnhap.Text == "")
            {
                errorProvider1.SetError(txbDangnhap, "Chưa Điền Tên Tài Khoản !");
                return;
            }
            else
            {
                errorProvider1.SetError(txbDangnhap, string.Empty);
            }
            if (txbPassword.Text == "")
            {
                errorProvider1.SetError(txbPassword, "Chưa Điền Password !");
                return;
            }
            else
            {
                errorProvider1.SetError(txbPassword, string.Empty);
            }
            ContextChatDB context = new ContextChatDB();
            Login dbBanned = context.Logins.FirstOrDefault(p => p.Username == txbDangnhap.Text && p.Password == txbPassword.Text && p.IDPermission == 3);
            Login dblogin = context.Logins.FirstOrDefault(p=>p.Username == txbDangnhap.Text && p.Password == txbPassword.Text);
            Login dbadmin = context.Logins.FirstOrDefault(p => p.Username == txbDangnhap.Text && p.Password == txbPassword.Text && p.IDPermission == 2);
            if(dbBanned != null)
            {
                MessageBox.Show("Người dùng đã bị giới hạn quyền truy cập xin hãy liên hệ Admin", " Thông Báo", MessageBoxButtons.OK);
                return;
            }
            if(dblogin != null)
            {
                MessageBox.Show("Đăng Nhập Thành Công !", " Thông Báo", MessageBoxButtons.OK);
                Form2 form2 = new Form2();
                this.Visible = false;
                form2.usernames = txbDangnhap.Text;
                form2.Show();
                if(dbadmin != null)
                {
                    Form3 form3 = new Form3();
                    form3.usernames = txbDangnhap.Text;
                    form3.Show();
                }
            }
            else
            {
                MessageBox.Show("Đăng Nhập Không Thành Công !", " Thông Báo", MessageBoxButtons.OK);
            }
        }

   

        private void cbShowpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowpassword.Checked == true)
            {
                txbPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txbPassword.UseSystemPasswordChar = true;
            }
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Blue;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
        }
        private void label6_Click(object sender, EventArgs e)
        {
            closeform();
            panel2.Visible = true;

        }
        private void btnGetpassword_Click(object sender, EventArgs e)
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
            if(dblogin != null)
            {
                MessageBox.Show("Password của bạn là : "+dblogin.Password, " Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                errorProvider1.SetError(txbttkQuenmatkhau, "Kiểm tra");
                errorProvider1.SetError(txbEmailquenmatkhau, "Kiểm tra");
                MessageBox.Show("Không tìm thấy người dùng xin hãy kiểm tra lại" , " Thông Báo", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
