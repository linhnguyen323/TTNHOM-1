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
    public class HoaDonControl
    {
        HoaDonData data = new HoaDonData();
        ChiTietHoaDonData datact = new ChiTietHoaDonData();

        BindingSource bs = new BindingSource();
        public HoaDonControl()
        {
            //bs.DataSource = data.l("-1");
        }

        public void HienThiHoaDon(DataGridView dg, BindingNavigator pt)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayDanhSachHoaDon();
            dg.DataSource = bs;
            pt.BindingSource = bs;
        }

        public void HienThiComboboxMaHoaDon(ComboBox cmb)
        {
            HoaDonData hd = new HoaDonData();
            cmb.DataSource = hd.LayDanhSachHoaDon();
            cmb.DisplayMember = "MaHoaDon";
            cmb.ValueMember = "MaHoaDon";
        }

        public void HienthiDataGridviewComboBoxMaHoaDon(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = data.LayDanhSachHoaDon();
            cmb.DisplayMember = "MaHoaDon";
            cmb.ValueMember = "MaHoaDon";
            cmb.DataPropertyName = "MaHoaDon";
            cmb.HeaderText = "Mã hóa đơn";
        }

        public void HienthiHoaDon(BindingNavigator bn, TextBox txtMaHD, TextBox txtNhanVien, ComboBox cmbMaKH, ComboBox cmbMaPhieuNhan, NumericUpDown numTongtien, DateTimePicker dateNgayLap)
        {
            BindingSource bs = new BindingSource();
            bn.BindingSource = bs;

            txtMaHD.DataBindings.Clear();
            txtMaHD.DataBindings.Add("Text", bs, "MaHoaDon");

            txtNhanVien.DataBindings.Clear();
            txtNhanVien.DataBindings.Add("Text", bs, "NhanVienLap");

            cmbMaKH.DataBindings.Clear();
            cmbMaKH.DataBindings.Add("SelectedValue", bs, "MaKhachHang");

            cmbMaPhieuNhan.DataBindings.Clear();
            cmbMaPhieuNhan.DataBindings.Add("SelectedValue", bs, "MaNhanPhong");

            numTongtien.DataBindings.Clear();
            numTongtien.DataBindings.Add("Text", bs, "TongTien");

            dateNgayLap.DataBindings.Clear();
            dateNgayLap.DataBindings.Add("Text", bs, "NgayLap");
        }

        public HoaDonInFo LayHoaDon(String id)
        {
            DataTable tbl = data.LayMaHoaDon(id);
            HoaDonInFo ph = null;
            KhachHangControl khctrl = new KhachHangControl();
            PhieuNhanPhongControl ptctrl = new PhieuNhanPhongControl();
            if (tbl.Rows.Count > 0)
            {

                ph = new HoaDonInFo();
                ph.MaHoaDon = Convert.ToString(tbl.Rows[0]["MaHoaDon"]);
                ph.TenNhanVien = Convert.ToString(tbl.Rows[0]["NhanVienLap"]);
                ph.TenKhachHang = khctrl.LKH(Convert.ToString(tbl.Rows[0]["MaKhachHang"]));
                ph.MaNhanPhong = ptctrl.LayPhieuNhan(Convert.ToString(tbl.Rows[0]["MaNhanPhong"]));
                ph.TongTien = Convert.ToSingle(tbl.Rows[0]["TongTien"]);
                ph.NgayLap = Convert.ToDateTime(tbl.Rows[0]["NgayLap"]);
                ChiTietHoaDonControl cthd = new ChiTietHoaDonControl();
                ph.ChiTiet = cthd.ChiTietHoaDon(ph.MaHoaDon);
            }
            return ph;
        }

        public void TimPhieuNhan(string manhanphong)
        {
            data.TimPhieuNhan(manhanphong.ToString());
        }

        public void TimMaPhong(string maphong)
        {
            data.TimMaPhong(maphong.ToString());
        }

        public void TimMaSuDung(string masudung)
        {
            data.TimMaSuDung(masudung.ToString());
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
