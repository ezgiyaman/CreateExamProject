using Application.Models.DTOs;
using Application.Models.VMs;
using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IArticleService
    {
        Task Create(CreateArticleDTO model);
        Task<List<ArticleVM>> GetArticles();
        Task<Article> GetArticleById(int id);
        Task<string> GetByContent(int id);
        Task Delete(int id);
    }
}
