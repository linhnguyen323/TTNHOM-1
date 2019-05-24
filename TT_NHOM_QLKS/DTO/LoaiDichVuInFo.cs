using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiDichVuInFo
    {
        private string m_MaLoaiDichVu;

        public string MaLoaiDichVu
        {
            get { return m_MaLoaiDichVu; }
            set { m_MaLoaiDichVu = value; }
        }

        private string m_TenLoaiDichVu;

        public string TenLoaiDichVu
        {
            get { return m_TenLoaiDichVu; }
            set { m_TenLoaiDichVu = value; }
        }
    }
}
