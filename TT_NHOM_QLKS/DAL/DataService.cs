using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DataService:DataTable
    {
        static SqlConnection m_Connection;
        SqlDataAdapter m_DataAdapter;
        SqlCommand m_Command;

        public static string strConn = "Data Source=.;Initial Catalog=QuanLyKhachSan;Integrated Security=True";
        public DataService()
        {

        }

        public void Load(SqlCommand command)
        {
                m_DataAdapter = new SqlDataAdapter();
                m_Command = new SqlCommand();
                if (m_Connection == null || m_Connection.State == ConnectionState.Closed)
                {
                    m_Connection = new SqlConnection(strConn);
                    m_Connection.Open();
                }

                m_Command = command;
                m_Command.Connection = m_Connection;
                m_DataAdapter = new SqlDataAdapter(m_Command);
                this.Clear();
                try
                {
                    m_DataAdapter.Fill(this);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }

        public static bool OpenConnection()
        {
            try
            {
                if (m_Connection == null)
                    m_Connection = new SqlConnection(strConn);
                if (m_Connection.State == ConnectionState.Closed)
                    m_Connection.Open();
                return true;
            }
            catch
            {
                m_Connection.Close();
                return false;
            }
        }

        public void Update()
        {
            SqlCommandBuilder buider = new SqlCommandBuilder(m_DataAdapter);
            m_DataAdapter.Update(this);
        }

        public void UpdatePassWord(String tenDangNhap, String matKhauMoi)
        {
            m_Command = new SqlCommand();
            m_DataAdapter = new SqlDataAdapter();
            String sql = "UPDATE NGUOI_DUNG SET MatKhau=@matKhau WHERE TenDangNhap = @ten";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("ten", SqlDbType.VarChar).Value = tenDangNhap;
            cmd.Parameters.Add("matKhau", SqlDbType.VarChar).Value = matKhauMoi;
            if (m_Connection == null || m_Connection.State == ConnectionState.Closed)
            {
                m_Connection = new SqlConnection(strConn);
                m_Connection.Open();
            }

            m_Command = cmd;
            m_Command.Connection = m_Connection;
            m_DataAdapter = new SqlDataAdapter(m_Command);
            m_DataAdapter.Fill(this);
            SqlCommandBuilder buider = new SqlCommandBuilder(m_DataAdapter);
            m_DataAdapter.Update(this);

        }

        public int ExecuteNoneQuery()
        {
            int result = 0;
            SqlTransaction tr = null;
            try
            {
                tr = m_Connection.BeginTransaction();

                m_Command.Connection = m_Connection;
                m_Command.Transaction = tr;

                m_DataAdapter = new SqlDataAdapter();
                m_DataAdapter.SelectCommand = m_Command;

                SqlCommandBuilder builder = new SqlCommandBuilder(m_DataAdapter);

                result = m_DataAdapter.Update(this);
                tr.Commit();

            }
            catch (Exception e)
            {
                if (tr != null) tr.Rollback();

            }
            return result;
        }
        /// <summary>
        /// Thuc thi mot command
        /// </summary>
        /// <param name="command">OleDb hay Store Procedure</param>
        /// <returns></returns>
        public int ExecuteNoneQuery(SqlCommand cmd)
        {

            int result = 0;
            SqlTransaction tr = null;

            try
            {
                tr = m_Connection.BeginTransaction();

                cmd.Connection = m_Connection;

                cmd.Transaction = tr;

                result = cmd.ExecuteNonQuery();

                this.AcceptChanges();

                tr.Commit();

            }
            catch (Exception e)
            {
                if (tr != null) tr.Rollback();
                throw;
            }
            return result;

        }

        public object ExecuteScalar(SqlCommand cmd)
        {
            object result = null;
            SqlTransaction tr = null;

            tr = m_Connection.BeginTransaction();

            cmd.Connection = m_Connection;

            cmd.Transaction = tr;

            result = cmd.ExecuteScalar();

            this.AcceptChanges();

            tr.Commit();

            if (result == DBNull.Value)
            {
                result = null;
            }
            return result;
        }
    }
}
