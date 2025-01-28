using CommunityApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CommunityApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Province>().Property(p => p.ProvinceCode).IsRequired();
            builder.Entity<City>().Property(c => c.CityName).IsRequired();
            builder.Entity<Province>().ToTable("Provinces");
            builder.Entity<City>().ToTable("Cities");
            builder.Seed();
        }
    }
}
