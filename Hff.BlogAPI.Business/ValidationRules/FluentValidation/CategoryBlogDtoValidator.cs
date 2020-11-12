using FluentValidation;
using Hff.BlogAPI.Dtos.Dtos.CategoryBlogDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.BlogAPI.Business.ValidationRules.FluentValidation
{
   public class CategoryBlogDtoValidator:AbstractValidator<CategoryBlogDto>
    {
        public CategoryBlogDtoValidator()
        {
            RuleFor(p => p.CategoryId).InclusiveBetween(0, int.MaxValue).WithMessage("CategoryId boş geçilemez");
            RuleFor(p => p.BlogId).InclusiveBetween(0, int.MaxValue).WithMessage("BlogId boş geçilemez");
        }
    }
}
