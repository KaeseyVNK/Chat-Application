using BusChatApplication;
using Castle.Components.DictionaryAdapter.Xml;
using DalChatApplication.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Chat_Application
{
    public partial class Form2 : Form
    {
        private LoginService loginservice = new LoginService();
        private AddFriendService addfriendservice = new AddFriendService();
        private ReasonService reasonservice = new ReasonService();
        private MessengerService messengerservice = new MessengerService();
        string filename = "";
        Form1 form1 = new Form1();

        TextBox Mess;
        Button SendBtn;
        Panel ChatArea;
        string usercchat;

        int truoc;
        int sau;

        int statustruoc;
        int statussau;
        UserControl1 iconchat;
        public string usernames { set; get; }
        public Form2()
        {
            form1 = new Form1();
            InitializeComponent();
            ContextChatDB context = new ContextChatDB();
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
        private void closepanel()
        {
            pnlAddfriend.Visible = false;
            pnlDoiThongTin.Visible = false;
            pnlFriendRequest.Visible = false;
            pnlMenu.Visible = false;
            pnlThongTin.Visible = false;
            pnlReport.Visible = false;
            PanelChat.Visible = false;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = usernames;
            ContextChatDB context = new ContextChatDB();
            Login dblogin = loginservice.FindUsername(usernames);
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
            flowLayoutPanel1.AutoScroll = true;
            ContextChatDB context = new ContextChatDB();
            var listusername = loginservice.GetAll();
            var countusername = loginservice.CountAll();
            statustruoc = loginservice.StatusCount();
            UserControl1[] userControls = new UserControl1[countusername];
            for (int i = 0; i < 1; i++)
            {
                foreach (var username in listusername)
                {
                    userControls[i] = new UserControl1();
                    userControls[i].Title = username.Username;
                    userControls[i].Icon = username.image;
                    userControls[i].Status = username.UserStatus.ToString();
                    userControls[i].Click += ClickAllUser;
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
        private void ThemHinhAnhUser(string Imagename)
        {
            if (string.IsNullOrEmpty(Imagename))
            {
                pcbProfile.Image = null;
            }
            else
            {
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string imagepath = Path.Combine(parentDirectory, "Images", Imagename);
                pcbpnlThongTinTaiKhoan.Image = Image.FromFile(imagepath);
                pcbpnlThongTinTaiKhoan.Refresh();
            }
        }
        private void ClickAllUser(object sender, EventArgs e)
        {
            UserControl1 userControls = sender as UserControl1;
            foreach (Control control in pnlThongTin.Controls)
            {
                if (control is Button)
                {
                    pnlThongTin.Controls.Remove(control);
                }
            }
            if (pnlThongTin.Visible == false)
            {
                closepanel();
                pnlThongTin.Visible = true;
                ContextChatDB context = new ContextChatDB();
                Login dbuser = loginservice.FindUsername(userControls.Title);
                AddFriend dbaddfriendTrue = addfriendservice.AddFriendTrue(userControls.Title, label1.Text);
                AddFriend dbaddfriendFalse = addfriendservice.AddFriendFalse(userControls.Title, label1.Text);
                var listfriend = addfriendservice.GetAll();
                SendBtn = new Button();
                if (dbaddfriendTrue != null)
                {
                    SendBtn.Text = "Đã Kết Bạn";
                    SendBtn.Enabled = false;
                }
                if (dbaddfriendFalse != null)
                {
                    SendBtn.Text = "Đã Gửi Kết Bạn";
                    SendBtn.Enabled = false;
                }
                if(dbaddfriendTrue == null && dbaddfriendFalse == null)
                {
                    SendBtn.Text = "Kết Bạn !";
                }
                SendBtn.Size = new Size(75, 40);
                SendBtn.Location = new Point(354, 325);
                SendBtn.BackColor = Color.White;
                SendBtn.Click += addfriendclick;
                pnlThongTin.Controls.Add(SendBtn);
                if (dbuser != null)
                {
                    txbpnlTentaikhoan.Text = dbuser.Username.ToString();
                    txbpnlEmail.Text = dbuser.Email.ToString();
                    ThemHinhAnhUser(dbuser.image);
                }
            }
            else
            {
                closepanel();
            }
        }
        private void addfriendclick(object sender, EventArgs e)
        {
            try
            {
                UserControl1 userControls = sender as UserControl1;
                ContextChatDB context = new ContextChatDB();
                Login dbAddFriend = loginservice.FindUsername(txbpnlTentaikhoan.Text);
                AddFriend dbcheckfriend = addfriendservice.CheckAddFriendUser(txbpnlTentaikhoan.Text);
                if (dbcheckfriend != null)
                {
                    MessageBox.Show("Đã gửi lời kết bạn/đã kết bạn với người này !", " Thông Báo", MessageBoxButtons.OK);
                    return;
                }
                if (dbAddFriend == null)
                {
                    errorProvider1.SetError(txbThemBan, "Không Tìm Thấy người dùng xin hãy xem lại!");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txbThemBan, string.Empty);
                }
                if (dbAddFriend != null)
                {
                    AddFriend add = new AddFriend();
                    add.User1 = usernames;
                    add.User2 = txbpnlTentaikhoan.Text;
                    add.FriendRequestFlag = false;
                    add.DateTime = DateTime.Now;
                    addfriendservice.InsertAddFriend(add);
                    MessageBox.Show("Gửi Lời Kết Bạn Thành Công !", " Thông Báo", MessageBoxButtons.OK);
                    SendBtn.Text = "Đã Gửi Kết Bạn";
                    SendBtn.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã gửi lời kết bạn/đã kết bạn với người này !", " Thông Báo", MessageBoxButtons.OK);
            }
        }
        private void DanhSachThemBanBe()
        {

            FlowUserControlThemBan.Controls.Clear();
            FlowUserControlThemBan.AutoScroll = true;
            ContextChatDB context = new ContextChatDB();
            var listusername = loginservice.GetAll();
            var countusername = loginservice.CountAll();
            UserControl1[] userControls = new UserControl1[countusername];
            for (int i = 0; i < 1; i++)
            {
                foreach (var username in listusername)
                {
                    userControls[i] = new UserControl1();
                    userControls[i].Title = username.Username;
                    userControls[i].Icon = username.image;
                    userControls[i].Status = username.UserStatus.ToString();
                    userControls[i].Click += Btnusercontrols1;
                    if (userControls[i].Title == label1.Text)
                    {
                        FlowUserControlThemBan.Controls.Remove(userControls[i]);
                    }

                    else
                    {
                        FlowUserControlThemBan.Controls.Add(userControls[i]);
                    }
                }
            }
        }
        private void Btnusercontrols1(object sender, EventArgs e)
        {
            UserControl1 userControls = sender as UserControl1;
            txbThemBan.Text = userControls.Title;
        }
        private void XuatDanhSachBanBe()
        {
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.AutoScroll = true;
            ContextChatDB context = new ContextChatDB();
            var listusername = loginservice.GetAll();
            var listfriend = addfriendservice.GetAll();
            var countusername = loginservice.CountAll();
            UserControl1[] userControls = new UserControl1[countusername];
            for (int i = 0; i < 1; i++)
            {
                foreach (var username in listusername)
                {
                    foreach (var friend in listfriend)
                    {
                        userControls[i] = new UserControl1();
                        userControls[i].Title = username.Username;
                        userControls[i].Icon = username.image;
                        userControls[i].Status = username.UserStatus.ToString();
                        if (userControls[i].Title == friend.User2 && friend.User1 == label1.Text && friend.FriendRequestFlag == true || userControls[i].Title == friend.User1 && friend.User2 == label1.Text && friend.FriendRequestFlag == true)
                        {
                            flowLayoutPanel2.Controls.Add(userControls[i]);
                        }
                        if (userControls[i].Title == label1.Text)
                        {
                            flowLayoutPanel2.Controls.Remove(userControls[i]);
                        }
                        userControls[i].Click += userControl11_Click;
                        
                    }
                }
            }
        }
        private void XuatDanhSachKetBan()
        {
            flowControlFriendRequest.Controls.Clear();
            flowControlFriendRequest.AutoScroll = true;
            ContextChatDB context = new ContextChatDB();
            var listusername = loginservice.GetAll();
            var listfriend = addfriendservice.GetAll();
            var countusername = loginservice.CountAll();
            UserControl1[] userControls = new UserControl1[countusername];
            for (int i = 0; i < 1; i++)
            {
                foreach (var username in listusername)
                {
                    foreach (var friend in listfriend)
                    {
                        userControls[i] = new UserControl1();
                        userControls[i].Title = username.Username;
                        userControls[i].Icon = username.image;
                        userControls[i].Status = username.UserStatus.ToString();
                        userControls[i].Click += Btnusercontrols;
                        if (userControls[i].Title == friend.User1 && friend.User2 == label1.Text && friend.FriendRequestFlag == false)
                        {
                            flowControlFriendRequest.Controls.Add(userControls[i]);
                        }
                        if (userControls[i].Title == label1.Text)
                        {
                            flowControlFriendRequest.Controls.Remove(userControls[i]);
                        }
                    }
                }
            }
        }
        private void DanhSachReport()
        {
            flpReportuser.Controls.Clear();
            flpReportuser.AutoScroll = true;
            ContextChatDB context = new ContextChatDB();
            var listusername = loginservice.GetAll();
            var countusername = loginservice.CountAll();
            UserControl1[] userControls = new UserControl1[countusername];
            for (int i = 0; i < 1; i++)
            {
                foreach (var username in listusername)
                {
                    userControls[i] = new UserControl1();
                    userControls[i].Title = username.Username;
                    userControls[i].Icon = username.image;
                    userControls[i].Status = username.UserStatus.ToString();
                    userControls[i].Click += Btnusercontrols2;
                    if (userControls[i].Title == label1.Text)
                    {
                        flpReportuser.Controls.Remove(userControls[i]);
                    }
                    else
                    {
                        flpReportuser.Controls.Add(userControls[i]);
                    }
                }
            }
        }


        private void Btnusercontrols2(object sender,EventArgs e)
        {
            UserControl1 userControls = sender as UserControl1;
            txbUserreport.Text = userControls.Title;
        }
        private void Btnusercontrols(object sender,EventArgs e)
        {
            UserControl1 userControls = sender as UserControl1;
            txbTimBan.Text = userControls.Title;
        }
        private void btnThoat_Click_1(object sender, EventArgs e)
        {        
            {
                ContextChatDB context = new ContextChatDB();
                var listuser = context.Logins.ToList();
                foreach (Login user in listuser)
                {
                    if(user.Username == label1.Text)
                    {
                        user.UserStatus = false;
                        context.SaveChanges();
                    }
                }
                this.Visible = false;
                form1.Visible = true;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (pnlMenu.Visible == false)
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
                closepanel();
                pnlDoiThongTin.Visible = true;
                Login dbuser = loginservice.FindUsername(usernames);
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
            Login dbupdate = loginservice.FindUsername(usernames);
            Login dbuser = loginservice.FindUsername(usernames);
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
                filename = Path.GetFileName(dlg.FileName);
                var image = Image.FromFile(dlg.FileName);
                pcbDoiThongTin.Image = image;
            }
        }

        private void btnXemthongtin_Click(object sender, EventArgs e)
        {
            if (pnlThongTin.Visible == false)
            {
                closepanel();
                pnlThongTin.Visible = true;
                ContextChatDB context = new ContextChatDB();
                Login dbuser = loginservice.FindUsername(usernames);
                if (dbuser != null)
                {
                    txbpnlTentaikhoan.Text = dbuser.Username.ToString();
                    txbpnlEmail.Text = dbuser.Email.ToString();
                    pcbpnlThongTinTaiKhoan.Image = pcbProfile.Image;
                }
            }
            else
            {
                closepanel();
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

        private void txbTimkiem_TextChanged(object sender, EventArgs e)
        {
           foreach(Control c in flowLayoutPanel1.Controls)
            {
               if(c is UserControl1 usercontrol&& usercontrol.Title.Contains(txbTimkiem.Text)==true)
                {
                    c.Visible = true;
                }
               else
                {
                    c.Visible = false;
                }
            }
            if (txbTimkiem.Text == "")
            {
                flowLayoutPanel1.Visible = true;
            }
        }

        private void btnAddFriend_Click(object sender, EventArgs e)
        {
            if (pnlAddfriend.Visible == false)
            {
                closepanel();
                pnlAddfriend.Visible = true;
                DanhSachThemBanBe();
            }
            else
            {
                pnlAddfriend.Visible = false;
            }
        }

        private void txbThemBan_TextChanged(object sender, EventArgs e)
        {
            foreach (Control c in FlowUserControlThemBan.Controls)
            {
                if (c is UserControl1 usercontrol && usercontrol.Title.Contains(txbThemBan.Text) == true)
                {
                    c.Visible = true;
                }
                else
                {
                    c.Visible = false;
                }
            }
            if (txbThemBan.Text == "")
            {
                FlowUserControlThemBan.Visible = true;
            }
        }

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            ContextChatDB context = new ContextChatDB();
            List <AddFriend> listfriend = new List<AddFriend>();
            try
            {
                if (txbThemBan.Text == "")
                {
                    errorProvider1.SetError(txbThemBan, "Chưa Điền Tên Kết Bạn !");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txbThemBan, string.Empty);
                }
                Login dbAddFriend = loginservice.FindUsername(txbThemBan.Text);
                AddFriend dbcheckfriend = addfriendservice.CheckAddFriendUser(txbThemBan.Text);
                if(dbcheckfriend != null)
                {
                  MessageBox.Show("Đã gửi lời kết bạn/đã kết bạn với người này !", " Thông Báo", MessageBoxButtons.OK);
                  return;
                }
                if (dbAddFriend == null)
                {
                    errorProvider1.SetError(txbThemBan, "Không Tìm Thấy người dùng xin hãy xem lại!");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txbThemBan, string.Empty);
                }
                if (dbAddFriend != null)
                {
                    AddFriend add = new AddFriend();
                    add.User1 = usernames;
                    add.User2 = txbThemBan.Text;
                    add.FriendRequestFlag = false;
                    add.DateTime = DateTime.Now;
                    addfriendservice.InsertAddFriend(add);
                    MessageBox.Show("Gửi Lời Kết Bạn Thành Công !", " Thông Báo", MessageBoxButtons.OK);
                    txbThemBan.Clear();
                    closepanel();
                }
            }catch
            {
                MessageBox.Show("Đã gửi lời kết bạn/đã kết bạn với người này !", " Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btnShowfriend_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = true;
            XuatDanhSachBanBe();
        }

        private void btnDongy_Click(object sender, EventArgs e)
        {
            ContextChatDB context = new ContextChatDB();
            AddFriend dbAcceptFriend = context.AddFriends.FirstOrDefault(p => p.User1 == txbTimBan.Text && p.User2 == label1.Text);
            if (dbAcceptFriend != null)
            {
                dbAcceptFriend.FriendRequestFlag = true;
                context.SaveChanges();
                txbTimBan.Clear();
                closepanel();
                MessageBox.Show("Kết Bạn Thành Công !", " Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void txbTimBan_TextChanged(object sender, EventArgs e)
        {
            foreach (Control c in flowControlFriendRequest.Controls)
            {
                if (c is UserControl1 usercontrol && usercontrol.Title.Contains(txbTimBan.Text) == true)
                {
                    c.Visible = true;
                }
                else
                {
                    c.Visible = false;
                }
            }
            if (txbTimkiem.Text == "")
            {
                flowLayoutPanel1.Visible = true;
            }
        }

        private void btnFriendrequest_Click(object sender, EventArgs e)
        {
             if (pnlFriendRequest.Visible == false)
            {
                closepanel();
                pnlFriendRequest.Visible = true;
                XuatDanhSachKetBan();
            }
            else
            {
                closepanel();
            }
        }

        private void btnKhongdongy_Click(object sender, EventArgs e)
        {
            ContextChatDB context = new ContextChatDB();
            AddFriend dbNoAcceptFriend = context.AddFriends.FirstOrDefault(p => p.User1 == txbTimBan.Text && p.User2 == label1.Text);
            if (dbNoAcceptFriend != null)
            {
                context.AddFriends.Remove(dbNoAcceptFriend);
                context.SaveChanges();
                txbTimBan.Clear();
                closepanel();
                Form2_Load(sender, e);
                MessageBox.Show("Đã không chấp nhận kết bạn !", " Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btnAlluser_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel2.Visible = false;
            DanhSachNguoiDung();
        }

        private void txbUserreport_TextChanged(object sender, EventArgs e)
        {
            foreach (Control c in flpReportuser.Controls)
            {
                if (c is UserControl1 usercontrol && usercontrol.Title.Contains(txbUserreport.Text) == true)
                {
                    c.Visible = true;
                }
                else
                {
                    c.Visible = false;
                }
            }
            if (txbTimkiem.Text == "")
            {
                flpReportuser.Visible = true;
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (pnlReport.Visible == false)
            {
                ContextChatDB context = new ContextChatDB();
                List<Reason> listreason = reasonservice.GetAll();
                closepanel();
                FillReportComboBox(listreason);
                pnlReport.Visible = true;
                DanhSachReport();
            }
            else
            {
                pnlReport.Visible = false;
            }
        }
        private void FillReportComboBox(List<Reason> listreason)
        {
            this.cmbReportreason.DataSource = listreason;
            this.cmbReportreason.DisplayMember = "Reasons";
            this.cmbReportreason.ValueMember = "ReportReasonID";
        }

        private void btnReportUser_Click(object sender, EventArgs e)
        {
            try
            {
                ContextChatDB context = new ContextChatDB();
                Login dbReport = loginservice.FindUsername(label1.Text);
                if (dbReport != null)
                {
                    ReportUser report = new ReportUser();
                    report.ReportUser1 = label1.Text;
                    report.ReportedUser = txbUserreport.Text;
                    report.ReportReasonID = (cmbReportreason.SelectedItem as Reason).ReportReasonID;
                    report.Note = txbNote.Text;
                    context.ReportUsers.Add(report);
                    context.SaveChanges();
                    closepanel();
                    Form2_Load(sender, e);
                    MessageBox.Show("Report Thành Công !", " Thông Báo", MessageBoxButtons.OK);
                }
            }catch
            {
                MessageBox.Show("Report Không Thành Công !", " Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void userControl11_Click(object sender, EventArgs e)
        {
            //closepanel();
            PanelChat.BringToFront();
            UserControl1 user = sender as UserControl1;
            //MessageBox.Show("Da chon user");
            foreach (Control control in PanelChat.Controls)
            {
                if (control is UserControl1)
                {
                    PanelChat.Controls.Remove(control);
                }
            }
            if (PanelChat.Visible == false)
            {
                PanelChat.Visible = true;
                UserControl1  nguoichat = new UserControl1();
                nguoichat.Size = new Size(550, 71);
                nguoichat.BackColor = Color.Cyan;
                nguoichat.Title = user.Title;
                nguoichat.Icon = user.Icon;
                nguoichat.Status = user.Status;
                iconchat = user;
                PanelChat.Controls.Clear();
                PanelChat.Controls.Add(nguoichat);                
                CreatedTextAndSendButton(PanelChat, nguoichat.Title );
                usercchat = nguoichat.Title;
                
                ChatArea.VerticalScroll.Value = ChatArea.VerticalScroll.Maximum;
            }
            else if (user.Title == usercchat && PanelChat.Visible == true)
            {
                PanelChat.Visible = false;

            }
            else
            {
                PanelChat.Visible = false;
            }

        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            ContextChatDB context = new ContextChatDB();
            try
            {
                using(var transaction = context.Database.BeginTransaction() )
                {
                    try
                    {


                        Messenger mess = new Messenger();
                        mess.Username1 = usernames;
                        mess.Username2 = usercchat;
                        mess.Messenger1 = Mess.Text;
                        mess.TimeMessenger = DateTime.Now;
                        messengerservice.InsertMessage(mess);
                        ChatArea.Controls.Clear();
                        var MessList = messengerservice.GetAllMessage(usernames);
                        truoc = messengerservice.CountMessage(usernames);
                        BindGridMess(MessList, usercchat);
                      //  ChatArea.VerticalScroll.Value = ChatArea.VerticalScroll.Maximum;

                        transaction.Commit();
                        Mess.Text = "";
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Da Co Loi Khi Gui Tin Nhan!!!");
                        transaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 
        }

        private void CreatedTextAndSendButton(Panel panel, string userchat)
        {
            Mess = new TextBox();
            Mess.Multiline = true;
            Mess.Location = new Point(2, 565);
            Mess.Size = new Size(457, 48);

            SendBtn = new Button();
            SendBtn.Text = "Gửi";
            SendBtn.Size = new Size(80, 48);
            SendBtn.Location = new Point(459, 565);
            SendBtn.BackColor = Color.White;
           

            ChatArea = new Panel();
            ChatArea.Location = new Point(3, 74);
            ChatArea.Size = new Size(536, 485);
            ChatArea.BackColor = Color.White;
            ChatArea.AutoScroll = true;
          
            SendBtn.Click += btnGui_Click;

            ContextChatDB context = new ContextChatDB();
            var MessList = messengerservice.GetAllMessage(usernames);
            truoc = messengerservice.CountMessage(usernames);
            //Mess.Text = MessList.Count.ToString();

            BindGridMess(MessList, userchat);
            ChatArea.VerticalScroll.Value = ChatArea.VerticalScroll.Maximum;
            usercchat = userchat;
            


            panel.Controls.Add(ChatArea);
            panel.Controls.Add(SendBtn);
            panel.Controls.Add(Mess);
        
        }


        private void BindGridMess ( List<Messenger> MessList, string userchat)
        {

            if (MessList.Count > 0)
            {
                int y = 0;
                foreach (var mess in MessList)
                {
                    if (mess.Username1 == usernames && mess.Username2 == userchat)
                    {
                        User1 user1 = new User1();
                        user1.Title = mess.Messenger1;
                        user1.Location = new Point(180, y);
                        ChatArea.Controls.Add(user1);
                        y += 60;
                    }
                    else
                        if (mess.Username1 == userchat && mess.Username2 == usernames)
                    {
                        User2 user2 = new User2();
                        user2.Title = mess.Messenger1;
                        user2.Location = new Point(0, y);
                        user2.Icon = iconchat.Icon;
                        ChatArea.Controls.Add(user2);
                        y += 60;
                    }
                    ChatArea.Refresh();
                }
            }
            ChatArea.VerticalScroll.Value = ChatArea.VerticalScroll.Maximum;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ContextChatDB context = new ContextChatDB();
            if ( ChatArea != null )
            {
                sau = messengerservice.CountMessage(usernames);
                if ( truoc != sau )
                {
                    var MessList = messengerservice.GetAllMessage(usernames);
                    BindGridMess(MessList, usercchat);
                    ChatArea.VerticalScroll.Value = ChatArea.VerticalScroll.Maximum;
                    truoc = sau;
                }
            }
                statussau = loginservice.StatusCount();
                if (statustruoc != statussau)
                {
                DanhSachNguoiDung();
                XuatDanhSachBanBe();
                DanhSachReport();
                XuatDanhSachKetBan();
                DanhSachThemBanBe();
                statustruoc = statussau;
                }
            }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            ContextChatDB context = new ContextChatDB();
            var listuser = context.Logins.ToList();
            foreach (Login user in listuser)
            {
                if (user.Username == label1.Text)
                {
                    user.UserStatus = false;
                    context.SaveChanges();
                }
            }
        }
    }
}
