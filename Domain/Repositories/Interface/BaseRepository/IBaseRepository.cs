using Domain.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interface.BaseRepositories
{
    public interface IBaseRepository<T> where T : IBaseEntity
    {
        //Asenkron olması için Task olarak işaretledim.

        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //GetByDefault & GetByDefaults'ta data çekme işlemleri yapılmaktadır.
        //Her türlü parametreyi çekmek için Linq Expression kullanılır.
        //<T,bool> T tipi bool dönüyor.

        //Get : Veri tabanından data çekmek,tek nesne
        Task<T> GetDefault(Expression<Func<T, bool>> expression);

        //List : İlgili nesnenin listesini gönderecektir.
        Task<List<T>> GetDefaults(Expression<Func<T, bool>> expression);
    }
}
