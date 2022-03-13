using Application.Models.DTOs;
using Application.Models.VMs;
using AutoMapper;
using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.AutoMapper
{
    //AutoMapper paketi indirilir.
    public class Mapping : Profile
    {
        //Constructor içinde Map'leme işlemlerini tanımladım.

        public Mapping()
        {
            CreateMap<AppUser, LoginDTO>().ReverseMap();
            CreateMap<AppUser, RegisterDTO>().ReverseMap();
           
            CreateMap<AppUser, AppUserVM>().ReverseMap();
        

            CreateMap<Article, CreateArticleDTO>().ReverseMap();
            CreateMap<Article, CreateQuestionDTO>().ReverseMap();
            CreateMap<Article, ArticleVM>().ReverseMap();

            CreateMap<Question, CreateQuestionDTO>().ReverseMap();
            CreateMap<Question, UpdateQuestionDTO>().ReverseMap();
            CreateMap<Question, QuestionVM>().ReverseMap();
           
        }
    }
}
