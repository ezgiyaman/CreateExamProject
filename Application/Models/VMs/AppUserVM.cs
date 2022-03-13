using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.VMs
{
    public class AppUserVM
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
