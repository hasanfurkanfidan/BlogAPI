using Hff.BlogAPI.Business.Abstract;
using Hff.BlogAPI.Business.Concrete;
using Hff.BlogAPI.Business.Utilities.JwtTool;
using Hff.BlogAPI.DataAccess.Abstract;
using Hff.BlogAPI.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.BlogAPI.Business.IOC.Microsoft
{
   public static class CustomExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IJwtService, JwtManager>();
            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDal, EfBlogRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentRepository>();
        }
    }
}
