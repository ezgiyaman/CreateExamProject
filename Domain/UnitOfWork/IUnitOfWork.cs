using Domain.Repositories.Interface.EntityTypeRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UnitOfWork
{
    //Businesslarımızda birden fazla repository devreye girecektir.İş bittiğinde bu business içerisine giren repositorylerin memory managament yapmak için IAsyncDisposible sınıfının yeteneklerinden faydalanmak için IAsyncDisposible kalıtım aldım.
    public interface IUnitOfWork : IAsyncDisposable
    {
        //Repositoryleri singletonla ürettim sadece get olarak belirttim.(Nesnelerini çıkarmak istemediğimiz için UnitOfwork harici bi yerde newlememek için singleton ile ürettim.)

        IUserRepository UserRepository { get; }

        IQuestionRepository QuestionRepository { get; }

        IArticleRepository ArticleRepository { get; }

        //Asenkron
        Task Commit(); //Birden fazla repository'den gelen bilgileri tek bir seferde db'ye göndermek için kullanacağım.
    }
}
