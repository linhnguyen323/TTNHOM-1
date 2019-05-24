using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TT_NHOM_QLKS
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private string m_TenNguoiDung;
        public string LayTenNguoiDung
        {
            get { return m_TenNguoiDung; }
            set { m_TenNguoiDung = value; }
        }
        private string m_MatKhau;
        public string LayMatKhau
        {
            get { return m_MatKhau; }
            set { m_MatKhau = value; }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            this.txtTenDangNhap.Focus();
            m_TenNguoiDung = this.txtTenDangNhap.Text;
            m_MatKhau = this.txtMatKhau.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            this.txtTenDangNhap.Text = "";
            this.txtMatKhau.Text = "";
        }

    }
}
