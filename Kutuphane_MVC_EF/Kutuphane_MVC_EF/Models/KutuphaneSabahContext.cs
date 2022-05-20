using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Kutuphane_MVC_EF.Models
{
    public partial class KutuphaneSabahContext : DbContext
    {
        public KutuphaneSabahContext()
        {
        }

        public KutuphaneSabahContext(DbContextOptions<KutuphaneSabahContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kitaplar> Kitaplars { get; set; }
        public virtual DbSet<Odunc> Oduncs { get; set; }
        public virtual DbSet<Turler> Turlers { get; set; }
        public virtual DbSet<Uyeler> Uyelers { get; set; }
        public virtual DbSet<Yayinevleri> Yayinevleris { get; set; }
        public virtual DbSet<Yazarlar> Yazarlars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-5JA1DBH;Database=KutuphaneSabah;Trusted_Connection=true;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Kitaplar>(entity =>
            {
                entity.HasKey(e => e.Isbn)
                    .HasName("PK__Kitaplar__447D36EBC8C9DD62");

                entity.ToTable("Kitaplar");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Ad)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TurlerId).HasColumnName("TurlerID");

                entity.Property(e => e.YayinEvleriId).HasColumnName("YayinEvleriID");

                entity.Property(e => e.YazarlarId).HasColumnName("YazarlarID");

                entity.HasOne(d => d.Turler)
                    .WithMany(p => p.Kitaplars)
                    .HasForeignKey(d => d.TurlerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Kitaplar__Turler__4222D4EF");

                entity.HasOne(d => d.YayinEvleri)
                    .WithMany(p => p.Kitaplars)
                    .HasForeignKey(d => d.YayinEvleriId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Kitaplar__YayinE__440B1D61");

                entity.HasOne(d => d.Yazarlar)
                    .WithMany(p => p.Kitaplars)
                    .HasForeignKey(d => d.YazarlarId)
                    .HasConstraintName("FK__Kitaplar__Yazarl__4316F928");
            });

            modelBuilder.Entity<Odunc>(entity =>
            {
                entity.ToTable("Odunc");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KitaplarIsbn)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("KitaplarISBN");

                entity.Property(e => e.TeslimTarihi).HasColumnType("date");

                entity.Property(e => e.UyeId).HasColumnName("UyeID");

                entity.Property(e => e.VerilisTarihi).HasColumnType("date");

                entity.HasOne(d => d.KitaplarIsbnNavigation)
                    .WithMany(p => p.Oduncs)
                    .HasForeignKey(d => d.KitaplarIsbn)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Odunc__KitaplarI__47DBAE45");

                entity.HasOne(d => d.Uye)
                    .WithMany(p => p.Oduncs)
                    .HasForeignKey(d => d.UyeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Odunc__UyeID__46E78A0C");
            });

            modelBuilder.Entity<Turler>(entity =>
            {
                entity.ToTable("Turler");

                entity.HasIndex(e => e.TurAd, "UQ__Turler__A1D0193D816FCF10")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TurAd)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Uyeler>(entity =>
            {
                entity.ToTable("Uyeler");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdSoyad)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cinsiyet)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DogumTarihi).HasColumnType("date");

                entity.Property(e => e.Mail)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Meslek)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TcNo)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Tel)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.UyelikTarihi).HasColumnType("date");
            });

            modelBuilder.Entity<Yayinevleri>(entity =>
            {
                entity.ToTable("Yayinevleri");

                entity.HasIndex(e => e.Ad, "UQ__Yayinevl__3214AD00DD60C7E3")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Adres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tel)
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Yazarlar>(entity =>
            {
                entity.ToTable("Yazarlar");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdSoyad)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cinsiyet)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DogumTarihi).HasColumnType("date");

                entity.Property(e => e.Mail)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Tel)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TurlerId).HasColumnName("TurlerID");

                entity.HasOne(d => d.Turler)
                    .WithMany(p => p.Yazarlars)
                    .HasForeignKey(d => d.TurlerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Yazarlar__Turler__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
