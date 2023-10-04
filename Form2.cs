using Chat_Application.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Application
{
    public partial class Form2 : Form
    {
        string filename = "";
        Form1 form1 = new Form1();
        public string usernames { set; get; }
        public Form2()
        {
            form1 = new Form1();
            InitializeComponent();
        }

        private void ThemHinhAnh(string Imagename)
        {
            if (string.IsNullOrEmpty(Imagename))
            {
                pcbProfile.Image = null;
            }
            else
            {
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string imagepath = Path.Combine(parentDirectory, "Images", Imagename);
                pcbDoiThongTin.Image = Image.FromFile(imagepath);
                pcbProfile.Image = Image.FromFile(imagepath);
                pcbProfile.Refresh();
                pcbDoiThongTin.Refresh();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = usernames;
            ContextChatDB context = new ContextChatDB();
            Login dblogin = context.Login.FirstOrDefault(p => p.Username == usernames);
            if (dblogin != null)
            {
                label1.Text = dblogin.Username;
                ThemHinhAnh(dblogin.image);
            }
            DanhSachNguoiDung();
        }
        private void DanhSachNguoiDung()
        {
            flowLayoutPanel1.Controls.Clear();
            ContextChatDB context = new ContextChatDB();
            var listusername = context.Login.ToList();
            var countusername = context.Login.Count();
            UserControl1[] userControls = new UserControl1[countusername];
            for(int i=0;i<1;i++)
            {
                foreach(var username in listusername)
                {
                    userControls[i] = new UserControl1();
                    userControls[i].Title = username.Username;
                    userControls[i].Icon = username.image;
                    if (userControls[i].Title == label1.Text)
                    {
                        flowLayoutPanel1.Controls.Remove(userControls[i]);
                    }
                    else
                    {
                        flowLayoutPanel1.Controls.Add(userControls[i]);
                    }
                }
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {        
            {
                this.Visible = false;
                form1.Visible = true;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if(pnlMenu.Visible == false)
            {
                pnlMenu.Visible = true;
                btnMenu.BackColor = Color.Gray;
            }
            else
            {
                pnlMenu.Visible = false;
                btnMenu.BackColor = Color.White;
            }
        }

       

        private void btnDoithongtin_Click(object sender, EventArgs e)
        {
            if (pnlDoiThongTin.Visible == false)
            {
                ContextChatDB context = new ContextChatDB();
                pnlDoiThongTin.Visible = true;
                pnlThongTin.Visible = false;
                pnlMenu.Visible = false;
                Login dbuser = context.Login.FirstOrDefault(p => p.Username == usernames);
                if (dbuser != null)
                {
                    txbDoiEmail.Text = dbuser.Email.ToString();
                    ThemHinhAnh(dbuser.image);
                    filename = dbuser.image;
                }
            }
            else
            {
                pnlDoiThongTin.Visible = false;
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            ContextChatDB context = new ContextChatDB();
            Login dbupdate = context.Login.FirstOrDefault(p => p.Username == usernames);
            Login dbuser = context.Login.FirstOrDefault(p => p.Username == usernames);
            var email = new EmailAddressAttribute();
            if (txbDoiEmail.Text == "")
            {
                errorProvider1.SetError(txbDoiEmail, "Chưa Điền Email !");
                return;
            }
            else
            {
                errorProvider1.SetError(txbDoiEmail, string.Empty);
            }
            if (email.IsValid(txbDoiEmail.Text) == false)
            {
                errorProvider1.SetError(txbDoiEmail, "Email sai cú pháp xin hãy xem lại");
                return;
            }
            else
            {
                errorProvider1.SetError(txbDoiEmail, string.Empty);
            }
            if (txbOldpassword.Text == "")
            {
                errorProvider1.SetError(txbOldpassword, "Chưa Điền Password cữ !");
                return;
            }
            else
            {
                errorProvider1.SetError(txbOldpassword, string.Empty);
            }
            if (txbOldpassword.Text != dbuser.Password.ToString())
            {
                errorProvider1.SetError(txbOldpassword, "Password cũ sai xin hãy xem lại !");
                return;
            }
            else
            {
                errorProvider1.SetError(txbOldpassword, string.Empty);
            }
            if (txbDoipassword.Text == "")
            {
                errorProvider1.SetError(txbDoipassword, "Chưa Điền Password mới !");
                return;
            }
            else
            {
                errorProvider1.SetError(txbDoipassword, string.Empty);
            }
            if (txbNhaplaipassword.Text == "")
            {
                errorProvider1.SetError(txbNhaplaipassword, "Chưa Điền Lại Password");
                return;
            }
            else
            {
                errorProvider1.SetError(txbNhaplaipassword, string.Empty);
            }
            if (txbDoipassword.Text != txbNhaplaipassword.Text)
            {
                errorProvider1.SetError(txbNhaplaipassword, "Mật Khẩu Không Trùng Khớp");
                return;
            }
            else
            {
                errorProvider1.SetError(txbNhaplaipassword, string.Empty);
            }
            if(dbupdate !=null)
            {
                dbupdate.Email = txbDoiEmail.Text;
                dbupdate.Password = txbDoipassword.Text;
                dbupdate.Password = txbNhaplaipassword.Text;
                dbupdate.image = filename.ToString();
                context.SaveChanges();
                Form2_Load(sender, e);
                MessageBox.Show("Sửa Thành Công ! ", "Thông Báo", MessageBoxButtons.OK);
                txbOldpassword.Clear();
                txbDoipassword.Clear();
                txbNhaplaipassword.Clear();
                pnlDoiThongTin.Visible = false;

            }
        }

        private void pcbDoiThongTin_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filename = dlg.FileName;
                var image = Image.FromFile(dlg.FileName);
                pcbDoiThongTin.Image = image;
            }
        }

        private void btnXemthongtin_Click(object sender, EventArgs e)
        {
            if (pnlThongTin.Visible == false)
            {
                pnlThongTin.Visible = true;
                pnlDoiThongTin.Visible = false;
                pnlMenu.Visible = false;
                ContextChatDB context = new ContextChatDB();
                Login dbuser = context.Login.FirstOrDefault(p => p.Username == usernames);
                if(dbuser != null)
                {
                    txbpnlTentaikhoan.Text = dbuser.Username.ToString();
                    txbpnlEmail.Text = dbuser.Email.ToString();
                    pcbpnlThongTinTaiKhoan.Image = pcbProfile.Image;
                }
            }
            else
            {
                pnlThongTin.Visible = false;
                btnXemthongtin.BackColor = Color.White;
            }
        }

        private void cbShowpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowpassword.Checked == true)
            {
                txbOldpassword.UseSystemPasswordChar = false;
                txbDoipassword.UseSystemPasswordChar = false;
                txbNhaplaipassword.UseSystemPasswordChar = false;
            }
            else
            {
                txbOldpassword.UseSystemPasswordChar = true;
                txbDoipassword.UseSystemPasswordChar = true;
                txbNhaplaipassword.UseSystemPasswordChar = true;
            }
        }
    }
}
