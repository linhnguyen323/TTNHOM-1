using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace TT_NHOM_QLKS
{
    public partial class frmDanhSachSDDV : Form
    {
        DanhSachSuDungDichVuControl ctrl = new DanhSachSuDungDichVuControl();
        DichVuControl dvctrl = new DichVuControl();
        PhieuNhanPhongControl pnctrl = new PhieuNhanPhongControl();
        public frmDanhSachSDDV()
        {
            InitializeComponent();
        }

        private void frmDanhSachSDDV_Load(object sender, EventArgs e)
        {
            dvctrl.HienThiCombobox(cmbMadichvu);
            dataGridViewX1.Columns.Add(dvctrl.HienthiDataGridViewComboBoxColumn());
            pnctrl.HienthiComboBoxMaPhieuNhan(cmbMaCTNhanPhong);
            dataGridViewX1.Columns.Add(pnctrl.HienthiDataGridViewComboBoxColumn());

            ctrl.HienThi(txtMaSuDung, cmbMadichvu, cmbMaCTNhanPhong, numSoLuong, dataGridViewX1, bindingNavigator1);

        }

        private void toolStripButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonLuu_Click(object sender, EventArgs e)
        {
            cmbMadichvu.Focus();
            bindingNavigator1.BindingSource.MoveNext();
            ctrl.Save();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Danh Sach Su Dung Dich Vu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigator1.BindingSource.RemoveCurrent();
                ctrl.Save();
            }
        }

        private void dataGridViewX1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Danh Sach Su Dung Dich Vu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void toolTimKiem_Enter(object sender, EventArgs e)
        {
            toolTimKiem.Text = "";
            toolTimKiem.ForeColor = Color.Black; 
        }

        private void toolTimKiem_Leave(object sender, EventArgs e)
        {
            if (tìmMãDịchVụToolStripMenuItem.Checked == true)
                tìmMãDịchVụToolStripMenuItem.Text = "Tìm theo mã dịch vụ";
            else
                tìmMãPhiếuNhậnToolStripMenuItem.Text = "Tìm theo mã phiếu nhận";

            toolTimKiem.ForeColor = Color.FromArgb(224, 224, 224);
        }

        private void toolTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (tìmMãDịchVụToolStripMenuItem.Checked)
                    ctrl.TimMaDichVu(toolTimKiem.Text);
                else
                    ctrl.TimMaPhieuNhan(toolTimKiem.Text);
            }
        }

        private void tìmMãDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tìmMãPhiếuNhậnToolStripMenuItem.Checked = false;
            tìmMãDịchVụToolStripMenuItem.Checked = true;
            toolTimKiem.Text = "Tìm theo mã dịch vụ";
            bindingNavigator1.Focus();
        }

        private void tìmMãPhiếuNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tìmMãPhiếuNhậnToolStripMenuItem.Checked = true;
            tìmMãDịchVụToolStripMenuItem.Checked = false;
            toolTimKiem.Text = "Tìm theo mã phiếu nhận";
            bindingNavigator1.Focus();
        }

        private void btnMaDVu_Click(object sender, EventArgs e)
        {
            frmDichVu dv = new frmDichVu();
            dv.ShowDialog();
            dvctrl.HienThiCombobox(cmbMadichvu);
        }

        private void btnMaPhieuNhan_Click(object sender, EventArgs e)
        {
            frmPhieuNhanPhong pn = new frmPhieuNhanPhong();
            pn.ShowDialog();
            pnctrl.HienthiComboBoxMaPhieuNhan(cmbMaCTNhanPhong);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DataRow row = ctrl.NewRow();

            row["MaSuDungDvu"] = "";
            row["SoLuong"] = 0;
           // row["TienDichVu"] = 0;
            ctrl.Add(row);
            bindingNavigator1.BindingSource.MoveLast();
            txtMaSuDung.Focus();
        }


    }
}
