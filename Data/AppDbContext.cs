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
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(l => l.Languages)
                .WithMany();

            // modelBuilder.Entity<Question>()
            //     .HasOne(l => l.Language)
            //     .WithMany(q => q.Questions)
            //     .HasForeignKey("LanguageId");
        }
    }
}