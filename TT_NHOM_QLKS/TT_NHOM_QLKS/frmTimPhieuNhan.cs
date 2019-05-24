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
    public partial class frmTimPhieuNhan : Form
    {
        public frmTimPhieuNhan()
        {
            InitializeComponent();
        }

        private void frmTimPhieuNhan_Load(object sender, EventArgs e)
        {
            PhieuNhanPhongControl ctrl = new PhieuNhanPhongControl();
            ctrl.HienthiComboBoxMaPhieuNhan(cmbTimPhieuNhan);
        }
    }
}
