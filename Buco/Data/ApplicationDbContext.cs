using System.IO;
using Buco.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Buco.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActivityEntry> ActivityEntries { get; set; }
        public virtual DbSet<ActivityType> ActivityTypes { get; set; }
        public virtual DbSet<MealEntry> MealEntries { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<PetType> PetTypes { get; set; }
        public virtual DbSet<WeightEntry> WeightEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json")
                      .Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ActivityEntry>(entity =>
            {
                entity.HasKey(e => e.ActivityEntryId);

                entity.Property(e => e.ActivityEntryId).ValueGeneratedOnAdd();

                entity.HasOne(p => p.Pet)
                .WithMany(a => a.ActivityEntries)
                .HasForeignKey(p => p.PetId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(p => p.ActivityType)
                .WithMany(a => a.ActivityEntries)
                .HasForeignKey(p => p.ActivityTypeId)
                .OnDelete(DeleteBehavior.Cascade);               
            });

            builder.Entity<ActivityType>(entity =>
            {
                entity.HasKey(e => e.ActivityTypeId);

                entity.Property(e => e.ActivityTypeId).ValueGeneratedOnAdd();
            });

            builder.Entity<MealEntry>(entity =>
            {
                entity.HasKey(e => e.MealEntryId);

                entity.Property(e => e.MealEntryId).ValueGeneratedOnAdd();

                entity.HasOne(p => p.Pet)
                .WithMany(a => a.MealEntries)
                .HasForeignKey(p => p.PetId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Pet>(entity =>
            {
                entity.HasKey(e => e.PetId);

                entity.Property(e => e.PetId).ValueGeneratedOnAdd();

                entity.HasOne(p => p.PetType)
                .WithMany(a => a.Pets)
                .HasForeignKey(p => p.PetTypeId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(p => p.User)
                .WithMany(u => u.Pets)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<PetType>(entity =>
            {
                entity.HasKey(e => e.PetTypeId);

                entity.Property(e => e.PetTypeId).ValueGeneratedOnAdd();
            });

            builder.Entity<WeightEntry>(entity =>
            {
                entity.HasKey(e => e.WeightEntryId);

                entity.Property(e => e.WeightEntryId).ValueGeneratedOnAdd();

                entity.HasOne(p => p.Pet)
                .WithMany(a => a.WeightEntries)
                .HasForeignKey(p => p.PetId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
