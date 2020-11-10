using Hff.BlogAPI.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.BlogAPI.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.AuthorName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Mail).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(400).IsRequired();
            //Relations
            builder.HasMany(p => p.SubComments).WithOne(prop => prop.ParentComment).HasForeignKey(prop => prop.ParentCommentId);


        }
    }
}
