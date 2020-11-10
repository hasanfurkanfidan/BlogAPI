using Hff.BlogAPI.Business.Abstract;
using Hff.BlogAPI.DataAccess.Abstract;
using Hff.BlogAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.BlogAPI.Business.Concrete
{
   public class CommentManager:GenericManager<Comment>,ICommentService
    {
        private readonly IGenericDal<Comment> _genericDal;
        public CommentManager(IGenericDal<Comment>genericDal):base(genericDal)
        {
                
        }
    }
}
