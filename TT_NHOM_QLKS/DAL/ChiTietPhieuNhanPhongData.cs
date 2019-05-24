using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ChiTietPhieuNhanPhongData
    {
        DataService ds = new DataService();
        public DataTable LayDanhSachChiTietPhieuNhan()
        {
            SqlCommand cmd = new SqlCommand("select * from CHI_TIET_PHIEU_NHAN_PHONG");
            ds.Load(cmd);
            return ds;
        }
        public int XoaChiTietPhieuNhan(String id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM CHI_TIET_PHIEU_NHAN_PHONG WHERE MaNhanPhong = @id");
            cmd.Parameters.Add("id", SqlDbType.VarChar, 10).Value = id;
            return ds.ExecuteNoneQuery(cmd);
        }

        public DataTable LayChiTietPhieuNhan(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from CHI_TIET_PHIEU_NHAN_PHONG WHERE MaNhanPhong = @id");
            cmd.Parameters.Add("id", SqlDbType.VarChar).Value = id;
            ds.Load(cmd);
            return ds;
        }

        public DataTable LayChiTietPhieuNhan(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from CHI_TIET_PHIEU_NHAN_PHONG WHERE MaNhanPhong = @id");
            cmd.Parameters.Add("id", SqlDbType.BigInt).Value = id;
            ds.Load(cmd);
            return ds;
        }


        public DataTable LaySoNgay(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from CHI_TIET_PHIEU_NHAN_PHONG");
            //cmd.Parameters.Add("id", SqlDbType.VarChar, 10).Value = id;
            ds.Load(cmd);
            return ds;
        }

        public DataRow NewRow()
        {
            return ds.NewRow();
        }

        public void Add(DataRow row)
        {
            ds.Rows.Add(row);
        }

        public bool Save()
        {
            return (ds.ExecuteNoneQuery() > 0);
        }
    }
}
