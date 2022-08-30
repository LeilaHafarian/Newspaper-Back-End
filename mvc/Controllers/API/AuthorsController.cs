using Microsoft.AspNetCore.Mvc;
using Service.Models;
using Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mvc.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorService _authorService = new AuthorService();

        //[Route("api/Authors")]
        [HttpGet]
        public IEnumerable<AuthorDTO> Get()
        {
            return _authorService.GetAuthors();
        }

        //[Route("api/Authors/{id}")]
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("id is null!");
            }
            else
            {
                var searchAuthorById = _authorService.GetAuthor(id);
                if (searchAuthorById != null)
                {
                    return Ok(searchAuthorById);
                }
                else
                    return NotFound("id not valid!");

            }
        }

        //[HttpPost]
        [HttpPost]
        // [Route("api/Authors/{createAuthor}")]

        public IActionResult Post(CreateAuthorDTO createAuthor)
        {
            if (createAuthor.ImageName.Contains(".png") || createAuthor.ImageName.Contains(".jpg"))
            {
                _authorService.CreateAuthor(createAuthor);
                return Ok();
            }
            else
                return NotFound("Invalid Inputs!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(UpdateAuthorDTO updateAuthorDTO)
        {
            if (updateAuthorDTO.Id == Guid.Empty)
            {
                return BadRequest("id is null!");
            }
            else
            {
                _authorService.UpdateAuthor(updateAuthorDTO);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("id is null!");
            }
            else
            {
                var article = _authorService.GetAuthor(id);
                if (article != null)
                {
                    _authorService.DeleteAuthor(id);
                    return Ok("New Author Added Successfully");
                }
                else
                    return NotFound("id not valid!");

            }

        }

    }
}
