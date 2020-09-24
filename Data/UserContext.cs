﻿using System;
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
            modelBuilder.Entity<UserModel>().ToTable("User").HasKey(s => s.Id);
            modelBuilder.Entity<UserModel>()
                        .HasOne(s => s.Role)
                        .WithMany(s => s.Users)
                        .HasForeignKey(s => s.RoleId);
            
            modelBuilder.Entity<UserRole>().ToTable("Roles").HasKey(s => s.Id);
            modelBuilder.Entity<UserRole>()
                        .HasMany(s => s.Users)
                        .WithOne(s => s.Role)
                        .HasForeignKey(c => c.Id);
                        
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

        public override ValueTask DisposeAsync()
        {
            return base.DisposeAsync();
        }
    }
}
