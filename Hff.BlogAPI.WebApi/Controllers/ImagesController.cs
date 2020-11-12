using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hff.BlogAPI.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hff.BlogAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public ImagesController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet("{action}/{id}")]
        public async Task<IActionResult>GetBlogImageById(int id)
        {
            var blog = await _blogService.FindByIdAsync(id);
            if (!string.IsNullOrEmpty(blog.ImagePath))
            {
                return File($"/img/{blog.ImagePath}", "image/jpeg");
            }
            return NotFound("Bu resim yok");
            
        }

    }
}
