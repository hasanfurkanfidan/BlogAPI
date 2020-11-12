using Hff.BlogAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hff.BlogAPI.DataAccess.Abstract
{
    public interface IBlogDal:IGenericDal<Blog>
    {
       Task< List<Blog>> GetAllWithCategoryId(int id);
    }
}
