using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.VMs
{
    public class ArticleVM
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
