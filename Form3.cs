using Chat_Application.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Application
{
    public partial class Form3 : Form
    {
        string filename = "";
        Form1 form1 = new Form1();
        public string usernames { set; get; }
        public Form3()
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
                pcbProfile.Image = Image.FromFile(imagepath);
                pcbProfile.Refresh();
            }
        }
        private void ThemHinhAnh1(string Imagename)
        {
            if (string.IsNullOrEmpty(Imagename))
            {
                pcbAnhnguoidung.Image = null;
            }
            else
            {
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string imagepath = Path.Combine(parentDirectory, "Images", Imagename);
                pcbAnhnguoidung.Image = Image.FromFile(imagepath);
                pcbAnhnguoidung.Refresh();
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = usernames;
            ContextChatDB context = new ContextChatDB();
            Login dblogin = context.Login.FirstOrDefault(p => p.Username == usernames);
            if (dblogin != null)
            {
                label1.Text = dblogin.Username;
                ThemHinhAnh(dblogin.image);
            }
            dgvUsers.DataSource = context.Login.OrderBy(p => p.Username).ToList();
            dgvReports.DataSource = context.ReportUser.OrderBy(p => p.ReportID).ToList();
            dgvReports.Columns[3].Visible = false;
            dgvReports.Columns[5].Visible = false;
            dgvReports.Columns[6].Visible = false;
            dgvUsers.Columns[5].Visible = false;
            dgvUsers.Columns[3].Visible = false;
            dgvUsers.Columns[6].Visible = false;
            dgvUsers.Columns[7].Visible = false;
            dgvUsers.Columns[8].Visible = false;
            dgvUsers.Columns[9].Visible = false;
            dgvUsers.Columns[10].Visible = false;
            List<Permission> listpermission = context.Permission.OrderBy(p => p.IDPermission).ToList();
            List<Reason> listreason = context.Reason.OrderBy(p => p.ReportReasonID).ToList();
            fillPermission(listpermission);
            cmbPermission.SelectedIndex = -1;
            fillReason(listreason);
            pcbAnhnguoidung.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void fillPermission(List<Permission> listpermission)
        {
            this.cmbPermission.DataSource = listpermission;
            this.cmbPermission.DisplayMember = "PermissionName";
            this.cmbPermission.ValueMember = "IDPermission";
        }
        private void fillReason(List<Reason> listreason)
        {
            this.cmbReason.DataSource = listreason;
            this.cmbReason.DisplayMember = "Reasons";
            this.cmbReason.ValueMember = "ReportReasonID";
        }
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string user = txbUsername.Text = dgvUsers.Rows[e.RowIndex].Cells[0].Value.ToString();
                ContextChatDB context = new ContextChatDB();
                Login find = context.Login.FirstOrDefault(p => p.Username == user);
                dgvUsers.CurrentRow.Selected = true;
                {
                    if (find != null)
                    {
                        txbUsername.Text = find.Username;
                        txbPassword.Text = find.Password;
                        txbEmail.Text = find.Email;
                        cmbPermission.SelectedValue = find.IDPermission;
                        filename = find.image;
                        ThemHinhAnh1(find.image);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ContextChatDB context = new ContextChatDB();
            Login find = context.Login.FirstOrDefault(p => p.Username == txbUsername.Text);
            if (find != null)
            {
                find.Username = txbUsername.Text;
                find.Password = txbPassword.Text;
                find.Email = txbEmail.Text;
                find.IDPermission = (cmbPermission.SelectedItem as Permission).IDPermission;
                find.image = filename.ToString();
                context.SaveChanges();
                Form3_Load(sender, e);
                MessageBox.Show("Sửa Thành Công ! ", " Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void pcbAnhnguoidung_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filename = Path.GetFileName(dlg.FileName);
                var image = Image.FromFile(dlg.FileName);
                pcbAnhnguoidung.Image = image;
                pcbAnhnguoidung.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ContextChatDB context = new ContextChatDB();
            Login find = context.Login.FirstOrDefault(p => p.Username == txbUsername.Text);
            var listfriend = context.AddFriend.ToList();
            var listreport = context.ReportUser.ToList();
            AddFriend friends = context.AddFriend.FirstOrDefault(p => p.User1 == txbUsername.Text || p.User2 == txbUsername.Text);
            ReportUser reports = context.ReportUser.FirstOrDefault(p => p.ReportUser1 == txbUsername.Text || p.ReportedUser == txbUsername.Text);
            if (find != null)
            {
                context.Login.Remove(find);
                if (friends != null)
                {
                    foreach (var friend in listfriend)
                    {
                        if (friend.User1 == txbUsername.Text || friend.User2 == txbUsername.Text)
                        {
                            context.AddFriend.Remove(friends);
                        }
                    }
                }
                if(reports != null)
                {
                    foreach(var report in listreport)
                    {
                        if(report.ReportUser1 == txbUsername.Text || report.ReportedUser == txbUsername.Text)
                        {
                            context.ReportUser.Remove(reports);
                        }
                    }
                }
                context.SaveChanges();
                Form3_Load(sender, e);
                MessageBox.Show("Xóa Thành Công ! ", " Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.Visible == false)
            {
                panel1.Visible = false;
                dgvUsers.Visible = true;
            }
            else
            {
                dgvUsers.Visible = false;
            }
        }

        private void menuReportLog_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                dgvUsers.Visible = false;
                panel1.Visible = true;
            }
            else
            {
                dgvUsers.Visible = true;
                panel1.Visible = false;
            }
        }

        private void dgvReports_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string userreport = txbUsername.Text = dgvReports.Rows[e.RowIndex].Cells[2].Value.ToString();
            ContextChatDB context = new ContextChatDB();
            Login find = context.Login.FirstOrDefault(p => p.Username == userreport);
            dgvUsers.CurrentRow.Selected = true;
            {
                if (find != null)
                {
                    txbUsername.Text = find.Username;
                    txbPassword.Text = find.Password;
                    txbEmail.Text = find.Email;
                    cmbPermission.SelectedValue = find.IDPermission;
                    filename = find.image;
                    ThemHinhAnh1(find.image);
                    txbNote.Text = dgvReports.Rows[e.RowIndex].Cells[4].Value.ToString();
                    cmbReason.SelectedValue = dgvReports.Rows[e.RowIndex].Cells["ReportReasonID"].Value;
                }
            }
        }
    }
}
