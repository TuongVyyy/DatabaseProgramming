using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer0
{
    public class DataProvider
    {
        // Chứa các xử lý chung
        private SqlConnection cn;

        public DataProvider()
        {
            string cnStr = "Data Source=ZY-COM;Initial Catalog=CoffeeShop;Integrated Security=True";
            cn = new SqlConnection(cnStr);

        }
        public void Connect()
        {
            try
            {
                if (cn != null && cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public object MyExecuteScalar(string sql, CommandType type)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;

                return (cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }

        }
        public SqlDataReader MyExecuteReader(string sql, CommandType type)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = type;
            try
            {
                return (cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public int MyExecuteNonQuery (string sql, CommandType type)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = type;
            try
            {
                Connect();
                return (cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }
    }
}
