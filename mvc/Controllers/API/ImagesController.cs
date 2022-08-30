using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace mvc.Controllers.API
{
    //[Route("api/Images")]
    [ApiController]
    public class ImagesController : ControllerBase
    {

        ImageService _imageService = ImageService.Instance;

        //GET: api/Get
        [HttpGet]
        [Route("api/Images")]
        public List<string> Get()
        {
            return _imageService.GetAll();
        }



        [HttpPost]
        [Route("api/Images")]
        public IActionResult Post(IFormFile file)

        {
            _imageService.Upload(file);
            return Ok();
        }

    }
}
