using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DAL;
using DTO;

namespace BUS
{
    public class NguoiDungControl
    {
        NguoiDungData data = new NguoiDungData();
        NguoiDungData data1 = new NguoiDungData();

        public NguoiDungControl()
        {

        }

        public void HienThi(TextBox txtTenNguoiDung, TextBox txtMatKhau, ComboBox cmbPhanQuyen, DataGridView dg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayDSNguoiDung();
            dg.DataSource = bs;
            bn.BindingSource = bs;
            txtTenNguoiDung.DataBindings.Add("Text", bs, "TenDangNhap");
            txtMatKhau.DataBindings.Add("Text", bs, "MatKhau");
            cmbPhanQuyen.DataBindings.Add("SelectedValue", bs, "LoaiNguoiDung");

            //them cot LOAI_NGUOI_DUNG vao bang 
            LoaiNguoiDungControl ctrlLoaiNguoiDung = new LoaiNguoiDungControl();
            ctrlLoaiNguoiDung.HienThiCombobox(cmbPhanQuyen);
            dg.Columns.Add(ctrlLoaiNguoiDung.LoadComboBoxColumn());
            dg.Columns.Remove("LoaiNguoiDung");

        }

        // 
        //0:Ko ton tai nguoi dung
        //1:Sai mat khau
        //2:Dang nhap thanh cong.
        //

        private int m_PhanQuyen;
        public int PhanQuyen
        {
            get { return m_PhanQuyen; }
            set { m_PhanQuyen = value; }
        }

        //Download source code tai Sharecode.vn
        public int DangNhap(String tenDangNhap, String matKhau)
        {
            DataTable nd = data.LayDSNguoiDung(tenDangNhap);
            if (nd.Rows.Count == 0)
                return 0;

            String matkhau_hethong = nd.Rows[0]["MatKhau"].ToString();
            if (matkhau_hethong != matKhau)
            {
                return 1;//Sai mat khau
            }
            else
            {
                PhanQuyen = Convert.ToInt32(nd.Rows[0]["LoaiNguoiDung"]);
                return 2;//Dang Nhap thanh cong
            }
        }


        public void UpdatePassword(String tenDangNhap, String matKhau)
        {
            data1.UpdatePassWord(tenDangNhap, matKhau);
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
