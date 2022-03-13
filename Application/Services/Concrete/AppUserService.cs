using Application.Models.DTOs;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities.Concrete;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    public class AppUserService : IAppUserService
    {

        //Mapleme işlemi yapacağım için burada inject ettim.
        private readonly IMapper _mapper;

        //Identity yapılarını inj ettim,gömülü olan yapılar..

        //Identity Yapısı
        private readonly UserManager<AppUser> _userManager;

        //Identity Yapısı
        private readonly SignInManager<AppUser> _signInManager;


        public AppUserService(IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //Register olduktan sonra Login işlemi olacak.Yani kullanıcı kendini sisteme kayıt edecek kayıt ettikten sonra Login işlemi olacak.
        public async Task<IdentityResult> Register(RegisterDTO model)
        {
            //Mapleme işlemi ile AppUser sınıfında bulunan özelliklerin hepsi gelir.
            //RegisterDto'da yazdıklarımın hepsini tek tek çağırmak yerine mapleme işlemi ile tek satırda kodda çağırdım.
            var user = _mapper.Map<AppUser>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded) 
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }


        public async Task<SignInResult> Login(LoginDTO model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            return result;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
       
    }

      
}
