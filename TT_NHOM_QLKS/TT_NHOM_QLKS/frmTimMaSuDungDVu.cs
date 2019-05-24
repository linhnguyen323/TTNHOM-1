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
    public partial class frmTimMaSuDungDVu : Form
    {
        public frmTimMaSuDungDVu()
        {
            InitializeComponent();
        }

        private void frmTimMaSuDungDVu_Load(object sender, EventArgs e)
        {
            DanhSachSuDungDichVuControl ds = new DanhSachSuDungDichVuControl();
            ds.HienthiComboBoxMaSuDung(cmbmaSuDung);
        }
    }
}
