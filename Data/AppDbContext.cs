using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace recruitment_app.Data
{
    public class AppDbContext : DbContext
    {
        // public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        // {
        // }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=recruitment-app;User ID=postgres;Password=password;");

    }
}