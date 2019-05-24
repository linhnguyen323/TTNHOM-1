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
using DTO;
using BUS;

namespace TT_NHOM_QLKS
{
    public partial class frmDoiMatKhau : Form
    {
        NguoiDungControl nguoiDung = new NguoiDungControl();
        private int ktra;
        public int KTraDangNhap
        {
            get { return ktra; }
            set { ktra = value; }
        }

        private NguoiDungInFo m_NguoiDung = new NguoiDungInFo();
        public NguoiDungInFo pNguoiDung
        {
            get { return m_NguoiDung; }
            set { m_NguoiDung = value; }
        }

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            this.txtMatKhauCu.Text = "";
            this.txtMatKhauMoi.Text = "";
            this.txtXacNhanMatKhau.Text = "";
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            this.txtMatKhauCu.Focus();
            this.DialogResult = DialogResult.OK;
        }
    }
}
