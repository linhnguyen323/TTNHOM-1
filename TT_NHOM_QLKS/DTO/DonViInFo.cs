using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DonViInFo
    {
        private string m_MaDonVi;

        public string MaDonVi
        {
            get { return m_MaDonVi; }
            set { m_MaDonVi = value; }
        }
        private string m_TenDonVi;

        public string TenDonVi
        {
            get { return m_TenDonVi; }
            set { m_TenDonVi = value; }
        }
    }
}
