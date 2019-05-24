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
using DTO;
using BUS;

namespace TT_NHOM_QLKS
{
    public partial class frmLoaiTinhTrangPhong : Form
    {
        LoaiTinhTrangPhongControl ctrl = new LoaiTinhTrangPhongControl();
        public frmLoaiTinhTrangPhong()
        {
            InitializeComponent();
        }

        private void frmLoaiTinhTrangPhong_Load(object sender, EventArgs e)
        {
            ctrl.HienThi(dataGridViewX1, bindingNavigator1);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolLuu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            ctrl.Save();
        }
    }
}
