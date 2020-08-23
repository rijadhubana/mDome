using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class AdministratorLogin
    {
        public int AdministratorId { get; set; }
        public string AdminName { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
    }
}
