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
    public class DichVuControl
    {
        DichVuData data = new DichVuData();

        public DichVuInFo LayMaDichVu(string madv)
        {
            DichVuData dv = new DichVuData();
            DonViControl dvctrl = new DonViControl();
            LoaiDichVuControl ldvctrl = new LoaiDichVuControl();
            DichVuInFo pif = null;
            pif = new DichVuInFo();
            DataTable tbl = dv.LayMaDSDichVu(madv);
            if (tbl.Rows.Count > 0)
            {
                pif.MaDichVu = Convert.ToString(tbl.Rows[0]["MaDichVu"]);
                pif.DonGia = Convert.ToSingle(tbl.Rows[0]["DonGia"]);
                pif.MaDonVi = Convert.ToString(tbl.Rows[0]["MaDonVi"]);
                pif.MaLoaiDichVu = Convert.ToString(tbl.Rows[0]["MaLoaiDichVu"]);

            }
            return pif;

        }

        public void HienThi(TextBox txtMaDVu, ComboBox cmbMaLDVu, ComboBox cmbMaDonVi, NumericUpDown numDonGia, DataGridView dg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayMaDichVu();
            dg.DataSource = bs;
            bn.BindingSource = bs;

            txtMaDVu.DataBindings.Clear();
            txtMaDVu.DataBindings.Add("Text", bs, "MaDichVu");
            //Download source code tai Sharecode.vn
            cmbMaLDVu.DataBindings.Clear();
            cmbMaLDVu.DataBindings.Add("SelectedValue", bs, "MaLoaiDichVu");

            cmbMaDonVi.DataBindings.Clear();
            cmbMaDonVi.DataBindings.Add("SelectedValue", bs, "MaDonVi");

            numDonGia.DataBindings.Clear();
            numDonGia.DataBindings.Add("Value", bs, "DonGia");
        }

        public void HienThiCombobox(ComboBox cmb)
        {
            cmb.DataSource = data.LayMaDichVu();
            cmb.DisplayMember = "MaDichVu";
            cmb.ValueMember = "MaDichVu";
        }

        public DataGridViewComboBoxColumn HienthiDataGridViewComboBoxColumn()
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            DataTable tbl = data.LayMaDichVu();
            cmb.DataSource = tbl;
            cmb.DisplayMember = "MaDichVu";
            cmb.ValueMember = "MaDichVu";
            cmb.DataPropertyName = "MaDichVu";
            cmb.HeaderText = "Mã dịch vụ";
            return cmb;
        }

        public void TimMaLoaiDichVu(string maloaidichvu)
        {
            data.TimMaLoaiDichVu(maloaidichvu.ToString());
        }

        public void TimMaDonVi(string madonvi)
        {
            data.TimMaDonVi(madonvi.ToString());
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
