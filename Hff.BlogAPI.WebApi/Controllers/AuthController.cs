using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hff.BlogAPI.Business.Abstract;
using Hff.BlogAPI.Business.Utilities.JwtTool;
using Hff.BlogAPI.Dtos.Dtos.AppUserDtos;
using Hff.BlogAPI.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hff.BlogAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IJwtService _jwtService;
        public AuthController(IAppUserService appUserService,IJwtService jwtService)
        {
            _appUserService = appUserService;
            _jwtService = jwtService;
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult>SignIn(AppUserLoginDto appUserLoginDto)
        {
            var user =await _appUserService.CheckUserAsync(appUserLoginDto);
            if (user != null)
            {
                return Created("", _jwtService.GenerateJwt(user));
            }
            return BadRequest("Kullanıcı adı veya şifre hatalı");
        }
        [HttpGet("[action]")]
       
        public async Task<IActionResult> ActiveUser()
        {
            var userName = User.Identity.Name;
            var user =await _appUserService.FindByUserNameAsync(userName);
            var model = new AppUserDto
            {
                Name = user.Name,
                Surname = user.Surname
            };
            return Ok(model);
        }
    }
}
