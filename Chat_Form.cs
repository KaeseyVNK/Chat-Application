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
        Guna2TextBox Mess;
        Guna2Button SendBtn;
        Panel ChatArea;
        string usercchat;

        int mov;
        int movX;
        int movY;


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
            //đưa menu thoát lên đầu
            panelThoat.BringToFront(); 
            //đưa panel menu thoát lên
            PanelMenuThoat.BringToFront(); 
            //kéo thanh exit ra 2 chức năng là thoát chương trình và đăng xuất
            TimerMenuThoat.Start(); 
            panelMenu.Width = panelMenu.MinimumSize.Width;
            MenuExpend = false;
        }
        //Hàm thêm hình ảnh cho người dùng đang sử dụng
        private void ThemHinhAnh(string Imagename) 
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
        //Hàm thêm hình ảnh background cho người đang sử dụng
        private void ThemBackgroundImage(string Imagename) 
        {
            if (string.IsNullOrEmpty(Imagename))
            {
                pcbBackgroundTrangChu.Image = null;
            }
            else
            {
                //lấy địa chỉ tới thư mục hiện tại
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                //lất tới địa chỉ của thư mục Imgaes từ thư mục có địa chỉ parentDirectory
                string imagepath = Path.Combine(parentDirectory, "Images", Imagename);
                pcbBackgroundImageChinhSua.Image = Image.FromFile(imagepath);
                pcbTrangChu.SizeMode = PictureBoxSizeMode.Zoom;
                pcbBackgroundTrangChu.Image = Image.FromFile(imagepath);
                pcbBackgroundTrangChu.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        //Thêm hình ảnh cho người dùng có trong panel tìm kiếm người dùng khi bấm vào click event của all user
        private void ThemHinhAnhUser(string Imagename) 
        {
            if (string.IsNullOrEmpty(Imagename))
            {
                pcbAlluserimage.Image = null;
            }
            else
            {
                //lấy địa chỉ tới thư mục hiện tại
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                //lất tới địa chỉ của thư mục Imgaes từ thư mục có địa chỉ parentDirectory
                string imagepath = Path.Combine(parentDirectory, "Images", Imagename);
                pcbAlluserimage.Image = Image.FromFile(imagepath);
                pcbAlluserimage.Refresh();
            }
        }
        //Thêm hình ảnh background cho người dùng có trong panel tìm kiếm người dùng khi bấm vào click event của all user
        private void ThemBackgroundUser(string Imagename) 
        {
            if (string.IsNullOrEmpty(Imagename))
            {
                pcbAllUserBackground.Image = null;
            }
            else
            { 
                //lấy địa chỉ tới thư mục hiện tại
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                //lất tới địa chỉ của thư mục Imgaes từ thư mục có địa chỉ parentDirectory
                string imagepath = Path.Combine(parentDirectory, "Images", Imagename);          
                pcbAllUserBackground.Image = Image.FromFile(imagepath);
                pcbAllUserBackground.Refresh();
            }
        }
        private void DanhSachNguoiDung() //Xuất danh sách của tất cả tài khoản 
        {
            //clear những control cũ của layoutpanel
            flowLayoutPanel3.Controls.Clear(); 
            flowLayoutPanel3.AutoScroll = true;
            ContextChatDB context = new ContextChatDB();
            var listusername = loginservice.GetAll();
            var countusername = loginservice.CountAll();
            //Đếm status của tất cả các usercontrol để kiểm tra
            statustruoc = loginservice.StatusCount(); 
            UserControl1[] userControls = new UserControl1[countusername];
            for (int i = 0; i < 1; i++)
            {
                foreach (var username in listusername)
                {
                    //khởi tạo usercontrol 1 rồi truyền dữ liệu vào usercontrol
                    userControls[i] = new UserControl1(); 
                    userControls[i].Title = username.Username;
                    userControls[i].Icon = username.image;
                    userControls[i].Status = username.UserStatus.ToString();
                    // Nếu click vào usercontrol thì sẽ đưa tới event ClickAllUser
                    userControls[i].Click += ClickAllUser;
                    //nếu trùng với tên của tên tài khoản đang sử dụng thì xóa
                    if (userControls[i].Title == label1.Text) 
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
        //chức năng kết bạn qua profile của người khác
        private void ClickAllUser(object sender, EventArgs e) 
        {
            UserControl1 userControls = sender as UserControl1;
            //xóa button cũ
            foreach (Control control in pnlThongTin.Controls) 
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
                AddFriend dbaddfriendFalse = context.AddFriends.FirstOrDefault(p => p.User1 == label1.Text && p.User2 == userControls.Title && p.FriendRequestFlag == false);
                AddFriend dbaddfriendFalseuser = context.AddFriends.FirstOrDefault(p => p.User1 == userControls.Title && p.User2 == label1.Text && p.FriendRequestFlag == false);
                var listfriend = addfriendservice.GetAll();
                //tạo button kiểm tra
                SendBtn = new Guna2Button(); 
                //nếu người dùng đã kết bạn
                if (dbaddfriendTrue != null) 
                {
                    SendBtn.Text = " Đã Kết Bạn";
                    SendBtn.Size = new Size(180, 45);
                    SendBtn.Location = new Point(240, 404);
                    SendBtn.FillColor = Color.Crimson;
                    pnlThongTin.Controls.Add(SendBtn);
                    SendBtn.Enabled = false;
                }
                //nếu người dùng đã gửi lời kết bạn nhưng người kia chưa chấp nhận
                else if (dbaddfriendFalse != null) 
                {
                    SendBtn.Text = "Đã Gửi Kết Bạn";
                    SendBtn.Size = new Size(180, 45);
                    SendBtn.Location = new Point(240, 404);
                    SendBtn.FillColor = Color.Crimson;
                    pnlThongTin.Controls.Add(SendBtn);
                    SendBtn.Enabled = false;
                }
                //nếu người dùng được gửi lời mời kết bạn và chưa chấp nhận
                else if(dbaddfriendFalseuser != null)
                {
                    SendBtn.Text = "Chấp nhận kết bạn";
                    SendBtn.Size = new Size(180, 45);
                    SendBtn.Location = new Point(240, 404);
                    SendBtn.FillColor = Color.Crimson;
                    //khi click vào sẽ bặt đầu thêm dữ liệu kết bạn vào csdl
                    SendBtn.Click += acceptfriendclick;
                    pnlThongTin.Controls.Add(SendBtn);
                }
                //nếu cả ba điều kiện không xảy ra
                else if (dbaddfriendTrue == null && dbaddfriendFalse == null && dbaddfriendFalseuser == null) 
                {
                    SendBtn.Text = "Kết Bạn !";
                    SendBtn.Size = new Size(180, 45);
                    SendBtn.Location = new Point(240, 404);
                    SendBtn.FillColor = Color.Crimson;
                    //khi click vào sẽ bặt đầu thêm dữ liệu kết bạn vào csdl
                    SendBtn.Click += addfriendclick;
                    pnlThongTin.Controls.Add(SendBtn);
                }
                //truyền thông tin người dùng bạn đang tìm kiếm.
                if (dbuser != null) 
                {
                    lblAllusername.Text = dbuser.Username.ToString(); 
                    lblAllusergender.Text = dbuser.Gender.ToString();
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
        private void acceptfriendclick(object sender, EventArgs e)
        {
            ContextChatDB context = new ContextChatDB();
            AddFriend dbAcceptFriend = context.AddFriends.FirstOrDefault(p => p.User1 == lblAllusername.Text && p.User2 == label1.Text);
            if (dbAcceptFriend != null)
            {
                dbAcceptFriend.FriendRequestFlag = true;
                //Lưu vào cơ sở dữ liệu
                context.SaveChanges();
                //Cập nhật lại Danh sách kết bạn
                MessageBox.Show("Kết Bạn Thành Công !", " Thông Báo", MessageBoxButtons.OK);
                SendBtn.Text = "Đã Kết Bạn";
                SendBtn.Enabled = false;
            }
        }
        private void addfriendclick(object sender, EventArgs e)
        {
            try
            {
                UserControl1 userControls = sender as UserControl1;
                ContextChatDB context = new ContextChatDB();
                Login dbAddFriend = loginservice.FindUsername(lblAllusername.Text);
                AddFriend dbcheckfriend = addfriendservice.CheckAddFriendUser(lblAllusername.Text,label1.Text);
                //kiểm tra xem người dùng đã kết bạn hay đã gửi lời kết bạn chưa
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
                    //Thêm bạn bè
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
        //hàm đóng đồng loạt tất cả các panel
        private void ClosePanel()
        {
            pnlTimKiemNguoiDung.Visible = false;
            pnlToCaoNguoiDung.Visible = false;
            pnlYeuCauKetban.Visible = false;
            panelDanSachBanbe.Visible = false;
            pnlThongTin.Visible = false;
        }
        //dánh sách dùng để kiểm tra để kết bạn với bạn bè
        private void DanhSachThemBanBe() 
        {

            FlowUserControlThemBan.Controls.Clear();
            FlowUserControlThemBan.AutoScroll = true;
            ContextChatDB context = new ContextChatDB();
            var listusername = loginservice.GetAll();
            var countusername = loginservice.CountAll();
            UserControl1[] userControls = new UserControl1[countusername];
            //Tạo Danh Sach thêm bạ bè
            for (int i = 0; i < 1; i++)
            {
                foreach (var username in listusername)
                {
                    userControls[i] = new UserControl1();
                    userControls[i].Title = username.Username;
                    userControls[i].Icon = username.image;
                    userControls[i].Status = username.UserStatus.ToString();
                    //bấm vào sẽ truyền tên của usercontrol vào textbox rồi sau đó kết bạn
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
            //truyền vào txb thêm bạn rồi khi click button kết bạn sẽ gửi lời kết bạn
            txbThemBan.Text = userControls.Title; 
        }
        //xuất danh sách bạn bè và người dùng đã chấp nhận lời mời kết bạn.
        private void XuatDanhSachBanBe() 
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.AutoScroll = true;
            ContextChatDB context = new ContextChatDB();
            var listusername = loginservice.GetAll();
            var listfriend = addfriendservice.GetAll();
            var countusername = loginservice.CountAll();
            UserControl1[] userControls = new UserControl1[countusername];
            // tạo một danh sách các user control 
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
                        if (userControls[i].Title == friend.User2 && friend.User1 == label1.Text && friend.FriendRequestFlag == true || userControls[i].Title == friend.User1 
                            && friend.User2 == label1.Text && friend.FriendRequestFlag == true) 
                        {
                            flowLayoutPanel1.Controls.Add(userControls[i]);
                        }
                        if (userControls[i].Title == label1.Text)
                        {
                            flowLayoutPanel1.Controls.Remove(userControls[i]);
                        }
                        //Khi người dùng click vào user control thì thực hiện event UserControl11_Click
                        userControls[i].Click += userControl11_Click; 

                    }
                }
            }
        }


        private void Chat_Form_Load(object sender, EventArgs e)
        {
            //truyền usernames vào các label của chủ tài khoản
            ContextChatDB context = new ContextChatDB();
            label1.Text = label3.Text = usernames;
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
        //btn để trả về trang chủ
        private void btnTrangChu_Click(object sender, EventArgs e) 
        {
            panelTrangChu.BringToFront();
            panelMenu.Width = panelMenu.MinimumSize.Width;
            //tắt thanh menu danh sách người dùng
            MenuExpend = false; 
            PanelMenuThoat.Width = PanelMenuThoat.MinimumSize.Width;
            //tắt thanh menu thoát           
            MennuEXitExpend = false; 
        }
        //btn bấm vào để trả về trang chat chung
        private void btnChatChung_Click(object sender, EventArgs e)
        {
            panelMenu.Width = panelMenu.MinimumSize.Width;
            //tắt thanh menu danh sách người dùng
            MenuExpend = false; 
            PanelMenuThoat.Width = PanelMenuThoat.MinimumSize.Width;
            //tắt thanh menu thoát
            MennuEXitExpend = false; 
            panelChatChung.BringToFront();
            XuatDanhSachBanBe();
        }

        private void btnHienThiThongTin_Click(object sender, EventArgs e)
        {
            ContextChatDB context = new ContextChatDB();
            //đếm truyền vào biến toàn cục để kiểm tra qua timer
            friendrequesttruoc = context.AddFriends.Where(p => p.User2 == label1.Text && p.FriendRequestFlag == false).Count(); 
            //nếu đếm có lời mời kết bạn thì hiện ra nút notification không thì cho ẩn
            if (friendrequesttruoc != 0) 
            {
                Notification.Visible = true;
            }
            else
            {
                Notification.Visible = false;
            }
            //Đưa các panel lên đầu 
            panelHienThiThongTin.BringToFront();       
            panelMenu.BringToFront();
            TimerMenu.Start(); 

            PanelMenuThoat.Width = PanelMenuThoat.MinimumSize.Width;
            MennuEXitExpend = false;

        }
        //bấm vào sẽ truyền dữ liệu người dùng cũ vào các tính năng rồi đưa pnldoithongtin lên trước
        private void btnChinhSuaThongTin_Click(object sender, EventArgs e) 
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
        //khi nhấn sẽ bắt đầu
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            TimerMenu.Start();
        }

        private void TimerMenu_Tick(object sender, EventArgs e)
        {
            //Nếu thanh menu đang đc mở thì khi sẽ trừ 
            if ( MenuExpend )
            {

                panelMenu.Width -= 10;
                //nếu panel bằng mới MinimunSize thì sẽ dừng
                if ( panelMenu.Width == panelMenu.MinimumSize.Width)
                {
                    MenuExpend = false;
                    //dừng
                    TimerMenu.Stop();
                }
            }
            //Nếu thanh menu đang đc đòng thì khi sẽ mở 
            else
            {
                panelMenu.Width += 10;
                //Nếu panel bằng với MaximunSize thì sẽ dừng
                if ( panelMenu.Width == panelMenu.MaximumSize.Width)
                {
                    MenuExpend = true;
                    //dừng
                    TimerMenu.Stop();
                }
            }
        }

        // Dóng tất cả các panel
        private void CloseForm()
        {
            pnlToCaoNguoiDung.Visible = false;
            pnlYeuCauKetban.Visible = false;
            pnlTimKiemNguoiDung.Visible = false; 
            panelDanSachBanbe.Visible = false;
            pnlThongTin.Visible = false;
            panelAllUser.Visible= false;
        }
        //button để mở panel report người dùng và truyền dữ liệu vào combo box lý do tố cáo
        private void btnReport_Click_1(object sender, EventArgs e)
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
        //Them ban
        private void btnThemBann_Click(object sender, EventArgs e) 
        {
            CloseForm();
            panelMenu.Width = panelMenu.MinimumSize.Width;
            MenuExpend = false;
            pnlTimKiemNguoiDung.Visible = true;
            DanhSachThemBanBe();
        }
        //Mở xem thông báo
        private void btnThongBao_Click_1(object sender, EventArgs e) 
        {
            CloseForm();
            panelMenu.Width = panelMenu.MinimumSize.Width;
            MenuExpend = false;
            pnlYeuCauKetban.Visible = true;
            XuatDanhSachKetBan();
        }
        //xuất danh sách tất cả những người đã gửi lời mời kết bạn đến người dùng
        private void XuatDanhSachKetBan() 
        {
            flowControlFriendRequest.Controls.Clear();
            flowControlFriendRequest.AutoScroll = true;
            ContextChatDB context = new ContextChatDB();
            var listusername = loginservice.GetAll();
            var listfriend = addfriendservice.GetAll();
            var countusername = loginservice.CountAll();
            UserControl1[] userControls = new UserControl1[countusername];
            //Xuất danh sách Kết bạn
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
                        // Khi người dùng nhấn vào UserControls[i] thì sẽ thực hiện event BtnUserControls
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
                        if (userControls[i].Title == friend.User2 && friend.User1 == label1.Text && friend.FriendRequestFlag == true || 
                            userControls[i].Title == friend.User1 && friend.User2 == label1.Text && friend.FriendRequestFlag == true)
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
            //Xuất danh sách Người dùng Report
            for (int i = 0; i < 1; i++)
            {
                foreach (var username in listusername)
                {
                    userControls[i] = new UserControl1();
                    userControls[i].Title = username.Username;
                    userControls[i].Icon = username.image;
                    userControls[i].Status = username.UserStatus.ToString();
                    //Khi người dùng nhấn vào UsertControls[i] thì sẽ thực hiện event BtnUsercontrol2
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
                    //Thêm người dùng bị tố cáo
                    ReportUser report = new ReportUser();
                    report.ReportUser1 = label1.Text;
                    report.ReportedUser = txbUserreport.Text;
                    report.ReportReasonID = (cmbReportreason.SelectedItem as Reason).ReportReasonID;
                    report.Note = txbNote.Text;
                    context.ReportUsers.Add(report);
                    //Lưu vào cơ sở dữ liệu
                    context.SaveChanges();
                    CloseForm();
                    //Load lại chat form
                    Chat_Form_Load(sender, e);
                    MessageBox.Show("Report Thành Công !", " Thông Báo", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("Report Không Thành Công !", " Thông Báo", MessageBoxButtons.OK);
            }
        }
        //Hiện tên UserReport theo tên chữ bạn nhập
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
                //Lưu vào cơ sở dữ liệu
                context.SaveChanges();
                txbTimBan.Clear();
                //Cập nhật lại Danh sách kết bạn
                XuatDanhSachKetBan();
                MessageBox.Show("Kết Bạn Thành Công !", " Thông Báo", MessageBoxButtons.OK);
            }
        }
        //nhấp không đồng ý thì xóa khỏi danh sách rồi refresh
        private void btnKhongdongy_Click(object sender, EventArgs e) 
        {
            ContextChatDB context = new ContextChatDB();
            AddFriend dbNoAcceptFriend = context.AddFriends.FirstOrDefault(p => p.User1 == txbTimBan.Text && p.User2 == label1.Text);
            if (dbNoAcceptFriend != null)
            {
                context.AddFriends.Remove(dbNoAcceptFriend);
                //Lưu vào cơ sở dữ liệu
                context.SaveChanges();
                txbTimBan.Clear();
                //Cập nhật lại danh sách kết bạn
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
                //Hiện lỗi khi người dùng không thoã mãn các yêu cầu
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
                //Kiểm tra xem kết quả kết bạn
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
                    //Thêm Bạn cho người dùng này
                    AddFriend add = new AddFriend();
                    add.User1 = usernames;
                    add.User2 = txbThemBan.Text;
                    add.FriendRequestFlag = false;
                    add.DateTime = DateTime.Now;
                    //Lưu vào cơ sở dữ liệu
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
            // Kiểm tra xem có UserControl trong PanelChat nếu có thì xoá bỏ nó 
            // reset lại panelChat
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
                //** chỉnh sửa UI Usercontrol NguoiChat
                nguoichat.Size = new Size(550, 71);
                nguoichat.BackColor = Color.Cyan;
                nguoichat.Title = user.Title;
                nguoichat.Icon = user.Icon;
                nguoichat.Status = user.Status;
                //--------------------------------------------
                iconchat = user;
                PanelChat.Controls.Clear();
                //áp dụng UserControl nguoichat vào PanelChat
                PanelChat.Controls.Add(nguoichat);
                CreatedTextAndSendButton(PanelChat, nguoichat.Title);
                usercchat = nguoichat.Title;
                ChatArea.VerticalScroll.Value = ChatArea.VerticalScroll.Maximum;
            }
            //Nếu người dùng nhấn lại một lần nữa, kiểm tra xem có phải người mình đang nhắn ko nếu có thì tắt
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
                //sử dụng transaction để khi có lỗi khi gửi thì sẽ rollback về trước khi gửi
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //tạo mới một table Messenger trong cơ sở dữ liệu
                        Messenger mess = new Messenger();
                        mess.Username1 = usernames;
                        mess.Username2 = usercchat;
                        mess.Messenger1 = Mess.Text;
                        mess.TimeMessenger = DateTime.Now;
                        //thêm vào cơ sở dữ liệu
                        messengerservice.InsertMessage(mess);
                        ChatArea.Controls.Clear();
                        var MessList = messengerservice.GetAllMessage(usernames);
                        //kiểm tra xem số lượng tin nhắn trong cơ sở dữ liệu
                        truoc = messengerservice.CountMessage(usernames);
                        //Load đoạn chat tin nhắn
                        BindGridMess(MessList, usercchat);
                        //  ChatArea.VerticalScroll.Value = ChatArea.VerticalScroll.Maximum;
                        //Không có lỗi, lưu vào cơ sở dữ liệu
                        transaction.Commit();
                        Mess.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Da Co Loi Khi Gui Tin Nhan!!!");
                        //có lỗi xảy ra, đưa dữ liệu về trạng thái trước khi thực hiện event
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
            //tạo mới khu vực nhập nội dung tin nhắn
            Mess = new Guna2TextBox();
            Mess.Multiline = true;
            Mess.Location = new Point(2, 457);
            Mess.Size = new Size(387, 44);

            //tạo mới button gửi tin nhắn
            SendBtn = new Guna2Button();
            SendBtn.Text = "Gửi";
            SendBtn.Size = new Size(88, 45);
            SendBtn.Location = new Point(395, 456);
            SendBtn.FillColor = Color.Crimson;
           // SendBtn.BackColor = Color.White;

            // tạo mới khu vực hiện tin nhắn
            ChatArea = new Panel();
            ChatArea.Location = new Point(3, 74);
            ChatArea.Size = new Size(488, 381);
            ChatArea.BackColor = Color.White;
            ChatArea.AutoScroll = true;

            //Khi người dùng nhấn vào button SenBtn thì sẽ thực hiện event btnGui_Click
            SendBtn.Click += btnGui_Click;

            ContextChatDB context = new ContextChatDB();
            var MessList = messengerservice.GetAllMessage(usernames);
            truoc = messengerservice.CountMessage(usernames);
            //Mess.Text = MessList.Count.ToString();

            BindGridMess(MessList, userchat);
            //Đưa thanh cuộn vào cuối
            ChatArea.VerticalScroll.Value = ChatArea.VerticalScroll.Maximum;
            usercchat = userchat;


            // Áp dụng tất cả vào trong Panel
            panel.Controls.Add(ChatArea);
            panel.Controls.Add(SendBtn);
            panel.Controls.Add(Mess);

        }

        private void BindGridMess(List<Messenger> MessList, string userchat)
        {
            //Kiểm tra MessList có lớn hơn 0
            if (MessList.Count > 0)
            {
                //vị trí đoạn chat đầu tiên
                int y = 0;
                foreach (var mess in MessList)
                {
                    if (mess.Username1 == usernames && mess.Username2 == userchat)
                    {
                        //Tạo một UserControl tên là User1
                        User1 user1 = new User1();
                        user1.Title = mess.Messenger1;
                        user1.Location = new Point(150, y);
                        //Đưa vào panel ChatArea
                        ChatArea.Controls.Add(user1);
                        //cập nhật tới vị trí tiếp theo
                        y += 60;
                    }
                    else
                        if (mess.Username1 == userchat && mess.Username2 == usernames)
                    {
                        //Tạo một UserControl tên là User2
                        User2 user2 = new User2();
                        user2.Title = mess.Messenger1;
                        user2.Location = new Point(0, y);
                        user2.Icon = iconchat.Icon;
                        //Đưa vào Panel ChatArea
                        ChatArea.Controls.Add(user2);
                        //cập nhật tới vị trí tiếp theo
                        y += 60;
                    }
                    ChatArea.Refresh();
                }
            }
            ChatArea.VerticalScroll.Value = ChatArea.VerticalScroll.Maximum;
        }

        //Hàm kiểm tra lại có sự khác nhau về cơ sỡ dữ liệu và load lại thanh trạng thái của các user
        private void timer1_Tick(object sender, EventArgs e)
        {
            panel3.BringToFront();
            ContextChatDB context = new ContextChatDB();
            //Kiểm tra xem panel ChatArea có khác rỗng hay kh
            if (ChatArea != null)
            {
                //Kiểm số lượng tin nhắn
                sau = messengerservice.CountMessage(usernames);
                //Kiểm tra số lượng tin nhắn trong cơ sỡ dữ liệu có khác nhau mỗi giây hay ko nếu có thì load lại tin nhắn
                if (truoc != sau)
                {
                    var MessList = messengerservice.GetAllMessage(usernames);
                    BindGridMess(MessList, usercchat);
                    ChatArea.VerticalScroll.Value = ChatArea.VerticalScroll.Maximum;
                    // gán lại số lượng, để tránh load tin nhắn liên tục
                    truoc = sau;
                }
            }

            //Load lại các trạng thái của user
            friendrequestsau = context.AddFriends.Where(p => p.User2 == label1.Text && p.FriendRequestFlag == false).Count();
            if (pnlYeuCauKetban == null)
            {
                if (friendrequesttruoc != friendrequestsau)
                {
                    Notification.Visible = true;
                }

            }
            statussau = loginservice.StatusCount();
            //Nếu có sự thay đổi cơ sỡ dữ liệu thì sẽ cập nhật lại trạng thái của người dùng
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
                if(flowLayoutPanel1.Visible == true)
                {
                    XuatDanhSachKetBan();
                }
                statustruoc = statussau;
            }
        }

        //Hàm thực hiện Animation của MenuThoat
        private void TimerMenuThoat_Tick(object sender, EventArgs e)
        {
            //Nếu thanh menu đang đc mở thì khi sẽ trừ 
            if (MennuEXitExpend)
            {
                PanelMenuThoat.Width -= 10;
                //nếu panel bằng mới MinimunSize thì sẽ dừng
                if (PanelMenuThoat.Width == PanelMenuThoat.MinimumSize.Width)
                {
                    MennuEXitExpend = false;
                    //dừng
                    TimerMenuThoat.Stop();
                }
            }
            //Nếu thanh menu đang đc đòng thì khi sẽ mở 
            else
            {
                PanelMenuThoat.Width += 10;
                //Nếu panel bằng với MaximunSize thì sẽ dừng
                if (PanelMenuThoat.Width == PanelMenuThoat.MaximumSize.Width)
                {
                    MennuEXitExpend = true;
                    //dừng
                    TimerMenuThoat.Stop();
                }
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            //Cập nhật lại thanh trạng thái của User nếu người dùng nhất nút đăng xuất
                ContextChatDB context = new ContextChatDB();
                var listuser = context.Logins.ToList();
                foreach (Login user in listuser)
                {
                    if (user.Username == label1.Text)
                    {
                        user.UserStatus = false;
                        //Lưu thông tin vào cơ sở dữ liệu
                        context.SaveChanges();
                    }
                }
                this.Visible = false;
                form1.Visible = true;

         
        }

        private void btnCookLn_Click(object sender, EventArgs e)
        {
            //Cập nhật lại thanh trạng thái của User nếu người dùng nhấn nút thoát
            ContextChatDB context = new ContextChatDB();
            var listuser = context.Logins.ToList();
            foreach (Login user in listuser)
            {
                if (user.Username == label1.Text)
                {
                    user.UserStatus = false;
                    //Lưu thông tin vào cơ sở dữ liệu
                    context.SaveChanges();
                }
            }
            this.Close();
        }

        //Tìm kiếm bạn bè theo tên txbThemban.Text
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

        //tìm kiếm bạn theo tên txbTimBan.Text
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

        //Cập nhật lại thông tin khi người dùng nhấn nút cập nhật
        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            ContextChatDB context = new ContextChatDB();
            Login dbupdate = context.Logins.FirstOrDefault(p => p.Username == usernames);
            Login dbuser = context.Logins.FirstOrDefault(p => p.Username == usernames);
            var email = new EmailAddressAttribute();
            //Hiển thị Error khi người dùng không nhập nội dung
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
            // Kiểm tra điều kiện và cập nhật thông tin lại trên cơ sở dữ liệu
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
                //Lưu thông tin vào có sỡ dữ liệu
                context.SaveChanges();
                Chat_Form_Load(sender, e);
                MessageBox.Show("Sửa Thành Công ! ", "Thông Báo", MessageBoxButtons.OK);
                pnlDoiThongTin.Visible = false;
            }
        }

        private void Chat_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Cập nhật lại trạng thái của các User khi Form đc đóng lại
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

        //Đổi lại thông tin ảnh đại diện của người dùng
        private void pcbDoiThongTin_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //mở những file hình ảnh có đuôi phù hợp
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //Lây tên của hình ảnh
                filename = Path.GetFileName(dlg.FileName);
                var image = Image.FromFile(dlg.FileName);
                pcbDoiThongTin.Image = image;
                // lấy đường dẫn nguồn của file
                string source = dlg.FileName;
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string imagepath = Path.Combine(parentDirectory, "Images", Path.GetFileName(dlg.FileName));
                //Kiểm tra xem thư mục có tồn tại hay không nếu không có thì lưu hình ảnh vào thư mục Images
                if (File.Exists(imagepath))
                {

                }
                else
                {
                    File.Copy(source, imagepath, true);
                }
            }
        }

        //Cập Nhật hoặc thay đổi thông tin hình ảnh BackGround của User
        private void pcbBackgroundImageChinhSua_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //Mở những file có hình ảnh có đuôi phù hợp
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //Lây tên hình ảnh
                backgroundimagefilename = Path.GetFileName(dlg.FileName);
                var image = Image.FromFile(dlg.FileName);
                pcbBackgroundImageChinhSua.Image = image;
                //Lấy đường dẫn nguồn của hình ảnh
                string source = dlg.FileName;
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string imagepath = Path.Combine(parentDirectory, "Images", Path.GetFileName(dlg.FileName));
                    //Kiểm tra xem thư mục có tồn tại hay không nếu không có thì lưu hình ảnh vào thư mục Images
                 if (File.Exists(imagepath))
                {

                }
                else
                {
                    File.Copy(source, imagepath, true);
                }
            }
        }

        private void pcbExit_Click(object sender, EventArgs e)
        {
            pnlDoiMatKhau.Visible = false;
        }

        //Cập nhật lại mật khẩu khi người dùng nhấn vào button Cập Nhập mật khẩu
        private void btnCapNhatMatKhau_Click(object sender, EventArgs e)
        {
            ContextChatDB context = new ContextChatDB();
            Login dbupdate = context.Logins.FirstOrDefault(p => p.Username == usernames);
            Login dbuser = context.Logins.FirstOrDefault(p => p.Username == usernames);
            //Hiển thị lõi khi người dùng không thoã mãn các điều kiện
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
                //Cập nhật lại mật khẩu
                dbupdate.Password = txbDoipassword.Text;
                dbupdate.ConfirmPass = txbNhaplaipassword.Text;
                //Lưu thông tin vào cơ sở dữ liệu
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

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if ( mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }   
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
    }
}
