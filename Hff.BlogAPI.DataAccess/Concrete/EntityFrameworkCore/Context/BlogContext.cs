using Hff.BlogAPI.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.BlogAPI.DataAccess.Concrete.EntityFrameworkCore.Context
{
   public class BlogContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-3VB3SSC\\SQLEXPRESS;Database=BlogProject;IntegratedSecurity=true");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryBlog> CategoryBlogs { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
