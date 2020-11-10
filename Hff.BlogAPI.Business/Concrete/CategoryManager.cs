using Hff.BlogAPI.Business.Abstract;
using Hff.BlogAPI.DataAccess.Abstract;
using Hff.BlogAPI.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Hff.BlogAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hff.BlogAPI.Business.Concrete
{
    public class CategoryManager:GenericManager<Category>,ICategoryService
    {
        private readonly IGenericDal<Category> _genericDal;
        public CategoryManager(IGenericDal<Category>genericDal):base(genericDal)
        {
            _genericDal = genericDal;
        }

        public Task<List<Category>> GetAllSortedByCategory()
        {
            return _genericDal.GetAllAsync(p => p.Id);
        }
    }
}
