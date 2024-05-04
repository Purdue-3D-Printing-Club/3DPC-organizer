using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organizer.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserSubmitting",
                table: "Jobs",
                newName: "SupervisorName");

            migrationBuilder.RenameColumn(
                name: "Supervisor",
                table: "Jobs",
                newName: "SubmitterName");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedTime",
                table: "Jobs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FailureNotes",
                table: "Jobs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedTime",
                table: "Jobs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedTime",
                table: "Jobs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubmitterEmail",
                table: "Jobs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedTime",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "FailureNotes",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "StartedTime",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "SubmittedTime",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "SubmitterEmail",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "SupervisorName",
                table: "Jobs",
                newName: "UserSubmitting");

            migrationBuilder.RenameColumn(
                name: "SubmitterName",
                table: "Jobs",
                newName: "Supervisor");
        }
    }
}
