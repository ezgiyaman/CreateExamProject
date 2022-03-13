using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.DTOs
{
    public class UpdateQuestionDTO
    {
        public int QuestionId { get; set; }
        public string QuestionDescription { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string CorrectAnswer { get; set; }

        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        //Encapsulation yapıp ,default atadım.
        public DateTime UpdateDate => DateTime.Now;
        public Status Status => Status.Modified;
    }
}
