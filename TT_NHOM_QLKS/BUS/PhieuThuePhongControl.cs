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
    public class PhieuThuePhongControl
    {
        PhieuThuePhongData data = new PhieuThuePhongData();
        ChiTietPhieuThuePhongData datact = new ChiTietPhieuThuePhongData();

        BindingSource bs = new BindingSource();
        public PhieuThuePhongControl()
        {
            bs.DataSource = data.LayPhieuDangKy("-1");
        }

        public void HienThiPhieuThue(DataGridView dg, BindingNavigator pt)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.DanhSachPhieudangKy();
            dg.DataSource = bs;
            pt.BindingSource = bs;
        }

        public void HienthiComboBoxMaPhieuThue(ComboBox cmb)
        {
            cmb.DataSource = data.DanhSachPhieudangKy();
            cmb.DisplayMember = "MaPhieuThue";
            cmb.ValueMember = "MaPhieuThue";
        }

        public void HienthiDataGridviewComboBox(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = data.DanhSachPhieudangKy();
            cmb.DisplayMember = "MaPhieuThue";
            cmb.ValueMember = "MaPhieuThue";
            cmb.DataPropertyName = "MaPhieuThue";
            cmb.HeaderText = "Mã phiếu thuê";
        }

        public void TimPhieuThue(string cmnd)
        {
            data.TimPhieuThue(cmnd.ToString());
        }

        public void TimKhachHang(string cmnd)
        {
            data.TimKhachHang(cmnd.ToString());
        }

        public void HienthiPhieuDangKy(BindingNavigator bn, TextBox txtMPT, ComboBox cmbMaKH)
        {
            BindingSource bs = new BindingSource();
            bn.BindingSource = bs;

            txtMPT.DataBindings.Clear();
            txtMPT.DataBindings.Add("Text", bs, "MaPhieuThue");

            cmbMaKH.DataBindings.Clear();
            cmbMaKH.DataBindings.Add("SelectedValue", bs, "MaKhachHang");

        }

        public PhieuThuePhongInFo LayPhieuThue(String id)
        {
            DataTable tbl = data.LayPhieuDangKy(id);
            PhieuThuePhongInFo ph = null;
            KhachHangControl khctrl = new KhachHangControl();
            if (tbl.Rows.Count > 0)
            {

                ph = new PhieuThuePhongInFo();
                ph.MaPhieuThue = Convert.ToString(tbl.Rows[0]["MaPhieuThue"]);
                ph.MaKhachHang = khctrl.LKH(Convert.ToString(tbl.Rows[0]["MaKhachHang"]));
                ChiTietPhieuThueControl ctrl = new ChiTietPhieuThueControl();
                ph.ChiTiet = ctrl.ChiTietPhieuThue(ph.MaPhieuThue);
            }
            return ph;
        }
        public void Update()
        {
            bs.MoveNext();
            data.Save();
        }
        public DataRow NewRow()
        {
            return data.NewRow();
        }
        public void Add(DataRow row)
        {
            data.Add(row);
        }
        public bool Save()
        {
            return data.Save();
        }
    }
}
