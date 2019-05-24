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
    public partial class frmLoaiDV : Form
    {
        LoaiDichVuControl ctrl = new LoaiDichVuControl();
        public frmLoaiDV()
        {
            InitializeComponent();
        }

        private void frmLoaiDV_Load(object sender, EventArgs e)
        {
            ctrl.HienThi(dataGridViewX1, bindingNavigator1);
        }

        private void toolStripButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonLuu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            ctrl.Save();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn xóa không?","Loai Dich Vu",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                bindingNavigator1.BindingSource.RemoveCurrent();
            }
        }

        //private void dataGV_Delete(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    if(MessageBox.Show("Bạn có chắc chắn muốn xóa không?","Loai Dich Vu",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
        //    {
        //        e.Cancel = true;
        //    }
        //}
    }
}
