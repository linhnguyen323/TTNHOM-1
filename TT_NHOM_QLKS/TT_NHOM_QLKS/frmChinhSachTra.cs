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
    public partial class frmChinhSachTra : Form
    {
        ChinhSachTraControl ctrl = new ChinhSachTraControl();
        public frmChinhSachTra()
        {
            InitializeComponent();
        }

        private void frmChinhSachTra_Load(object sender, EventArgs e)
        {
            ctrl.HienThi(dataGridViewX1, bindingNavigator1);
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            ctrl.Save();
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
