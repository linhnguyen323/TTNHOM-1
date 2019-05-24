using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BUS;
using DTO;

namespace TT_NHOM_QLKS
{
    public partial class frmLoaiPhong : Form
    {
        LoaiPhongControl ctrl = new LoaiPhongControl();
        public frmLoaiPhong()
        {
            InitializeComponent();
        }

        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            ctrl.HienThi(dataGridViewX1, bindingNavigator1);
        }

        private void ThoattoolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SavetoolStripButton_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            ctrl.Save();
        }

    }
}
