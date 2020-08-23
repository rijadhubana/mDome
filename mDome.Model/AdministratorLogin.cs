using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model
{
    public class AdministratorLogin
    {
        public int AdministratorId { get; set; }
        public string AdminName { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
    }
}
