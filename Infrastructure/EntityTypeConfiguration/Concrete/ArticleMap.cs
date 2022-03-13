using Domain.Entities.Concrete;
using Infrastructure.EntityTypeConfiguration.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityTypeConfiguration.Concrete
{
    public class ArticleMap : BaseMap<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.ArticleId);
            builder.Property(x => x.Title).IsRequired(true);
            builder.Property(x => x.Content).IsRequired(true);

            builder.HasMany(x => x.Questions)
                    .WithOne(x => x.Article)
                    .HasForeignKey(x => x.ArticleId)
                    .OnDelete(DeleteBehavior.Restrict); //Sınav Sayfası silinse de soruların silinmemesi için

            base.Configure(builder);
        }
    }
}
