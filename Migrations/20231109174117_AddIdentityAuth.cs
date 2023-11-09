using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTL_final.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "NVARCHAR2(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "TIMESTAMP(7) WITH TIME ZONE",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "NVARCHAR2(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "NVARCHAR2(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "LONG12",
                table: "TAIKHOANNV",
                type: "NVARCHAR2(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "LONG12",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "LONG12",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    ClaimType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ClaimValue = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_TAIKHOANNV_UserId",
                        column: x => x.UserId,
                        principalSchema: "LONG12",
                        principalTable: "TAIKHOANNV",
                        principalColumn: "MANV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "LONG12",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    UserId = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_TAIKHOANNV_UserId",
                        column: x => x.UserId,
                        principalSchema: "LONG12",
                        principalTable: "TAIKHOANNV",
                        principalColumn: "MANV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "LONG12",
                columns: table => new
                {
                    UserId = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    LoginProvider = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Value = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_TAIKHOANNV_UserId",
                        column: x => x.UserId,
                        principalSchema: "LONG12",
                        principalTable: "TAIKHOANNV",
                        principalColumn: "MANV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser<string>",
                schema: "LONG12",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    UserName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "LONG12",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RoleId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ClaimValue = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "LONG12",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "LONG12",
                columns: table => new
                {
                    UserId = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    RoleId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "LONG12",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_TAIKHOANNV_UserId",
                        column: x => x.UserId,
                        principalSchema: "LONG12",
                        principalTable: "TAIKHOANNV",
                        principalColumn: "MANV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "LONG12",
                table: "TAIKHOANNV",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "LONG12",
                table: "TAIKHOANNV",
                column: "NormalizedUserName",
                unique: true,
                filter: "\"NormalizedUserName\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "LONG12",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "LONG12",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "\"NormalizedName\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "LONG12",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "LONG12",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "LONG12",
                table: "AspNetUserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "LONG12");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "LONG12");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "LONG12");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "LONG12");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "LONG12");

            migrationBuilder.DropTable(
                name: "IdentityUser<string>",
                schema: "LONG12");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "LONG12");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                schema: "LONG12",
                table: "TAIKHOANNV");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                schema: "LONG12",
                table: "TAIKHOANNV");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                schema: "LONG12",
                table: "TAIKHOANNV");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "LONG12",
                table: "TAIKHOANNV");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "LONG12",
                table: "TAIKHOANNV");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                schema: "LONG12",
                table: "TAIKHOANNV");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "LONG12",
                table: "TAIKHOANNV");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                schema: "LONG12",
                table: "TAIKHOANNV");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                schema: "LONG12",
                table: "TAIKHOANNV");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                schema: "LONG12",
                table: "TAIKHOANNV");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                schema: "LONG12",
                table: "TAIKHOANNV");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "LONG12",
                table: "TAIKHOANNV");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "LONG12",
                table: "TAIKHOANNV");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                schema: "LONG12",
                table: "TAIKHOANNV");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                schema: "LONG12",
                table: "TAIKHOANNV");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                schema: "LONG12",
                table: "TAIKHOANNV");

            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "LONG12",
                table: "TAIKHOANNV");
        }
    }
}
