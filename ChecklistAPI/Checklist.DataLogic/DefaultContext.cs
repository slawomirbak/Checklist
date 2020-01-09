using Checklist.DataLogic.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.DataLogic
{
    public class DefaultContext: DbContext
    {
        public DefaultContext(DbContextOptions <DefaultContext> options): base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<UserChecklist> UserChecklists { get; set; }
        public DbSet<ChecklistField> ChecklistFields { get; set; }
        public DbSet<ChecklistImage> ChecklistImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithMany(a => a.Users);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(60);

            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User);

            modelBuilder.Entity<UserChecklist>()
                .HasOne(uc => uc.User);

            modelBuilder.Entity<UserChecklist>()
                .HasMany(uc => uc.ChecklistImages);
        }
    }
}
