using Chat_Application.Model;
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

namespace Chat_Application
{
    public partial class Form2 : Form
    {
        Form1 form1 = new Form1();
        public string username { set; get; }
        public Form2()
        {
            form1 = new Form1();
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            form1.Visible = true;
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

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = username;
            ContextChatDB context = new ContextChatDB();
            Login dblogin = context.Login.FirstOrDefault(p => p.Username == username);
            if (dblogin != null)
            {
                label1.Text = dblogin.Username;
                ThemHinhAnh(dblogin.image);
            }
        }
    }
}
