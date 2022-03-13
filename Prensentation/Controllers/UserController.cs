using Application.Models.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prensentation.Controllers
{
    public class UserController : Controller
    {
        private IArticleService _articleService;
        private IQuestionService _questionService;
        public UserController(IArticleService articleService, IQuestionService questionService)
        {
            _articleService = articleService;
            _questionService = questionService;
        }
        public IActionResult Exam(int ArticleId)
        {
            var exam = _questionService.GetQuestionsByArticleId(ArticleId);
            return View(exam);
        }

        [HttpPost]
        public IActionResult QuizResult(List<CreateQuestionDTO> quizDto)
        {
            return RedirectToAction("Quiz", "User");
        }
    }
}
