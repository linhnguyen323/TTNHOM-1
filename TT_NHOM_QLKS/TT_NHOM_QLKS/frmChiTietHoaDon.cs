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
using DAL;
using TT_NHOM_QLKS.Report;

namespace TT_NHOM_QLKS
{
    public partial class frmChiTietHoaDon : Form
    {
        HoaDonControl ctrl = new HoaDonControl();
        ChiTietHoaDonControl ctctrl = new ChiTietHoaDonControl();
        PhongControl pctrl = new PhongControl();
        PhongControl pctrl1 = new PhongControl();
        DanhSachSuDungDichVuControl dvctrl = new DanhSachSuDungDichVuControl();
        KhachHangControl khctrl = new KhachHangControl();
        PhieuNhanPhongControl pnctrl = new PhieuNhanPhongControl();
        ChinhSachTraControl cstr = new ChinhSachTraControl();

        Controll status = Controll.Normal;
        public string maphong = "";
        public frmChiTietHoaDon()
        {
            InitializeComponent();
            status = Controll.AddNew;
        }

        public frmChiTietHoaDon(HoaDonControl ctrlPN)
            : this()
        {
            this.ctrl = ctrlPN;
            status = Controll.Normal;
        }

        void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (status == Controll.Normal)
                pctrl.HienThiChiTietPhieuDangKy(dataGridViewX1, txtMaHoaDon.Text);
        }

        private void cmbMaPhong_SelectedValueChanged(object sender, EventArgs e)
        {
            LoaiPhongControl lp = new LoaiPhongControl();
            PhongControl p = new PhongControl();
            if (cmbMaPhong.SelectedValue != null)
            {
                PhongInFo pi = p.LayMaPhong(cmbMaPhong.SelectedValue.ToString());
                LoaiPhongInFo lpi = lp.LayLoaiPhong(pi.MaLoaiPhong);
                txtTienPhong.Text = lpi.DonGia.ToString();
            }
        }

