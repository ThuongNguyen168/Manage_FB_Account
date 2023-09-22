using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
namespace DoAn
{
    public partial class QUANLI : Form
    {
        QUANLIMAIN qlm = new QUANLIMAIN();
        data dl = new data();
        public QUANLI()
        {
            InitializeComponent();
        }
        public void dataBingDing(DataTable tk)
        {
            txt_matk.DataBindings.Clear();
            txt_email.DataBindings.Clear();
            txt_mk.DataBindings.Clear();
            txt_tdn.DataBindings.Clear();
            txt_quyen.DataBindings.Clear();
             

            txt_matk.DataBindings.Add("text", tk, "MATK");
            txt_email.DataBindings.Add("text", tk, "Email");
            txt_mk.DataBindings.Add("text", tk, "MatKhau");
            txt_tdn.DataBindings.Add("text", tk, "TenDangNhap");
            txt_quyen.DataBindings.Add("text", tk, "QuyenHan");
        }
        public void loadTK()
        {
            DataTable dt = dl.loadTK();
            dataGridView1.DataSource = dt;
            dataBingDing(dt);
            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].ReadOnly = true;

        }
        public bool kTEmail(string email)
        {
            string chuoikitu = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex r = new Regex(chuoikitu);
            if (!r.IsMatch(email))
            {
                return true;
            }
            else
                return false;

        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txt_matk.Text))
            //{
            //    errorProvider1.SetError(txt_matk, "Vui lòng không để trống Mã Tài Khoản!");
            //}
            //else if (string.IsNullOrEmpty(txt_tdn.Text))
            //{
            //    errorProvider1.Clear();
            //    errorProvider1.SetError(txt_tdn, "Vui lòng không để trống Tên Đăng Nhập!");
            //}
            //else if (string.IsNullOrEmpty(txt_email.Text))
            //{
            //    errorProvider1.Clear();
            //    errorProvider1.SetError(txt_email, "Vui lòng không để trống Email!");
            //}
            //else if (string.IsNullOrEmpty(txt_mk.Text))
            //{
            //    errorProvider1.Clear();
            //    errorProvider1.SetError(txt_mk, "Vui lòng không để trống Mật Khẩu!");
            //}
            //else if (string.IsNullOrEmpty(txt_quyen.Text))
            //{
            //    errorProvider1.Clear();
            //    errorProvider1.SetError(txt_quyen, "Vui lòng không để trống Quyền!");
            //}
            //else
            //{
            //    errorProvider1.Clear();
            //   if (dl.ThemTK(txt_matk.Text, txt_email.Text, txt_mk.Text, txt_tdn.Text, txt_quyen.Text))
            //   {
            //       if(kTEmail(txt_email.Text))
            //       {
            //           MessageBox.Show("Thành công");
            //           DataTable dt = dl.loadTK();
            //           dataBingDing(dt);
            //       }
            //       else
            //       {
            //           MessageBox.Show("Email không hợp lệ (ten@gmail.com)");
            //       }
                    
            //   }
            //   else
            //   MessageBox.Show("Thất bại");
            //}
            if (dl.ThemTK(txt_matk.Text, txt_email.Text, txt_mk.Text, txt_tdn.Text, txt_quyen.Text))
            {
                MessageBox.Show("Thành công");
                DataTable a = dl.loadTK();
                dataBingDing(a);
            }
            else
                MessageBox.Show("Thất bại");
            
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dl.XoaTK(txt_matk.Text))
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa không thành công");
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if(dl.SuaTK(txt_matk.Text, txt_email.Text, txt_mk.Text, txt_tdn.Text, txt_quyen.Text))
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label15.Text = label15.Text.Substring(1, label15.Text.Length - 1) + label15.Text.Substring(0, 1);
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_matk.ResetText();
            txt_email.ResetText();
            txt_mk.ResetText();
            txt_tdn.ResetText();
            txt_quyen.ResetText();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            QUANLI form = new QUANLI();
            form.TopLevel = false;
            panel10.Controls.Add(form);
            panel10.BringToFront();
            form.Show();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if(dl.LuuTK())
            {
                MessageBox.Show("Lưu thành công");
            }
            else
            {
                MessageBox.Show("Lưu thất bại");
            }
        }


        private void QUANLI_Load(object sender, EventArgs e)
        {
            loadTK();
            label15.Text += "      ";
            timer1.Start();
        }

        private void QUANLI_Click(object sender, EventArgs e)
        {
            
        }

        private void QUANLI_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            qlm.Show();
            this.Hide();
        }

        private void btn_taikhoan_Click(object sender, EventArgs e)
        {

        }

        private void btn_khachhang_Click(object sender, EventArgs e)
        {
            QUANLIKHACHHANG qlkh = new QUANLIKHACHHANG();
            qlkh.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QUANLINHANVIEN qlnv = new QUANLINHANVIEN();
            qlnv.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QUANLIBINHLUAN qlbl = new QUANLIBINHLUAN();
            qlbl.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            QUANLIBAIVIET qlbv = new QUANLIBAIVIET();
            qlbv.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            QUANLISTORY qlstr = new QUANLISTORY();
            qlstr.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            QUANLITHONGBAO qltb = new QUANLITHONGBAO();
            qltb.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            QUANLITIMKIEM qltk = new QUANLITIMKIEM();
            qltk.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            QUANLITIMKIEM qltk = new QUANLITIMKIEM();
            qltk.Show();
            this.Hide();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=SU\SUPIGGY;Initial Catalog=QL_TAIKHOAN;User ID=sa;Password=123");

        private void button1_Click(object sender, EventArgs e)
        {
            string str = string.Format("EXEC FINDTK '{0}'", txt_matk.Text);
            SqlCommand cmd = new SqlCommand(str, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
