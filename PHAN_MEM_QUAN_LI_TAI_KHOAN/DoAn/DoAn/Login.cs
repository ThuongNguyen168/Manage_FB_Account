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
    public partial class Login : Form
    {
        KetNoi con = new KetNoi();
        public Login()
        {
            InitializeComponent();
        }
        void SetNull()
        {
            username.Text = "";
            password.Text = "";
        }
        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Alert("Hãy Nhập đầy đủ thông tin", notifation.enmType.Success);
            register register = new register();
            register.Show();
            this.Hide();
            
        }

        

        private void Login_Load(object sender, EventArgs e)
        {
            
        }
        public void Alert(string msg, notifation.enmType type)
        {
            notifation frm = new notifation();
            frm.showAlert(msg, type);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (username.Text.Length==0)
            {
                this.Alert("Hãy Nhập Tài Khoản", notifation.enmType.Success);
            }
            else
            {
                if(password.Text.Length==0)
                {
                    this.Alert("Hãy Nhập Mật Khẩu", notifation.enmType.Success);
                }
                else
                {
                    if(con.getDataTable("SELECT * FROM F_DANGNHAPUSER('" + username.Text + "', '" + password.Text + "')").Rows.Count == 1)
                    {
                        this.Alert("Đăng Nhập Thành Công!", notifation.enmType.Success);
                        Main main = new Main();
                        main.Show();
                        this.Hide();
                    }
                    if(con.getDataTable("SELECT * FROM F_DANGNHAPADMIN('" + username.Text + "', '" + password.Text + "')").Rows.Count == 1) 
                    {
                        this.Alert("Đăng Nhập ADM Thành Công!", notifation.enmType.Success);
                        QUANLIMAIN admain = new QUANLIMAIN();
                        admain.Show();
                        this.Hide();
                    }
                    else
                    { 
                        this.Alert("Đăng Nhập không Thành Công!", notifation.enmType.Error);
                        SetNull();
                        username.Focus();
                    }
                }
            }
            
            
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            if(password.Text.Length >=0)
            {
                erro.Clear();
            }
        }

        private void password_Leave(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
