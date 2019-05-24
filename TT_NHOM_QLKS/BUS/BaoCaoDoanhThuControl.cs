using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using System.Windows.Forms;

namespace BUS
{
    public class BaoCaoDoanhThuControl
    {
        BaoCaoDoanhThuData data = new BaoCaoDoanhThuData();

        public void LayDS(BindingNavigator bd, DataGridView dt, int thang, int nam)
        {
            BindingSource ds = new BindingSource();
            ds.DataSource = data.TruyVan(thang, nam);
            bd.BindingSource = ds;
            dt.DataSource = ds;
        }

        public bool Save()
        {
            return this.data.Save();
        }
    }
}
