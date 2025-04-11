using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class CoffeeShop: Form
    {
        public CoffeeShop()
        {
            InitializeComponent();
        }

        private void CoffeeShop_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Enabled = false;
            Login login = new Login();
            DialogResult result = login.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Enabled = true;
                lbWelcome.Text = "Welcome " + "TZyyy";

            }
            else
            {
                Application.Exit();
            }

        }

        // Create a mothed AddForm to add forms
        private void AddForrm(Form form)
        {
            form.TopLevel = false;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(form);

            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Show();
        }
        private void btSupplier_Click(object sender, EventArgs e)
        {
            FrmSupplier frm = new FrmSupplier();
            AddForrm(frm);
        }
    }
}
