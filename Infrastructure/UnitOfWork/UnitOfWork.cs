using Domain.Repositories.Interface.EntityTypeRepositories;
using Domain.UnitOfWork;
using Infrastructure.Context;
using Infrastructure.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //Context nesenesinin enjekt etmemin sebebi Infrastructure katmanında Repositoryler folderında olan "Entity Type Repositorylerde" constructor olarak açtığım sınıflarda kullanabilmek için aşağıda olan (_db) gibi.
  
        private readonly AppDbContext _db;

        //Unit of work'un bizden istediği için repositoryleri burada çağırıyorum.
        public UnitOfWork(AppDbContext appDbContext)
        {
            _db = appDbContext ?? throw new ArgumentException("db can't be null");
        }

        //Singleton deseni repositorylerimi burada üretiyorum.

        private IUserRepository _userRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_db);
                }
                return _userRepository;
            }
        }

        private IQuestionRepository _questionRepository;
        public IQuestionRepository QuestionRepository
        {
            get
            {
                if (_questionRepository == null)
                {
                    _questionRepository = new QuestionRepository(_db);
                }
                return _questionRepository;
            }

        }

        private IArticleRepository _articlePageRepository;
        public IArticleRepository ArticleRepository
        {
            get
            {
                if (_articlePageRepository == null)
                {
                    _articlePageRepository = new ArticleRepository(_db);
                }
                return _articlePageRepository;
            }
        }

        //Repositorylerde tek savechanges oluyor,transcation dolayı o da UnitOfWork'te bulunuyor.
        public async Task Commit()
        {
            await _db.SaveChangesAsync();
        }



        private bool isDisposed = false;
        public async ValueTask DisposeAsync()
        {
            if (!isDisposed)
            {
                isDisposed = true;
                await DisposeAsync(true);//method dönüyor altta
                GC.SuppressFinalize(this);
            }
        }

        protected async Task DisposeAsync(bool disposing)
        {
            if (disposing)
            {
                await _db.DisposeAsync();
            }
        }
    }
}
