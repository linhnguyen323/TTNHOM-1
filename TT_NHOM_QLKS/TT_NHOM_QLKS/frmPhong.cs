using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAL;
using BUS;
using DTO;

namespace TT_NHOM_QLKS
{
    public partial class frmPhong : Form
    {
        PhongControl ctrl = new PhongControl();
        LoaiPhongControl lpctrl = new LoaiPhongControl();
        LoaiTinhTrangPhongControl lttpctrl = new LoaiTinhTrangPhongControl();
        public frmPhong()
        {
            InitializeComponent();
        }

        private void frmPhong_Load(object sender, EventArgs e)
        {
            lpctrl.HienthiComboBoxMLPhong(cmbMaLPhong);
            dataGridViewX1.Columns.Add(lpctrl.HienthiDataGridViewComboBoxColumn());
            lttpctrl.HienthiComboBox(cmbMaTTrPhong);
            dataGridViewX1.Columns.Add(lttpctrl.HienthiDataGridViewComboBoxColumn());
            ctrl.HienThi(txtMaPhong, cmbMaLPhong, cmbMaTTrPhong, txtGhichu, dataGridViewX1, bindingNavigator1);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn xóa không?","Phong",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                bindingNavigator1.BindingSource.RemoveCurrent();
                ctrl.Save();
                txtMaPhong.Focus();
                bindingNavigator1.BindingSource.MoveNext();
                ctrl.Save();
            }
        }

        private void btnMaLPhong_Click(object sender, EventArgs e)
        {
            frmLoaiPhong lp = new frmLoaiPhong();
            lp.ShowDialog();
            lpctrl.HienthiComboBoxMLPhong(cmbMaLPhong);
        }

        private void ThoatToolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ctrl.Save();
        }

        private void LuuToolStripButton_Click(object sender, EventArgs e)
        {
            txtMaPhong.Focus();
            bindingNavigator1.BindingSource.MoveNext();
            ctrl.Save();
        }

        private void toolTimKiem_Enter(object sender, EventArgs e)
        {
            toolTimKiem.Text = "";
            toolTimKiem.ForeColor = Color.Black;
        }

        private void toolTimKiem_Leave(object sender, EventArgs e)
        {
            if (tìmTheoMãLoạiPhòngToolStripMenuItem.Checked == true)
                tìmTheoMãLoạiPhòngToolStripMenuItem.Text = "Tìm theo mã loại phòng";
            else
                tìmTìnhTrạngPhòngToolStripMenuItem.Text = "Tìm theo tình trạng phòng";
            toolTimKiem.ForeColor = Color.FromArgb(224, 224, 224);
        }

        private void toolTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (tìmTheoMãLoạiPhòngToolStripMenuItem.Checked)
                    ctrl.TimMaLoaiPhong(toolTimKiem.Text);
                else
                    ctrl.TimTinhTrangPhong(toolTimKiem.Text);
            }
        }

        private void tìmTheoMãLoạiPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tìmTìnhTrạngPhòngToolStripMenuItem.Checked = false;
            tìmTheoMãLoạiPhòngToolStripMenuItem.Checked = true;
            toolTimKiem.Text = "Tìm theo mã loại phòng";
            bindingNavigator1.Focus();
        }

        private void tìmTìnhTrạngPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tìmTheoMãLoạiPhòngToolStripMenuItem.Checked = false;
            tìmTìnhTrạngPhòngToolStripMenuItem.Checked = true;
            toolTimKiem.Text = "Tìm theo tình trạng phòng";
            bindingNavigator1.Focus();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DataRow row = ctrl.NewRow();
            row["MaPhong"] = "";
            row["GhiChu"] = "";
            ctrl.Add(row);
            bindingNavigator1.BindingSource.MoveLast();
        }

        private void DataGV_Delete(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phong", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnTinhTrangPhong_Click(object sender, EventArgs e)
        {
            frmLoaiTinhTrangPhong lttp = new frmLoaiTinhTrangPhong();
            lttp.ShowDialog();
            lttpctrl.HienthiComboBox(cmbMaTTrPhong);
        }
    }
}
