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

namespace TT_NHOM_QLKS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        NguoiDungControl nguoiDungctrl;
        NguoiDungInFo nguoiDunginfo;

        private void frmMain_Load(object sender, EventArgs e)
        {
            Default();
            PhongData data = new PhongData();
            listViewEx1.Items.Clear();
            foreach (DataRow dr in data.LayMaPhong().Rows)
            {
                PhongInFo phong = new PhongInFo();
                phong.MaLoaiPhong = (string)dr.ItemArray[1];
                phong.MaPhong = (string)dr.ItemArray[0];
                phong.TinhTrangPhong = (int)dr.ItemArray[2];
                ListViewItem item = new ListViewItem(phong.MaPhong);

                if (phong.TinhTrangPhong == 1)
                {
                    item.ImageIndex = 0;
                }
                else if (phong.TinhTrangPhong == 2)
                {
                    item.ImageIndex = 1;
                }
                else
                {
                    item.ImageIndex = 2;
                }
                listViewEx1.Items.Add(item);
            }
        }

        frmDangNhap dangnhap = null;
        private void DangNhap()
        {
        TiepTuc:
            if (dangnhap == null || dangnhap.IsDisposed)
            {
                dangnhap = new frmDangNhap();
            }
        if (dangnhap.ShowDialog() == DialogResult.OK)
        {
            String tenDangnhap = dangnhap.txtTenDangNhap.Text;
            String matKhau = dangnhap.txtMatKhau.Text;
            NguoiDungControl ctrlNguoiDung = new NguoiDungControl();
            int ketqua = ctrlNguoiDung.DangNhap(tenDangnhap, matKhau);
            switch (ketqua)
            {
                case 0:
                    MessageBox.Show("Không tồn tại người dùng trong hệ thống");
                    goto TiepTuc;
                case 1:
                    MessageBox.Show("Mật khẩu sai");
                    goto TiepTuc;
                case 2:
                    MessageBox.Show("Đăng nhập thành công");
                    if (ctrlNguoiDung.PhanQuyen == 1)
                        Admin();
                    else
                        User();
                    break;
            }
        }
        else this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        frmDoiMatKhau doimatkhau = null;
        public void DoiMatKhau()
        {
         tt:
            if (doimatkhau == null || doimatkhau.IsDisposed)
            {
                doimatkhau = new frmDoiMatKhau();
            }
         if (doimatkhau.ShowDialog() == DialogResult.OK)
         {
             String tenDangNhap = dangnhap.txtTenDangNhap.Text;
             String matKhau = dangnhap.txtMatKhau.Text;
             String matKhauCu = doimatkhau.txtMatKhauCu.Text;
             String matKhauMoi = doimatkhau.txtMatKhauMoi.Text;
             String xacNhanMatKhau = doimatkhau.txtXacNhanMatKhau.Text;
             if (matKhau != matKhauCu)
             {
                 MessageBox.Show("Mật khẩu hiện tại không phù hợp");
                 goto tt;
             }
             else if (matKhauMoi != xacNhanMatKhau)
             {
                 MessageBox.Show("Sai mật khẩu xác nhận");
                 goto tt;
             }
             else
             {
                 NguoiDungControl ctrlND = new NguoiDungControl();
                 ctrlND.UpdatePassword(tenDangNhap, matKhauMoi);
                 MessageBox.Show("Đổi mật khẩu thành công");
             }
         }

        }

        public void Default()
        {
            this.btnThanhToan.Enabled = false;
            this.btnThietBi.Enabled = false;
            this.buttonItemThietBi.Enabled = false;
            this.btnLoaiPhong.Enabled = true;
            this.btnLoaiDichVu.Enabled = true;
            this.buttonItemLoaiDVu.Enabled = true;
            this.buttonItemLoaiPhong.Enabled = true;
            this.buttonDangKy.Enabled = false;
            this.btnDangNhap.Enabled = true;
            this.btnDangXuat.Enabled = false;
            this.btnDichVu.Enabled = false;
            this.btnDoiMatKhau.Enabled = false;
            this.buttonHuongDan.Enabled = false;
            this.buttonKHDangKy.Enabled = false;
            this.buttonKHNhanPhong.Enabled = false;
            this.btnNguoiDung.Enabled = false;
            this.btnPhong.Enabled = false;
            this.buttonQuiDinh.Enabled = true;
            this.buttonThongTin.Enabled = true;
            //this.buttonTraPhong.Enabled = false;
            this.toolStripThemPhong.Enabled = false;
            this.ToolStripMenuItemTraPhong.Enabled = false;
            this.ToolStripMenuItemNhanPhong.Enabled = false;
            this.ToolStripMenuItemDangKy.Enabled = false;
            this.ToolStripCapNhat.Enabled = false;
        }


        public void Admin()
        {

            this.btnThanhToan.Enabled = true;
            this.buttonItemThietBi.Enabled = true;
            this.btnThietBi.Enabled = true;
            this.btnLoaiPhong.Enabled = true;
            this.btnLoaiDichVu.Enabled = true;
            this.buttonItemLoaiPhong.Enabled = true;
            this.buttonItemLoaiDVu.Enabled = true;
            this.buttonDangKy.Enabled = true;
            this.btnDangNhap.Enabled = false;
            this.btnDangXuat.Enabled = true;
            this.btnDichVu.Enabled = true;
            this.btnDoiMatKhau.Enabled = true;
            this.buttonHuongDan.Enabled = true;
            this.buttonKHDangKy.Enabled = true;
            this.buttonKHNhanPhong.Enabled = true;
            this.btnNguoiDung.Enabled = true;
            this.btnPhong.Enabled = true;
            this.buttonQuiDinh.Enabled = true;
            this.buttonThongTin.Enabled = true;
            //this.buttonTraPhong.Enabled = true;
            this.toolStripThemPhong.Enabled = true;
            this.ToolStripMenuItemTraPhong.Enabled = true;
            this.ToolStripMenuItemNhanPhong.Enabled = true;
            this.ToolStripMenuItemDangKy.Enabled = true;
            this.ToolStripCapNhat.Enabled = true;

        }

        public void User()
        {
            this.btnThanhToan.Enabled = true;
            this.buttonItemThietBi.Enabled = true;
            this.btnThietBi.Enabled = true;
            this.buttonItemLoaiPhong.Enabled = true;
            this.buttonItemLoaiDVu.Enabled = true;
            this.btnLoaiDichVu.Enabled = true;
            this.btnLoaiPhong.Enabled = true;
            this.buttonDangKy.Enabled = true;
            this.btnDangNhap.Enabled = false;
            this.btnDangXuat.Enabled = true;
            this.btnDichVu.Enabled = true;
            this.btnDoiMatKhau.Enabled = true;
            this.buttonHuongDan.Enabled = true;
            this.buttonKHDangKy.Enabled = true;
            this.buttonKHNhanPhong.Enabled = true;
            this.btnNguoiDung.Enabled = false;
            this.btnPhong.Enabled = true;
            this.buttonQuiDinh.Enabled = false;
            this.buttonThongTin.Enabled = true;
            //this.buttonTraPhong.Enabled = true;
            this.toolStripThemPhong.Enabled = false;
            this.ToolStripMenuItemTraPhong.Enabled = true;
            this.ToolStripMenuItemNhanPhong.Enabled = true;
            this.ToolStripMenuItemDangKy.Enabled = true;
            this.ToolStripCapNhat.Enabled = false;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            frmPhong phong = new frmPhong();
            phong.ShowDialog();
        }

        private void buttonItemLoaiPhong_Click(object sender, EventArgs e)
        {
            frmLoaiPhong loaiphong = new frmLoaiPhong();
            loaiphong.ShowDialog();
        }

        private void buttonDangKy_Click(object sender, EventArgs e)
        {
            frmKhachHang kh = new frmKhachHang();
            kh.ShowDialog();
        }

        private void btnNguoiDung_Click(object sender, EventArgs e)
        {
            frmNguoiDung ndctrl = new frmNguoiDung();
            ndctrl.ShowDialog();
        }

        string mahphong = "";

        private void ToolStripMenuItemDangKy_Click(object sender, EventArgs e)
        {
            frmPhieuDangKy ds = new frmPhieuDangKy();
            ds.maphong = this.mahphong;
            ds.ShowDialog();
        }

        private void listViewEx1_MouseClick(object sender, MouseEventArgs e)
        {
            mahphong = listViewEx1.SelectedItems[0].Text;
        }

        private void toolStripThemPhong_Click(object sender, EventArgs e)
        {
            frmPhong p = new frmPhong();
            p.ShowDialog();
        }

        private void ToolStripMenuItemNhanPhong_Click(object sender, EventArgs e)
        {
            frmPhieuNhanPhong dsnp = new frmPhieuNhanPhong();
            dsnp.maphong = this.mahphong;
            dsnp.Show();
        }

        private void ToolStripMenuItemTraPhong_Click(object sender, EventArgs e)
        {
            frmChiTietHoaDon hd = new frmChiTietHoaDon();
            hd.maphong = this.mahphong;
            hd.ShowDialog();
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            frmDichVu dv = new frmDichVu();
            dv.ShowDialog();
        }

        private void buttonItemThietBi_Click(object sender, EventArgs e)
        {
            frmThietBiTrongPhong tb = new frmThietBiTrongPhong();
            tb.ShowDialog();
        }

        private void buttonItemLoaiDVu_Click(object sender, EventArgs e)
        {
            frmLoaiDV ldv = new frmLoaiDV();
            ldv.ShowDialog();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            frmBaoCaoDoanhThu bcdt = new frmBaoCaoDoanhThu();
            bcdt.ShowDialog();
        }

        private void buttonKHNhanPhong_Click(object sender, EventArgs e)
        {
            frmDanhSachKHNhanPhong ds = new frmDanhSachKHNhanPhong();
            ds.ShowDialog();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            frmHoaDon hd = new frmHoaDon();
            hd.ShowDialog();
        }

        private void buttonKHDangKy_Click(object sender, EventArgs e)
        {
            frmDanhSachKHDKThuePhong dktp = new frmDanhSachKHDKThuePhong();
            dktp.ShowDialog();
        }

        private void ToolStripCapNhat_Click(object sender, EventArgs e)
        {
            //Default();
            PhongData data = new PhongData();
            listViewEx1.Items.Clear();
            foreach (DataRow dr in data.LayMaPhong().Rows)
            {
                PhongInFo phong = new PhongInFo();
                phong.MaLoaiPhong = (string)dr.ItemArray[1];
                phong.MaPhong = (string)dr.ItemArray[0];
                phong.TinhTrangPhong = (int)dr.ItemArray[2];
                ListViewItem item = new ListViewItem(phong.MaPhong);

                if (phong.TinhTrangPhong == 1)
                {
                    item.ImageIndex = 0;
                }
                else if (phong.TinhTrangPhong == 2)
                {
                    item.ImageIndex = 1;
                }
                else
                {
                    item.ImageIndex = 2;
                }
                listViewEx1.Items.Add(item);
            }
        }
    }
}
