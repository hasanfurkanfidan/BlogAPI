using Hff.BlogAPI.DataAccess.Abstract;
using Hff.BlogAPI.DataAccess.Concrete.EntityFrameworkCore.Context;
using Hff.BlogAPI.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hff.BlogAPI.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryDal
    {
        public async Task<List<Category>> GetAllWithCategoryBlogsAsync()
        {
            using (var context = new BlogContext())
            {
                return await context.Categories.OrderByDescending(p=>p.Id).Include(p => p.CategoryBlogs).ToListAsync();
            }
        }
    }
}
