using Hff.BlogAPI.DataAccess.Abstract;
using Hff.BlogAPI.DataAccess.Concrete.EntityFrameworkCore.Context;
using Hff.BlogAPI.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hff.BlogAPI.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfBlogRepository : EfGenericRepository<Blog>, IBlogDal
    {
        public async Task< List<Blog>> GetAllWithCategoryId(int id)
        {
            var context = new BlogContext();
            var blogs =await context.Blogs.Join(context.CategoryBlogs, bl => bl.Id, cb => cb.BlogId, (blog, categoryBlog) => new
            {
                blog = blog,
                categoryBlog = categoryBlog
            }).Where(p => p.categoryBlog.CategoryId == id).Select(p => new Blog
            {
                AppUser = p.blog.AppUser,
                AppUserId = p.blog.AppUserId,
                Description = p.blog.Description,
                ShortDescription = p.blog.ShortDescription,
                CategoryBlogs = p.blog.CategoryBlogs,
                Comments = p.blog.Comments,
                Id = p.blog.Id,
                ImagePath = p.blog.ImagePath,
                PostedTime = p.blog.PostedTime,
                Title = p.blog.Title
            }).ToListAsync();
            return blogs;
        }
    }
}
