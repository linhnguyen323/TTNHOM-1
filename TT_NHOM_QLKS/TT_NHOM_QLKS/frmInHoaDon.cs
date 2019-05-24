using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TT_NHOM_QLKS.Report;
using DAL;

namespace TT_NHOM_QLKS
{
    public partial class frmInHoaDon : Form
    {
        public frmInHoaDon()
        {
            InitializeComponent();
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            ChiTietHoaDonData chitietdata = new ChiTietHoaDonData();
            TT_NHOM_QLKS.Report.HoaDon hoadon = new TT_NHOM_QLKS.Report.HoaDon();
            hoadon.SetDataSource(chitietdata.LaydanhSachChiTietHoaDon());
            crystalReportViewer1.ReportSource = hoadon;
        }
    }
}
