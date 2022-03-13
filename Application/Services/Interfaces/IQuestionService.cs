using Application.Models.DTOs;
using Application.Models.VMs;
using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<List<Question>> GetQuestions();
        Task<Question> GetQuestionById(int id);
        Task<List<QuestionVM>> GetQuestionsByArticleId(int articleId);
        Task CreateMultiple(List<CreateQuestionDTO> createQuestionDtos);
        Task Create(CreateQuestionDTO model);
        Task Update(UpdateQuestionDTO model);
        Task Delete(int id);
    }
}
