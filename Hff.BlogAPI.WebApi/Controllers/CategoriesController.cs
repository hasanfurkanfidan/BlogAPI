using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hff.BlogAPI.Business.Abstract;
using Hff.BlogAPI.Dtos.Dtos.CategoryDtos;
using Hff.BlogAPI.Entities.Concrete;
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
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(mapper.Map<CategoryListDto>(await categoryService.FindByIdAsync(id)));
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Create(CategoryAddDto model)
        {
            await categoryService.AddAsync(mapper.Map<Category>(model));
            return Created("", model);
        }
        [HttpPut("{id}")]
        [Authorize(Roles ="Admin")]
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
        public async Task<IActionResult>Delete(int id)
        {
            var blog = await categoryService.FindByIdAsync(id);
            await categoryService.RemoveAsync(blog);
            return NoContent();
        }
    }
}
