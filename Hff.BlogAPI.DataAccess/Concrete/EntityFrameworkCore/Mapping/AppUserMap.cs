using Hff.BlogAPI.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hff.BlogAPI.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.UserName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Password).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(100);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Surname).HasMaxLength(100).IsRequired();

            //Relations
            builder.HasMany(p => p.Blogs).WithOne(p => p.AppUser).HasForeignKey(a => a.AppUserId);

        }
    }
}
