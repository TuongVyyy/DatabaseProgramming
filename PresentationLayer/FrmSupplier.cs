using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer0;
using TransferObject;

namespace PresentationLayer
{
    public partial class FrmSupplier: Form
    {
        private SupplierBL supplierBL;
        public FrmSupplier()
        {
            InitializeComponent();
            supplierBL = new SupplierBL();

        }
        private void FrmSupplier_Load(object sender, EventArgs e)
        {
            try
            {
                List<Supplier> suppliers = supplierBL.GetSuppliers();
                dgvSupplier.DataSource = suppliers;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
