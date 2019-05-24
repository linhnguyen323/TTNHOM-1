using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using DAL;
using DTO;
using BUS;

namespace TT_NHOM_QLKS
{
    public partial class frmDSPhong : Form
    {
        public frmDSPhong()
        {
            InitializeComponent();
        }
        PhongInFo phong = new PhongInFo();

        protected void OnPaint(PaintEventArgs e)
        {
            PhongData data = new PhongData();
            Graphics gp = this.CreateGraphics();

            List<PhongInFo> phongdb = new List<PhongInFo>();
            List<PhongInFo> phongl1 = new List<PhongInFo>();
            List<PhongInFo> phongl2 = new List<PhongInFo>();

            int x = 10;
            int y = 60;
            for (int i = 0; i < phongdb.Count; i++)
            {
                if (x > 480)
                {
                    x = y + 40;
                    x = 10;
                }
                switch (phongdb[i].TinhTrangPhong)
                {
                    case 1:
                        {
                            StringFormat s = new StringFormat();
                            s.Alignment = StringAlignment.Center;
                            s.LineAlignment = StringAlignment.Center;
                            Rectangle r = new Rectangle((x) + 15, y, 50, 30);
                            gp.DrawRectangle(new Pen(Color.White), r);
                            gp.FillRectangle(new SolidBrush(Color.LightSeaGreen), r);
                            gp.DrawString(phongdb[i].MaPhong.ToString(), this.Font, new SolidBrush(Color.White), r, s);
                            break;
                        }
                    case 2:
                        {
                            StringFormat s = new StringFormat();
                            s.Alignment = StringAlignment.Center;
                            s.LineAlignment = StringAlignment.Center;
                            Rectangle r = new Rectangle((x) + 15, y, 50, 30);
                            gp.DrawRectangle(new Pen(Color.White), r);
                            gp.FillRectangle(new SolidBrush(Color.MediumVioletRed), r);
                            gp.DrawString(phongdb[i].MaPhong.ToString(), this.Font, new SolidBrush(Color.White), r, s);
                            break;
                        }
                        case 3:
                        {
                            StringFormat s = new StringFormat();
                            s.Alignment = StringAlignment.Center;
                            s.LineAlignment = StringAlignment.Center;
                            Rectangle r = new Rectangle((x) + 15, y, 50, 30);
                            gp.DrawRectangle(new Pen(Color.White), r);
                            gp.FillRectangle(new SolidBrush(Color.Red), r);
                            gp.DrawString(phongl1[i].MaPhong.ToString(), this.Font, new SolidBrush(Color.White), r, s);
                            break;
                        }
                }
                x = x + 70;
                
            }
            
            x = 10;
            y = y + 50;
            gp.DrawLine(new Pen(Color.Black, 3), new Point(25, y-10), new Point(x + 485, y-10));
            for (int i = 0; i < phongl2.Count; i++)
            {
                if (x > 480)
                {
                    x = 10;
                    y += 40;
                }
                switch (phongl2[i].TinhTrangPhong)
                {
                    case 1:
                        {
                            StringFormat s = new StringFormat();
                            s.Alignment = StringAlignment.Center;
                            s.LineAlignment = StringAlignment.Center;
                            Rectangle r = new Rectangle((x) + 15, y, 50, 30);
                            gp.DrawRectangle(new Pen(Color.White), r);
                            gp.FillRectangle(new SolidBrush(Color.LightSeaGreen), r);
                            gp.DrawString(phongl2[i].MaPhong.ToString(), this.Font, new SolidBrush(Color.White), r, s);
                            break;
                        }
                    case 2:
                        {
                            StringFormat s = new StringFormat();
                            s.Alignment = StringAlignment.Center;
                            s.LineAlignment = StringAlignment.Center;
                            Rectangle r = new Rectangle((x) + 15, y, 50, 30);
                            gp.DrawRectangle(new Pen(Color.White), r);
                            gp.FillRectangle(new SolidBrush(Color.MediumVioletRed), r);
                            gp.DrawString(phongl2[i].MaPhong.ToString(), this.Font, new SolidBrush(Color.White), r, s);
                            break;
                        }
                    case 3:
                        {
                            StringFormat s = new StringFormat();
                            s.Alignment = StringAlignment.Center;
                            s.LineAlignment = StringAlignment.Center;
                            Rectangle r = new Rectangle((x) + 15, y, 50, 30);
                            gp.DrawRectangle(new Pen(Color.White), r);
                            gp.FillRectangle(new SolidBrush(Color.Red), r);
                            gp.DrawString(phongl2[i].MaPhong.ToString(), this.Font, new SolidBrush(Color.White), r, s);
                            break;
                        }
                }
                x += 70;
                
            }
            gp.Dispose();
        }

        private void dangKyPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhSachKHDKThuePhong ds = new frmDanhSachKHDKThuePhong();
            ds.ShowDialog();
        }

        private void traPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDon hd = new frmHoaDon();
            hd.ShowDialog();
        }
    }
}
