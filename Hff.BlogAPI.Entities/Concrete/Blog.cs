using Hff.BlogAPI.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.BlogAPI.Entities.Concrete
{
    public class Blog:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime PostedTime { get; set; }
        public List<CategoryBlog> CategoryBlogs { get; set; }


    }
}
