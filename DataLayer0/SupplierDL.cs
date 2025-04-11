using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Data;

namespace DataLayer0
{
    public class SupplierDL: DataProvider
    {
        public List<Supplier> GetSupplier()
        {
            List<Supplier> sups = new List<Supplier>();
            string sql = "SELECT * FROM Supplier";
            string id, name, address;
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while(reader.Read())
                {
                    id = reader[0].ToString();
                    name = reader[1].ToString();
                    address = reader[2].ToString();
                    Supplier supplier = new Supplier(id, name, address);
                    sups.Add(supplier);
                }
                reader.Close();
                return sups;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();

            }

        }

        public int Add(Supplier supplier)
        {
            string sql = "INSERT INTO Supplier " +
                "VALUES ('" + supplier.Id + "', N'" + supplier.Name + "', N'" + supplier.Address + "')";
            try
            {
                return (MyExecuteNonQuery(sql, CommandType.Text));
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
    }
}
