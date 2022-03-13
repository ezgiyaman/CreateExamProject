using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.VMs
{
    public class QuestionVM
    {
        public int QuestionId { get; set; }
        public string QuestionDescription { get; set; }

        public string CorrectAnswer { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
    }
}
