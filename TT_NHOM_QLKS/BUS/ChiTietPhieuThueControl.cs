using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
using DAL;
using System.Windows.Forms;

namespace BUS
{
    public class ChiTietPhieuThueControl
    {
        ChiTietPhieuThuePhongData data = new ChiTietPhieuThuePhongData();
        public void HienThi(DataGridView dg, String id)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayChiTietPhieuDangKy(id);
            dg.DataSource = bs;
            //bn.BindingSource = bs;            
        }

        public void TimPhong(string cmnd)
        {
            data.TimPhong(cmnd.ToString());
        }

        public void TimPhieuThue(string cmnd)
        {
            data.LayChiTietPhieuDangKy(cmnd.ToString());
        }

        public DataRow NewRow()
        {
            return this.data.NewRow();
        }

        public void Add(DataRow row)
        {
            this.data.Add(row);
        }

        public bool Save()
        {
            return this.data.Save();
        }

        public void Update()
        {
            BindingSource bs = new BindingSource();
            bs.MoveNext();
            data.Save();
        }

        public IList<ChiTietPhieuThuePhongInFo> ChiTietPhieuThue(String id)
        {
            IList<ChiTietPhieuThuePhongInFo> ds = new List<ChiTietPhieuThuePhongInFo>();

            DataTable tbl = data.LayChiTietPhieuDangKy(id);
            foreach (DataRow row in tbl.Rows)
            {
                //PhongControl pctrl = new PhongControl();
                ChiTietPhieuThuePhongInFo ct = new ChiTietPhieuThuePhongInFo();
                ct.MaPhieuThue = Convert.ToString(row["MaPhieuThue"]);
                ct.NgayDangKy = Convert.ToDateTime(row["NgayDangKy"]);
                ct.NgayNhan = Convert.ToDateTime(row["NgayNhan"]);
                ct.MaPhong = Convert.ToString(row["MaPhong"]);

                ds.Add(ct);
            }
            return ds;
        }

        public ChiTietPhieuThuePhongInFo LayPhieuThue(String id)
        {
            DataTable tbl = data.LayChiTietPhieuDangKy(id);
            ChiTietPhieuThuePhongInFo ph = null;
            PhongControl pctrl = new PhongControl();
            if (tbl.Rows.Count > 0)
            {
                ph.MaPhieuThue = Convert.ToString(tbl.Rows[0]["MaPhieuThue"]);
                ph.NgayDangKy = Convert.ToDateTime(tbl.Rows[0]["NgayDangKy"]);
                ph.NgayNhan = Convert.ToDateTime(tbl.Rows[0]["NgayNhan"]);
                ph.MaPhong = Convert.ToString(tbl.Rows[0]["MaPhong"]);
            }
            return ph;
        }
    }
}
