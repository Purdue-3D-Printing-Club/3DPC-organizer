using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organizer.Server.Migrations
{
    /// <inheritdoc />
    public partial class JobControlsFromPrinterPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AssignedPrinterId",
                table: "Jobs",
                type: "TEXT",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "FailureCount",
                table: "Jobs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "AssignedPrinterId", table: "Jobs");

            migrationBuilder.DropColumn(name: "FailureCount", table: "Jobs");
        }
    }
}
