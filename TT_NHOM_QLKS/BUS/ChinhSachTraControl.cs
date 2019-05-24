using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using DTO;
using System.Windows.Forms;

namespace BUS
{
    public class ChinhSachTraControl
    {
        ChinhSachTraData data = new ChinhSachTraData();
        public void HienThi(DataGridView dg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            DataTable tbl = data.LayDSChinhSach();
            bs.DataSource = tbl;
            dg.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienThiCombobox(ComboBox cmb)
        {
            cmb.DataSource = data.LayDSChinhSach();
            cmb.DisplayMember = "MaChinhSach";
            cmb.ValueMember = "MaChinhSach";
        }

        public DataGridViewComboBoxColumn HienthiDataGridViewComboBoxColumn()
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            DataTable tbl = data.LayDSChinhSach();
            cmb.DataSource = tbl;
            cmb.DisplayMember = "MaChinhSach";
            cmb.ValueMember = "MaChinhSach";
            cmb.DataPropertyName = "MaChinhSach";
            cmb.HeaderText = "Mã chính sách";
            return cmb;
        }

        public ChinhSachTraInFo LayMaChinhSach(string macs)
        {
            ChinhSachTraInFo pif = null;
            pif = new ChinhSachTraInFo();
            DataTable tbl = data.LayMaChinhSach(macs);
            if (tbl.Rows.Count > 0)
            {
                pif = new ChinhSachTraInFo();
                pif.MaChinhSachTra = Convert.ToString(tbl.Rows[0]["MaChinhSach"]);
                pif.ThoiGian = Convert.ToString(tbl.Rows[0]["ThoiGianQuiDinh"]);
                pif.PhuThu = Convert.ToSingle(tbl.Rows[0]["PhuThu"]);//!= DBNull.Value ? tbl.Rows[0]["PhuThu"] : 0);
            }
            return pif;
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
    }
}
