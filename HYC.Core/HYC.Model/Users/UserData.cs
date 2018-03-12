using System;
using System.Collections.Generic;
using System.Text;

namespace HYC.Model.Users
{
    public class UserData
    {
        public Int32 Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        public string EMail { get; set; }

        public DateTime LastChanged { get; set; }
    }
}
