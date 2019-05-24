using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ChinhSachTraData
    {
        DataService ds = new DataService();
        public DataTable LayDSChinhSach()
        {
            SqlCommand cmd = new SqlCommand("select * from CHINH_SACH_TRA_PHONG");
            ds.Load(cmd);
            return ds;
        }

        public DataTable LayMaChinhSach(string macsach)
        {
            SqlCommand cmd = new SqlCommand("select * from CHINH_SACH_TRA_PHONG where MaChinhSach='" + macsach + "' ");
            ds.Load(cmd);
            return ds;
        }

        public DataTable TimMaChinhSach(string machinhsach)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM CHINH_SACH_TRA_PHONG WHERE MaChinhSach = @machinhsach ");
            cmd.Parameters.Add("machinhsach", SqlDbType.VarChar).Value = machinhsach;
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
