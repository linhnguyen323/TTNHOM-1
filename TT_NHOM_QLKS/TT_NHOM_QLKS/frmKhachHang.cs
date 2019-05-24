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
    public partial class frmKhachHang : Form
    {
        KhachHangControl ctrl = new KhachHangControl();
        LoaiKhachHangControl khctrl = new LoaiKhachHangControl();
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            ctrl.HienThi(dataGridViewX1, bindingNavigator1);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Khach Hang", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigator1.BindingSource.RemoveCurrent();
                //ctrl.Save();
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            ctrl.Save();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripTextBoxTimKH_Enter(object sender, EventArgs e)
        {
            toolStripTextBoxTimKH.Text = "";
            toolStripTextBoxTimKH.ForeColor = Color.Black;
        }

        private void toolStripTextBoxTimKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (tìmTheoHọTênToolStripMenuItem.Checked)
                    ctrl.TimHoTen(toolStripTextBoxTimKH.Text);
                else if (tìmGiớiTínhToolStripMenuItem.Checked)
                    ctrl.TimGioiTinh(toolStripTextBoxTimKH.Text);
                else if (tìmĐịaChỉToolStripMenuItem.Checked)
                    ctrl.TimDiaChi(toolStripTextBoxTimKH.Text);
                else
                    ctrl.TimCMND(toolStripTextBoxTimKH.Text);
            }
        }

        private void toolStripTextBoxTimKH_Leave(object sender, EventArgs e)
        {
            if (tìmTheoHọTênToolStripMenuItem.Checked == true)
                tìmTheoHọTênToolStripMenuItem.Text = "Tìm theo Họ tên";
            else if (tìmGiớiTínhToolStripMenuItem.Checked == true)
                tìmGiớiTínhToolStripMenuItem.Text = "Tìm theo Giói tính";
            else if (tìmĐịaChỉToolStripMenuItem.Checked == true)
                tìmĐịaChỉToolStripMenuItem.Text = "Tìm theo Địa chỉ";
            else
                tìmCMNDToolStripMenuItem.Text = "Tìm theo CMND";

            toolStripTextBoxTimKH.ForeColor = Color.FromArgb(224, 224, 224);
        }

        private void tìmTheoHọTênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tìmGiớiTínhToolStripMenuItem.Checked = false;
            tìmCMNDToolStripMenuItem.Checked = false;
            tìmĐịaChỉToolStripMenuItem.Checked = false;
            tìmTheoHọTênToolStripMenuItem.Checked = true;
            toolStripTextBoxTimKH.Text = "Tìm theo Họ tên";
            bindingNavigator1.Focus();
        }

        private void tìmGiớiTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tìmGiớiTínhToolStripMenuItem.Checked = true;
            tìmCMNDToolStripMenuItem.Checked = false;
            tìmĐịaChỉToolStripMenuItem.Checked = false;
            tìmTheoHọTênToolStripMenuItem.Checked = false;
            toolStripTextBoxTimKH.Text = "Tìm theo Giới tính";
            bindingNavigator1.Focus();
        }

        private void tìmCMNDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tìmGiớiTínhToolStripMenuItem.Checked = false;
            tìmCMNDToolStripMenuItem.Checked = true;
            tìmĐịaChỉToolStripMenuItem.Checked = false;
            tìmTheoHọTênToolStripMenuItem.Checked = false;
            toolStripTextBoxTimKH.Text = "Tìm theo CMND";
            bindingNavigator1.Focus();
        }

        private void tìmĐịaChỉToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tìmGiớiTínhToolStripMenuItem.Checked = false;
            tìmCMNDToolStripMenuItem.Checked = false;
            tìmĐịaChỉToolStripMenuItem.Checked = true;
            tìmTheoHọTênToolStripMenuItem.Checked = false;
            toolStripTextBoxTimKH.Text = "Tìm theo Họ tên";
            bindingNavigator1.Focus();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DataGridView da = new DataGridView();
            if (CMND.ToString().Trim().Length <= 0)
            {
                MessageBox.Show("Chứng minh nhân dân đã tồn tại!", "Khach Hang", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (DienThoai.ToString().Trim().Length <= 0)
            {
                MessageBox.Show("Điện thoại đã tồn tại!", "Khach Hang", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataRow row = ctrl.NewRow();

                row["MaKhachHang"] = "";
                row["TenKhachHang"] = "";
                row["CMND"] = "";
                row["GioiTinh"] = "";
                row["DiaChi"] = "";
                row["DienThoai"] = 0;
                row["QuocTich"] = "";

                ctrl.Add(row);
                bindingNavigator1.BindingSource.MoveLast();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ctrl.HienThi(dataGridViewX1, bindingNavigator1);
        }
    }
}