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
    public class PhieuNhanPhongControl
    {
        PhieuNhanPhongData data = new PhieuNhanPhongData();
        ChiTietPhieuNhanPhongData datact = new ChiTietPhieuNhanPhongData();

        BindingSource bs = new BindingSource();
        public PhieuNhanPhongControl()
        {
            bs.DataSource = data.LayMaNhanPhong("-1");
        }

        public void HienThiPhieuNhan(DataGridView dg, BindingNavigator pt)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayDanhSachNhanPhong();
            dg.DataSource = bs;
            pt.BindingSource = bs;
        }

        public void HienthiComboBoxMaPhieuNhan(ComboBox cmb)
        {
            cmb.DataSource = data.LayDanhSachNhanPhong();
            cmb.DisplayMember = "MaNhanPhong";
            cmb.ValueMember = "MaNhanPhong";
        }

        public void HienthiDataGridviewComboBox(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = data.LayDanhSachNhanPhong();
            cmb.DisplayMember = "MaNhanPhong";
            cmb.ValueMember = "MaNhanPhong";
            cmb.DataPropertyName = "MaNhanPhong";
            cmb.HeaderText = "Mã nhận phòng";
        }

        public DataGridViewComboBoxColumn HienthiDataGridViewComboBoxColumn()
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            DataTable tbl = data.LayDanhSachNhanPhong();
            cmb.DataSource = tbl;
            cmb.DisplayMember = "MaNhanPhong";
            cmb.ValueMember = "MaNhanPhong";
            cmb.DataPropertyName = "MaNhanPhong";
            cmb.HeaderText = "Mã nhận phòng";
            return cmb;
        }


        public void HienthiPhieuNhanPhong(BindingNavigator bn, TextBox txtMPN, ComboBox cmbMaKH, ComboBox cmbMaPhieuThue)
        {
            BindingSource bs = new BindingSource();
            bn.BindingSource = bs;

            txtMPN.DataBindings.Clear();
            txtMPN.DataBindings.Add("Text", bs, "MaNhanPhong");

            cmbMaKH.DataBindings.Clear();
            cmbMaKH.DataBindings.Add("SelectedValue", bs, "MaKhachHang");

            cmbMaPhieuThue.DataBindings.Clear();
            cmbMaPhieuThue.DataBindings.Add("SelectedValue", bs, "MaPhieuThue");
        }

        public PhieuNhanPhongInFo LayPhieuNhan(String id)
        {
            DataTable tbl = data.LayMaNhanPhong(id);
            PhieuNhanPhongInFo ph = null;
            KhachHangControl khctrl = new KhachHangControl();
            PhieuThuePhongControl ptctrl = new PhieuThuePhongControl();
            if (tbl.Rows.Count > 0)
            {

                ph = new PhieuNhanPhongInFo();
                ph.MaNhanPhong = Convert.ToString(tbl.Rows[0]["MaNhanPhong"]);
                ph.MaPhieuThue = ptctrl.LayPhieuThue(Convert.ToString(tbl.Rows[0]["MaPhieuThue"]));
                ph.MaKhachHang = khctrl.LKH(Convert.ToString(tbl.Rows[0]["MaKhachHang"]));

                ChiTietPhieuNhanControl ctrl = new ChiTietPhieuNhanControl();
                ph.ChiTiet = ctrl.ChiTietPhieuNhan(ph.MaNhanPhong);
            }
            return ph;
        }
        public void TimPhieuThue(string mathuephong)
        {
            data.TimPhieuThue(mathuephong.ToString());
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
