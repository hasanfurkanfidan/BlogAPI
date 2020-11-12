using AutoMapper;
using Hff.BlogAPI.Dtos.Dtos.BlogDtos;
using Hff.BlogAPI.Dtos.Dtos.CategoryDtos;
using Hff.BlogAPI.Entities.Concrete;
using Hff.BlogAPI.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hff.BlogAPI.WebApi.Mapping.AutoMapper
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<BlogListDto, Blog>();
            CreateMap<Blog, BlogListDto>();


            CreateMap<BlogUpdateModel, Blog>();
            CreateMap<Blog, BlogUpdateModel>();

            CreateMap<Blog, BlogAddModel>();
            CreateMap<BlogAddModel, Blog>();

            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();

            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryListDto>();

            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();

        }
    }
}
