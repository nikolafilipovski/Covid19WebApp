using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Covid19.Entities;

namespace Covid19.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions options) : base(options) { }


        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CurrentCondition> CurrentConditions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Admin and roles

            const string ADMIN_ID = "b4280b6a-0613-4cbd-a9e6-f1701e926e73";
            const string ROLE_ID = ADMIN_ID;
            const string password = "Admin123!";

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ROLE_ID,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "b4280b6a-0613-4cbd-a9e6-f1701e926e74",
                    Name = "Guest",
                    NormalizedName = "GUEST"
                }
            );

            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "adminUserName",
                NormalizedUserName = "ADMINUSERNAME",
                Email = "admin@covid19.com",
                NormalizedEmail = "ADMIN@COVID19.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, password),
                SecurityStamp = string.Empty,
                ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc58"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }
}
