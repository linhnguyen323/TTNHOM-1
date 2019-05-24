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
    public partial class frmHoaDon : Form
    {
        HoaDonControl ctrl = new HoaDonControl();
        KhachHangControl khctrl = new KhachHangControl();
        PhieuNhanPhongControl pnctrl = new PhieuNhanPhongControl();
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            khctrl.HienthiDataGridviewComboBox(TenKhachHang);
            pnctrl.HienthiDataGridviewComboBox(MaNhanPhong);
            ctrl.HienThiHoaDon(dataGridViewX1, bindingNavigator1);
        }

        frmChiTietHoaDon chitiet = null;

        private void dataGridViewX1_DoubleClick(object sender, EventArgs e)
        {
            if (chitiet == null || chitiet.IsDisposed)
            {
                chitiet = new frmChiTietHoaDon();
                chitiet.Show();
            }
            else
                chitiet.Activate();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Hoa Don", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigator1.BindingSource.RemoveCurrent();
                ctrl.Save();
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (chitiet == null || chitiet.IsDisposed)
            {
                chitiet = new frmChiTietHoaDon();
                chitiet.Show();
            }
            else
                chitiet.Activate();
        }

        private void toolStripButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripTim_Click(object sender, EventArgs e)
        {
            frmTimPhieuNhan tim = new frmTimPhieuNhan();
            Point p = PointToScreen(toolStripTim.Bounds.Location);
            p.X += toolStripTim.Width;
            p.Y += toolStripTim.Height;
            tim.Location = p;
            tim.ShowDialog();
            if (tim.DialogResult == DialogResult.OK)
            {
                ctrl.TimPhieuNhan(tim.cmbTimPhieuNhan.SelectedValue.ToString());
            }
        }


    }
}
