using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using KursachBot.Model;

namespace Meal.Models
{
    public partial class MealDB : DbContext
    {
        public MealDB()
        {
        }

        public MealDB(DbContextOptions<MealDB> options)
            : base(options)
        {
        }

        public virtual DbSet<Model> MealInfs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("DB3");

                entity.Property(e => e.id)
                    .HasMaxLength(25)
                    .IsFixedLength();

                entity.Property(e => e.title)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.readyInMinutes)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


    public partial class PhoneDB : DbContext
    {
        public PhoneDB()
        {
        }

        public PhoneDB(DbContextOptions<PhoneDB> options)
            : base(options)
        {
        }

        public virtual DbSet<Phone> MealInfs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("DB5");

                entity.Property(e => e.phoneNumber)
                    .HasMaxLength(25)
                    .IsFixedLength();

            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
