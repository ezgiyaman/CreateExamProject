using Domain.Entities.Concrete;
using Infrastructure.EntityTypeConfiguration.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Context
{
    //Proje içerisinde "Identity" kullandığımız zaman sadece DbContext'ten beslenemiyoruz, o yüzden IdentityDbContext kullanıyoruz.User classımızı, Identy 'den kalıtım aldırıp kullandığımız için..
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ArticleMap());
            modelBuilder.ApplyConfiguration(new QuestionMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
