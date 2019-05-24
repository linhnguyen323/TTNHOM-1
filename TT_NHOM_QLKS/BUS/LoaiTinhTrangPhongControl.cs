using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BUS
{
    public class LoaiTinhTrangPhongControl
    {
        LoaiTinhTrangPhongData data = new LoaiTinhTrangPhongData();

        public void HienThi(DataGridView dg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayDSTinhTrangPhong();
            dg.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienthiComboBox(ComboBox combobox)
        {
            combobox.DataSource = data.LayDSTinhTrangPhong();
            combobox.DisplayMember = "MaLoaiTinhTrangPhong";
            combobox.ValueMember = "MaLoaiTinhTrangPhong";
        }

        public DataGridViewComboBoxColumn HienthiDataGridViewComboBoxColumn()
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            DataTable tbl = data.LayDSTinhTrangPhong();
            cmb.DataSource = tbl;
            cmb.DisplayMember = "MaLoaiTinhTrangPhong";
            cmb.ValueMember = "MaLoaiTinhTrangPhong";
            cmb.DataPropertyName = "MaLoaiTinhTrangPhong";
            cmb.HeaderText = "Mã loại tình trạng phòng";
            return cmb;
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
