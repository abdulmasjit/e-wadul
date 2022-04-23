using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Ewadul.Api.Models;
namespace Ewadul.Api.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        /**
        * DBSet
        * Digunakan untuk mendeklarasikan table ke model
        * Tanpa menggunakan mapping table dan column sudah bisa dijalankan
        *
        */
        public virtual DbSet<AppConfig> AppConfigs { get; set; } = null!;
        public virtual DbSet<JenisPengaduan> JenisPengaduans { get; set; } = null!;
        public virtual DbSet<Kecamatan> Kecamatans { get; set; } = null!;
        public virtual DbSet<Pengaduan> Pengaduans { get; set; } = null!;
        public virtual DbSet<PengaduanFoto> PengaduanFotos { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<StatusPengaduan> StatusPengaduans { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        /**
        * OnModelCreating
        * Digunakan untuk mapping table ke bentuk model yang telah dibuat
        * Mapping nama column cammel case
        *
        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=db_ewadul;uid=admin;pwd=1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<AppConfig>(entity =>
            {
                entity.ToTable("app_config");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .HasColumnName("id");

                entity.Property(e => e.ChildLogo)
                    .HasMaxLength(150)
                    .HasColumnName("child_logo");

                entity.Property(e => e.EmailInstansi)
                    .HasMaxLength(50)
                    .HasColumnName("email_instansi");

                entity.Property(e => e.Favicon)
                    .HasMaxLength(150)
                    .HasColumnName("favicon");

                entity.Property(e => e.Fax)
                    .HasMaxLength(20)
                    .HasColumnName("fax");

                entity.Property(e => e.Instansi)
                    .HasMaxLength(100)
                    .HasColumnName("instansi");

                entity.Property(e => e.Jalan)
                    .HasMaxLength(100)
                    .HasColumnName("jalan");

                entity.Property(e => e.Kabupaten)
                    .HasMaxLength(50)
                    .HasColumnName("kabupaten");

                entity.Property(e => e.Kecamatan)
                    .HasMaxLength(50)
                    .HasColumnName("kecamatan");

                entity.Property(e => e.Kelurahan)
                    .HasMaxLength(50)
                    .HasColumnName("kelurahan");

                entity.Property(e => e.KodePos)
                    .HasMaxLength(10)
                    .HasColumnName("kode_pos");

                entity.Property(e => e.Logo)
                    .HasMaxLength(150)
                    .HasColumnName("logo");

                entity.Property(e => e.NamaSistem)
                    .HasMaxLength(100)
                    .HasColumnName("nama_sistem");

                entity.Property(e => e.PassInstansi)
                    .HasMaxLength(50)
                    .HasColumnName("pass_instansi");

                entity.Property(e => e.Provinsi)
                    .HasMaxLength(50)
                    .HasColumnName("provinsi");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status");

                entity.Property(e => e.Tagline)
                    .HasMaxLength(100)
                    .HasColumnName("tagline");

                entity.Property(e => e.Telp)
                    .HasMaxLength(20)
                    .HasColumnName("telp");

                entity.Property(e => e.UrlRoot)
                    .HasMaxLength(100)
                    .HasColumnName("url_root");
            });

            modelBuilder.Entity<JenisPengaduan>(entity =>
            {
                entity.ToTable("jenis_pengaduan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Kecamatan>(entity =>
            {
                entity.ToTable("kecamatan");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .HasColumnName("id");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(30)
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(30)
                    .HasColumnName("longitude");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .HasColumnName("nama");

                entity.Property(e => e.RegencyId)
                    .HasMaxLength(10)
                    .HasColumnName("regency_id");
            });

            modelBuilder.Entity<Pengaduan>(entity =>
            {
                entity.ToTable("pengaduan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alamat)
                    .HasColumnType("text")
                    .HasColumnName("alamat");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.IdJenisPengaduan).HasColumnName("id_jenis_pengaduan");

                entity.Property(e => e.IdKecamatan)
                    .HasMaxLength(10)
                    .HasColumnName("id_kecamatan");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Keterangan)
                    .HasColumnType("text")
                    .HasColumnName("keterangan");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(30)
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(30)
                    .HasColumnName("longitude");

                entity.Property(e => e.Status)
                    .HasMaxLength(15)
                    .HasColumnName("status");

                entity.Property(e => e.Tanggal).HasColumnName("tanggal");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<PengaduanFoto>(entity =>
            {
                entity.ToTable("pengaduan_foto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Foto)
                    .HasMaxLength(100)
                    .HasColumnName("foto");

                entity.Property(e => e.IdPengaduan).HasColumnName("id_pengaduan");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasColumnName("id");

                entity.Property(e => e.Nama)
                    .HasMaxLength(20)
                    .HasColumnName("nama");
            });

            modelBuilder.Entity<StatusPengaduan>(entity =>
            {
                entity.ToTable("status_pengaduan");

                entity.Property(e => e.Id)
                    .HasMaxLength(2)
                    .HasColumnName("id");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alamat)
                    .HasColumnType("text")
                    .HasColumnName("alamat");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.IdRole)
                    .HasMaxLength(10)
                    .HasColumnName("id_role");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama");

                entity.Property(e => e.Nik)
                    .HasMaxLength(20)
                    .HasColumnName("nik");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Telepon)
                    .HasMaxLength(15)
                    .HasColumnName("telepon");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
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
