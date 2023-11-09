using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dongsp> Dongsps { get; set; } = null!;
        public virtual DbSet<Hoadon> Hoadons { get; set; } = null!;
        public virtual DbSet<Khachhang> Khachhangs { get; set; } = null!;
        public virtual DbSet<Nhanvien> Nhanviens { get; set; } = null!;
        public virtual DbSet<Sanpham> Sanphams { get; set; } = null!;
        public virtual DbSet<Taikhoannv> Taikhoannvs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle("data source=localhost:1521/oracle123;persist security info=true;user id=long12;password=long12");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("LONG12");

            modelBuilder.Entity<Dongsp>(entity =>
            {
                entity.HasKey(e => e.Madong)
                    .HasName("SYS_C0010415");

                entity.ToTable("DONGSP");

                entity.Property(e => e.Madong)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MADONG");

                entity.Property(e => e.Loai)
                    .HasMaxLength(255)
                    .HasColumnName("LOAI");

                entity.Property(e => e.Tendong)
                    .HasMaxLength(255)
                    .HasColumnName("TENDONG");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Mahd)
                    .HasName("SYS_C0010429");

                entity.ToTable("HOADON");

                entity.Property(e => e.Mahd)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MAHD");

                entity.Property(e => e.Makh)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MAKH");

                entity.Property(e => e.Manv)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MANV");

                entity.Property(e => e.Masp)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MASP");

                entity.Property(e => e.Ngaymua)
                    .HasColumnType("DATE")
                    .HasColumnName("NGAYMUA");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.Makh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HOADON_KHACHHANG");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.Manv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HOADON_NHANVIEN");

                entity.HasOne(d => d.MaspNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.Masp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HOADON_SANPHAM");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Makh)
                    .HasName("SYS_C0010424");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.Makh)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MAKH");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(255)
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .HasColumnName("SDT");

                entity.Property(e => e.Tenkh)
                    .HasMaxLength(255)
                    .HasColumnName("TENKH");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Manv)
                    .HasName("SYS_C0010411");

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.Manv)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MANV");

                entity.Property(e => e.Chucvu)
                    .HasMaxLength(255)
                    .HasColumnName("CHUCVU");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .HasColumnName("SDT");

                entity.Property(e => e.Tennv)
                    .HasMaxLength(255)
                    .HasColumnName("TENNV");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.Masp)
                    .HasName("SYS_C0010420");

                entity.ToTable("SANPHAM");

                entity.Property(e => e.Masp)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MASP");

                entity.Property(e => e.Giaban)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("GIABAN");

                entity.Property(e => e.Madong)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MADONG");

                entity.Property(e => e.Sltonkho)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SLTONKHO");

                entity.Property(e => e.Tensp)
                    .HasMaxLength(255)
                    .HasColumnName("TENSP");

                entity.HasOne(d => d.MadongNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.Madong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SANPHAM_DONGSP");
            });

            modelBuilder.Entity<Taikhoannv>(entity =>
            {
                entity.HasKey(e => e.Manv)
                    .HasName("SYS_C0010407");

                entity.ToTable("TAIKHOANNV");

                entity.Property(e => e.Manv)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MANV");

                entity.Property(e => e.Matkhau)
                    .HasMaxLength(255)
                    .HasColumnName("MATKHAU");

                entity.HasOne(d => d.ManvNavigation)
                    .WithOne(p => p.Taikhoannv)
                    .HasForeignKey<Taikhoannv>(d => d.Manv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TAIKHOANNV_NHANVIEN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
