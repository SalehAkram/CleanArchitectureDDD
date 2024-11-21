using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalCare.Core.Entities;

namespace VitalCare.Infra
{
    public class VitalCareDbContext: DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<VitalSign> VitalSigns { get; set; }
        public VitalCareDbContext(DbContextOptions<VitalCareDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Account configuration
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedNever(); // IDs are provided explicitly for Accounts

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity
                    .HasMany(e => e.VitalSigns)
                    .WithOne()
                    .HasForeignKey(m => m.PatientId)
                    .IsRequired();
                // Seed the data
                entity.HasData(PatientSeedData.GetPatients());

            });
            modelBuilder.Entity<VitalSign>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.DateMeasured)
                    .IsRequired();

                entity.Property(e => e.Value)
                    .IsRequired();
                entity.Property(v => v.VitalSignType).HasColumnName("VitalSignType").IsRequired().HasConversion<string>();


            });

        }
    }
}
