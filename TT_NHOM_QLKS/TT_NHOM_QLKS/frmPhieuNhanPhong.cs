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
using DTO;
using BUS;

namespace TT_NHOM_QLKS
{
    public partial class frmPhieuNhanPhong : Form
    {
        PhieuThuePhongControl ptctrl = new PhieuThuePhongControl();
        PhongControl pctrl = new PhongControl();
        PhongControl pctrl1 = new PhongControl();
        KhachHangControl khctrl = new KhachHangControl();
        PhieuNhanPhongControl ctrl = new PhieuNhanPhongControl();
        ChiTietPhieuNhanControl ctpnctrl = new ChiTietPhieuNhanControl();

        Controll status = Controll.Normal;
        public string maphong = "";
        public frmPhieuNhanPhong()
        {
            InitializeComponent();
            status = Controll.AddNew;
        }

        public frmPhieuNhanPhong(PhieuNhanPhongControl ctrlPN)
            : this()
        {
            this.ctrl = ctrlPN;
            status = Controll.Normal;
        }

        void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (status == Controll.Normal)
                ctpnctrl.HienThi(dataGridViewX1, txtMaNhanPhong.Text);
        }

        private void frmPhieuNhanPhong_Load(object sender, EventArgs e)
        {
            pctrl1.HienthiComboBoxPhongDat(cmbMaPhg);
            cmbMaPhg.SelectedValue = maphong;

            pctrl.HienthiDataGridviewComboBoxMaPhong(MaPhong);


            ptctrl.HienthiComboBoxMaPhieuThue(cmbMaPThue);
            khctrl.HienthiComboBox(cmbMaKH);

            ctrl.HienThiPhieuNhan(dataGridViewX1, bindingNavigator1);
            bindingNavigator1.BindingSource.CurrentChanged -= new EventHandler(BindingSource_CurrentChanged);
            bindingNavigator1.BindingSource.CurrentChanged += new EventHandler(BindingSource_CurrentChanged);

            ctpnctrl.HienThi(dataGridViewX1, txtMaNhanPhong.Text);
            if (status == Controll.AddNew)
            {
                txtMaNhanPhong.Text = ThamSo.LayPhieuNhan().ToString();
                Allow(true);
            }
            else
            {
                Allow(false);
            }
            f();
        }

        public void f()
        {

        }

        void Allow(bool val)
        {
            txtMaNhanPhong.Enabled = val;
            txtTenKH.Enabled = val;
            txtCMND.Enabled = val;
            cmbMaPThue.Enabled = val;
            cmbMaPhg.Enabled = val;
            cmbMaKH.Enabled = val;
            dtNgayNhan.Enabled = val;
            dtNgayTraDuKien.Enabled = val;
            dtNgayTraThucTe.Enabled = val;
            btnThemPDKy.Enabled = val;
            toolDoDuLieu.Enabled = val;
            dataGridViewX1.Enabled = val;
        }

        void Luu()
        {
            if (status == Controll.AddNew)
            {
                ThemMoi();
            }
            else
            {
                CapNhat();
            }
        }

        void CapNhat()
        {
            ctrl.Save();
            ctrl.Update();
        }

