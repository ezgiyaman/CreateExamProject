using Domain.Entities.Interface;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Concrete
{
    public class Question : IBaseEntity
    {
        public int QuestionId { get; set; }
        public string QuestionDescription { get; set; }

        public string CorrectAnswer { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public Status Status { get; set; }
    }
}
