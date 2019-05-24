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
    public class LoaiDichVuControl
    {
        LoaiDichVuData data = new LoaiDichVuData();

        public void HienThi(DataGridView dg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            DataTable tbl = data.LayMaLoaiDichVu();
            bs.DataSource = tbl;
            dg.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienThiCombobox(ComboBox cmb)
        {
            cmb.DataSource = data.LayMaLoaiDichVu();
            cmb.DisplayMember = "MaLoaiDichVu";
            cmb.ValueMember = "MaLoaiDichVu";
        }

        public DataGridViewComboBoxColumn HienthiDataGridViewComboBoxColumn()
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            DataTable tbl = data.LayMaLoaiDichVu();
            cmb.DataSource = tbl;
            cmb.DisplayMember = "TenLoaiDichVu";
            cmb.ValueMember = "MaLoaiDichVu";
            cmb.DataPropertyName = "MaLoaiDichVu";
            cmb.HeaderText = "Mã loại dịch vụ";
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
