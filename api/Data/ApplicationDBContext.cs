using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; 

using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public DbSet<Stocks> Stocks { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Portfolio> portfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppUserId, p.stockId }));

            builder.Entity<Portfolio>()
                .HasOne(u => u.appUser)
                .WithMany(u => u.portfolios)
                .HasForeignKey(p => p.AppUserId);

            builder.Entity<Portfolio>()
                .HasOne(u => u.stock)
                .WithMany(u => u.portfolios)
                .HasForeignKey(p => p.stockId);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "8D04DCE2-969A-435D-BBA4-DF3F325983DC",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "F6F1A3F6-76C1-4A1F-B56C-BFFDB62D78C5",
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }

        
    }
}