using Domain.Entities.Concrete;
using Infrastructure.EntityTypeConfiguration.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityTypeConfiguration.Concrete
{
    public class QuestionMap : BaseMap<Question>
    {
        public override void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.QuestionId);
            builder.Property(x => x.QuestionDescription).IsRequired(true);
            builder.Property(x => x.A).IsRequired(true);
            builder.Property(x => x.B).IsRequired(true);
            builder.Property(x => x.C).IsRequired(true); ;
            builder.Property(x => x.D).IsRequired(true);
            builder.Property(x => x.CorrectAnswer).IsRequired(true);

            builder.HasOne(x => x.Article)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.ArticleId);

            base.Configure(builder);
        }
    }
}
