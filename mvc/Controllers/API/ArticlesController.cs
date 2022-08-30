using Microsoft.AspNetCore.Mvc;
using Service.Models;
using Service.Services;

namespace mvc.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        ArticleService _articleService = new ArticleService();

        // GET: api/Get
        [HttpGet]
        public IEnumerable<ApiArticleDTO> Get()
        {
            return _articleService.GetAllArticles();
        }

        // GET api/Get/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("id is null!");
            }
            else
            {
                var searchArticleById = _articleService.GetById(id);
                if (searchArticleById != null)
                {
                    return Ok(searchArticleById);
                }
                else
                    return NotFound("id not valid!");

            }
        }

        //POST api/Post
        [HttpPost]
        public IActionResult Post(CreateArticleDTO createArticleDTO)
        {
            if (ModelState.IsValid)
            {
                _articleService.CreateArticle(createArticleDTO);
                return Ok();
            }
            else
                return NotFound("Invalid Inputs!");

        }

        // PUT api/5
        [HttpPut("{id}")]
        public IActionResult Put(UpdateArticleDTO updateArticleDTO)
        {
            if (updateArticleDTO.Id == Guid.Empty)
            {
                return BadRequest("id is null!");
            }
            else
            {
                _articleService.UpdateArticle(updateArticleDTO);
                return Ok();
            }
        }

        // DELETE api/Delete/5
        //[Route("api/Articles/{id}")]
        //[HttpDelete("{id}")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("id is null!");
            }
            else
            {
                var article = _articleService.GetById(id);
                if (article != null)
                {
                    _articleService.DeleteArticle(id);
                    return Ok("The Article Deleted Successfully");
                }
                else
                    return NotFound("id not valid!");

            }

        }
    }
}
