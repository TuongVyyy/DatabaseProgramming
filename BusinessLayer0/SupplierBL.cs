using DataLayer0;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer0
{
    public class SupplierBL
    {
        private SupplierDL supplierDL;
        public SupplierBL()
        {
            supplierDL = new SupplierDL();

        }
        public List<Supplier> GetSuppliers()
        {
            try
            {
                return (supplierDL.GetSupplier());
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }
           
        public int Add(Supplier supplier)
        {
            try
            {
                return supplierDL.Add(supplier);
            }
            catch (Exception ex)
            {
                throw ex;   // nem ngoai le len lop tren (giao dien) 
            }
        }
    }
}
