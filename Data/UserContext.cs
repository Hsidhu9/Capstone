using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShiftPicker.Data.Models;

namespace ShiftPicker.Data
{
    /// <summary>
    /// The Database Context For Shift_Picker Database, This class inherits from DbContext offered by Microsoft.EntityFrameworkCore
    /// </summary>
    public class UserContext : DbContext
    {
        public UserContext (DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Table of Users
        /// </summary>
        public DbSet<UserModel> UserModels { get; set; }

        /// <summary>
        /// Table of Shift Details
        /// </summary>
        public DbSet<ShiftDetailModel> ShiftDetailModels { get; set; }
        /// <summary>
        /// Table of Shifts
        /// </summary>
        public DbSet<ShiftModel> ShiftModels { get; set; }
        /// <summary>
        /// Table of User Roles
        /// </summary>
        public DbSet<UserRole> UserRoles { get; set; }

        /// <summary>
        /// Configuring the Database Context
        /// defining the shape of the entities, the relationships between them, and how they map to the database.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///defining relation ships b/w different entities i.e one to many and many to one
            /// Also defining the primary keys and foriegn keys on various tables
           
            modelBuilder.Entity<UserModel>().ToTable("UserDetails").HasKey(s => s.Id);
            modelBuilder.Entity<UserModel>()
                        .HasOne(s => s.Role)
                        .WithMany(s => s.Users)
                        .HasForeignKey(s => s.RoleId);
            
            modelBuilder.Entity<UserRole>().ToTable("Roles").HasKey(s => s.Id);
            modelBuilder.Entity<UserRole>()
                        .HasMany(s => s.Users)
                        .WithOne(s => s.Role)
                        .HasForeignKey(s => s.RoleId);
                        
            modelBuilder.Entity<ShiftDetailModel>().ToTable("ShiftDetails").HasKey(c => c.Id);
            modelBuilder.Entity<ShiftDetailModel>()
                        .HasOne(c => c.Shift)
                        .WithMany(s => s.ShiftDetails)
                        .HasForeignKey(a => a.ShiftId);

            modelBuilder.Entity<ShiftModel>().ToTable("Shift").HasKey(c => c.Id);
            modelBuilder.Entity<ShiftModel>()
                        .HasMany(s => s.ShiftDetails)
                        .WithOne(s => s.Shift)
                        .HasForeignKey(s => s.ShiftId);
        }

        /// <summary>
        /// Function to manually dispose/destruct the Database context, if needed
        /// </summary>
        /// <returns></returns>
        public override ValueTask DisposeAsync()
        {
            return base.DisposeAsync();
        }
    }
}
