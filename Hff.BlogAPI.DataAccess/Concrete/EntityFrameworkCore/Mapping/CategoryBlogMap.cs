using Hff.BlogAPI.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.BlogAPI.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CategoryBlogMap : IEntityTypeConfiguration<CategoryBlog>
    {
        public void Configure(EntityTypeBuilder<CategoryBlog> builder)
        {
            builder.HasKey(prop => prop.Id);
            builder.Property(p => p.Id).UseIdentityColumn();

            builder.HasIndex(p => new { p.BlogId, p.CategoryId }).IsUnique();
        }
    }
}
