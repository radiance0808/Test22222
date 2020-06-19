using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
        public class PetsDbContext : DbContext
    {
        public DbSet<BreedType> BreedTypes { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Volunteer_Pet> Volunteer_Pets { get; set; }


        public PetsDbContext()
        {

        }

        public PetsDbContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pet>(opt =>
            {
                opt.HasKey(p => p.IdPet);
                opt.Property(p => p.IdPet)
                    .IsRequired().ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                    .HasMaxLength(80)
                    .IsRequired();
                opt.Property(p => p.IsMale)
                    .HasColumnType("bit")
                    .IsRequired();

                opt.Property(p => p.DateRegistered)
                    .IsRequired();
                opt.Property(p => p.ApprocimateDateOfBirth)
                    .IsRequired();

                opt.HasOne(p => p.BreedType)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(p => p.IdBreedType)
                    .IsRequired();
            });

            modelBuilder.Entity<Volunteer>(opt =>
            {
                opt.HasKey(p => p.IdVolunteer);
                opt.Property(p => p.IdVolunteer)
                    .IsRequired().ValueGeneratedOnAdd();
                opt.Property(p => p.Name)
                    .HasMaxLength(80)
                    .IsRequired();
                opt.Property(p => p.Surname)
                    .HasMaxLength(80)
                    .IsRequired();
                opt.Property(p => p.Phone)
                    .HasMaxLength(30)
                    .IsRequired();
                opt.Property(p => p.Address)
                    .HasMaxLength(100)
                    .IsRequired();
                opt.Property(p => p.Email)
                    .HasMaxLength(80)
                    .IsRequired();
                opt.Property(p => p.StartingDate)
                    .IsRequired();

            });

         

            modelBuilder.Entity<Volunteer_Pet>(opt =>
            {
                opt.HasKey(p => new { p.IdVolunteer, p.IdPet });
                opt.Property(p => p.DateAccepted)
                    .IsRequired().ValueGeneratedOnAdd();

                opt.HasOne(p => p.Pet)
                    .WithMany(p => p.Volunteer_Pets)
                    .HasForeignKey(p => p.IdPet)
                    .IsRequired();

                opt.HasOne(p => p.Volunteer)
                    .WithMany(p => p.Volunteer_Pets)
                    .HasForeignKey(p => p.IdVolunteer)
                    .IsRequired();
            });

          

            modelBuilder.Entity<BreedType>(opt =>
            {
                opt.HasKey(p => p.IdBreedType);
                opt.Property(p => p.IdBreedType)
                    .IsRequired().ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                    .HasMaxLength(50)
                    .IsRequired();
                opt.Property(p => p.Description)
                    .HasMaxLength(500);
            });
        }
    }
}