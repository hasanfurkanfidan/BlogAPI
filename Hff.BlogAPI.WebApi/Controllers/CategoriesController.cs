using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hff.BlogAPI.Business.Abstract;
using Hff.BlogAPI.Dtos.Dtos.CategoryBlogDtos;
using Hff.BlogAPI.Dtos.Dtos.CategoryDtos;
using Hff.BlogAPI.Entities.Concrete;
using Hff.BlogAPI.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hff.BlogAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await categoryService.GetAllAsync());
        }
        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<>))]

        public async Task<IActionResult> GetById(int id)
        {
            return Ok(mapper.Map<CategoryListDto>(await categoryService.FindByIdAsync(id)));
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        [ValidModel]
        public async Task<IActionResult> Create(CategoryAddDto model)
        {
            await categoryService.AddAsync(mapper.Map<Category>(model));
            return Created("", model);
        }
        [HttpPut("{id}")]
        [Authorize(Roles ="Admin")]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Category>))]

        public async Task<IActionResult> Update(int id, CategoryUpdateDto model)
        {
            if (id != model.Id)
            {
                return BadRequest("Geçersiz id");
            }
            await categoryService.UpdateAsync(mapper.Map<Category>(model));
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        [ServiceFilter(typeof(ValidId<Category>))]

        public async Task<IActionResult>Delete(int id)
        {
            var blog = await categoryService.FindByIdAsync(id);
            await categoryService.RemoveAsync(blog);
            return NoContent();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetWithCategryCount()
        {
           var categories =  await categoryService.GetAllWithCategoryBlogsAsync();
            List<CategoryWithBlogsCountDto> models = new List<CategoryWithBlogsCountDto>();
            foreach (var item in categories)
            {
                var model = new CategoryWithBlogsCountDto();
                model.Name = item.Name;

                model.Id = item.Id;
                model.BlogsCount = item.CategoryBlogs.Count();
                models.Add(model);
            }
            return Ok(models);
        }
    }
}
