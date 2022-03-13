using Domain.Entities.Interface;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Concrete
{
    public class AppUser : IdentityUser, IBaseEntity
    {
        //Kullanıcı yönetimini gerçekleştirmek için Identity kullandım.
        // Microsoft.Extensitation.Identity.Stores paketini indirdim.
        public string FullName { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public Status Status { get; set; }
    }
}
