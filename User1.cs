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
    public partial class User1 : UserControl
    {
        public User1()
        {
            InitializeComponent();
        }
        private string _tittle;

        public string Title
        {
            get { return _tittle; }
            set { _tittle = value; label1.Text = value; }
        }
      
        private void User1_Load(object sender, EventArgs e)
        {

        }
  
    }
}
