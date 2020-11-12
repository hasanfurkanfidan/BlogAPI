using FluentValidation;
using Hff.BlogAPI.Dtos.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.BlogAPI.Business.ValidationRules.FluentValidation
{
    public class CategoryUpdateDtoValidator:AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleFor(p => p.Id).InclusiveBetween(0, int.MaxValue).WithMessage("Id boş geçilemez");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Kategori Adı boş geçilemez");
        }
    }
}
