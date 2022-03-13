using Application.Models.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prensentation.Controllers
{
    public class ExamController : Controller
    {
        private readonly IQuestionService _questionService;
        // private readonly IWebRequestContentSiteService _webRequestContentSiteService;

        public ExamController(IQuestionService questionService)
        {
            this._questionService = questionService;
            //this._webRequestContentSiteService = webRequestContentSiteService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(List<CreateQuestionDTO> model)
        {
            _questionService.CreateMultiple(model);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> List()
        {
            var exam = await _questionService.GetQuestions();
            return View(exam);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _questionService.Delete(id);
            return RedirectToAction("List");
        }
    }
}
