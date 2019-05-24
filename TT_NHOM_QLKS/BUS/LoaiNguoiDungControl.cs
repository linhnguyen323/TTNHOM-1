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
    public class LoaiNguoiDungControl
    {
        LoaiNguoiDungData data = new LoaiNguoiDungData();
        public DataGridViewComboBoxColumn LoadComboBoxColumn()
        {
            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.DataSource = data.LayDSLoaiNguoiDung();
            col.DisplayMember = "LoaiNguoiDung";
            col.ValueMember = "LoaiNguoiDung";
            col.HeaderText = "Phân quyền";
            col.DataPropertyName = "LoaiNguoiDung";
            return col;
        }

        public void HienThiCombobox(ComboBox cmb)
        {
            cmb.DataSource = data.LayDSLoaiNguoiDung();
            cmb.DisplayMember = "LoaiNguoiDung";
            cmb.ValueMember = "LoaiNguoiDung";

        }

        public LoaiNguoiDungInFo LayLoaiNguoiDung(string id)
        {
            LoaiNguoiDungInFo lnd = null;
            DataTable tbl = data.LayDSLoaiNguoiDung_Q(id);
            if (tbl.Rows.Count > 0)
            {
                lnd = new LoaiNguoiDungInFo();
                lnd.loaiNguoiDung = Convert.ToInt32(tbl.Rows[0]["LoaiNguoiDung"]);
            }
            return lnd;
        }

        //public void UpdatePassWord(String tenDangNhap, String matKhau)
        //{
        //    data.UpdatePassWord(tenDangNhap, matKhau);
        //}

        public void Update()
        {
            data.Update();
        }
    }
}
