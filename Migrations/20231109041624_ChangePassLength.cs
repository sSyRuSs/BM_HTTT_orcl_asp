using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTL_final.Migrations
{
    /// <inheritdoc />
    public partial class ChangePassLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MATKHAU",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "NVARCHAR2(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(20)",
                oldMaxLength: 20);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MATKHAU",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "NVARCHAR2(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(255)",
                oldMaxLength: 255);
        }
    }
}
