using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class QUANLIMAIN : Form
    {
        
        public QUANLIMAIN()
        {
            InitializeComponent();
        }

        private void QUANLIMAIN_Load(object sender, EventArgs e)
        {

        }

        private void btn_taikhoan_Click(object sender, EventArgs e)
        {
            QUANLI ql = new QUANLI();
            ql.Show();
            this.Hide();
        }

        private void QUANLIMAIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if(r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btn_khachhang_Click(object sender, EventArgs e)
        {
            QUANLIKHACHHANG qlk = new QUANLIKHACHHANG();
            qlk.Show();
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
    }
}
