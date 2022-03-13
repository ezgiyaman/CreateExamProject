using Application.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IAppUserService
    {
        //Kayıt Olurken
        Task<IdentityResult> Register(RegisterDTO model);

        //Giriş Yaparken
        Task<SignInResult> Login(LoginDTO model);

        //Çıkış Yaparken
        Task LogOut();

    }
}
