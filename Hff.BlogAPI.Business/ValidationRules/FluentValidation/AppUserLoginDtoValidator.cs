using FluentValidation;
using Hff.BlogAPI.Dtos.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.BlogAPI.Business.ValidationRules.FluentValidation
{
   public class AppUserLoginDtoValidator:AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Parola alanı boş geçilemez");
        }
    }
}
