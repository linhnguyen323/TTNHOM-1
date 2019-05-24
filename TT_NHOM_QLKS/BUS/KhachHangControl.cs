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
    public class KhachHangControl
    {
        KhachHangData data = new KhachHangData();

        public void HienThi(DataGridView dg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayMaKhachHang();

            dg.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienthiComboBox(ComboBox cmb)
        {
            cmb.DataSource = data.LayMaKhachHang();
            cmb.DisplayMember = "TenKhachHang";
            cmb.ValueMember = "MaKhachHang";
        }

        public void HienthiDataGridviewComboBox(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = data.LayMaKhachHang();
            cmb.DisplayMember = "TenKhachHang";
            cmb.ValueMember = "MaKhachHang";
            cmb.DataPropertyName = "MaKhachHang";
            cmb.HeaderText = "Khách hàng";
        }

        public KhachHangInFo LKH(String id)
        {
            DataTable tbl = data.LKH(id);
            KhachHangInFo kh = new KhachHangInFo();
            if (tbl.Rows.Count > 0)
            {
                kh.MaKhachHang = Convert.ToString(tbl.Rows[0]["MaKhachHang"]);
                kh.TenKhachHang = Convert.ToString(tbl.Rows[0]["TenKhachHang"]);
                kh.GioiTinh = Convert.ToString(tbl.Rows[0]["GioiTinh"]);
                kh.DienThoai = Convert.ToInt32(tbl.Rows[0]["DienThoai"]);
                kh.DiaChi = Convert.ToString(tbl.Rows[0]["DiaChi"]);
                kh.CMND = Convert.ToString(tbl.Rows[0]["CMND"]);
                kh.QuocTich = Convert.ToString(tbl.Rows[0]["QuocTich"]);
            }
            return kh;
        }

        public void TimHoTen(string hoten)
        {
            data.TimHoTen(hoten.ToString());
        }

        public void TimDiaChi(string diachi)
        {
            data.TimDiaChi(diachi.ToString());
        }

        public void TimGioiTinh(string gioitinh)
        {
            data.TimGioiTinh(gioitinh.ToString());
        }

        public void TimCMND(string cmnd)
        {
            data.TimCMND(cmnd.ToString());
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
