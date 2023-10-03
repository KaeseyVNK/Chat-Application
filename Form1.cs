using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            panel1.Visible = false;
            button1.BackColor = Color.Gray;
            button2.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            button2.BackColor = Color.Gray;
            button1.BackColor = Color.White;
        }

        private void btnDangkyForm_Click(object sender, EventArgs e)
        {
            try
            {
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
                l.image = filename.ToString();
                ThemHinhAnh(l.image);
                context.Login.Add(l);
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
                filename = dlg.FileName;
                var image = Image.FromFile(dlg.FileName);
                pcbDangKy.Image = image;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
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
            Login dblogin = context.Login.FirstOrDefault(p=>p.Username == txbDangnhap.Text && p.Password == txbPassword.Text);
            if (dblogin != null)
            {
                MessageBox.Show("Đăng Nhập Thành Công !", " Thông Báo", MessageBoxButtons.OK);
                Form2 form2 = new Form2();
                this.Visible = false;
                form2.username = txbDangnhap.Text;
                form2.Show();
            }
            else
            {
                MessageBox.Show("Đăng Nhập Không Thành Công !", " Thông Báo", MessageBoxButtons.OK);
            }
        }
    }
}
