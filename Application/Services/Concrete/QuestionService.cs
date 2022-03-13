using Application.Models.DTOs;
using Application.Models.VMs;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities.Concrete;
using Domain.Enums;
using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task Create(CreateQuestionDTO model)
        {
            var question = _mapper.Map<Question>(model);
            await _unitOfWork.QuestionRepository.Add(question);
            await _unitOfWork.Commit();
        }

        public async Task Update(UpdateQuestionDTO model)
        {
            var question = _mapper.Map<Question>(model);
            _unitOfWork.QuestionRepository.Update(question);
            await _unitOfWork.Commit();
        }
        public async Task CreateMultiple(List<CreateQuestionDTO> createQuestionDtos)
        {
            var questions = await _mapper.Map<Task<List<Question>>>(createQuestionDtos);
            foreach (var question in questions)
            {
                await _unitOfWork.QuestionRepository.Add(question);
            }
        }



        public async Task<Question> GetQuestionById(int id)
        {
            var question = await _unitOfWork.QuestionRepository.GetDefault(x => x.QuestionId == id);
            return question;
        }

        public async Task<List<Question>> GetQuestions()
        {
            var questions = await _unitOfWork.QuestionRepository.GetDefaults(x => x.Status != Status.Passive);
            return questions;
        }

        public async Task<List<QuestionVM>> GetQuestionsByArticleId(int articleId)
        {
            var questions = await _unitOfWork.QuestionRepository.GetDefaults(x => x.ArticleId == articleId);
            var questionsVM = await _mapper.Map<Task<List<QuestionVM>>>(questions);
            return questionsVM;
        }



        public async Task Delete(int id)
        {
            var question = await _unitOfWork.QuestionRepository.GetDefault(x => x.QuestionId == id);
            question.Status = Status.Passive;
            question.DeleteDate = DateTime.Now;
            await _unitOfWork.Commit();
        }

        public async Task MultipleSellection(List<CreateQuestionDTO> createQuestionDto)
        {
            var questions = await _mapper.Map<Task<List<Question>>>(createQuestionDto);
            foreach (var question in questions)
            {
                await _unitOfWork.QuestionRepository.Add(question);
            }
        }
    }
}
