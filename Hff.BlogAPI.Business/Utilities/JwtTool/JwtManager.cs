using Hff.BlogAPI.Business.StringInfos;
using Hff.BlogAPI.Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hff.BlogAPI.Business.Utilities.JwtTool
{
    public class JwtManager : IJwtService
    {
        public JwtToken GenerateJwt(AppUser appUser)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer:JwtInfo.Issuer,audience:JwtInfo.Audience,claims:SetClaims(appUser),DateTime.Now,DateTime.Now.AddMinutes(JwtInfo.Minute),signingCredentials:signingCredentials);
            JwtToken jwtToken = new JwtToken();
            jwtToken.Token =  handler.WriteToken(jwtSecurityToken);
            return jwtToken;
        }
        private List<Claim>SetClaims(AppUser appUser)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            return claims;
        }
    }
}
