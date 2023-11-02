using DalChatApplication.Model;
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
        string bannername = "";
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
        private void ThemBanner(string Imagename)
        {
            if (string.IsNullOrEmpty(Imagename))
            {
                pcbProfile.Image = null;
            }
            else
            {
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string imagepath = Path.Combine(parentDirectory, "Images", Imagename);
                pcbBannernguoidung.Image = Image.FromFile(imagepath);
                pcbBannernguoidung.Refresh();
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = usernames;
            ContextChatDB context = new ContextChatDB();
            Login dblogin = context.Logins.FirstOrDefault(p => p.Username == usernames);
            if (dblogin != null)
            {
                label1.Text = dblogin.Username;
                ThemHinhAnh(dblogin.image);
            }
            dgvUsers.DataSource = context.Logins.OrderBy(p => p.Username).ToList();
            dgvReports.DataSource = context.ReportUsers.OrderBy(p => p.ReportID).ToList();
            dgvReports.Columns[3].Visible = false;
            dgvReports.Columns[5].Visible = false;
            dgvReports.Columns[6].Visible = false;
            dgvUsers.Columns[3].Visible = false;
            dgvUsers.Columns[5].Visible = false;
            dgvUsers.Columns[11].Visible = false;
            dgvUsers.Columns[12].Visible = false;
            dgvUsers.Columns[13].Visible = false;
            dgvUsers.Columns[14].Visible = false;
            dgvUsers.Columns[15].Visible = false;
            dgvUsers.Columns[16].Visible = false;
            dgvUsers.Columns[17].Visible = false;
            List<Permission> listpermission = context.Permissions.OrderBy(p => p.IDPermission).ToList();
            List<Reason> listreason = context.Reasons.OrderBy(p => p.ReportReasonID).ToList();
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
                Login find = context.Logins.FirstOrDefault(p => p.Username == user);
                dgvUsers.CurrentRow.Selected = true;
                {
                    if (find != null)
                    {
                        txbUsername.Text = find.Username;
                        txbPassword.Text = find.Password;
                        txbEmail.Text = find.Email;
                        cmbPermission.SelectedValue = find.IDPermission;
                        txbGioitinh.Text = find.Gender;
                        dtpNgaySinh.Value = find.DateofBirth;
                        if (find.UserDescription != null)
                        {
                            txbUserDescription.Text = find.UserDescription;
                        }
                        else
                        {
                            txbUserDescription.Text = null;
                        }
                        filename = find.image;
                        ThemHinhAnh1(find.image);
                        if (find.BackgroundImage == null)
                        {
                            pcbBannernguoidung.Image = null;
                        }
                        else
                        {
                            bannername = find.BackgroundImage;
                            ThemBanner(find.BackgroundImage);
                        }
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
            Login find = context.Logins.FirstOrDefault(p => p.Username == txbUsername.Text);
            if (find != null)
            {
                find.Username = txbUsername.Text;
                find.Password = txbPassword.Text;
                find.Email = txbEmail.Text;
                find.IDPermission = (cmbPermission.SelectedItem as Permission).IDPermission;
                find.image = filename.ToString();
                find.BackgroundImage = bannername.ToString();
                find.DateofBirth = dtpNgaySinh.Value;
                find.Gender = txbGioitinh.Text;
                find.UserDescription = txbUserDescription.Text;
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
                string source = dlg.FileName;
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string imagepath = Path.Combine(parentDirectory, "Images", Path.GetFileName(dlg.FileName));
                if (File.Exists(imagepath))
                {

                }
                else
                {
                    File.Copy(source, imagepath, true);
                }
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
                Form3_Load(sender, e);
                panel1.Visible = false;
                dgvUsers.Visible = true;
            }
            else
            {
                Form3_Load(sender, e);
                dgvUsers.Visible = false;
            }
        }

        private void menuReportLog_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                Form3_Load(sender, e);
                dgvUsers.Visible = false;
                panel1.Visible = true;
            }
            else
            {
                Form3_Load(sender, e);
                dgvUsers.Visible = true;
                panel1.Visible = false;
            }
        }

        private void dgvReports_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbReportID.Text = dgvReports.Rows[e.RowIndex].Cells[0].Value.ToString();
            string userreport = txbUsername.Text = dgvReports.Rows[e.RowIndex].Cells[2].Value.ToString();
            ContextChatDB context = new ContextChatDB();
            Login find = context.Logins.FirstOrDefault(p => p.Username == userreport);
            dgvUsers.CurrentRow.Selected = true;
            {
                if (find != null)
                {
                    txbUsername.Text = find.Username;
                    txbPassword.Text = find.Password;
                    txbEmail.Text = find.Email;
                    cmbPermission.SelectedValue = find.IDPermission;
                    txbGioitinh.Text = find.Gender;
                    dtpNgaySinh.Value = find.DateofBirth;
                    if (find.UserDescription != null)
                    {
                        txbUserDescription.Text = find.UserDescription;
                    }
                    else
                    {
                        txbUserDescription.Text = null;
                    }
                    filename = find.image;
                    ThemHinhAnh1(find.image);
                    if (find.BackgroundImage == null)
                    {
                        pcbBannernguoidung.Image = null;
                    }
                    else
                    {
                        bannername = find.BackgroundImage;
                        ThemBanner(find.BackgroundImage);
                    }
                    txbNote.Text = dgvReports.Rows[e.RowIndex].Cells[4].Value.ToString();
                    cmbReason.SelectedValue = dgvReports.Rows[e.RowIndex].Cells["ReportReasonID"].Value;
                }
            }
        }

        private void btnDeletereport_Click(object sender, EventArgs e)
        {
            int txbreportid = int.Parse(txbReportID.Text);
            ContextChatDB context = new ContextChatDB();
            ReportUser delete = context.ReportUsers.FirstOrDefault(p => p.ReportID == txbreportid);
            if(delete != null)
            {
                context.ReportUsers.Remove(delete);
                context.SaveChanges();
                Form3_Load(sender, e);
                MessageBox.Show("Xóa thành công ! ", " Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void pcbBannernguoidung_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                bannername = Path.GetFileName(dlg.FileName);
                var image = Image.FromFile(dlg.FileName);
                pcbBannernguoidung.Image = image;
                pcbBannernguoidung.SizeMode = PictureBoxSizeMode.Zoom;
                string source = dlg.FileName;
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string imagepath = Path.Combine(parentDirectory, "Images", Path.GetFileName(dlg.FileName));
                if (File.Exists(imagepath))
                {

                }
                else
                {
                    File.Copy(source, imagepath, true);
                }
            }
        }
    }
}
