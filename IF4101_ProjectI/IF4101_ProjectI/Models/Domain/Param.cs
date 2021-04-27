using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IF4101_ProjectI.Models.Data
{
    public class Param
    {

        private string user;
        private string password;

        public Param()
                {
                }

        public Param(string user, string password)
        {
            this.user = user;
            this.password = password;
        }

        public string Password { get => password; set => password = value; }
        public string User { get => user; set => user = value; }

    }

}
