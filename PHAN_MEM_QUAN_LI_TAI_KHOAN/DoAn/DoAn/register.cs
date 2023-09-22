using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
namespace DoAn
{
    public partial class register : Form
    {
        KetNoi con = new KetNoi();
        public register()
        {
            InitializeComponent();
        }
        void SetNull()
        {
            taikhoan.Text = "";
            matkhau.Text = "";
            xacnhanmk.Text = "";
            dk_email.Text = "";
        }
        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Alert("Wellcome To Login", notifation.enmType.Success);
            Login m = new Login();
            m.Show();
            this.Hide();
        }

        private void register_Load(object sender, EventArgs e)
        {

        }
        public void Alert(string msg, notifation.enmType type)
        {
            notifation frm = new notifation();
            frm.showAlert(msg, type);
        }
        public static bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if(taikhoan.Text.Length==0)
            {
                this.Alert("Hãy Nhập Tài Khoản", notifation.enmType.Success);
            }
            else
            {
                if(matkhau.Text.Length==0)
                {
                    this.Alert("Hãy Nhập Mật Khẩu", notifation.enmType.Success);
                }    
                else
                {
                    if(xacnhanmk.Text!=matkhau.Text)
                    {
                        this.Alert("Xác Nhận Mật Khẩu Không Đúng", notifation.enmType.Error);
                    }
                    else 
                    {
                        if(dk_email.Text.Length==0)
                        {
                            this.Alert("Vui Lòng Nhập Email!", notifation.enmType.Success);

                        }
                        else if(isEmail(dk_email.Text) == false)
                        {
                            this.Alert("Email không chính xác!", notifation.enmType.Success);
                        }    
                        else 
                        {
                            try
                            {
                                con.executeNonQuery("EXEC SP_DANGKY '" + taikhoan.Text + "', '" + matkhau.Text + "', '" + dk_email.Text + "'");
                                this.Alert("Đăng Ký Thành Công", notifation.enmType.Success);
                                SetNull();
                                Login login = new Login();
                                login.Show();
                                this.Hide();
                            }
                            catch
                            {
                                this.Alert("Tên đăng nhập đã tồn tại.", notifation.enmType.Error);
                            }
                        }
                    }
                }    
            }
            
        }
    }
}
