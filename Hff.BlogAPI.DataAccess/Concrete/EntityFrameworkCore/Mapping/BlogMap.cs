using Hff.BlogAPI.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.BlogAPI.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class BlogMap : IEntityTypeConfiguration<Blog>
    {
        //public int Id { get; set; }
        //public string Title { get; set; }
        //public string ShortDescription { get; set; }
        //public string Description { get; set; }
        //public string ImagePath { get; set; }
        //public DateTime PostedTime { get; set; }
        //public List<CategoryBlog> CategoryBlogs { get; set; }
        //public int AppUserId { get; set; }

        //public AppUser AppUser { get; set; }

        //public List<Comment> Comments { get; set; }
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(prop => prop.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Title).HasMaxLength(100).IsRequired();
            builder.Property(p => p.ShortDescription).HasMaxLength(350).IsRequired();
            builder.Property(p => p.Description).HasColumnType("ntext").IsRequired();
            builder.Property(p => p.ImagePath).HasMaxLength(250).IsRequired();
            //Relations
            builder.HasMany(p => p.CategoryBlogs).WithOne(p => p.Blog).HasForeignKey(p => p.BlogId);
            builder.HasMany(p => p.Comments).WithOne(prop => prop.Blog).HasForeignKey(prop => prop.BlogId);

        }
    }
}
