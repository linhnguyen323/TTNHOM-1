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
    public partial class frmDanhSachKHDKThuePhong : Form
    {
        PhieuThuePhongControl ctrl = new PhieuThuePhongControl();
        PhongControl pctrl = new PhongControl();
        KhachHangControl khctrl = new KhachHangControl();
        public frmDanhSachKHDKThuePhong()
        {
            InitializeComponent();
        }

        private void frmDanhSachKHDKThuePhong_Load(object sender, EventArgs e)
        {
            khctrl.HienthiDataGridviewComboBox(MaKhachHang);
            ctrl.HienThiPhieuThue(dataGridViewX1, bindingNavigator1);
        }
        frmPhieuDangKy dangky = null;

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (dangky == null || dangky.IsDisposed)
            {
                dangky = new frmPhieuDangKy();
                dangky.Show();
            }
            else
                dangky.Activate();
        }

        private void toolStripButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phieu Dang Ky", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigator1.BindingSource.RemoveCurrent();
                ctrl.Save();
            }
        }

        private void dataGridViewX1_DoubleClick(object sender, EventArgs e)
        {
            if (dangky == null || dangky.IsDisposed)
            {
                dangky = new frmPhieuDangKy(ctrl);
                dangky.Show();
            }
            else
                dangky.Activate();
        }

        private void toolStripButtonLuu_Click(object sender, EventArgs e)
        {
            ctrl.Save();
        }

        private void toolTimKiem_Click(object sender, EventArgs e)
        {
            frmTimKhachHang tim = new frmTimKhachHang();
            Point p = PointToScreen(toolTimKiem.Bounds.Location);
            p.X += toolTimKiem.Width;
            p.Y += toolTimKiem.Height;
            tim.Location = p;
            tim.ShowDialog();
            if (tim.DialogResult == DialogResult.OK)
            {
                ctrl.TimKhachHang(tim.cmbtimKH.SelectedValue.ToString());
            }
        }
    }
}
