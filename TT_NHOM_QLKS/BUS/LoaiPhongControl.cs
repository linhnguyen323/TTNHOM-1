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
    public class LoaiPhongControl
    {
        LoaiPhongData data = new LoaiPhongData();

        public LoaiPhongInFo LayLoaiPhong(string id)
        {
            LoaiPhongInFo lph = null;
            lph = new LoaiPhongInFo();
            DataTable tbl = data.LayMaLoaiPhongml(id);
            if (tbl.Rows.Count > 0)
            {

                lph.MaLoaiPhong = Convert.ToString(tbl.Rows[0]["MaLoaiPhong"]);
                lph.TenLoaiPhong = Convert.ToString(tbl.Rows[0]["TenLoaiPhong"]);
                lph.DonGia = Convert.ToInt64(tbl.Rows[0]["DonGia"]);
                lph.SoNguoiChuan = Convert.ToInt32(tbl.Rows[0]["SoNguoiChuan"]);
                lph.SoNguoiToiDa = Convert.ToInt32(tbl.Rows[0]["SoNguoiToiDa"]);
                lph.TyLeTang = Convert.ToInt16(tbl.Rows[0]["TyLeTang"] != DBNull.Value ? tbl.Rows[0]["TyLeTang"] : 0);
            }
            return lph;
        }


        public LoaiPhongInFo LayLoaiPhongML(string id)
        {
            LoaiPhongInFo lph = null;
            DataTable tbl = data.LayMaLoaiPhongml(id);
            if (tbl.Rows.Count > 0)
            {
                lph = new LoaiPhongInFo();
                lph.MaLoaiPhong = Convert.ToString(tbl.Rows[0]["MaLoaiPhong"]);
                lph.TenLoaiPhong = Convert.ToString(tbl.Rows[0]["TenLoaiPhong"]);
                lph.DonGia = Convert.ToInt64(tbl.Rows[0]["DonGia"]);
                lph.SoNguoiChuan = Convert.ToInt32(tbl.Rows[0]["SoNguoiChuan"]);
                lph.SoNguoiToiDa = Convert.ToInt32(tbl.Rows[0]["SoNguoiToiDa"]);
                lph.TyLeTang = Convert.ToInt16(tbl.Rows[0]["TyLeTang"] != DBNull.Value ? tbl.Rows[0]["TyLeTang"] : 0);
            }
            return lph;
        }

        public void HienThi(DataGridView dg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            DataTable tbl = data.LayMaLoaiPhong();
            bs.DataSource = tbl;
            dg.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienthiComboBoxMLPhong(ComboBox combobox)
        {
            combobox.DataSource = data.LayMaLoaiPhong();
            combobox.DisplayMember = "MaLoaiPhong";
            combobox.ValueMember = "MaLoaiPhong";
        }

        public DataGridViewComboBoxColumn HienthiDataGridViewComboBoxColumn()
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            DataTable tbl = data.LayMaLoaiPhong();
            cmb.DataSource = tbl;
            cmb.DisplayMember = "TenLoaiPhong";
            cmb.ValueMember = "MaLoaiPhong";
            cmb.DataPropertyName = "MaLoaiPhong";
            cmb.HeaderText = "Mã loại phòng";
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
