using Hff.BlogAPI.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.BlogAPI.Entities.Concrete
{
   public class Comment:IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public string Mail { get; set; }
        public DateTime PostedTime { get; set; } = DateTime.Now;
        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
        public List<Comment> SubComments { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
