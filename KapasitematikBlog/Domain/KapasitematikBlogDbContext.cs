using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KapasitematikBlog.Domain
{
    public partial class KapasitematikBlogDbContext : DbContext
    {
        public KapasitematikBlogDbContext()
        {
        }

        public KapasitematikBlogDbContext(DbContextOptions<KapasitematikBlogDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Makale> Makale { get; set; }
        public virtual DbSet<Resim> Resim { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KapasitematikBlogDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>(entity =>
            {
                entity.ToTable("KATEGORI");

                entity.Property(e => e.KategoriAd)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kullanici>(entity =>
            {
                entity.ToTable("KULLANICI");

                entity.Property(e => e.KullaniciAd)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KullaniciName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KullaniciPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KullaniciSoyad)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Makale>(entity =>
            {
                entity.ToTable("MAKALE");

                entity.Property(e => e.MakaleBaslik)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MakaleKategori)
                    .WithMany(p => p.Makale)
                    .HasForeignKey(d => d.MakaleKategoriId)
                    .HasConstraintName("FK_MAKALE_KATEGORI1");

            });

            modelBuilder.Entity<Resim>(entity =>
            {
                entity.ToTable("RESIM");

                entity.Property(e => e.ResimUrl).HasColumnName("Resim");
            });
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("ADMIN");

                entity.Property(e => e.AdminAd)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdminSifre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
