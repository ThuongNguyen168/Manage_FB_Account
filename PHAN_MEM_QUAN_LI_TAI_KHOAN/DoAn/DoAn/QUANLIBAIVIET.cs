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
    public partial class QUANLIBAIVIET : Form
    {
        data dl = new data();
        public QUANLIBAIVIET()
        {
            InitializeComponent();
        }
        public void dataBingDing(DataTable bv)
        {
            txt_mabv.DataBindings.Clear();
            txt_noidung.DataBindings.Clear();
            dateTimePicker1.DataBindings.Clear();
            cbo_makh.DataBindings.Clear();

            txt_mabv.DataBindings.Add("text", bv, "MABAIDANG");
            txt_noidung.DataBindings.Add("text", bv, "NoiDung");
            dateTimePicker1.DataBindings.Add("text", bv, "NGAYDANG");
            cbo_makh.DataBindings.Add("text", bv, "MAKH");

        }
        public void loadBV()
        {
            DataTable dt = dl.loadBV();
            dataGridView1.DataSource = dt;
            dataBingDing(dt);
            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].ReadOnly = true;

            DataTable dt1 = dl.loadKH();
            cbo_makh.DataSource = dt1;
            cbo_makh.DisplayMember = "TENKH";
            cbo_makh.ValueMember = "MAKH";

        }
        private void QUANLIBAIVIET_Load(object sender, EventArgs e)
        {
            loadBV();
            label15.Text += "      ";
            timer1.Start();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            DateTime ngaydang = dateTimePicker1.Value;
            if (dl.ThemBV(txt_mabv.Text, txt_noidung.Text, ngaydang, cbo_makh.ToString()))
            {
                MessageBox.Show("Thành công");
                DataTable a = dl.loadBV();
                dataBingDing(a);
            }
            else
                MessageBox.Show("Thất bại");
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dl.XoaBL(txt_mabv.Text))
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
            DateTime ngaydang = dateTimePicker1.Value;
            if (dl.SuaBV(txt_mabv.Text, txt_noidung.Text, ngaydang, cbo_makh.ToString()))
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
            if (dl.LuuBV())
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
            txt_mabv.ResetText();
            txt_noidung.ResetText();
            dateTimePicker1.ResetText();
            cbo_makh.ResetText();
            
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=SU\SUPIGGY;Initial Catalog=QL_TAIKHOAN;User ID=sa;Password=123");
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string str = string.Format("EXEC FINDBD '{0}'", txt_mabv.Text);
            SqlCommand cmd = new SqlCommand(str, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                label15.Text = label15.Text.Substring(1, label15.Text.Length - 1) + label15.Text.Substring(0, 1);
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

    }
}
