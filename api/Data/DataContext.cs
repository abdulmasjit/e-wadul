using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Ewadul.Api.Models;

namespace Ewadul.Api.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext(){}
        public DataContext(DbContextOptions<DataContext> options): base(options){}

        /**
        * DBSet
        * Digunakan untuk mendeklarasikan table ke model
        * Tanpa menggunakan mapping table dan column sudah bisa dijalankan
        *
        */
        public virtual DbSet<JenisPengaduan> JenisPengaduan { get; set; } = null!;

        /**
        * OnModelCreating
        * Digunakan untuk mapping table ke bentuk model yang telah dibuat
        * Mapping nama column cammel case
        *
        */
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            // Jenis Pengaduan
            modelBuilder.Entity<JenisPengaduan>(entity =>
            {
                entity.ToTable("jenis_pengaduan");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("status");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


        /*=================================================================
        * Override SaveChanges()
        * Digunakan untuk generate createAt dan updatedAt timestamp
        *
        *==================================================================*/
        
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            AddTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow; // current datetime

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                }
                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }

    }
}
