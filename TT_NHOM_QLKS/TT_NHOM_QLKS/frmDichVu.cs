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
    public partial class frmDichVu : Form
    {
        DichVuControl ctrl = new DichVuControl();
        LoaiDichVuControl ldvctrl = new LoaiDichVuControl();
        DonViControl dvctrl = new DonViControl();
        public frmDichVu()
        {
            InitializeComponent();
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            ldvctrl.HienThiCombobox(cmbMaLDVu);
            dataGridViewX1.Columns.Add(ldvctrl.HienthiDataGridViewComboBoxColumn());
            dvctrl.HienThiCombobox(cmbMadonVi);
            dataGridViewX1.Columns.Add(dvctrl.HienthiDataGridViewComboBoxColumn());
            ctrl.HienThi(txtMaDVu, cmbMaLDVu, cmbMadonVi, numericUpDownDGia, dataGridViewX1, bindingNavigator1);
           
        }

        private void toolStripButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonLuu_Click(object sender, EventArgs e)
        {
            txtMaDVu.Focus();
            bindingNavigator1.BindingSource.MoveNext();
            ctrl.Save();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xóa không?", "Dich Vu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigator1.BindingSource.RemoveCurrent();
                ctrl.Save();
            }
        }

        private void dataGridViewX1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xóa không?", "Dich Vu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnThemMLDV_Click(object sender, EventArgs e)
        {
            frmLoaiDV ldv = new frmLoaiDV();
            ldv.ShowDialog();
            ldvctrl.HienThiCombobox(cmbMaLDVu);
        }

        private void btnThemMaDVi_Click(object sender, EventArgs e)
        {
            frmDonVi dv = new frmDonVi();
            dv.ShowDialog();
            dvctrl.HienThiCombobox(cmbMadonVi);
        }

        private void TimMaLDVuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimDonViToolStripMenuItem.Checked = false;
            TimMaLDVuToolStripMenuItem.Checked = true;
            toolTimKiem.Text = "Tìm theo mã loại dịch vụ";
            bindingNavigator1.Focus();
        }

        private void toolTimKiem_Enter(object sender, EventArgs e)
        {
            toolTimKiem.Text = "";
            toolTimKiem.ForeColor = Color.Black; 
        }

        private void toolTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (TimMaLDVuToolStripMenuItem.Checked)
                    ctrl.TimMaLoaiDichVu(toolTimKiem.Text);
                else
                    ctrl.TimMaDonVi(toolTimKiem.Text);
            }
        }

        private void toolTimKiem_Leave(object sender, EventArgs e)
        {
            if (TimMaLDVuToolStripMenuItem.Checked == true)
                TimMaLDVuToolStripMenuItem.Text = "Tìm theo mã loại dịch vụ";
            else
                TimDonViToolStripMenuItem.Text = "Tìm theo mã đơn vị";

            toolTimKiem.ForeColor = Color.FromArgb(224, 224, 224);
        }

        private void TimDonViToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimDonViToolStripMenuItem.Checked = true;
            TimMaLDVuToolStripMenuItem.Checked = false;
            toolTimKiem.Text = "Tìm theo mã đơn vị";
            bindingNavigator1.Focus();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DataRow row = ctrl.NewRow();
            row["MaDichVu"] = "";
            row["DonGia"] = 0;
            ctrl.Add(row);
            bindingNavigator1.BindingSource.MoveLast();
        }



    }
}
