using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace PresentationLayer
{
    public partial class Login: Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool UserLogin(Account account)
        {
            // check account in database?
            return true;
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            string user, password;
            user = txtUsername.Text.Trim();
            password = txtPassword.Text;

            Account account = new Account(user, password);

            if(UserLogin(account) == true)
            {
                //MessageBox.Show("Success!");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                string msg = "Username or password is incorrect!";
                DialogResult result = MessageBox.Show(msg, "Login", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry)
                {
                    txtPassword.Clear();
                    txtUsername.Clear();

                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}
