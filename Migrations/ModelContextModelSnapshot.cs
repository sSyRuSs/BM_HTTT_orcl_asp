﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using WebApplication1.Models;

#nullable disable

namespace BTL_final.Migrations
{
    [DbContext(typeof(ModelContext))]
    partial class ModelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("LONG12")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Dongsp", b =>
                {
                    b.Property<decimal>("Madong")
                        .HasColumnType("NUMBER(38)")
                        .HasColumnName("MADONG");

                    b.Property<string>("Loai")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("LOAI");

                    b.Property<string>("Tendong")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("TENDONG");

                    b.HasKey("Madong")
                        .HasName("SYS_C0010415");

                    b.ToTable("DONGSP", "LONG12");
                });

            modelBuilder.Entity("WebApplication1.Models.Hoadon", b =>
                {
                    b.Property<decimal>("Mahd")
                        .HasColumnType("NUMBER(38)")
                        .HasColumnName("MAHD");

                    b.Property<decimal>("Makh")
                        .HasColumnType("NUMBER(38)")
                        .HasColumnName("MAKH");

                    b.Property<decimal>("Manv")
                        .HasColumnType("NUMBER(38)")
                        .HasColumnName("MANV");

                    b.Property<decimal>("Masp")
                        .HasColumnType("NUMBER(38)")
                        .HasColumnName("MASP");

                    b.Property<DateTime?>("Ngaymua")
                        .HasColumnType("DATE")
                        .HasColumnName("NGAYMUA");

                    b.HasKey("Mahd")
                        .HasName("SYS_C0010429");

                    b.HasIndex("Makh");

                    b.HasIndex("Manv");

                    b.HasIndex("Masp");

                    b.ToTable("HOADON", "LONG12");
                });

            modelBuilder.Entity("WebApplication1.Models.Khachhang", b =>
                {
                    b.Property<decimal>("Makh")
                        .HasColumnType("NUMBER(38)")
                        .HasColumnName("MAKH");

                    b.Property<string>("Diachi")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("DIACHI");

                    b.Property<string>("Sdt")
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR2(10)")
                        .HasColumnName("SDT");

                    b.Property<string>("Tenkh")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("TENKH");

                    b.HasKey("Makh")
                        .HasName("SYS_C0010424");

                    b.ToTable("KHACHHANG", "LONG12");
                });

            modelBuilder.Entity("WebApplication1.Models.Nhanvien", b =>
                {
                    b.Property<decimal>("Manv")
                        .HasColumnType("NUMBER(38)")
                        .HasColumnName("MANV");

                    b.Property<string>("Chucvu")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("CHUCVU");

                    b.Property<string>("Sdt")
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR2(10)")
                        .HasColumnName("SDT");

                    b.Property<string>("Tennv")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("TENNV");

                    b.HasKey("Manv")
                        .HasName("SYS_C0010411");

                    b.ToTable("NHANVIEN", "LONG12");
                });

            modelBuilder.Entity("WebApplication1.Models.Sanpham", b =>
                {
                    b.Property<decimal>("Masp")
                        .HasColumnType("NUMBER(38)")
                        .HasColumnName("MASP");

                    b.Property<decimal>("Giaban")
                        .HasColumnType("NUMBER(38)")
                        .HasColumnName("GIABAN");

                    b.Property<decimal>("Madong")
                        .HasColumnType("NUMBER(38)")
                        .HasColumnName("MADONG");

                    b.Property<decimal?>("Sltonkho")
                        .HasColumnType("NUMBER(38)")
                        .HasColumnName("SLTONKHO");

                    b.Property<string>("Tensp")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("TENSP");

                    b.HasKey("Masp")
                        .HasName("SYS_C0010420");

                    b.HasIndex("Madong");

                    b.ToTable("SANPHAM", "LONG12");
                });

            modelBuilder.Entity("WebApplication1.Models.Taikhoannv", b =>
                {
                    b.Property<decimal>("Manv")
                        .HasColumnType("NUMBER(38)")
                        .HasColumnName("MANV");

                    b.Property<string>("Matkhau")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("MATKHAU");

                    b.HasKey("Manv")
                        .HasName("SYS_C0010407");

                    b.ToTable("TAIKHOANNV", "LONG12");
                });

            modelBuilder.Entity("WebApplication1.Models.Hoadon", b =>
                {
                    b.HasOne("WebApplication1.Models.Khachhang", "MakhNavigation")
                        .WithMany("Hoadons")
                        .HasForeignKey("Makh")
                        .IsRequired()
                        .HasConstraintName("FK_HOADON_KHACHHANG");

                    b.HasOne("WebApplication1.Models.Nhanvien", "ManvNavigation")
                        .WithMany("Hoadons")
                        .HasForeignKey("Manv")
                        .IsRequired()
                        .HasConstraintName("FK_HOADON_NHANVIEN");

                    b.HasOne("WebApplication1.Models.Sanpham", "MaspNavigation")
                        .WithMany("Hoadons")
                        .HasForeignKey("Masp")
                        .IsRequired()
                        .HasConstraintName("FK_HOADON_SANPHAM");

                    b.Navigation("MakhNavigation");

                    b.Navigation("ManvNavigation");

                    b.Navigation("MaspNavigation");
                });

            modelBuilder.Entity("WebApplication1.Models.Sanpham", b =>
                {
                    b.HasOne("WebApplication1.Models.Dongsp", "MadongNavigation")
                        .WithMany("Sanphams")
                        .HasForeignKey("Madong")
                        .IsRequired()
                        .HasConstraintName("FK_SANPHAM_DONGSP");

                    b.Navigation("MadongNavigation");
                });

            modelBuilder.Entity("WebApplication1.Models.Taikhoannv", b =>
                {
                    b.HasOne("WebApplication1.Models.Nhanvien", "ManvNavigation")
                        .WithOne("Taikhoannv")
                        .HasForeignKey("WebApplication1.Models.Taikhoannv", "Manv")
                        .IsRequired()
                        .HasConstraintName("FK_TAIKHOANNV_NHANVIEN");

                    b.Navigation("ManvNavigation");
                });

            modelBuilder.Entity("WebApplication1.Models.Dongsp", b =>
                {
                    b.Navigation("Sanphams");
                });

            modelBuilder.Entity("WebApplication1.Models.Khachhang", b =>
                {
                    b.Navigation("Hoadons");
                });

            modelBuilder.Entity("WebApplication1.Models.Nhanvien", b =>
                {
                    b.Navigation("Hoadons");

                    b.Navigation("Taikhoannv")
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.Sanpham", b =>
                {
                    b.Navigation("Hoadons");
                });
#pragma warning restore 612, 618
        }
    }
}
