using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstTestWebApp.Migrations
{
    /// <inheritdoc />
    public partial class SecondChangenamesoftable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "C_Categories");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "C_Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "C_Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_C_Categories",
                table: "C_Categories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_C_Categories",
                table: "C_Categories");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "C_Categories");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "C_Categories");

            migrationBuilder.RenameTable(
                name: "C_Categories",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryId");
        }
    }
}
