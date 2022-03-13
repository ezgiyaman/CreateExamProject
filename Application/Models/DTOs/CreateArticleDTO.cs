using Domain.Entities.Concrete;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.DTOs
{
    public class CreateArticleDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Question> Questions { get; set; }

        //Encapsulation yapıp ,default atadım.
        public DateTime CreateDate => DateTime.Now;
        public Status Status => Status.Active;
    }
}
