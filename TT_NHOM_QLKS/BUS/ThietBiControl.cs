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
    public class ThietBiControl
    {
        ThietBiData data = new ThietBiData();

        public void HienThi(DataGridView dg, BindingNavigator bn, DevComponents.DotNetBar.Controls.TextBoxX txtMaThietBi, DevComponents.DotNetBar.Controls.TextBoxX txtTenThietBi, DevComponents.DotNetBar.Controls.ComboBoxEx cmbMaLPhong, NumericUpDown numSoLuong)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayMaThietBi();
            dg.DataSource = bs;
            bn.BindingSource = bs;

            txtMaThietBi.DataBindings.Clear();
            txtMaThietBi.DataBindings.Add("Text", bs, "MaThietBi");

            txtTenThietBi.DataBindings.Clear();
            txtTenThietBi.DataBindings.Add("Text", bs, "TenThietBi");

            cmbMaLPhong.DataBindings.Clear();
            cmbMaLPhong.DataBindings.Add("SelectedValue", bs, "MaLoaiPhong");

            numSoLuong.DataBindings.Clear();
            numSoLuong.DataBindings.Add("Value", bs, "SoLuong");
        }

        public void TimMaLoaiPhong(string mlp)
        {
            data.TimMaLoaiPhong(mlp.ToString());
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
