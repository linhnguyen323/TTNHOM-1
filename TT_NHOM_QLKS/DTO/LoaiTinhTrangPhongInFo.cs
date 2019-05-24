using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiTinhTrangPhongInFo
    {
        private int m_MaLoaiTinhTrangPhong;

        public int MaLoaiTinhTrangPhong
        {
            get { return m_MaLoaiTinhTrangPhong; }
            set { m_MaLoaiTinhTrangPhong = value; }
        }

        private string m_TenLoaiTinhTrangPhong;

        public string TenLoaiTinhTrangPhong
        {
            get { return m_TenLoaiTinhTrangPhong; }
            set { m_TenLoaiTinhTrangPhong = value; }
        }
    }
}
