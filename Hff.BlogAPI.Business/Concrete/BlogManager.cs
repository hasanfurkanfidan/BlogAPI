using Hff.BlogAPI.Business.Abstract;
using Hff.BlogAPI.DataAccess.Abstract;
using Hff.BlogAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hff.BlogAPI.Business.Concrete
{
   public class BlogManager:GenericManager<Blog>,IBlogService
    {
        private readonly IGenericDal<Blog> _genericDal;
        public BlogManager(IGenericDal<Blog>genericDal):base(genericDal)
        {
            _genericDal = genericDal;
        }

        public Task<List<Blog>> GetAllSortedByPostedTime()
        {
            return _genericDal.GetAllAsync(p => p.PostedTime);
        }
    }
}
