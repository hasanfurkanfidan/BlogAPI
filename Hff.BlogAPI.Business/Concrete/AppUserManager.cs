using Hff.BlogAPI.Business.Abstract;
using Hff.BlogAPI.DataAccess.Abstract;
using Hff.BlogAPI.Dtos.Dtos.AppUserDtos;
using Hff.BlogAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hff.BlogAPI.Business.Concrete
{
    public class AppUserManager:GenericManager<AppUser>,IAppUserService
    {
        private readonly IGenericDal<AppUser> _genericDal;
        public AppUserManager(IGenericDal<AppUser>genericDal):base(genericDal)
        {
            _genericDal = genericDal;
        }

        public Task<AppUser> CheckUserAsync(AppUserLoginDto appUserLoginDto)
        {
            var appUser = _genericDal.GetAsync(p => p.UserName == appUserLoginDto.UserName && p.Password == appUserLoginDto.Password);
            if (appUser!=null)
            {
                return appUser;
            }
            else
            {
                return null;
            }
        }

        public async Task<AppUser> FindByUserNameAsync(string userName)
        {
            return await _genericDal.GetAsync(p => p.UserName == userName);
        }
    }
}
