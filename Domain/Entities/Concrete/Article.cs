using Domain.Entities.Interface;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Concrete
{
    public class Article : IBaseEntity
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<Question> Questions { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public Status Status { get; set; }
    }
}
