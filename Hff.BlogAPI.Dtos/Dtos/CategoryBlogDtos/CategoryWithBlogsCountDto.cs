using Hff.BlogAPI.Dtos.Abstract;
using Hff.BlogAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.BlogAPI.Dtos.Dtos.CategoryBlogDtos
{
   public class CategoryWithBlogsCountDto:IDto
    {
        public int BlogsCount { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
