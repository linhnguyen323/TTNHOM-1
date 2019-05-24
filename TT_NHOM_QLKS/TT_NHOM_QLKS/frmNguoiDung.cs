using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BUS;
using DTO;

namespace TT_NHOM_QLKS
{
    public partial class frmNguoiDung : Form
    {
        NguoiDungControl ctrl = new NguoiDungControl();
        public frmNguoiDung()
        {
            InitializeComponent();
        }

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            ctrl.HienThi(txtTenDangnhap, txtMatKhau, cmbLoaiNDung, dataGridViewX1, bindingNavigator1);
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            ctrl.Save();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xóa không?", "Nguoi Dung", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigator1.BindingSource.RemoveCurrent();
                ctrl.Save();
            }
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dataGridViewX1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xóa không?", "Nguoi Dung", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DataRow row = ctrl.NewRow();
            row["TenDangNhap"] = "";
            row["MatKhau"] = "";
            row["LoaiNguoiDung"] = cmbLoaiNDung.SelectedValue;
            ctrl.Add(row);
            bindingNavigator1.BindingSource.MoveLast();
        }

    }
}
