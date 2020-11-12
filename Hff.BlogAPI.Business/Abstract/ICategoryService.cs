using Hff.BlogAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hff.BlogAPI.Business.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        Task<List<Category>> GetAllSortedByCategory();
        Task<List<Category>> GetAllWithCategoryBlogsAsync();

    }
}
