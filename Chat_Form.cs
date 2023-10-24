using BusChatApplication;
using ChangeTracking;
using DalChatApplication.Model;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Chat_Application
{
    public partial class Chat_Form : Form
    {
        private LoginService loginservice = new LoginService();
        private AddFriendService addfriendservice = new AddFriendService();
        private ReasonService reasonservice = new ReasonService();
        private MessengerService messengerservice = new MessengerService();
        string filename = ""; // Tạo biến toàn cục lấy filename của hình ảnh
        string backgroundimagefilename = ""; // Tạo biến toàn cục lấy filename của ảnh background
        Login_Register_Form form1 = new Login_Register_Form(); // khởi tạo form1 nhầm lấy username truyền vào label1
        string destination = @"C:\Users\Admin\Desktop\New folder\Chat Application\Images\"; //Đường dẫn đến file hình ảnh để khi người dùng lấy hình ảnh sẽ tự động lưu vào folder.
        Guna2TextBox Mess;
        Guna2Button SendBtn;
        Panel ChatArea;
        string usercchat; 

        int truoc; //biến toàn cục dùng để kiểm tra số message giữa hai người dùng trước để update timer
        int sau; //biến toàn cục dùng để kiểm tra số message sau giữa hai người dùng để update timer.

        int friendrequesttruoc; //Như trên nhưng dùng cho friend request
        int friendrequestsau; //Như trên

        bool MenuExpend = false; //biến toàn cục dùng để kéo thanh menu danh sách người dùng
        bool MennuEXitExpend = false; //biến toàn cục dùng đẻ kéo thanh menu về khi click trong lúc menuexpend == true;

        int statustruoc; //biến toàn cục kiểm tra status online của người dùng trước
        int statussau; //biến toàn cục kiểm tra status online của người dùng sau.
        UserControl1 iconchat;
        public string usernames { set; get; }

        public Chat_Form()
        {
            form1 = new Login_Register_Form();
            InitializeComponent();
            ContextChatDB context = new ContextChatDB();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            panelThoat.BringToFront(); //đưa menu thoát lên đầu
            PanelMenuThoat.BringToFront(); //đưa panel menu thoát lên
            TimerMenuThoat.Start(); //kéo thanh exit ra 2 chức năng là thoát chương trình và đăng xuất
            panelMenu.Width = panelMenu.MinimumSize.Width;
            MenuExpend = false;
        }

        private void ThemHinhAnh(string Imagename) //Hàm thêm hình ảnh cho người dùng đang sử dụng
        {
            {
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string imagepath = Path.Combine(parentDirectory, "Images", Imagename);
                pcbDoiThongTin.Image = Image.FromFile(imagepath);
                pcbDoiThongTin.SizeMode = PictureBoxSizeMode.Zoom;
                pcbProfile.Image = Image.FromFile(imagepath);
                pcbProfile.SizeMode = PictureBoxSizeMode.Zoom;
                pcbTrangChu.Image = Image.FromFile(imagepath);
                pcbTrangChu.SizeMode = PictureBoxSizeMode.Zoom;
                pcbTrangChu.Refresh();
                pcbProfile.Refresh();
                pcbDoiThongTin.Refresh();
            }
        }
        private void ThemBackgroundImage(string Imagename) //Hàm thêm hình ảnh background cho người đang sử dụng
        {
            if (string.IsNullOrEmpty(Imagename))
            {
                pcbBackgroundTrangChu.Image = null;
            }
            else
            {
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string imagepath = Path.Combine(parentDirectory, "Images", Imagename);
                pcbBackgroundImageChinhSua.Image = Image.FromFile(imagepath);
                pcbTrangChu.SizeMode = PictureBoxSizeMode.Zoom;
                pcbBackgroundTrangChu.Image = Image.FromFile(imagepath);
                pcbBackgroundTrangChu.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        private void ThemHinhAnhUser(string Imagename) //Thêm hình ảnh cho người dùng có trong panel tìm kiếm người dùng khi bấm vào click event của all user
        {
            if (string.IsNullOrEmpty(Imagename))
            {
                pcbAlluserimage.Image = null;
            }
            else
            {
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string imagepath = Path.Combine(parentDirectory, "Images", Imagename);
                pcbAlluserimage.Image = Image.FromFile(imagepath);
                pcbAlluserimage.Refresh();
            }
        }
        private void ThemBackgroundUser(string Imagename) //Thêm hình ảnh background cho người dùng có trong panel tìm kiếm người dùng khi bấm vào click event của all user
        {
            if (string.IsNullOrEmpty(Imagename))
            {
                pcbAllUserBackground.Image = null;
            }
            else
            {
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string imagepath = Path.Combine(parentDirectory, "Images", Imagename);          
                pcbAllUserBackground.Image = Image.FromFile(imagepath);
                pcbAllUserBackground.Refresh();
            }
        }
        private void DanhSachNguoiDung() //Xuất danh sách của tất cả tài khoản 
        {
            flowLayoutPanel3.Controls.Clear(); //clear những control cũ của layoutpanel
            flowLayoutPanel3.AutoScroll = true;
            ContextChatDB context = new ContextChatDB();
            var listusername = loginservice.GetAll();
            var countusername = loginservice.CountAll();
            statustruoc = loginservice.StatusCount(); //Đếm status của tất cả các usercontrol để kiểm tra
            UserControl1[] userControls = new UserControl1[countusername];
            for (int i = 0; i < 1; i++)
            {
                foreach (var username in listusername)
                {
                    userControls[i] = new UserControl1(); //khởi tạo usercontrol 1 rồi truyền dữ liệu vào usercontrol
                    userControls[i].Title = username.Username; 
                    userControls[i].Icon = username.image;
                    userControls[i].Status = username.UserStatus.ToString();
                    userControls[i].Click += ClickAllUser;
                    if (userControls[i].Title == label1.Text) //nếu trùng với tên của tên tài khoản đang sử dụng thì xóa
                    {
                        flowLayoutPanel3.Controls.Remove(userControls[i]);
                    }
                    else //thêm
                    {
                        flowLayoutPanel3.Controls.Add(userControls[i]);
                    }
                }
            }
        }

        private void ClickAllUser(object sender, EventArgs e) //chức năng kết bạn qua profile của người khác
        {
            UserControl1 userControls = sender as UserControl1;
            foreach (Control control in pnlThongTin.Controls) //xóa button cũ
            {
                if (control is Guna2Button)
                {
                    pnlThongTin.Controls.Remove(control);
                }
            }
            if (pnlThongTin.Visible == false)
            {
                ClosePanel();
                pnlThongTin.Visible = true;
                ContextChatDB context = new ContextChatDB();
                Login dbuser = loginservice.FindUsername(userControls.Title);
                AddFriend dbaddfriendTrue = addfriendservice.AddFriendTrue(userControls.Title, label1.Text);
                AddFriend dbaddfriendFalse = addfriendservice.AddFriendFalse(userControls.Title, label1.Text);
                var listfriend = addfriendservice.GetAll();
                SendBtn = new Guna2Button(); //tạo button kiểm tra
                if (dbaddfriendTrue != null) //nếu người dùng đã kết bạn
                {
                    SendBtn.Text = " Đã Kết Bạn";
                    SendBtn.Enabled = false;
                }
                else if (dbaddfriendFalse != null) //nếu người dùng đã gửi lời kết bạn nhưng người kia chưa chấp nhận
                {
                    SendBtn.Text = "Đã Gửi Kết Bạn";
                    SendBtn.Enabled = false;
                }
                else if (dbaddfriendTrue == null && dbaddfriendFalse == null) //nếu cả hai điều kiện không xảy ra
                {
                    SendBtn.Text = "Kết Bạn !";
                }
                SendBtn.Size = new Size(180, 45);
                SendBtn.Location = new Point(240, 404);
                SendBtn.FillColor = Color.Crimson;
                SendBtn.Click += addfriendclick; //khi click vào sẽ bặt đầu thêm dữ liệu kết bạn vào csdl
                pnlThongTin.Controls.Add(SendBtn);
                if (dbuser != null) //truyền thông tin người dùng bạn đang tìm kiếm.
                {
                    lblAllusername.Text = dbuser.Username.ToString(); 
                    lblGender.Text = dbuser.Gender.ToString();
                    dtpAlluser.Value = dbuser.DateofBirth;
                    if (dbuser.UserDescription != null)
                    {
                        txbAlluseraboutme.Text = dbuser.UserDescription.ToString();
                    }
                    else
                    {
                        txbAlluseraboutme.Clear();
                    }
                    ThemHinhAnhUser(dbuser.image);
                    ThemBackgroundUser(dbuser.BackgroundImage);
                }
            }
            else
            {
                ClosePanel();
            }
        }

        private void ClosePanel() //hàm đóng đồng loạt tất cả các panel
        {
            pnlTimKiemNguoiDung.Visible = false;
            pnlToCaoNguoiDung.Visible = false;
            pnlYeuCauKetban.Visible = false;
            panelDanSachBanbe.Visible = false;
            pnlThongTin.Visible = false;
        }

        private void addfriendclick(object sender, EventArgs e)
        {
            try
            {
                UserControl1 userControls = sender as UserControl1;
                ContextChatDB context = new ContextChatDB();
                Login dbAddFriend = loginservice.FindUsername(lblAllusername.Text);
                AddFriend dbcheckfriend = addfriendservice.CheckAddFriendUser(lblAllusername.Text,label1.Text);
                if (dbcheckfriend != null) //kiểm tra xem người dùng đã kết bạn hay đã gửi lời kết bạn chưa
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
                    add.User2 = lblAllusername.Text;
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

        private void DanhSachThemBanBe() //dánh sách dùng để kiểm tra để kết bạn với bạn bè
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
                    userControls[i].Click += Btnusercontrols1; //bấm vào sẽ truyền tên của usercontrol vào textbox rồi sau đó kết bạn
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
            txbThemBan.Text = userControls.Title; //truyền vào txb thêm bạn rồi khi click button kết bạn sẽ gửi lời kết bạn
        }

        private void XuatDanhSachBanBe() //xuất danh sách bạn bè và người dùng đã chấp nhận lời mời kết bạn.
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.AutoScroll = true;
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
                            flowLayoutPanel1.Controls.Add(userControls[i]);
                        }
                        if (userControls[i].Title == label1.Text)
                        {
                            flowLayoutPanel1.Controls.Remove(userControls[i]);
                        }
                        userControls[i].Click += userControl11_Click;

                    }
                }
            }
        }


        private void Chat_Form_Load(object sender, EventArgs e)
        {
            
            label1.Text = label3.Text = usernames; //truyền usernames vào các label của chủ tài khoản
            ContextChatDB context = new ContextChatDB();
          
            Login dblogin = loginservice.FindUsername(usernames);
            if (dblogin != null)
            {
                label1.Text = dblogin.Username;
                ThemHinhAnh(dblogin.image);
                ThemBackgroundImage(dblogin.BackgroundImage);
                txbMotaTrangChu.Text = dblogin.UserDescription;
                txbMotaTrangChu.Enabled = false;
                lblGender.Text = dblogin.Gender;
                dtpTrangChu.Enabled = false;
                dtpTrangChu.Value = dblogin.DateofBirth;
            }          
        }

        private void btnTrangChu_Click(object sender, EventArgs e) //btn để trả về trang chủ
        {
            panelTrangChu.BringToFront();
            panelMenu.Width = panelMenu.MinimumSize.Width;
            MenuExpend = false; //tắt thanh menu danh sách người dùng
            PanelMenuThoat.Width = PanelMenuThoat.MinimumSize.Width;
            MennuEXitExpend = false; //tắt thanh menu thoát
        }

        private void btnChatChung_Click(object sender, EventArgs e) //btn bấm vào để trả về trang chat chung
        {
            panelMenu.Width = panelMenu.MinimumSize.Width;
            MenuExpend = false; //tắt thanh menu danh sách người dùng
            PanelMenuThoat.Width = PanelMenuThoat.MinimumSize.Width;
            MennuEXitExpend = false; //tắt thanh menu thoát
            panelChatChung.BringToFront();
            XuatDanhSachBanBe();
        }

        private void btnHienThiThongTin_Click(object sender, EventArgs e)
        {
            ContextChatDB context = new ContextChatDB();
            friendrequesttruoc = context.AddFriends.Where(p => p.User2 == label1.Text && p.FriendRequestFlag == false).Count(); //đếm truyền vào biến toàn cục để kiểm tra qua timer
            if (friendrequesttruoc != 0) //nếu đếm có lời mời kết bạn thì hiện ra nút notification không thì cho ẩn
            {
                Notification.Visible = true;
            }
            else
            {
                Notification.Visible = false;
            }
            panelHienThiThongTin.BringToFront();       
            panelMenu.BringToFront();
            TimerMenu.Start(); 

            PanelMenuThoat.Width = PanelMenuThoat.MinimumSize.Width;
            MennuEXitExpend = false;

        }

        private void btnChinhSuaThongTin_Click(object sender, EventArgs e) //bấm vào sẽ truyền dữ liệu người dùng cũ vào các tính năng rồi đưa pnldoithongtin lên trước
        {
            pnlDoiThongTin.Visible = true;
            ContextChatDB context = new ContextChatDB();
            Login dbuser = context.Logins.FirstOrDefault(p => p.Username == usernames);
            ThemBackgroundImage(dbuser.BackgroundImage);
            txbChangeAboutMe.Text = dbuser.UserDescription;
            txbDoiEmail.Text = dbuser.Email;
            dtpDateofBirth.Value = dbuser.DateofBirth;
            if (dbuser.Gender == "Nam")
            {
                rbNam.Checked = true;
            }
            if (dbuser.Gender == "Nữ")
            {
                rbNu.Checked = true;
            }
            if (dbuser.Gender == "Non Binary")
            {
                rbNonBinary.Checked = true;
            }
            panelMenu.Width = panelMenu.MinimumSize.Width;
            MenuExpend = false;

            PanelMenuThoat.Width = PanelMenuThoat.MinimumSize.Width;
            MennuEXitExpend = false;

            pnlDoiThongTin.BringToFront();
        }
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            TimerMenu.Start();
        }

        private void TimerMenu_Tick(object sender, EventArgs e)
        {
            if ( MenuExpend )
            {
                panelMenu.Width -= 10;
                if ( panelMenu.Width == panelMenu.MinimumSize.Width)
                {
                    MenuExpend = false;
                    TimerMenu.Stop();
                }
            }
            else
            {
                panelMenu.Width += 10;
                if ( panelMenu.Width == panelMenu.MaximumSize.Width)
                {
                    MenuExpend = true;
                    TimerMenu.Stop();
                }
            }
        }


        private void CloseForm()
        {
            pnlToCaoNguoiDung.Visible = false;
            pnlYeuCauKetban.Visible = false;
            pnlTimKiemNguoiDung.Visible = false; 
            panelDanSachBanbe.Visible = false;
            pnlThongTin.Visible = false;
            panelAllUser.Visible= false;
        }

        private void btnReport_Click_1(object sender, EventArgs e) //button để mở panel report người dùng và truyền dữ liệu vào combo box lý do tố cáo
        {
            
            if (pnlToCaoNguoiDung.Visible == false)
            {
                CloseForm();
                panelMenu.Width = panelMenu.MinimumSize.Width;
                MenuExpend = false;
                pnlToCaoNguoiDung.Visible = true;
                ContextChatDB context = new ContextChatDB();
                List<Reason> listreason = reasonservice.GetAll();
               
                FillReportComboBox(listreason);
                pnlToCaoNguoiDung.Visible = true;
                DanhSachReport();
            }
            else
            {
                pnlToCaoNguoiDung.Visible = false;
            }


        }

        private void btnThemBann_Click(object sender, EventArgs e) //Them ban
        {
            CloseForm();
            panelMenu.Width = panelMenu.MinimumSize.Width;
            MenuExpend = false;
            pnlTimKiemNguoiDung.Visible = true;
            DanhSachThemBanBe();
        }

        private void btnThongBao_Click_1(object sender, EventArgs e) //Mở xem thông báo
        {
            CloseForm();
            panelMenu.Width = panelMenu.MinimumSize.Width;
            MenuExpend = false;
            pnlYeuCauKetban.Visible = true;
            XuatDanhSachKetBan();
        }

        private void XuatDanhSachKetBan() //xuất danh sách tất cả những người đã gửi lời mời kết bạn đến người dùng
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
        private void Btnusercontrols(object sender, EventArgs e) //truyền title của usercontrol vào textbox 
        {
            UserControl1 userControls = sender as UserControl1;
            txbTimBan.Text = userControls.Title;
        }
        private void btnTimKiem_Click(object sender, EventArgs e) //btn tìm kiếm trong danh sách
        {
            CloseForm();
            panelMenu.Width = panelMenu.MinimumSize.Width;
            MenuExpend = false;
            panelAllUser.Visible = true;
            DanhSachNguoiDung();
        }
        private void XuatDanhSachBanBe1()
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
                        //userControls[i].Click += userControl11_Click;

                    }
                }
            }
        }

        private void btnListFiend_Click_1(object sender, EventArgs e)
        {
            CloseForm();
            panelMenu.Width = panelMenu.MinimumSize.Width;
            MenuExpend = false;
            panelDanSachBanbe.Visible = true;
            panelDanSachBanbe.BringToFront();
            label13.Text = "Danh Sách Bạn Bè ";
            XuatDanhSachBanBe1();
        }
        private void DanhSachReport() //xuất danh sách report có event click 
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

        private void Btnusercontrols2(object sender, EventArgs e)
        {
            UserControl1 userControls = sender as UserControl1;
            txbUserreport.Text = userControls.Title;
        }

        private void FillReportComboBox(List<Reason> listreason) //fill combo box
        {
            this.cmbReportreason.DataSource = listreason;
            this.cmbReportreason.DisplayMember = "Reasons";
            this.cmbReportreason.ValueMember = "ReportReasonID";
        }


        private void btnReportUser_Click(object sender, EventArgs e) //report người dùng
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
                    CloseForm();
                    Chat_Form_Load(sender, e);
                    MessageBox.Show("Report Thành Công !", " Thông Báo", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("Report Không Thành Công !", " Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void txbUserreport_TextChanged(object sender, EventArgs e) //kiểm tra textchanged 
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
            if (txbUserreport.Text == "")
            {
                flpReportuser.Visible = true;
            }
        }

        private void btnDongy_Click(object sender, EventArgs e) //nhấp đồng ý thì trả friendrequestflag true rồi refresh danh sách
        {
            ContextChatDB context = new ContextChatDB();
            AddFriend dbAcceptFriend = context.AddFriends.FirstOrDefault(p => p.User1 == txbTimBan.Text && p.User2 == label1.Text);
            if (dbAcceptFriend != null)
            {
                dbAcceptFriend.FriendRequestFlag = true;
                context.SaveChanges();
                txbTimBan.Clear();
                XuatDanhSachKetBan();
                MessageBox.Show("Kết Bạn Thành Công !", " Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btnKhongdongy_Click(object sender, EventArgs e) //nhấp không đồng ý thì xóa khỏi danh sách rồi refresh
        {
            ContextChatDB context = new ContextChatDB();
            AddFriend dbNoAcceptFriend = context.AddFriends.FirstOrDefault(p => p.User1 == txbTimBan.Text && p.User2 == label1.Text);
            if (dbNoAcceptFriend != null)
            {
                context.AddFriends.Remove(dbNoAcceptFriend);
                context.SaveChanges();
                txbTimBan.Clear();
                XuatDanhSachKetBan();
                MessageBox.Show("Đã không chấp nhận kết bạn !", " Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            ContextChatDB context = new ContextChatDB();
            List<AddFriend> listfriend = new List<AddFriend>();
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
                AddFriend dbcheckfriend = addfriendservice.CheckAddFriendUser(txbThemBan.Text, label1.Text);
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
                    add.User2 = txbThemBan.Text;
                    add.FriendRequestFlag = false;
                    add.DateTime = DateTime.Now;
                    addfriendservice.InsertAddFriend(add);
                    MessageBox.Show("Gửi Lời Kết Bạn Thành Công !", " Thông Báo", MessageBoxButtons.OK);
                    txbThemBan.Clear();
                    
                }
            }
            catch
            {
                MessageBox.Show("Đã gửi lời kết bạn/đã kết bạn với người này !", " Thông Báo", MessageBoxButtons.OK);
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
                UserControl1 nguoichat = new UserControl1();
                nguoichat.Size = new Size(550, 71);
                nguoichat.BackColor = Color.Cyan;
                nguoichat.Title = user.Title;
                nguoichat.Icon = user.Icon;
                nguoichat.Status = user.Status;
                iconchat = user;
                PanelChat.Controls.Clear();
                PanelChat.Controls.Add(nguoichat);
                CreatedTextAndSendButton(PanelChat, nguoichat.Title);
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
                using (var transaction = context.Database.BeginTransaction())
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
                    catch (Exception ex)
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
            Mess = new Guna2TextBox();
            Mess.Multiline = true;
            Mess.Location = new Point(2, 457);
            Mess.Size = new Size(387, 44);

            SendBtn = new Guna2Button();
            SendBtn.Text = "Gửi";
            SendBtn.Size = new Size(88, 45);
            SendBtn.Location = new Point(395, 456);
            SendBtn.FillColor = Color.Crimson;
           // SendBtn.BackColor = Color.White;


            ChatArea = new Panel();
            ChatArea.Location = new Point(3, 74);
            ChatArea.Size = new Size(488, 381);
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

        private void BindGridMess(List<Messenger> MessList, string userchat)
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
                        user1.Location = new Point(150, y);
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
            if (ChatArea != null)
            {
                sau = messengerservice.CountMessage(usernames);
                if (truoc != sau)
                {
                    var MessList = messengerservice.GetAllMessage(usernames);
                    BindGridMess(MessList, usercchat);
                    ChatArea.VerticalScroll.Value = ChatArea.VerticalScroll.Maximum;
                    truoc = sau;
                }
            }
            friendrequestsau = context.AddFriends.Where(p => p.User2 == label1.Text && p.FriendRequestFlag == false).Count();
            if (pnlYeuCauKetban == null)
            {
                if (friendrequesttruoc != friendrequestsau)
                {
                    Notification.Visible = true;
                }

            }
            statussau = loginservice.StatusCount();
            if (statustruoc != statussau)
            {
                if (panelAllUser.Visible == true)
                {
                    DanhSachNguoiDung();
                }
                if (panelDanSachBanbe.Visible == true)
                {
                    XuatDanhSachBanBe();
                }
                if (pnlToCaoNguoiDung.Visible == true)
                {
                    DanhSachReport();
                }
                if (flowControlFriendRequest.Visible == true)
                {
                    XuatDanhSachKetBan();
                }
                if (FlowUserControlThemBan.Visible == true)
                {
                    DanhSachThemBanBe();
                }   
                statustruoc = statussau;
            }
        }

        private void TimerMenuThoat_Tick(object sender, EventArgs e)
        {
            if (MennuEXitExpend)
            {
                PanelMenuThoat.Width -= 10;
                if (PanelMenuThoat.Width == PanelMenuThoat.MinimumSize.Width)
                {
                    MennuEXitExpend = false;
                    TimerMenuThoat.Stop();
                }
            }
            else
            {
                PanelMenuThoat.Width += 10;
                if (PanelMenuThoat.Width == PanelMenuThoat.MaximumSize.Width)
                {
                    MennuEXitExpend = true;
                    TimerMenuThoat.Stop();
                }
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
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
                this.Visible = false;
                form1.Visible = true;

         
        }

        private void btnCookLn_Click(object sender, EventArgs e)
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
            this.Close();
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

        private void txbTimBan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbTimBan_TextChanged_1(object sender, EventArgs e)
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
            if (txbTimBan.Text == "")
            {
                flowLayoutPanel1.Visible = true;
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            ContextChatDB context = new ContextChatDB();
            Login dbupdate = context.Logins.FirstOrDefault(p => p.Username == usernames);
            Login dbuser = context.Logins.FirstOrDefault(p => p.Username == usernames);
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
            if (dbupdate != null)
            {
                if (txbDoiEmail.Text != "")
                {
                    dbupdate.Email = txbDoiEmail.Text;
                }
                if (filename.ToString() != "")
                {
                    dbupdate.image = filename.ToString();
                }
                if (backgroundimagefilename.ToString() != "")
                {
                    dbupdate.BackgroundImage = backgroundimagefilename.ToString();
                }
                if(rbNam.Checked == true)
                {
                    dbupdate.Gender = "Nam";
                }
                if(rbNu.Checked == true)
                {
                    dbupdate.Gender = "Nữ";
                }
                if(rbNonBinary.Checked == true)
                {
                    dbupdate.Gender = "Non Binary";
                }
                dbupdate.UserDescription = txbChangeAboutMe.Text;
                dbupdate.DateofBirth = dtpDateofBirth.Value;
                context.SaveChanges();
                Chat_Form_Load(sender, e);
                MessageBox.Show("Sửa Thành Công ! ", "Thông Báo", MessageBoxButtons.OK);
                pnlDoiThongTin.Visible = false;
            }
        }

        private void Chat_Form_FormClosed(object sender, FormClosedEventArgs e)
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

        private void pcbDoiThongTin_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filename = Path.GetFileName(dlg.FileName);
                var image = Image.FromFile(dlg.FileName);
                pcbDoiThongTin.Image = image;
                string source = dlg.FileName;
                if (File.Exists(destination + Path.GetFileName(dlg.FileName)))
                {

                }
                else
                {
                    File.Copy(source, destination + Path.GetFileName(dlg.FileName), true);
                }
            }
        }

        private void pcbBackgroundImageChinhSua_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                backgroundimagefilename = Path.GetFileName(dlg.FileName);
                var image = Image.FromFile(dlg.FileName);
                pcbBackgroundImageChinhSua.Image = image;
                string source = dlg.FileName;
                if (File.Exists(destination + Path.GetFileName(dlg.FileName)))
                {

                }
                else
                {
                    File.Copy(source, destination + Path.GetFileName(dlg.FileName), true);
                }
            }
        }

        private void pcbExit_Click(object sender, EventArgs e)
        {
            pnlDoiMatKhau.Visible = false;
        }

        private void btnCapNhatMatKhau_Click(object sender, EventArgs e)
        {
            ContextChatDB context = new ContextChatDB();
            Login dbupdate = context.Logins.FirstOrDefault(p => p.Username == usernames);
            Login dbuser = context.Logins.FirstOrDefault(p => p.Username == usernames);
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
            if (dbupdate != null)
            {
                dbupdate.Password = txbDoipassword.Text;
                dbupdate.ConfirmPass = txbNhaplaipassword.Text;
                context.SaveChanges();
                MessageBox.Show("Sửa Thành Công ! ", "Thông Báo", MessageBoxButtons.OK);
                pnlDoiMatKhau.Visible = false;
                txbOldpassword.Clear();
                txbDoipassword.Clear();
                txbNhaplaipassword.Clear();
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (pnlDoiMatKhau.Visible == false)
                pnlDoiMatKhau.Visible = true;
            else
                pnlDoiMatKhau.Visible = false;
        }
    }
}
