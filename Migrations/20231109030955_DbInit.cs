using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTL_final.Migrations
{
    /// <inheritdoc />
    public partial class DbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "LONG12");

            migrationBuilder.CreateTable(
                name: "DONGSP",
                schema: "LONG12",
                columns: table => new
                {
                    MADONG = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    TENDONG = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    LOAI = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C0010415", x => x.MADONG);
                });

            migrationBuilder.CreateTable(
                name: "KHACHHANG",
                schema: "LONG12",
                columns: table => new
                {
                    MAKH = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    TENKH = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    SDT = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: true),
                    DIACHI = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C0010424", x => x.MAKH);
                });

            migrationBuilder.CreateTable(
                name: "NHANVIEN",
                schema: "LONG12",
                columns: table => new
                {
                    MANV = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    TENNV = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    SDT = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: true),
                    CHUCVU = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C0010411", x => x.MANV);
                });

            migrationBuilder.CreateTable(
                name: "SANPHAM",
                schema: "LONG12",
                columns: table => new
                {
                    MASP = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    TENSP = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    GIABAN = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    SLTONKHO = table.Column<decimal>(type: "NUMBER(38)", nullable: true),
                    MADONG = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C0010420", x => x.MASP);
                    table.ForeignKey(
                        name: "FK_SANPHAM_DONGSP",
                        column: x => x.MADONG,
                        principalSchema: "LONG12",
                        principalTable: "DONGSP",
                        principalColumn: "MADONG");
                });

            migrationBuilder.CreateTable(
                name: "TAIKHOANNV",
                schema: "LONG12",
                columns: table => new
                {
                    MANV = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    MATKHAU = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C0010407", x => x.MANV);
                    table.ForeignKey(
                        name: "FK_TAIKHOANNV_NHANVIEN",
                        column: x => x.MANV,
                        principalSchema: "LONG12",
                        principalTable: "NHANVIEN",
                        principalColumn: "MANV");
                });

            migrationBuilder.CreateTable(
                name: "HOADON",
                schema: "LONG12",
                columns: table => new
                {
                    MAHD = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    NGAYMUA = table.Column<DateTime>(type: "DATE", nullable: true),
                    MANV = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    MAKH = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    MASP = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C0010429", x => x.MAHD);
                    table.ForeignKey(
                        name: "FK_HOADON_KHACHHANG",
                        column: x => x.MAKH,
                        principalSchema: "LONG12",
                        principalTable: "KHACHHANG",
                        principalColumn: "MAKH");
                    table.ForeignKey(
                        name: "FK_HOADON_NHANVIEN",
                        column: x => x.MANV,
                        principalSchema: "LONG12",
                        principalTable: "NHANVIEN",
                        principalColumn: "MANV");
                    table.ForeignKey(
                        name: "FK_HOADON_SANPHAM",
                        column: x => x.MASP,
                        principalSchema: "LONG12",
                        principalTable: "SANPHAM",
                        principalColumn: "MASP");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HOADON_MAKH",
                schema: "LONG12",
                table: "HOADON",
                column: "MAKH");

            migrationBuilder.CreateIndex(
                name: "IX_HOADON_MANV",
                schema: "LONG12",
                table: "HOADON",
                column: "MANV");

            migrationBuilder.CreateIndex(
                name: "IX_HOADON_MASP",
                schema: "LONG12",
                table: "HOADON",
                column: "MASP");

            migrationBuilder.CreateIndex(
                name: "IX_SANPHAM_MADONG",
                schema: "LONG12",
                table: "SANPHAM",
                column: "MADONG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HOADON",
                schema: "LONG12");

            migrationBuilder.DropTable(
                name: "TAIKHOANNV",
                schema: "LONG12");

            migrationBuilder.DropTable(
                name: "KHACHHANG",
                schema: "LONG12");

            migrationBuilder.DropTable(
                name: "SANPHAM",
                schema: "LONG12");

            migrationBuilder.DropTable(
                name: "NHANVIEN",
                schema: "LONG12");

            migrationBuilder.DropTable(
                name: "DONGSP",
                schema: "LONG12");
        }
    }
}
