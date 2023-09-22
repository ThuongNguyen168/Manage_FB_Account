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
    public partial class QUANLITIMKIEM : Form
    {
        data dl = new data();
        public QUANLITIMKIEM()
        {
            InitializeComponent();
        }
        public void dataBingDing(DataTable timkiem)
        {
            txt_matk.DataBindings.Clear();
            cbo_makh.DataBindings.Clear();
            txt_noidung.DataBindings.Clear();


            txt_matk.DataBindings.Add("text", timkiem, "MATIMKIEM");
            cbo_makh.DataBindings.Add("text", timkiem, "MAKH");
            txt_noidung.DataBindings.Add("text", timkiem, "NoiDung");
        }
        public void loadTIMKIEM()
        {
            DataTable dt = dl.loadTIMKIEM();
            dataGridView1.DataSource = dt;
            dataBingDing(dt);
            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].ReadOnly = true;

            DataTable dt1 = dl.loadKH();
            cbo_makh.DataSource = dt1;
            cbo_makh.DisplayMember = "TENKH";
            cbo_makh.ValueMember = "MAKH";

        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            if (dl.ThemTIMKIEM(txt_matk.Text, cbo_makh.ToString(), txt_noidung.Text))
            {
                MessageBox.Show("Thành công");
                DataTable a = dl.loadKH();
                dataBingDing(a);
            }
            else
                MessageBox.Show("Thất bại");
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dl.XoaTIMKIEM(txt_matk.Text))
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
            if (dl.SuaTIMKIEM(txt_matk.Text, cbo_makh.ToString(), txt_noidung.Text))
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
            if (dl.LuuTIMKIEM())
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
            txt_matk.ResetText();
            txt_noidung.ResetText();
            cbo_makh.ResetText();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=SU\SUPIGGY;Initial Catalog=QL_TAIKHOAN;User ID=sa;Password=123");

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            label15.Text = label15.Text.Substring(1, label15.Text.Length - 1) + label15.Text.Substring(0, 1);

        }

        private void QUANLITIMKIEM_Load(object sender, EventArgs e)
        {
            loadTIMKIEM();
            label15.Text += "      ";
            timer1.Start();
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

        private void button9_Click(object sender, EventArgs e)
        {
            QUANLITINNHAN qltn = new QUANLITINNHAN();
            qltn.Show();
            this.Hide();
        }
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string str = string.Format("EXEC FINDTIMKIEM '{0}'", txt_matk.Text);
            SqlCommand cmd = new SqlCommand(str, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        
    }
}
