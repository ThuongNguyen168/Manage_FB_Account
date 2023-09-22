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
    public partial class QUANLITHONGBAO : Form
    {
        data dl = new data();
        public QUANLITHONGBAO()
        {
            InitializeComponent(); 
        }
        public void dataBingDing(DataTable tb)
        {
            txt_matb.DataBindings.Clear();
            txt_noidung.DataBindings.Clear();
            cbo_makh.DataBindings.Clear();
            dateTimePicker1.DataBindings.Clear();


            txt_matb.DataBindings.Add("text", tb, "MATB");
            txt_noidung.DataBindings.Add("text", tb, "NoiDung");
            cbo_makh.DataBindings.Add("text", tb, "MAKH");
            dateTimePicker1.DataBindings.Add("text", tb, "NGAYBAO");
        }
        public void loadTB()
        {
            DataTable dt = dl.loadTB();
            dataGridView1.DataSource = dt;
            dataBingDing(dt);
            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].ReadOnly = true;

            DataTable dt1 = dl.loadKH();
            cbo_makh.DataSource = dt1;
            cbo_makh.DisplayMember = "TENKH";
            cbo_makh.ValueMember = "MAKH";

        }
        private void QUANLITHONGBAO_Load(object sender, EventArgs e)
        {
            loadTB();
            label15.Text += "      ";
            timer1.Start();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            DateTime ngaytb = dateTimePicker1.Value;
            if (dl.ThemTB(txt_matb.Text, txt_noidung.Text, cbo_makh.ToString(),  ngaytb))
            {
                MessageBox.Show("Thành công");
                DataTable a = dl.loadTB();
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
            if (dl.XoaTB(txt_matb.Text))
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
            DateTime ngaytb = dateTimePicker1.Value;
            if (dl.SuaTB(txt_matb.Text, txt_noidung.Text, cbo_makh.ToString(), ngaytb))
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
            if (dl.LuuTB())
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
            txt_matb.ResetText();
            txt_noidung.ResetText();
            cbo_makh.ResetText();
            dateTimePicker1.ResetText();
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
            string str = string.Format("EXEC FINDTB '{0}'", txt_matb.Text);
            SqlCommand cmd = new SqlCommand(str, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        
    }
}
