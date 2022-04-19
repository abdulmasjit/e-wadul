using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using sekolah.Models;

namespace sekolah.Data
{
    public partial class sekolahContext : DbContext
    {
        public sekolahContext()
        {
        }

        public sekolahContext(DbContextOptions<sekolahContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Siswa> Siswas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Siswa>(entity =>
            {
                entity.ToTable("siswa");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