        private void cmbMaSDDVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            DanhSachSuDungDichVuControl dsdvctrl = new DanhSachSuDungDichVuControl();
            if (cmbMaSDDVu.SelectedValue != null)
            {
                DanhSachSuDungDichVuInFo dsi = dsdvctrl.LayDSSuDungDVu(cmbMaSDDVu.SelectedValue.ToString());
                int solg = dsi.SoLuong;
                DichVuControl dvctrl = new DichVuControl();
                DichVuInFo dvi = dvctrl.LayMaDichVu(dsi.MaDichVu);
                float dongia = dvi.DonGia;
                float tien = solg * dongia;
                txtTienDVu.Text = tien.ToString();
            }
        }

        private void cmbMaChinhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChinhSachTraControl cst = new ChinhSachTraControl();
            ChinhSachTraInFo csi = cst.LayMaChinhSach(cmbMaChinhSach.SelectedValue.ToString());
            txtPhuThu.Text = csi.PhuThu.ToString();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            status = Controll.AddNew;
            txtMaHoaDon.Text = ThamSo.LayHoaDon().ToString();
            ctctrl.HienThi(dataGridViewX1, txtMaHoaDon.Text);
            this.Allow(true);
        }

        void Allow(bool val)
        {
            txtMaHoaDon.Enabled = val;
            txtTenNhanVien.Enabled = val;
            cmbMaSDDVu.Enabled = val;
            cmbMaNhanPhong.Enabled = val;
            cmbMaPhong.Enabled = val;
            cmbTenKhachHang.Enabled = val;
            dateNgaylap.Enabled = val;
            txtTienDVu.Enabled = val;
            txtTienPhong.Enabled = val;
            txtTongTien.Enabled = val;
            btnTimMaDVu.Enabled = val;
            btnTimMaNPhong.Enabled = val;
            cmbMaChinhSach.Enabled = val;
            txtHinhThucTT.Enabled = val;
            txtPhuThu.Enabled = val;
            numGiamGia.Enabled = val;
            numSoNgay.Enabled = val;
            txtThanhTien.Enabled = val;
            bindingNavigator1.Enabled = val;
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

            row["MaHoaDon"] = txtMaHoaDon.Text;
            row["NhanVienLap"] = txtTenNhanVien.Text;
            row["MaKhachHang"] = cmbTenKhachHang.SelectedValue;
            row["MaNhanPhong"] = cmbMaNhanPhong.SelectedValue;
            row["TongTien"] = txtTongTien.Text;
            row["NgayLap"] = dateNgaylap.Value.Date;

            ctrl.Add(row);

            HoaDonControl hdctrl = new HoaDonControl();
            if (hdctrl.LayHoaDon(txtMaHoaDon.Text) != null)
            {
                MessageBox.Show("Mã hóa đơn này đã tồn tại !", "Hoa Don", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ThamSo.LaSoNguyen(txtMaHoaDon.Text))
            {
                long so = Convert.ToInt64(txtMaHoaDon.Text);
                if (so >= ThamSo.LayHoaDon())
                {
                    ThamSo.GanHoaDon(so + 1);
                }
            }
            ctrl.Update();

            DataTable tblCTHD = (DataTable)bindingNavigator1.BindingSource.DataSource;

            ctctrl.Update();
            ctrl.Save();
            ctctrl.Save();
            khctrl.Save();
            pnctrl.Save();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Hoa Don", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigator1.BindingSource.RemoveCurrent();
                ctrl.Save();
            }
        }

        private void dataGridViewX1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xóa không?", "Hoa Don", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
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
                    PhongData.CapNhatMaLoaiTinhTrangPhong(maphong, 1);
                }
            }
        }

        private void toolDoDuLieu_Click(object sender, EventArgs e)
        {
            HoaDonControl ctrl = new HoaDonControl();
            HoaDonInFo ctif = ctrl.LayHoaDon(txtMaHoaDon.Text.Trim());
            if (ctif == null)
            {
                foreach (DataGridViewRow view in dataGridViewX1.Rows)
                {
                    if (cmbMaPhong.SelectedValue.ToString().Trim().Equals(view.Cells["MaPhong"].Value))
                    {
                        MessageBox.Show("Phòng tồn tại trong danh sách! Vui lòng nhập lại !", "Hoa Don", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (cmbMaPhong.SelectedValue.ToString().Trim().Length <= 0)
                {
                    MessageBox.Show("Vui lòng nhập Mã hóa đơn !", "Hoa Don", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtTienPhong.Text == "")
                {
                    MessageBox.Show("Nhập Tiền phòng!", "Hoa Don", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtTienDVu.Text == "")
                {
                    MessageBox.Show("Nhập Tiền dịch vụ!", "Hoa Don", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cmbMaSDDVu.SelectedValue.ToString().Trim().Length <= 0)
                {
                    MessageBox.Show("Chọn Mã dịch vụ!", "Hoa Don", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (numSoNgay.Value < 0)
                {
                    MessageBox.Show("Số ngày sai!", "Hoa Don", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtPhuThu.Text == "")
                {
                    MessageBox.Show("Chọn phụ thu!", "Hoa Don", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cmbMaChinhSach.SelectedValue.ToString().Trim().Length <= 0)
                {
                    MessageBox.Show("Chọn Mã chính sách!", "Hoa Don", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    DataRow row = ctctrl.NewRow();

                    row["MaHoaDon"] = txtMaHoaDon.Text;
                    row["MaPhong"] = cmbMaPhong.SelectedValue.ToString();
                    row["TienPhong"] = txtTienPhong.Text;
                    row["MaSuDungDichVu"] = cmbMaSDDVu.SelectedValue.ToString();
                    row["TienDichVu"] = txtTienDVu.Text;
                    row["MaChinhSach"] = cmbMaChinhSach.SelectedValue.ToString();
                    row["GiamGiaKH"] = numGiamGia.Value;
                    row["PhuThu"] = txtPhuThu.Text;
                    row["HinhThucThanhToan"] = txtHinhThucTT.Text;
                    row["SoNgay"] = numSoNgay.Value;

                    ctctrl.Add(row);
                    bindingNavigator1.BindingSource.MoveLast();
                    txtMaHoaDon.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mã hóa đơn này đã tồn tại! Vui lòng nhập lại !", "Hoa Don", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimMaDVu_Click(object sender, EventArgs e)
        {
            frmDanhSachSDDV ds = new frmDanhSachSDDV();
            ds.ShowDialog();
            
        }

        private void btnThemMaChinhsach_Click(object sender, EventArgs e)
        {
            frmChinhSachTra chtr = new frmChinhSachTra();
            chtr.ShowDialog();
            dvctrl.HienthiComboBoxMaSuDung(cmbMaSDDVu);
        }

        private void btnTimMaNPhong_Click(object sender, EventArgs e)
        {
            frmPhieuNhanPhong dsnp = new frmPhieuNhanPhong();
            dsnp.ShowDialog();
        }

        private void cmbMaNhanPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            HoaDonControl hdctrl = new HoaDonControl();
            HoaDonInFo hdi = hdctrl.LayHoaDon(cmbMaNhanPhong.SelectedValue.ToString());
            ChiTietPhieuNhanControl pnctrl = new ChiTietPhieuNhanControl();
            ChiTietHoaDonInFo cthdi = new ChiTietHoaDonInFo();
            int songay = pnctrl.TinhSoNgay(cthdi.SoNgay);

            try
            {
                numSoNgay.Value = TinhSoNgay(Convert.ToString(cmbMaNhanPhong.SelectedValue.ToString()));
            }
            catch (Exception ex) { }
        }

        public int TinhSoNgay(string manp)
        {
            ChiTietPhieuNhanPhongData data = new ChiTietPhieuNhanPhongData();
            DataTable tbl = data.LayChiTietPhieuNhan(manp);
            DateTime nnhan = Convert.ToDateTime(tbl.Rows[0]["NgayNhan"].ToString());
            DateTime ntra = Convert.ToDateTime(tbl.Rows[0]["NgayTraThucTe"].ToString());

            int soNgay = 0;
            if (nnhan.Year == ntra.Year)
                soNgay = ntra.DayOfYear - nnhan.DayOfYear;
            else
            {
                int soNam = ntra.Year - nnhan.Year;
                if (soNam == 1)
                {
                    if ((nnhan.Year % 400 == 0) || (nnhan.Year % 4 == 0 && nnhan.Year % 100 == 0))
                        soNgay = (366 - nnhan.DayOfYear) + ntra.DayOfYear;
                    else
                        soNgay = (365 - nnhan.DayOfYear) + ntra.DayOfYear;
                }
                else
                {
                    for (int i = 0; i < soNam - 1; i++)
                    {
                        if (((nnhan.Year + i) % 400 == 0) || ((nnhan.Year + i) % 4 == 0 && (nnhan.Year + i) % 100 == 0))
                            soNgay = soNgay + 366;
                        else
                            soNgay = soNgay + 365;
                    }
                    if ((nnhan.Year % 400 == 0) || (nnhan.Year % 4 == 0 && nnhan.Year % 100 == 0))
                        soNgay = (366 - nnhan.DayOfYear) + ntra.DayOfYear;
                    else
                        soNgay = (365 - nnhan.DayOfYear) + ntra.DayOfYear;

                }
            }
            if (soNgay == 0)
                soNgay = 1;

            numSoNgay.Value = soNgay;
            return soNgay;
        }

        private void btnThanhTien_Click(object sender, EventArgs e)
        {
            float tienphong = Convert.ToSingle(txtTienPhong.Text.ToString());
            float tiendv = Convert.ToSingle(txtTienDVu.Text.ToString());
            float giamgia = Convert.ToSingle(numGiamGia.Value.ToString());
            int songay = Convert.ToInt32(numSoNgay.Value.ToString());
            float phuthu = Convert.ToSingle(txtPhuThu.Text.ToString());
            float thanhtien = Convert.ToSingle((tienphong * songay) + tiendv + (tienphong * phuthu) - giamgia);
            txtThanhTien.Text = thanhtien.ToString();
            txtTongTien.Text = txtThanhTien.Text;
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            pctrl1.HienthiComboBoxPhongTra(cmbMaPhong);
            cmbMaPhong.SelectedValue = maphong;
            pctrl.HienthiDataGridviewComboBoxMaPhong(MaPhong);

            cmbMaPhong.SelectedIndexChanged += new EventHandler(cmbMaPhong_SelectedValueChanged);

            dvctrl.HienthiComboBoxMaSuDung(cmbMaSDDVu);
            dataGridViewX1.Rows.Add(dvctrl.HienthiDataGridViewComboBoxColumn());
            cmbMaSDDVu.SelectedIndexChanged += new EventHandler(cmbMaSDDVu_SelectedIndexChanged);

            cstr.HienThiCombobox(cmbMaChinhSach);
            dataGridViewX1.Columns.Add(cstr.HienthiDataGridViewComboBoxColumn());
            cmbMaChinhSach.SelectedIndexChanged += new EventHandler(cmbMaChinhSach_SelectedIndexChanged);

            cmbMaNhanPhong.SelectedIndexChanged += new EventHandler(cmbMaNhanPhong_SelectedIndexChanged);

            khctrl.HienthiComboBox(cmbTenKhachHang);
            pnctrl.HienthiComboBoxMaPhieuNhan(cmbMaNhanPhong);
            ctrl.HienThiHoaDon(dataGridViewX1, bindingNavigator1);
            bindingNavigator1.BindingSource.CurrentChanged -= new EventHandler(BindingSource_CurrentChanged);
            bindingNavigator1.BindingSource.CurrentChanged += new EventHandler(BindingSource_CurrentChanged);

            ctctrl.HienThi(dataGridViewX1, txtMaHoaDon.Text);
            if (status == Controll.AddNew)
            {
                txtMaHoaDon.Text = ThamSo.LayHoaDon().ToString();
                Allow(true);
            }
            else
            {
                Allow(false);
            }
        }

        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            pctrl1.HienthiComboBoxPhongTra(cmbMaPhong);
            cmbMaPhong.SelectedValue = maphong;
            pctrl.HienthiDataGridviewComboBoxMaPhong(MaPhong);

            cmbMaPhong.SelectedIndexChanged += new EventHandler(cmbMaPhong_SelectedValueChanged);

            dvctrl.HienthiComboBoxMaSuDung(cmbMaSDDVu);
            dataGridViewX1.Rows.Add(dvctrl.HienthiDataGridViewComboBoxColumn());
            cmbMaSDDVu.SelectedIndexChanged += new EventHandler(cmbMaSDDVu_SelectedIndexChanged);

            cstr.HienThiCombobox(cmbMaChinhSach);
            dataGridViewX1.Columns.Add(cstr.HienthiDataGridViewComboBoxColumn());
            cmbMaChinhSach.SelectedIndexChanged += new EventHandler(cmbMaChinhSach_SelectedIndexChanged);

            cmbMaNhanPhong.SelectedIndexChanged += new EventHandler(cmbMaNhanPhong_SelectedIndexChanged);

            khctrl.HienthiComboBox(cmbTenKhachHang);
            pnctrl.HienthiComboBoxMaPhieuNhan(cmbMaNhanPhong);
            ctrl.HienThiHoaDon(dataGridViewX1, bindingNavigator1);
            bindingNavigator1.BindingSource.CurrentChanged -= new EventHandler(BindingSource_CurrentChanged);
            bindingNavigator1.BindingSource.CurrentChanged += new EventHandler(BindingSource_CurrentChanged);

            ctctrl.HienThi(dataGridViewX1, txtMaHoaDon.Text);
            if (status == Controll.AddNew)
            {
                txtMaHoaDon.Text = ThamSo.LayHoaDon().ToString();
                Allow(true);
            }
            else
            {
                Allow(false);
            } 
        }

        //private void toolStripTrangIn_Click(object sender, EventArgs e)
        //{
        //    if (dataGridViewX1.Rows.Count > 1)
        //    {
        //        TT_NHOM_QLKS.Report.HoaDon rphoadon = new TT_NHOM_QLKS.Report.HoaDon();
        //        HoaDonData hoadonData = new HoaDonData();
        //        rphoadon.SetDataSource(hoadonData.LayMaKhachHang(cmbTenKhachHang.Text));
        //        rphoadon.SetParameterValue("MaKhachHang", cmbTenKhachHang.Text);
        //        frmInHoaDon inhoadon = new frmInHoaDon();
        //        inhoadon.ShowDialog();
        //    }
        //    else MessageBox.Show("Không có dữ liễu in");
        //}
    }
}
