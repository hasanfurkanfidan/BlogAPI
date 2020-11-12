using Hff.BlogAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.BlogAPI.Business.Utilities.JwtTool
{
    public interface IJwtService
    {
        JwtToken GenerateJwt(AppUser appUser);
    }
}
