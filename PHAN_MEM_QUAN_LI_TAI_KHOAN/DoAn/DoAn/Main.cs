using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }



        public void loadform(object Form)
        {
            if (this.ma.Controls.Count > 0)
                this.ma.Controls.RemoveAt(0);
            Form s = Form as Form;
            s.TopLevel = false;
            s.Dock = DockStyle.Fill;
            this.ma.Controls.Add(s);
            this.ma.Tag = s;
            s.Show();

        }
        public void Alert(string msg, notifation.enmType type)
        {
            notifation frm = new notifation();
            frm.showAlert(msg, type);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Alert("Đăng Xuất Thành Công", notifation.enmType.Info);
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            loadform(new setting());
        }
        
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            QUANLIMAIN qlm = new QUANLIMAIN();
            qlm.Show();
            this.Hide();
        }
    }
}
