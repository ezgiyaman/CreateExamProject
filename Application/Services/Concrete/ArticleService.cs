using Application.Models.DTOs;
using Application.Models.VMs;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities.Concrete;
using Domain.Enums;
using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{

    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task Create(CreateArticleDTO model)
        {
            var article = _mapper.Map<Article>(model);
            await _unitOfWork.ArticleRepository.Add(article);
            await _unitOfWork.Commit();
        }

        public async Task Delete(int id)
        {
            var article = await _unitOfWork.ArticleRepository.GetDefault(x => x.ArticleId == id);
            article.Status = Status.Passive;
            article.DeleteDate = DateTime.Now;
            await _unitOfWork.Commit();
        }



        public async Task<Article> GetArticleById(int id)
        {
            var article = await _unitOfWork.ArticleRepository.GetDefault(x => x.ArticleId == id);
            return article;
        }



        public async Task<string> GetByContent(int id)
        {
            var article = await _unitOfWork.ArticleRepository.GetDefault(x => x.ArticleId == id);
            return article.Content;
        }



        public async Task<List<ArticleVM>> GetArticles()
        {
            var articles = await _unitOfWork.ArticleRepository.GetDefaults(x => x.Status != Status.Passive);
            var articleVM = _mapper.Map<List<ArticleVM>>(articles);
            return articleVM;
        }


    }
}