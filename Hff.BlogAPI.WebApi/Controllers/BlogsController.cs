using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hff.BlogAPI.Business.Abstract;
using Hff.BlogAPI.Entities.Concrete;
using Hff.BlogAPI.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hff.BlogAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public BlogsController(IBlogService blogService,IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _blogService.GetAllSortedByPostedTime());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetBtId(int id)
        {
            return Ok(await _blogService.FindByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult>Create(BlogAddModel model)
        {
          await _blogService.AddAsync(_mapper.Map<Blog>(model));
            return Created("",model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>Update(int id,BlogUpdateModel model)
        {
            if (id!=model.Id)
            {
                return BadRequest("Geçersiz id");
            }
           await _blogService.UpdateAsync(_mapper.Map<Blog>(model));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _blogService.RemoveAsync(await _blogService.FindByIdAsync(id));
            return NoContent();

        }



    }
}
