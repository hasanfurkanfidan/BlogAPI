using Hff.BlogAPI.Dtos.Dtos.AppUserDtos;
using Hff.BlogAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hff.BlogAPI.Business.Abstract
{
    public interface IAppUserService:IGenericService<AppUser>
    {
        Task<AppUser> CheckUserAsync(AppUserLoginDto appUserLoginDto);
        Task<AppUser> FindByUserNameAsync(string userName);
    }
}
