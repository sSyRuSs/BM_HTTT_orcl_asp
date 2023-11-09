using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTL_final.Migrations
{
    /// <inheritdoc />
    public partial class DelRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Create",
                schema: "LONG12",
                table: "TAIKHOANNV");

            migrationBuilder.DropColumn(
                name: "Expire",
                schema: "LONG12",
                table: "TAIKHOANNV");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                schema: "LONG12",
                table: "TAIKHOANNV");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Create",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Expire",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }
    }
}
