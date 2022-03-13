using Domain.Entities.Concrete;
using Domain.Repositories.Interface.EntityTypeRepositories;
using Infrastructure.Context;
using Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories.Concrete
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        private readonly AppDbContext _dbContext;
        public ArticleRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            this._dbContext = appDbContext;
        }

        public Article GetArticleAndQuestions(int articleId)
        {
            var result = _dbContext.Articles
                             .Include(x => x.Questions)
                             .Where(x => x.ArticleId == articleId)
                             .FirstOrDefault();
            return result;
        }
    }
}
