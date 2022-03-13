using Application.Models.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validation.FluentValidation
{
    public class RegisterValidation : AbstractValidator<RegisterDTO>
    {
        public RegisterValidation()
        {

            RuleFor(x => x.FullName).NotEmpty().WithMessage("İsim boş geçilemez.").MinimumLength(3).MaximumLength(50).WithMessage("Minumum 3, maksimum 50 karakter giriniz");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.").MinimumLength(3).MaximumLength(20).WithMessage("Minumum 3, maksimum 50 karakter giriniz");

            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta adresi girin").EmailAddress().WithMessage("Geçerli bir e-posta adresi girin");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre giriniz.");

            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Şifre eşleşmiyor.");

        }
    }
}
