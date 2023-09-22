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
    public partial class QUANLISTORY : Form
    {
        data dl = new data();
        public QUANLISTORY()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label15.Text = label15.Text.Substring(1, label15.Text.Length - 1) + label15.Text.Substring(0, 1);
        }
        public void dataBingDing(DataTable story)
        {
             
            txt_mastory.DataBindings.Clear();
            txt_tenstory.DataBindings.Clear();
            cbo_makh.DataBindings.Clear();
            txt_noidung.DataBindings.Clear();
            dateTimePicker1.DataBindings.Clear();

            txt_mastory.DataBindings.Add("text", story, "MASTORY");
            txt_tenstory.DataBindings.Add("text", story, "TENSTORY");
            cbo_makh.DataBindings.Add("text", story, "MAKH");
            txt_noidung.DataBindings.Add("text", story, "NOIDUNG");
            dateTimePicker1.DataBindings.Add("text", story, "NGDANG");
        }
        public void loadSTR()
        {
            DataTable dt = dl.loadSTR();
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
            DateTime ngaystr = dateTimePicker1.Value;
            if (dl.ThemSTR(txt_mastory.Text, txt_tenstory.Text, cbo_makh.ToString(), txt_noidung.Text, ngaystr))
            {
                MessageBox.Show("Thành công");
                DataTable a = dl.loadSTR();
                dataBingDing(a);
            }
            else
                MessageBox.Show("Thất bại");
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dl.XoaSTR(txt_mastory.Text))
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
            DateTime ngaystr = dateTimePicker1.Value;
            if (dl.SuaSTR(txt_mastory.Text, txt_tenstory.Text, cbo_makh.ToString(), txt_noidung.Text, ngaystr))
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
            if (dl.LuuSTR())
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
            txt_mastory.ResetText();
            txt_tenstory.ResetText();
            cbo_makh.ResetText();
            txt_noidung.ResetText();
            dateTimePicker1.ResetText();
        }

        private void QUANLISTORY_Load(object sender, EventArgs e)
        {
            loadSTR();
            label15.Text += "      ";
            timer1.Start();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=SU\SUPIGGY;Initial Catalog=QL_TAIKHOAN;User ID=sa;Password=123");

        
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

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string str = string.Format("EXEC FINDSTR '{0}'", txt_mastory.Text);
            SqlCommand cmd = new SqlCommand(str, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

    }
}