        void ThemMoi()
        {
            DataRow row = ctrl.NewRow();
            row["MaNhanPhong"] = txtMaNhanPhong.Text;
            row["MaPhieuThue"] = cmbMaPThue.SelectedValue;
            row["MaKhachHang"] = cmbMaKH.SelectedValue;

            ctrl.Add(row);

            PhieuNhanPhongControl ctrlPN = new PhieuNhanPhongControl();

            if (ctrlPN.LayPhieuNhan(txtMaNhanPhong.Text) != null)
            {
                MessageBox.Show("Mã Phiếu này đã tồn tại !", "Phieu Nhan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ThamSo.LaSoNguyen(txtMaNhanPhong.Text))
            {
                int so = Convert.ToInt32(txtMaNhanPhong.Text);
                if (so >= ThamSo.LayPhieuNhan())
                {
                    ThamSo.GanPhieuNhan(so + 1);
                }
            }

            ctrl.Update();
            DataTable tblCTP = (DataTable)bindingNavigator1.BindingSource.DataSource;

            ctpnctrl.Update();
            ctrl.Save();
            ctpnctrl.Save();
            khctrl.Save();
            ptctrl.Save();
        }

        private void toolStripButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemMaPhong_Click(object sender, EventArgs e)
        {
            frmPhong p = new frmPhong();
            p.ShowDialog();
            pctrl1.HienthiComboBox(cmbMaPhg);
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frmKhachHang kh = new frmKhachHang();
            kh.ShowDialog();
        }

        private void btnThemPDKy_Click(object sender, EventArgs e)
        {
            frmPhieuDangKy pdk = new frmPhieuDangKy();
            pdk.ShowDialog();
            ptctrl.HienthiComboBoxMaPhieuThue(cmbMaPThue);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            this.Luu();
            status = Controll.Normal;
            this.Allow(false);

            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                if (row.Cells["MaPhong"].Value != null)
                {
                    String maphong = row.Cells["MaPhong"].Value.ToString();
                    PhongData.CapNhatMaLoaiTinhTrangPhong(maphong, 3);
                }
            }
        }

        private void dataGridViewX1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xóa không?", "Phieu Nhan Phong", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnThemPhieuNhan_Click(object sender, EventArgs e)
        {
            status = Controll.AddNew;
            txtMaNhanPhong.Text = ThamSo.LayPhieuNhan().ToString();
            ctpnctrl.HienThi(dataGridViewX1, txtMaNhanPhong.Text);
            this.Allow(true);
        }

        private void toolDoDuLieu_Click(object sender, EventArgs e)
        {
            PhieuNhanPhongControl pnctrl = new PhieuNhanPhongControl();

            PhieuNhanPhongInFo pif = pnctrl.LayPhieuNhan(txtMaNhanPhong.Text.Trim());

            if (pif == null)
            {
                foreach (DataGridViewRow view in dataGridViewX1.Rows)
                {
                    if (cmbMaPhg.SelectedValue.ToString().Trim().Equals(view.Cells["MaPhong"].Value))
                    {
                        MessageBox.Show("Phòng tồn tại trong danh sách! Vui lòng nhập lại !", "Phieu Nhan Phong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (cmbMaPhg.SelectedValue.ToString().Trim().Length <= 0)
                {
                    MessageBox.Show("Vui lòng nhập Mã phiếu nhận !", "Phieu Nhan Phong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtTenKH.Text == "")
                {
                    MessageBox.Show("Nhập tên khách hàng!", "Phieu Nhan Phong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtCMND.Text == "")
                {
                    MessageBox.Show("Nhập chứng minh nhân dân!", "Phieu Nhan Phong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dtNgayNhan.Value > dtNgayTraDuKien.Value)
                {
                    MessageBox.Show("Ngày nhận phải nhỏ hơn ngày trả dự kiến!", "Phieu Nhan Phong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dtNgayNhan.Value > dtNgayTraThucTe.Value)
                {
                    MessageBox.Show("Ngày nhận phải nhỏ hơn ngày trả thực tế!", "Phieu Nhan Phong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dtNgayTraDuKien.Value > dtNgayTraThucTe.Value)
                {
                    MessageBox.Show("Ngày trả dự kiến phải nhỏ hơn ngày trả thực tế!", "Phieu Nhan Phong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataRow row = ctpnctrl.NewRow();

                    row["MaPhong"] = cmbMaPhg.SelectedValue.ToString();
                    row["MaNhanPhong"] = txtMaNhanPhong.Text;
                    row["HoTenKhachHang"] = txtTenKH.Text;
                    row["CMND"] = txtCMND.Text;
                    row["NgayNhan"] = dtNgayNhan.Value.Date;
                    row["NgayTraDuKien"] = dtNgayTraDuKien.Value.Date;
                    row["NgayTraThucTe"] = dtNgayTraThucTe.Value.Date;

                    ctpnctrl.Add(row);
                    bindingNavigator1.BindingSource.MoveLast();
                    txtMaNhanPhong.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mã phiếu này đã tồn tại! Vui lòng nhập lại !", "Phieu Nhan Phong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolTim_Click(object sender, EventArgs e)
        {
            frmTimPhieuNhan tim = new frmTimPhieuNhan();
            Point p = PointToScreen(toolTim.Bounds.Location);
            p.X += toolTim.Width;
            p.Y += toolTim.Height;
            tim.Location = p;
            tim.ShowDialog();
            if (tim.DialogResult == DialogResult.OK)
            {
                ctpnctrl.TimPhieuNhan(tim.cmbTimPhieuNhan.SelectedValue.ToString());
            }
        }

        private void toolStripButtonXoa_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)bindingNavigator1.BindingSource.Current;
            if (row != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phieu Nhan Phong", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bindingNavigator1.BindingSource.RemoveCurrent();
                    ctrl.Save();
                }
            }
        }
    }
}
