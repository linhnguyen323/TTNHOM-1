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
    public partial class frmTimPhieuThue : Form
    {
        public frmTimPhieuThue()
        {
            InitializeComponent();
        }

        private void frmTimPhieuThue_Load(object sender, EventArgs e)
        {
            PhieuThuePhongControl ctrl = new PhieuThuePhongControl();
            ctrl.HienthiComboBoxMaPhieuThue(cmbMaPhieuThue);
        }

    }
}
