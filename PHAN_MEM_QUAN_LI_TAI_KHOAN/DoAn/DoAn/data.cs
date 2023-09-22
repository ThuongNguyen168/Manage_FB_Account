using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DoAn
{
    public class data
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=SU\SUPIGGY;Initial Catalog=QL_TAIKHOAN;User ID=sa;Password=123");
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        string str;
        public DataTable loadTK()
        {
            str = "select * from TAIKHOAN";
            da = new SqlDataAdapter(str, cnn);
            da.Fill(ds, "TAIKHOAN");
            DataColumn[]keys = new DataColumn[1];
            keys[0] = ds.Tables["TAIKHOAN"].Columns[0];
            ds.Tables["TAIKHOAN"].PrimaryKey = keys;
            return ds.Tables["TAIKHOAN"];
        }


        public bool ThemTK(string matk, string email, string mk, string tendn, string quyen)
        {
            try
            {
                DataRow dr = ds.Tables["TAIKHOAN"].NewRow();
                dr[0] = matk;
                dr[1] = email;
                dr[2] = mk;
                dr[3] = tendn;
                dr[4] = quyen;
                ds.Tables["TAIKHOAN"].Rows.Add(dr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaTK(string matk)
        {
            try
            {
                DataRow dr = ds.Tables["TAIKHOAN"].Rows.Find(matk);
                if (dr != null)
                {
                    dr.Delete();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaTK(string matk, string email, string mk, string tendn, string quyen)
        {
            try
            {
                DataRow dr = ds.Tables["TAIKHOAN"].Rows.Find(matk);
                if (dr != null)
                {
                    dr[0] = matk;
                    dr[1] = email;
                    dr[2] = mk;
                    dr[3] = tendn;
                    dr[4] = quyen;
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool LuuTK()
        {
            try
            {
                SqlCommandBuilder buil = new SqlCommandBuilder(da);
                da.Update(ds, "TAIKHOAN");
                return true;
            }
            catch
            {
                return false;
            }
        }

        // KHÁCH HÀNG
        public DataTable loadKH()
        {
            str = "select * from KHACHHANG";
            da = new SqlDataAdapter(str, cnn);
            da.Fill(ds, "KHACHHANG");
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["KHACHHANG"].Columns[0];
            ds.Tables["KHACHHANG"].PrimaryKey = keys;
            return ds.Tables["KHACHHANG"];
        }


        public bool ThemKH(string makh, string tenkh, string matk, string sdt, DateTime ngsinh, string gioitinh, string diachi)
        {
            try
            {
                DataRow dr = ds.Tables["KHACHHANG"].NewRow();
                dr[0] = makh;
                dr[1] = tenkh;
                dr[2] = matk;
                dr[3] = sdt;
                dr[4] = ngsinh;
                dr[5] = gioitinh;
                dr[6] = diachi;
                ds.Tables["KHACHHANG"].Rows.Add(dr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaKH(string makh)
        {
            try
            {
                DataRow dr = ds.Tables["KHACHHANG"].Rows.Find(makh);
                if (dr != null)
                {
                    dr.Delete();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaKH(string makh, string tenkh, string matk, string sdt, DateTime ngsinh, string gioitinh, string diachi)
        {
            try
            {
                DataRow dr = ds.Tables["KHACHHANG"].Rows.Find(matk);
                if (dr != null)
                {
                    dr[0] = makh;
                    dr[1] = tenkh;
                    dr[2] = matk;
                    dr[3] = sdt;
                    dr[4] = ngsinh;
                    dr[5] = gioitinh;
                    dr[6] = diachi;
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool LuuKH()
        {
            try
            {
                SqlCommandBuilder buil = new SqlCommandBuilder(da);
                da.Update(ds, "KHACHHANG");
                return true;
            }
            catch
            {
                return false;
            }
        }

        // NHÂN VIÊN
        public DataTable loadNV()
        {
            str = "select * from NHANVIEN";
            da = new SqlDataAdapter(str, cnn);
            da.Fill(ds, "NHANVIEN");
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["NHANVIEN"].Columns[0];
            ds.Tables["NHANVIEN"].PrimaryKey = keys;
            return ds.Tables["NHANVIEN"];
        }


        public bool ThemNV(string manv, string tennv, DateTime ngsinh, string matk, string sdt, string diachi, string luong)
        {
            try
            {
                DataRow dr = ds.Tables["NHANVIEN"].NewRow();
                dr[0] = manv;
                dr[1] = tennv;
                dr[2] = ngsinh;
                dr[3] = matk;
                dr[4] = sdt;
                dr[5] = diachi;
                dr[6] = luong;
                ds.Tables["NHANVIEN"].Rows.Add(dr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaNV(string manv)
        {
            try
            {
                DataRow dr = ds.Tables["NHANVIEN"].Rows.Find(manv);
                if (dr != null)
                {
                    dr.Delete();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaNV(string manv, string tennv, DateTime ngsinh, string matk, string sdt, string diachi, string luong)
        {
            try
            {
                DataRow dr = ds.Tables["NHANVIEN"].Rows.Find(matk);
                if (dr != null)
                {
                    dr[0] = manv;
                    dr[1] = tennv;
                    dr[2] = ngsinh;
                    dr[3] = matk;
                    dr[4] = sdt;
                    dr[5] = diachi;
                    dr[6] = luong;
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool LuuNV()
        {
            try
            {
                SqlCommandBuilder buil = new SqlCommandBuilder(da);
                da.Update(ds, "NHANVIEN");
                return true;
            }
            catch
            {
                return false;
            }
        }





        // BÌNH LUẬN
        public DataTable loadBL()
        {
            str = "select * from BINHLUAN";
            da = new SqlDataAdapter(str, cnn);
            da.Fill(ds, "BINHLUAN");
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["BINHLUAN"].Columns[0];
            ds.Tables["BINHLUAN"].PrimaryKey = keys;
            return ds.Tables["BINHLUAN"];
        }


        public bool ThemBL(string mabl, string makh, string nd, DateTime ngbl)
        {
            try
            {
                DataRow dr = ds.Tables["BINHLUAN"].NewRow();
                dr[0] = mabl;
                dr[1] = makh;
                dr[2] = nd;
                dr[3] = ngbl;
                ds.Tables["BINHLUAN"].Rows.Add(dr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaBL(string mabl)
        {
            try
            {
                DataRow dr = ds.Tables["BINHLUAN"].Rows.Find(mabl);
                if (dr != null)
                {
                    dr.Delete();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaBL(string mabl, string makh, string nd, DateTime ngbl)
        {
            try
            {
                DataRow dr = ds.Tables["BINHLUAN"].Rows.Find(mabl);
                if (dr != null)
                {
                    dr[0] = mabl;
                    dr[1] = makh;
                    dr[2] = nd;
                    dr[3] = ngbl;
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool LuuBL()
        {
            try
            {
                SqlCommandBuilder buil = new SqlCommandBuilder(da);
                da.Update(ds, "BINHLUAN");
                return true;
            }
            catch
            {
                return false;
            }
        }



        // BÀI VIẾT
        public DataTable loadBV()
        {
            str = "select * from BAIDANG";
            da = new SqlDataAdapter(str, cnn);
            da.Fill(ds, "BAIDANG");
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["BAIDANG"].Columns[0];
            ds.Tables["BAIDANG"].PrimaryKey = keys;
            return ds.Tables["BAIDANG"];
        }


        public bool ThemBV(string mabv, string nd, DateTime ngbl, string makh)
        {
            try
            {
                DataRow dr = ds.Tables["BAIDANG"].NewRow();
                dr[0] = mabv;
                dr[1] = nd;
                dr[2] = ngbl;
                dr[3] = makh;
                ds.Tables["BAIDANG"].Rows.Add(dr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaBV(string mabV)
        {
            try
            {
                DataRow dr = ds.Tables["BAIDANG"].Rows.Find(mabV);
                if (dr != null)
                {
                    dr.Delete();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaBV(string mabv, string nd, DateTime ngbl, string makh)
        {
            try
            {
                DataRow dr = ds.Tables["BAIDANG"].Rows.Find(mabv);
                if (dr != null)
                {
                    dr[0] = mabv;
                    dr[1] = nd;
                    dr[2] = ngbl;
                    dr[3] = makh;
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool LuuBV()
        {
            try
            {
                SqlCommandBuilder buil = new SqlCommandBuilder(da);
                da.Update(ds, "BAIDANG");
                return true;
            }
            catch
            {
                return false;
            }
        }


        // STORY
        public DataTable loadSTR()
        {
            str = "select * from STORY";
            da = new SqlDataAdapter(str, cnn);
            da.Fill(ds, "STORY");
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["STORY"].Columns[0];
            ds.Tables["STORY"].PrimaryKey = keys;
            return ds.Tables["STORY"];
        }


        public bool ThemSTR(string mastr, string tenstr, string makh, string nd, DateTime ngdang)
        {
            try
            {
                DataRow dr = ds.Tables["STORY"].NewRow();
                dr[0] = mastr;
                dr[1] = tenstr;
                dr[2] = makh;
                dr[3] = nd;
                dr[4] = ngdang;
                ds.Tables["STORY"].Rows.Add(dr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaSTR(string mastr)
        {
            try
            {
                DataRow dr = ds.Tables["STORY"].Rows.Find(mastr);
                if (dr != null)
                {
                    dr.Delete();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaSTR(string mastr, string tenstr, string makh, string nd, DateTime ngdang)
        {
            try
            {
                DataRow dr = ds.Tables["STORY"].Rows.Find(mastr);
                if (dr != null)
                {
                    dr[0] = mastr;
                    dr[1] = tenstr;
                    dr[2] = makh;
                    dr[3] = nd;
                    dr[4] = ngdang;
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool LuuSTR()
        {
            try
            {
                SqlCommandBuilder buil = new SqlCommandBuilder(da);
                da.Update(ds, "STORY");
                return true;
            }
            catch
            {
                return false;
            }
        }

        // THÔNG BÁO
        public DataTable loadTB()
        {
            str = "select * from THONGBAO";
            da = new SqlDataAdapter(str, cnn);
            da.Fill(ds, "THONGBAO");
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["THONGBAO"].Columns[0];
            ds.Tables["THONGBAO"].PrimaryKey = keys;
            return ds.Tables["THONGBAO"];
        }


        public bool ThemTB(string matb, string nd, string makh, DateTime ngbao)
        {
            try
            {
                DataRow dr = ds.Tables["THONGBAO"].NewRow();
                dr[0] = matb;
                dr[1] = nd;
                dr[2] = makh;
                dr[3] = ngbao;
                ds.Tables["THONGBAO"].Rows.Add(dr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaTB(string matb)
        {
            try
            {
                DataRow dr = ds.Tables["THONGBAO"].Rows.Find(matb);
                if (dr != null)
                {
                    dr.Delete();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaTB(string matb, string nd, string makh, DateTime ngbao)
        {
            try
            {
                DataRow dr = ds.Tables["THONGBAO"].Rows.Find(matb);
                if (dr != null)
                {
                    dr[0] = matb;
                    dr[1] = nd;
                    dr[2] = makh;
                    dr[3] = ngbao;
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool LuuTB()
        {
            try
            {
                SqlCommandBuilder buil = new SqlCommandBuilder(da);
                da.Update(ds, "THONGBAO");
                return true;
            }
            catch
            {
                return false;
            }
        }

        // TÌM KIẾM
        public DataTable loadTIMKIEM()
        {
            str = "select * from TIMKIEM";
            da = new SqlDataAdapter(str, cnn);
            da.Fill(ds, "TIMKIEM");
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["TIMKIEM"].Columns[0];
            ds.Tables["TIMKIEM"].PrimaryKey = keys;
            return ds.Tables["TIMKIEM"];
        }


        public bool ThemTIMKIEM(string matk, string makh, string nd)
        {
            try
            {
                DataRow dr = ds.Tables["TIMKIEM"].NewRow();
                dr[0] = matk;
                dr[1] = makh;
                dr[2] = nd;
                ds.Tables["TIMKIEM"].Rows.Add(dr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaTIMKIEM(string matk)
        {
            try
            {
                DataRow dr = ds.Tables["TIMKIEM"].Rows.Find(matk);
                if (dr != null)
                {
                    dr.Delete();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaTIMKIEM(string matk, string makh, string nd)
        {
            try
            {
                DataRow dr = ds.Tables["TIMKIEM"].Rows.Find(matk);
                if (dr != null)
                {
                    dr[0] = matk;
                    dr[1] = makh;
                    dr[2] = nd;
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool LuuTIMKIEM()
        {
            try
            {
                SqlCommandBuilder buil = new SqlCommandBuilder(da);
                da.Update(ds, "TIMKIEM");
                return true;
            }
            catch
            {
                return false;
            }
        }


        // TIN NHẮN
        public DataTable loadTN()
        {
            str = "select * from TINNHAN";
            da = new SqlDataAdapter(str, cnn);
            da.Fill(ds, "TINNHAN");
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["TINNHAN"].Columns[0];
            ds.Tables["TINNHAN"].PrimaryKey = keys;
            return ds.Tables["TINNHAN"];
        }


        public bool ThemTN(string matn, string nd, string makh, DateTime ngnhan)
        {
            try
            {
                DataRow dr = ds.Tables["TINNHAN"].NewRow();
                dr[0] = matn;
                dr[1] = nd;
                dr[2] = makh;
                dr[3] = ngnhan;
                ds.Tables["TINNHAN"].Rows.Add(dr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaTN(string matn)
        {
            try
            {
                DataRow dr = ds.Tables["TINNHAN"].Rows.Find(matn);
                if (dr != null)
                {
                    dr.Delete();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaTN(string matn, string nd, string makh, DateTime ngnhan)
        {
            try
            {
                DataRow dr = ds.Tables["TINNHAN"].Rows.Find(matn);
                if (dr != null)
                {
                    dr[0] = matn;
                    dr[1] = nd;
                    dr[2] = makh;
                    dr[3] = ngnhan;
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool LuuTN()
        {
            try
            {
                SqlCommandBuilder buil = new SqlCommandBuilder(da);
                da.Update(ds, "TINNHAN");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool TimMaBD(string MABD)
        {
            try
            {
                string str = string.Format("EXEC FINDBD '{0}'", MABD);
                SqlCommand cmd = new SqlCommand(str, cnn);
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TimMaBL(string MABL)
        {
            try
            {
                string str = string.Format("EXEC FINDBL '{0}'", MABL);
                SqlCommand cmd = new SqlCommand(str, cnn);
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TimMaKH(string MAKH)
        {
            try
            {
                string str = string.Format("EXEC FINDKH '{0}'", MAKH);
                SqlCommand cmd = new SqlCommand(str, cnn);
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TimMaNV(string MANV)
        {
            try
            {
                string str = string.Format("EXEC FINDNV '{0}'", MANV);
                SqlCommand cmd = new SqlCommand(str, cnn);
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TimMaSTR(string MASTR)
        {
            try
            {
                string str = string.Format("EXEC FINDSTR '{0}'", MASTR);
                SqlCommand cmd = new SqlCommand(str, cnn);
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TimMaTK(string MATK)
        {
            try
            {
                string str = string.Format("EXEC FINDTK '{0}'", MATK);
                SqlCommand cmd = new SqlCommand(str, cnn);
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TimMaTIMKIEM(string MATIMKIEM)
        {
            try
            {
                string str = string.Format("EXEC FINDTIMKIEM '{0}'", MATIMKIEM);
                SqlCommand cmd = new SqlCommand(str, cnn);
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TimMaTN(string MATN)
        {
            try
            {
                string str = string.Format("EXEC FINDTN '{0}'", MATN);
                SqlCommand cmd = new SqlCommand(str, cnn);
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TimMaTB(string MATB)
        {
            try
            {
                string str = string.Format("EXEC FINDTB '{0}'", MATB);
                SqlCommand cmd = new SqlCommand(str, cnn);
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                return true;
            }
            catch
            {
                return false;
            }
        }
        
    }
}
