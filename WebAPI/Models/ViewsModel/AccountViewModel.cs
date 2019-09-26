using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class AccountViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NewPassword { get; set; }
        public byte DefaultPassword { get; set; }
        public string CurrentPassword { get; set; }
        public string LoggedOn { get; set; }

        public string[] Roles { get; set; }

    }
}