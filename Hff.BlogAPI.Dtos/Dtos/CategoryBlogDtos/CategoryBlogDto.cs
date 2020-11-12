using Hff.BlogAPI.Dtos.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.BlogAPI.Dtos.Dtos.CategoryBlogDtos
{
   public class CategoryBlogDto:IDto
    {
        public int CategoryId { get; set; }
        public int BlogId { get; set; }
    }
}
