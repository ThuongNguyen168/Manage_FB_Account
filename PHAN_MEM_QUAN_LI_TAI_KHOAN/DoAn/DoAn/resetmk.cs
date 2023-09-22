using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace DoAn
{
    public partial class resetmk : Form
    {
        KetNoi con = new KetNoi();
        private string _message;
        public resetmk()
        {
            InitializeComponent();
        }
        void setNull()
        {
            email.Text = "";
            guna2TextBox1.Text = "";
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        private void resetmk_Load(object sender, EventArgs e)
        {
            guna2ControlBox1.Text = _message;
        }

        public void Alert(string msg, notifation.enmType type)
        {
            notifation frm = new notifation();
            frm.showAlert(msg, type);
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (email.Text == guna2TextBox1.Text)
            {
                try
                {
                    con.executeNonQuery("EXEC SP_RESETMK '" + guna2ControlBox1.Text + "', '" + email.Text + "'");
                    this.Alert("Đổi lại mật khẩu Thành Công", notifation.enmType.Success);
                    setNull();
                    Login login = new Login();
                    login.Show();
                    this.Hide();
                }
                catch
                {
                    this.Alert("Đổi mật khẩu thất bại", notifation.enmType.Error);
                }
            }
            else
            {
                this.Alert("Mật khẩu không khớp", notifation.enmType.Error);
                setNull();
                email.Focus();
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Alert("Wellcome Login", notifation.enmType.Success);
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
