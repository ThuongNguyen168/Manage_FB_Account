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
    public partial class QUANLINHANVIEN : Form
    {
        data dl = new data();
        public QUANLINHANVIEN()
        {
            InitializeComponent();
        }

        public void dataBingDing(DataTable nv)
        {
            txt_manv.DataBindings.Clear();
            txt_tennv.DataBindings.Clear();
            dtPicker_ngasinh.DataBindings.Clear();
            cbo_matk.DataBindings.Clear();
            txt_sdt.DataBindings.Clear();
            txt_diachi.DataBindings.Clear();
            txt_luong.DataBindings.Clear();

            txt_manv.DataBindings.Add("text", nv, "MANV");
            txt_tennv.DataBindings.Add("text", nv, "TENNV");
            dtPicker_ngasinh.DataBindings.Add("text", nv, "NGSINH");
            cbo_matk.DataBindings.Add("text", nv, "MATK");
            txt_sdt.DataBindings.Add("text", nv, "SDT");
            txt_diachi.DataBindings.Add("text", nv, "DIACHI");
            txt_luong.DataBindings.Add("text", nv, "LUONG");
        }
        public void loadNV()
        {
            DataTable dt = dl.loadNV();
            dataGridView1.DataSource = dt;
            dataBingDing(dt);
            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].ReadOnly = true;

            DataTable dt1 = dl.loadTK();
            cbo_matk.DataSource = dt1;
            cbo_matk.DisplayMember = "TENTK";
            cbo_matk.ValueMember = "MATK";

        }
        private void QUANLINHANVIEN_Load(object sender, EventArgs e)
        {
            loadNV();
            label15.Text += "      ";
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label15.Text = label15.Text.Substring(1, label15.Text.Length - 1) + label15.Text.Substring(0, 1);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            DateTime ngaysinh = dtPicker_ngasinh.Value;
            string sdt = txt_sdt.Text;
            string luong = txt_luong.Text;
            if (dl.ThemNV(txt_manv.Text, txt_tennv.Text, ngaysinh, cbo_matk.ToString(), sdt, txt_diachi.Text, luong))
            {
                MessageBox.Show("Thành công");
                DataTable a = dl.loadNV();
                dataBingDing(a);
            }
            else
                MessageBox.Show("Thất bại");
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dl.XoaNV(txt_manv.Text))
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
            string luong = txt_luong.Text;
            if (dl.SuaNV(txt_manv.Text, txt_tennv.Text, ngaysinh, cbo_matk.ToString(), sdt, txt_diachi.Text, luong))
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
            if (dl.LuuNV())
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
            txt_manv.ResetText();
            txt_tennv.ResetText();
            dtPicker_ngasinh.ResetText();
            cbo_matk.ResetText();
            txt_sdt.ResetText();
            txt_diachi.ResetText();
            txt_luong.ResetText();
        }

        private void btn_taikhoan_Click(object sender, EventArgs e)
        {
            QUANLI ql = new QUANLI();
            ql.Show();
            this.Hide();
        }

        private void btn_khachhang_Click(object sender, EventArgs e)
        {
            QUANLIKHACHHANG qlkh = new QUANLIKHACHHANG();
            qlkh.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            QUANLIBINHLUAN qlbl = new QUANLIBINHLUAN();
            qlbl.Show();
            this.Hide();
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

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
            string str = string.Format("EXEC FINDNV '{0}'", txt_manv.Text);
            SqlCommand cmd = new SqlCommand(str, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
