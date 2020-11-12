using Hff.BlogAPI.Business.Abstract;
using Hff.BlogAPI.DataAccess.Abstract;
using Hff.BlogAPI.Dtos.Dtos.CategoryBlogDtos;
using Hff.BlogAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hff.BlogAPI.Business.Concrete
{
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        private readonly IGenericDal<Blog> _genericDal;
        private readonly IGenericDal<CategoryBlog> _categoryBlogService;
        private readonly IBlogDal _blogDal;
        
        public BlogManager(IGenericDal<Blog> genericDal, IGenericDal<CategoryBlog> categoryBlogService,IBlogDal blogDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _categoryBlogService = categoryBlogService;
            _blogDal = blogDal;
            
        }

        public async Task AddToCategoryAsync(CategoryBlogDto categoryBlogDto)
        {
            var control = await _categoryBlogService.GetAsync(p => p.CategoryId == categoryBlogDto.CategoryId && p.BlogId == categoryBlogDto.BlogId);
            if (control == null)
            {
                await _categoryBlogService.AddAsync(
                new CategoryBlog
                {
                    BlogId = categoryBlogDto.BlogId,
                    CategoryId = categoryBlogDto.CategoryId
                }
                );
            }

        }

        public async Task<List<Blog>> GetAllSortedByPostedTime()
        {
            return await _genericDal.GetAllAsync(p => p.PostedTime);
        }

        public Task<List<Blog>> GetAllWithCategoryId(int id)
        {
            return _blogDal.GetAllWithCategoryId(id);
        }

        public async Task RemoveFromCategoryAsync(CategoryBlogDto categoryBlogDto)
        {
            var categoryBlog = await _categoryBlogService.GetAsync(p => p.CategoryId == categoryBlogDto.CategoryId && p.BlogId == categoryBlogDto.BlogId);
            if (categoryBlog != null)
            {
                await _categoryBlogService.RemoveAsync(categoryBlog);
            }
        }
    }
}
