using Domain.Entities.Concrete;
using Domain.Repositories.Interface.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories.Interface.EntityTypeRepositories
{
    public interface IQuestionRepository : IBaseRepository<Question>
    {
    }
}
