using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Persistence.Migrations;

public partial class UpdateMangaEnums : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // First, create temporary columns with the new enum types
        migrationBuilder.AddColumn<int>(
            name: "Format_New",
            table: "Mangas",
            type: "int",
            nullable: true);

        migrationBuilder.AddColumn<int>(
            name: "Season_New",
            table: "Mangas",
            type: "int",
            nullable: true);

        migrationBuilder.AddColumn<int>(
            name: "Region_New",
            table: "Mangas",
            type: "int",
            nullable: true);

        migrationBuilder.AddColumn<int>(
            name: "ReleaseStatus_New",
            table: "Mangas",
            type: "int",
            nullable: true);

        // Copy data from old columns to new columns
        migrationBuilder.Sql(@"
            UPDATE Mangas 
            SET Format_New = Format,
                Season_New = Season,
                Region_New = Region,
                ReleaseStatus_New = ReleaseStatus
        ");

        // Drop old columns
        migrationBuilder.DropColumn(
            name: "Format",
            table: "Mangas");

        migrationBuilder.DropColumn(
            name: "Season",
            table: "Mangas");

        migrationBuilder.DropColumn(
            name: "Region",
            table: "Mangas");

        migrationBuilder.DropColumn(
            name: "ReleaseStatus",
            table: "Mangas");

        // Rename new columns to original names
        migrationBuilder.RenameColumn(
            name: "Format_New",
            table: "Mangas",
            newName: "Format");

        migrationBuilder.RenameColumn(
            name: "Season_New",
            table: "Mangas",
            newName: "Season");

        migrationBuilder.RenameColumn(
            name: "Region_New",
            table: "Mangas",
            newName: "Region");

        migrationBuilder.RenameColumn(
            name: "ReleaseStatus_New",
            table: "Mangas",
            newName: "ReleaseStatus");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        // First, create temporary columns with the old int type
        migrationBuilder.AddColumn<int>(
            name: "Format_Old",
            table: "Mangas",
            type: "int",
            nullable: true);

        migrationBuilder.AddColumn<int>(
            name: "Season_Old",
            table: "Mangas",
            type: "int",
            nullable: true);

        migrationBuilder.AddColumn<int>(
            name: "Region_Old",
            table: "Mangas",
            type: "int",
            nullable: true);

        migrationBuilder.AddColumn<int>(
            name: "ReleaseStatus_Old",
            table: "Mangas",
            type: "int",
            nullable: true);

        // Copy data from enum columns to old columns
        migrationBuilder.Sql(@"
            UPDATE Mangas 
            SET Format_Old = Format,
                Season_Old = Season,
                Region_Old = Region,
                ReleaseStatus_Old = ReleaseStatus
        ");

        // Drop enum columns
        migrationBuilder.DropColumn(
            name: "Format",
            table: "Mangas");

        migrationBuilder.DropColumn(
            name: "Season",
            table: "Mangas");

        migrationBuilder.DropColumn(
            name: "Region",
            table: "Mangas");

        migrationBuilder.DropColumn(
            name: "ReleaseStatus",
            table: "Mangas");

        // Rename old columns back to original names
        migrationBuilder.RenameColumn(
            name: "Format_Old",
            table: "Mangas",
            newName: "Format");

        migrationBuilder.RenameColumn(
            name: "Season_Old",
            table: "Mangas",
            newName: "Season");

        migrationBuilder.RenameColumn(
            name: "Region_Old",
            table: "Mangas",
            newName: "Region");

        migrationBuilder.RenameColumn(
            name: "ReleaseStatus_Old",
            table: "Mangas",
            newName: "ReleaseStatus");
    }
} 