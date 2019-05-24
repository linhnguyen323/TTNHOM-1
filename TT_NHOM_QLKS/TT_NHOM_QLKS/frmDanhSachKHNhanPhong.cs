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
using DTO;

namespace TT_NHOM_QLKS
{
    public partial class frmDanhSachKHNhanPhong : Form
    {
        PhieuNhanPhongControl ctrl = new PhieuNhanPhongControl();
        KhachHangControl khctrl = new KhachHangControl();
        PhieuThuePhongControl ptctrl = new PhieuThuePhongControl();
        PhongControl pctrl = new PhongControl();
        public frmDanhSachKHNhanPhong()
        {
            InitializeComponent();
        }

        private void frmDanhSachKHNhanPhong_Load(object sender, EventArgs e)
        {
            ptctrl.HienthiDataGridviewComboBox(MaPhieuThue);
            khctrl.HienthiDataGridviewComboBox(MaKhachHang);

            ctrl.HienThiPhieuNhan(dataGridViewX1, bindingNavigator1);
        }

        frmPhieuNhanPhong nhanphong = null;

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (nhanphong == null || nhanphong.IsDisposed)
            {
                nhanphong = new frmPhieuNhanPhong();
                nhanphong.Show();
            }
            else
                nhanphong.Activate();
        }

        private void toolStripButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DataRowView view = (DataRowView)bindingNavigator1.BindingSource.Current;
            if (view != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phieu Nhan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //ChiTietPhieuNhanControl ctrl = new ChiTietPhieuNhanControl();
                    //IList<QUANLYKHACHSAN.BusinessObject.ChiTietPhieuNhanPhongInFo> ds = ctrl.ChiTietPhieuNhan(view["MaNhanPhong"].ToString());

                    bindingNavigator1.BindingSource.RemoveCurrent();
                    ctrl.Save();
                }
            }
        }

        private void dataGridViewX1_DoubleClick(object sender, EventArgs e)
        {
            if (nhanphong == null || nhanphong.IsDisposed)
            {
                nhanphong = new frmPhieuNhanPhong();
                nhanphong.Show();
            }
            else
                nhanphong.Activate();
        }

        private void toolStripButtonLuu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            bindingNavigator1.BindingSource.MoveNext();
            ctrl.Save();
        }

        private void toolTimKiem_Click(object sender, EventArgs e)
        {
            frmTimPhieuThue tim = new frmTimPhieuThue();
            Point p = PointToScreen(toolTimKiem.Bounds.Location);
            p.X += toolTimKiem.Width;
            p.Y += toolTimKiem.Height;
            tim.Location = p;
            tim.ShowDialog();
            if (tim.DialogResult == DialogResult.OK)
            {
                ctrl.TimPhieuThue(tim.cmbMaPhieuThue.SelectedValue.ToString());
            }
        }

        private void dataGridViewX1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phieu Nhan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                DataRowView view = (DataRowView)bindingNavigator1.BindingSource.Current;
                ChiTietPhieuNhanControl ctrl = new ChiTietPhieuNhanControl();
                IList<ChiTietPhieuNhanPhongInFo> ds = ctrl.ChiTietPhieuNhan(view["MaNhanPhong"].ToString());

                ctrl.Save();
            }
        }


    }
}
