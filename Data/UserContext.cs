using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShiftPicker.Data.Models;

namespace ShiftPicker.Data
{
    public class UserContext : DbContext
    {
        public UserContext (DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<ShiftDetailModel> ShiftDetailModels { get; set; }
        public DbSet<ShiftModel> ShiftModels { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("User");
            modelBuilder.Entity<ShiftDetailModel>().ToTable("ShiftDetails");
            modelBuilder.Entity<ShiftModel>().ToTable("Shift");
            modelBuilder.Entity<UserRole>().ToTable("Roles");
        }
    }
}
