using FluentValidation;
using Hff.BlogAPI.Dtos.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.BlogAPI.Business.ValidationRules.FluentValidation
{
    public class CategoryAddDtoValidator:AbstractValidator<CategoryAddDto>
    {
        public CategoryAddDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez");
        }
    }
}
