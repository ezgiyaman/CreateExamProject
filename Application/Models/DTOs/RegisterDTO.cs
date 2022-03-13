using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.DTOs
{
    public class RegisterDTO
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        //Encapsulation yapıp ,default atadım.
        public DateTime CreateDate => DateTime.Now;
        public Status Status => Status.Active;
    }
}
