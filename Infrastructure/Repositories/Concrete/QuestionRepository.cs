using Domain.Entities.Concrete;
using Domain.Repositories.Interface.EntityTypeRepositories;
using Infrastructure.Context;
using Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Concrete
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository 
    {
        public QuestionRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}
