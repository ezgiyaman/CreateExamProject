using Application.Models.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validation.FluentValidation
{
    //FluentValidation.AspNetCore 10.3.6 
    //FluentValidation.DependencyInjectionExtensions 10.3.6
    public class LoginValidation : AbstractValidator<LoginDTO>
    {
       
        public LoginValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı girin");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola girin");
        }
    }
}
