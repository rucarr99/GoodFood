using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace WADProject.Models
{
    public class RestaurantContext : IdentityDbContext<CustomUser>
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options)
        {
        }

        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<StaffRole> StaffRole { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedRoles(builder);
        }


        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "2", Name = "Administrator", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "1", Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
            );
        }
    }

}
