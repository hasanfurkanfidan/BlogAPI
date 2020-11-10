using Hff.BlogAPI.DataAccess.Abstract;
using Hff.BlogAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.BlogAPI.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
   public class EfBlogRepository:EfGenericRepository<Blog>,IBlogDal
    {
    }
}
