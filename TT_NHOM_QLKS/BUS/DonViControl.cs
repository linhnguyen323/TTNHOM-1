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
    public class DonViControl
    {
        DonViData data = new DonViData();
        public void HienThi(DataGridView dg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            DataTable tbl = data.LayMaDonVi();
            bs.DataSource = tbl;
            dg.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienThiCombobox(ComboBox cmb)
        {
            cmb.DataSource = data.LayMaDonVi();
            cmb.DisplayMember = "MaDonVi";
            cmb.ValueMember = "MaDonVi";
        }

        public DataGridViewComboBoxColumn HienthiDataGridViewComboBoxColumn()
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            DataTable tbl = data.LayMaDonVi();
            cmb.DataSource = tbl;
            cmb.DisplayMember = "TenDonVi";
            cmb.ValueMember = "MaDonVi";
            cmb.DataPropertyName = "MaDonVi";
            cmb.HeaderText = "Mã đơn vị";
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
