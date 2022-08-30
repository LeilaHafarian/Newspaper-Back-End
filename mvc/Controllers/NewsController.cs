using DAL;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using Service.Services;

namespace mvc.Controllers
{
    public class NewsController : Controller
    {
        private readonly ILogger<NewsController> _logger;
        ArticleService article = new ArticleService(); 
        public NewsController(ILogger<NewsController> logger)
        {
            _logger = logger;
        }

        public IActionResult StartPage()
        {
            var dataExist = article.GetLatestArticles(5);
            if (dataExist.Count()>0)
            {
                ViewBag.pinned = article.GetPinnedArticles();
                return View(dataExist);
            }

            return View();
        }

        [Route("News/{id}/{title}")]
        public IActionResult Artikle(Guid id)
        {
            var searchByID = article.GetById(id);
            return View(searchByID);

        }
        [Route("News/{id}/{title}")]
        [HttpPost]
        public IActionResult Artikle(CreateCommentDTO createComment)
        { 
            article.AddComment(createComment);
            var searchByID = article.GetById(createComment.ArticleId);
            return View(searchByID);
           
        }
    }
}