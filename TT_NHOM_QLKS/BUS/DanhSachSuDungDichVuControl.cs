using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BUS
{
    public class DanhSachSuDungDichVuControl
    {
        DanhSachSuDungDichVuData data = new DanhSachSuDungDichVuData();

        public DanhSachSuDungDichVuInFo LayDSSuDungDVu(string madvu)
        {
            PhieuNhanPhongControl pnctrl = new PhieuNhanPhongControl();
            DichVuControl dvctrl = new DichVuControl();
            DanhSachSuDungDichVuInFo pif = null;
            pif = new DanhSachSuDungDichVuInFo();
            DataTable tbl = data.LayMaDSSuDungDichVu(madvu);
            if (tbl.Rows.Count > 0)
            {
                pif.MaDichVu = Convert.ToString(tbl.Rows[0]["MaDichVu"]);
                pif.MaNhanPhong = pnctrl.LayPhieuNhan(Convert.ToString(tbl.Rows[0]["MaNhanPhong"]));
                pif.SoLuong = Convert.ToInt32(tbl.Rows[0]["SoLuong"]);
                //pif.TienDichVu = Convert.ToSingle(tbl.Rows[0]["TienDichVu"] != DBNull.Value ? tbl.Rows[0]["TienDichVu"] : 0);

            }
            return pif;

        }

        public void HienThi(TextBox txtMaSuDung, ComboBox cmbMaDVu, ComboBox cmbMaPhieuNhan, NumericUpDown numSoLuong, DataGridView dg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayMaSuDungDichVu();
            dg.DataSource = bs;
            bn.BindingSource = bs;

            txtMaSuDung.DataBindings.Clear();
            txtMaSuDung.DataBindings.Add("Text", bs, "MaSuDungDVu");

            cmbMaDVu.DataBindings.Clear();
            cmbMaDVu.DataBindings.Add("SelectedValue", bs, "MaDichVu");

            cmbMaPhieuNhan.DataBindings.Clear();
            cmbMaPhieuNhan.DataBindings.Add("SelectedValue", bs, "MaNhanPhong");

            numSoLuong.DataBindings.Clear();
            numSoLuong.DataBindings.Add("value", bs, "SoLuong");
        }

        public DataGridViewComboBoxColumn HienthiDataGridViewComboBoxColumn()
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            DataTable tbl = data.LayMaSuDungDichVu();
            cmb.DataSource = tbl;
            cmb.DisplayMember = "MaSuDungDVu";
            cmb.ValueMember = "MaSuDungDVu";
            cmb.DataPropertyName = "MaSuDungDVu";
            cmb.HeaderText = "Mã sử dụng Dv";
            return cmb;
        }

        public void HienthiComboBoxMaSuDung(ComboBox cmb)
        {
            cmb.DataSource = data.LayMaSuDungDichVu();
            cmb.DisplayMember = "MaSuDungDVu";
            cmb.ValueMember = "MaSuDungDVu";
        }

        public float TinhTienDichVu(String masudung)
        {
            float tien = 0;
            DataTable tbl = data.TimMaDichVu(masudung);

            for (int i = 0; i < tbl.DefaultView.Count; i++)
            {
                DichVuData dvdata = new DichVuData();
                DataTable tblTienDV = dvdata.DonGiaDichVu(tbl.Rows[i]["MaDichVu"].ToString());
                float dongia = Convert.ToInt16(tblTienDV.Rows[0]["DonGia"]);
                int soLan = Convert.ToInt32(tbl.Rows[i]["SoLuong"]);
                tien = tien + (dongia * soLan);
            }
            return tien;

        }

        public void TimMaDichVu(string madichvu)
        {
            data.TimMaDichVu(madichvu.ToString());
        }

        public void TimMaPhieuNhan(string phieunhanphong)
        {
            data.TimMaPhieuNhan(phieunhanphong.ToString());
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
