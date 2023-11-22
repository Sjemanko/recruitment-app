using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using recruitment_app.Models;

namespace recruitment_app.Data
{
    public class AppDbContext : DbContext
    {
        // public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        // {
        // }

        public DbSet<Language> Languages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=recruitment-app;User ID=postgres;Password=password;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>()
                .HasMany(l => l.Users)
                .WithMany(u => u.Languages)
                .UsingEntity(j => j.ToTable("UserLanguages"));

            modelBuilder.Entity<Question>()
                .HasOne(l => l.Language)
                .WithMany(q => q.Questions)
                .HasForeignKey("LanguageId");
        }
    }
}