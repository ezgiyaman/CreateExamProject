using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prensentation.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            this._articleService = articleService;
        }
        public async Task<IActionResult> List()
        {
            var articles = await _articleService.GetArticles();
            return View(articles);
        }

        public IActionResult Delete(int articleId)
        {
            _articleService.Delete(articleId);
            return RedirectToAction("List", "Article");
        }
    }
}
