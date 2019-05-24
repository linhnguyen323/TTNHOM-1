using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAL;
using BUS;

namespace TT_NHOM_QLKS
{
    public partial class frmPhieuDangKy : Form
    {
        PhongControl pctrl = new PhongControl();
        PhongControl pctrl1 = new PhongControl();
        KhachHangControl khctrl = new KhachHangControl();
        PhieuThuePhongControl ctrl = new PhieuThuePhongControl();
        ChiTietPhieuThueControl ctpnctrl = new ChiTietPhieuThueControl();

        Controll status = Controll.Normal;
        public string maphong = "";
        public frmPhieuDangKy()
        {
            InitializeComponent();
            status = Controll.AddNew;
        }

        public frmPhieuDangKy(PhieuThuePhongControl ctrlPT)
            : this()
        {
            this.ctrl = ctrlPT;
            status = Controll.Normal;
        }

        void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (status == Controll.Normal)
                pctrl.HienThiChiTietPhieuDangKy(dataGridViewX1, txtMaPhieuThue.Text);
        }

        private void btnMaPhong_Click(object sender, EventArgs e)
        {
            frmPhong p = new frmPhong();
            p.ShowDialog();
            pctrl1.HienthiComboBox(cmbMaPHong);
        }

        private void btnMaKH_Click(object sender, EventArgs e)
        {
            frmKhachHang kh = new frmKhachHang();
            kh.ShowDialog();
            khctrl.HienthiComboBox(cmbMaKH);
        }

        void Allow(bool val)
        {
            txtMaPhieuThue.Enabled = val;
            cmbMaKH.Enabled = val;
            cmbMaPHong.Enabled = val;
            dateNgayDangKy.Enabled = val;
            dateTimeNgayNhan.Enabled = val;
            btnMaKH.Enabled = val;
            btnMaPhong.Enabled = val;
            //dataGridViewX1.Enabled = val;
        }

        private void toolStripluu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            this.Luu();
            status = Controll.Normal;
            this.Allow(false);

            foreach(DataGridViewRow row in dataGridViewX1.Rows)
            {
                if (row.Cells["MaPhong"].Value != null)
                {
                    String maphongt = row.Cells["MaPhong"].Value.ToString();
                    PhongData.CapNhatMaLoaiTinhTrangPhong(maphongt, 2);
                }
            }
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
            row["MaPhieuThue"] = txtMaPhieuThue.Text;
            row["MaKhachHang"] = cmbMaKH.SelectedValue;

            ctrl.Add(row);

            PhieuThuePhongControl ctrlPN = new PhieuThuePhongControl();

            if (ctrlPN.LayPhieuThue(txtMaPhieuThue.Text) != null)
            {
                MessageBox.Show("Mã Phiếu này đã tồn tại !", "Phieu Thue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ThamSo.LaSoNguyen(txtMaPhieuThue.Text))
            {
                int so = Convert.ToInt32(txtMaPhieuThue.Text);
                if (so >= ThamSo.LayPhieuDangKy())
                {
                    ThamSo.GanPhieuDangKy(so + 1);
                }
            }

            ctrl.Update();
            DataTable tblCTP = (DataTable)bindingNavigator1.BindingSource.DataSource;

            ctpnctrl.Update();
            ctrl.Save();
            ctpnctrl.Save();
            khctrl.Save();
            //ptctrl.Save();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phieu Nhan Phong", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigator1.BindingSource.RemoveCurrent();
                ctrl.Save();
            }
        }

        private void dataGridViewX1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn xóa không?","Phieu Nhan Phong",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            status = Controll.AddNew;
            txtMaPhieuThue.Text = ThamSo.LayPhieuNhan().ToString();
            ctpnctrl.HienThi(dataGridViewX1, txtMaPhieuThue.Text);
            this.Allow(true);
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolDoDuLieu_Click(object sender, EventArgs e)
        {
            PhieuThuePhongControl pctrl = new PhieuThuePhongControl();
            PhieuThuePhongInFo pif = pctrl.LayPhieuThue(txtMaPhieuThue.Text.Trim());
            if (pif == null)
            {
                foreach (DataGridViewRow view in dataGridViewX1.Rows)
                {
                    if (cmbMaPHong.SelectedValue.ToString().Trim().Equals(view.Cells["MaPhong"].Value))
                    {
                        MessageBox.Show("Phòng tồn tại trong danh sách! Vui lòng nhập lại !", "Phieu Dang Ky", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (cmbMaPHong.SelectedValue.ToString().Trim().Length <= 0)
                {
                    MessageBox.Show("Vui lòng nhập Mã phiếu thuê !", "Phieu Thue Phong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }               
                else if (dateNgayDangKy.Value > dateTimeNgayNhan.Value)
                {
                    MessageBox.Show("Ngày đăng ký phải nhỏ hơn hoặc bằng ngày nhận!", "Phieu Thue Phong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                             
                else
                { 
                    DataRow row = ctpnctrl.NewRow();
                    
                    row["MaPhieuThue"] = txtMaPhieuThue.Text;
                    row["MaPhong"] = cmbMaPHong.SelectedValue.ToString();
                    row["NgayDangKy"] = dateNgayDangKy.Value.Date;                         
                    row["NgayNhan"] = dateTimeNgayNhan.Value.Date;                                 

                    ctpnctrl.Add(row);
                    bindingNavigator1.BindingSource.MoveLast();
                    txtMaPhieuThue.Focus();
                } 
            }
            else
            {
                MessageBox.Show("Mã phiếu này đã tồn tại! Vui lòng nhập lại !", "Phieu Thue Phong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PhieuDangKy_Load(object sender, EventArgs e)
        {
            pctrl1.HienthiComboBox(cmbMaPHong);
            cmbMaPHong.SelectedValue = maphong;
            pctrl.HienthiDataGridviewComboBoxMaPhong(MaPhong);

            khctrl.HienthiComboBox(cmbMaKH);
            ctrl.HienThiPhieuThue(dataGridViewX1, bindingNavigator1);
            bindingNavigator1.BindingSource.CurrentChanged -= new EventHandler(BindingSource_CurrentChanged);
            bindingNavigator1.BindingSource.CurrentChanged += new EventHandler(BindingSource_CurrentChanged);

            ctpnctrl.HienThi(dataGridViewX1, txtMaPhieuThue.Text);
            if (status == Controll.AddNew)
            {
                txtMaPhieuThue.Text = ThamSo.LayPhieuDangKy().ToString();
                Allow(true);
            }
            else
            {
                Allow(false);
            }
        }

        private void toolStripButton_Click(object sender, EventArgs e)
        {
            frmTimPhieuThue tim = new frmTimPhieuThue();
            Point p = PointToScreen(toolStripButton.Bounds.Location);
            p.X += toolStripButton.Width;
            p.Y += toolStripButton.Height;
            tim.Location = p;
            tim.ShowDialog();
            if (tim.DialogResult == DialogResult.OK)
            {
                ctpnctrl.TimPhieuThue(tim.cmbMaPhieuThue.SelectedValue.ToString());
            }
        }


    }
}
