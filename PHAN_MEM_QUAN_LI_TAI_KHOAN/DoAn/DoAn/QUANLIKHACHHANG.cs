using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace DoAn
{
    public partial class QUANLIKHACHHANG : Form
    {
        data dl = new data();
        public QUANLIKHACHHANG()
        {
            InitializeComponent();
        }
        public void dataBingDing(DataTable kh)
        {
            txt_makh.DataBindings.Clear();
            txt_tenkh.DataBindings.Clear();
            cbo_matk.DataBindings.Clear();
            txt_sdt.DataBindings.Clear();
            dtPicker_ngasinh.DataBindings.Clear();
            txt_gioitinh.DataBindings.Clear();
            txt_diachi.DataBindings.Clear();


            txt_makh.DataBindings.Add("text", kh, "MAKH");
            txt_tenkh.DataBindings.Add("text", kh, "TENKH");
            cbo_matk.DataBindings.Add("text", kh, "MATK");
            txt_sdt.DataBindings.Add("text", kh, "SDT");
            dtPicker_ngasinh.DataBindings.Add("text", kh, "NGSINH");
            txt_gioitinh.DataBindings.Add("text", kh, "GIOITINH");
            txt_diachi.DataBindings.Add("text", kh, "DIACHI");
        }
        public void loadKH()
        {
            DataTable dt = dl.loadKH();
            dataGridView1.DataSource = dt;
            dataBingDing(dt);
            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].ReadOnly = true;

            DataTable dt1 = dl.loadTK();
            cbo_matk.DataSource = dt1;
            cbo_matk.DisplayMember = "TENTK";
            cbo_matk.ValueMember = "MATK";

        }
        private void QUANLIKHACHHANG_Load(object sender, EventArgs e)
        {
            loadKH();
            label15.Text += "      ";
            timer1.Start();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            DateTime ngaysinh = dtPicker_ngasinh.Value;
            string sdt = txt_sdt.Text;
            if (dl.ThemKH(txt_makh.Text, txt_tenkh.Text, cbo_matk.ToString(), sdt, ngaysinh, txt_gioitinh.Text, txt_diachi.Text))
            {
                MessageBox.Show("Thành công");
                DataTable a = dl.loadKH();
                dataBingDing(a);
            }
            else
                MessageBox.Show("Thất bại");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label15.Text = label15.Text.Substring(1, label15.Text.Length - 1) + label15.Text.Substring(0, 1);
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dl.XoaKH(txt_makh.Text))
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
            DateTime ngaysinh = dtPicker_ngasinh.Value;
            string sdt = txt_sdt.Text;
            if (dl.SuaKH(txt_makh.Text, txt_tenkh.Text, cbo_matk.ToString(), sdt, ngaysinh, txt_gioitinh.Text, txt_diachi.Text))
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (dl.LuuKH())
            {
                MessageBox.Show("Lưu thành công");
            }
            else
            {
                MessageBox.Show("Lưu thất bại");
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_makh.ResetText();
            txt_tenkh.ResetText();
            cbo_matk.ResetText();
            txt_sdt.ResetText();
            dtPicker_ngasinh.ResetText();
            txt_gioitinh.ResetText();
            txt_diachi.ResetText();
        }

        

        private void QUANLIKHACHHANG_FormClosing(object sender, FormClosingEventArgs e)
        {
            QUANLIMAIN qlm = new QUANLIMAIN();
            qlm.Show();
            this.Hide();
        }

        private void btn_taikhoan_Click(object sender, EventArgs e)
        {
            QUANLI ql = new QUANLI();
            ql.Show();
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
            QUANLITINNHAN qltn = new QUANLITINNHAN();
            qltn.Show();
            this.Hide();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=SU\SUPIGGY;Initial Catalog=QL_TAIKHOAN;User ID=sa;Password=123");

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string str = string.Format("EXEC FINDKH '{0}'", txt_makh.Text);
            SqlCommand cmd = new SqlCommand(str, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        
    }
}
