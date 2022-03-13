using Domain.Entities.Concrete;
using Infrastructure.EntityTypeConfiguration.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityTypeConfiguration.Concrete
{
    public class UserMap : BaseMap<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).IsRequired(true);
            builder.Property(x => x.NormalizedUserName).IsRequired(false);

            builder.Property(x => x.FullName).IsRequired(true);
           
            base.Configure(builder);

        }
    }
}
