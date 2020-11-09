using Hff.BlogAPI.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.BlogAPI.Entities.Concrete
{
   public class CategoryBlog:IEntity
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Blog Blog { get; set; }

    }
}
