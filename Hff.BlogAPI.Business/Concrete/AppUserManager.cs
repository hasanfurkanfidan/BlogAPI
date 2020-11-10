using Hff.BlogAPI.Business.Abstract;
using Hff.BlogAPI.DataAccess.Abstract;
using Hff.BlogAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Hff.BlogAPI.Business.Concrete
{
    public class AppUserManager:GenericManager<AppUser>,IAppUserService
    {
        private readonly IGenericDal<AppUser> _genericDal;
        public AppUserManager(IGenericDal<AppUser>genericDal):base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
