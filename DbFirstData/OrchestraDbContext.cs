using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OrchestraManagement.DbFirstData
{
    public partial class OrchestraDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public OrchestraDbContext()
        {
        }

        public OrchestraDbContext(DbContextOptions<OrchestraDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Instrument> Instrument { get; set; }
        public virtual DbSet<Musician> Musician { get; set; }
        public virtual DbSet<Orchestra> Orchestra { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instrument>(entity =>
            {
                entity.Property(e => e.Condition)
                    .HasMaxLength(50)
                    .IsUnicode(false);
        
                entity.Property(e => e.Description).IsUnicode(false);
        
                entity.Property(e => e.MaintenanceDate)
                    .HasColumnName("Maintenance_Date")
                    .HasColumnType("date");
        
                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
        
                entity.HasOne(d => d.Musician)
                    .WithMany(p => p.Instrument)
                    .HasForeignKey(d => d.MusicianId)
                    .HasConstraintName("FK_Musician");
            });
        
            modelBuilder.Entity<Musician>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Section)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Orchestra)
                    .WithMany(p => p.Musician)
                    .HasForeignKey(d => d.OrchestraId)
                    .HasConstraintName("FK_Orchestra");
            });

            modelBuilder.Entity<Orchestra>(entity =>
            {
                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.WebsiteUrl)
                    .HasColumnName("WebsiteURL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });
        }
    }
}
