using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class Customer : UserControl
    {
        data dl = new data();
        public Customer()
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

        }
        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Customer_Load(object sender, EventArgs e)
        {
            loadKH();
            label15.Text += "      ";
            timer1.Start();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            DateTime ngaysinh = dtPicker_ngasinh.Value;
            string sdt = txt_sdt.Text;
            if (dl.ThemKH(txt_makh.Text, txt_tenkh.Text, cbo_matk.ToString(), sdt, ngaysinh, txt_gioitinh.Text ,txt_diachi.Text))
            {
                MessageBox.Show("Thành công");
                DataTable a = dl.loadKH();
                dataBingDing(a);
            }
            else
                MessageBox.Show("Thất bại");
        }
    }
}
