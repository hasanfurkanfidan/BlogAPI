using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hff.BlogAPI.Business.Abstract;
using Hff.BlogAPI.Dtos.Dtos.BlogDtos;
using Hff.BlogAPI.Dtos.Dtos.CategoryBlogDtos;
using Hff.BlogAPI.Dtos.Dtos.CategoryDtos;
using Hff.BlogAPI.Entities.Concrete;
using Hff.BlogAPI.WebApi.CustomFilters;
using Hff.BlogAPI.WebApi.Enums;
using Hff.BlogAPI.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
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
        BaseController baseController = new BaseController();
        public BlogsController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<BlogListDto>>(await _blogService.GetAllSortedByPostedTime()));
        }
        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Blog>))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<BlogListDto>(await _blogService.FindByIdAsync(id)));
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidModel]
        public async Task<IActionResult> Create([FromForm] BlogAddModel model)
        {
            var uploadModel = await baseController.UploadFile(model.Image, "image/jpeg");
            if (uploadModel.UploadState == Enums.UploadState.NotExist)
            {
                await _blogService.AddAsync(_mapper.Map<Blog>(model));
                return Created("", model);

            }
            else if (uploadModel.UploadState == Enums.UploadState.Success)
            {
                model.ImagePath = uploadModel.NewName;
                await _blogService.AddAsync(_mapper.Map<Blog>(model));
                return Created("", model);

            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }

        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Blog>))]

        public async Task<IActionResult> Update(int id, [FromForm] BlogUpdateModel model)
        {
            var blog = await _blogService.FindByIdAsync(id);
            if (id != model.Id)
            {
                return BadRequest("Geçersiz id");
            }
            var uploadModel = await baseController.UploadFile(model.Image, "image/jpeg");
            if (uploadModel.UploadState == UploadState.Success)
            {
                model.ImagePath = uploadModel.NewName;
                await _blogService.UpdateAsync(_mapper.Map<Blog>(model));
                return NoContent();

            }
            else if (uploadModel.UploadState == UploadState.NotExist)
            {
                model.ImagePath = blog.ImagePath;
                await _blogService.UpdateAsync(_mapper.Map<Blog>(model));
                return NoContent();

            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidId<Blog>))]
        public async Task<IActionResult> Delete(int id)
        {

            await _blogService.RemoveAsync(await _blogService.FindByIdAsync(id));
            return NoContent();

        }
        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddToCategory(CategoryBlogDto model)
        {
            await _blogService.AddToCategoryAsync(model);
            return Created("", model);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveFromCategory(CategoryBlogDto model)
        {
            await _blogService.RemoveFromCategoryAsync(model);
            return NoContent();
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAllWithCategoryId(int id)
        {

            return Ok(_mapper.Map<List<BlogListDto>>(await _blogService.GetAllWithCategoryId(id)));
        }




    }
}
