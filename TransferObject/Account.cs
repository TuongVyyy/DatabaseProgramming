using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TransferObject
{
    public class Account
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Account(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }
    }
}
