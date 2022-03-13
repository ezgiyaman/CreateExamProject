using Domain.Entities.Concrete;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.DTOs
{
    public class UpdateArticleDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Question> Questions { get; set; }
        public DateTime UpdateDate => DateTime.Now;
        public Status Status => Status.Modified;

    }
}
