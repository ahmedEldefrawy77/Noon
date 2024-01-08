using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Noon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OtpMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OTPs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 128, nullable: false),
                    OneTimePassword = table.Column<int>(type: "int", nullable: false),
                    DateCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateExAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTPs", x => x.id);
                    table.ForeignKey(
                        name: "FK_OTPs_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OTPs_UserId",
                table: "OTPs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OTPs");
        }
    }
}
