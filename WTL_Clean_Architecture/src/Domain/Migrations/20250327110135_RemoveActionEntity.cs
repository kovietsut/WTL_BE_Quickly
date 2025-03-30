using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Persistence.Migrations
{
    public partial class RemoveActionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop foreign key constraints first
            migrationBuilder.DropForeignKey(
                name: "FK__FeaturedC__Actio__7E37BEF6",
                table: "FeaturedCollectionPermissions");

            // Drop the ActionId column from FeaturedCollectionPermissions
            migrationBuilder.DropColumn(
                name: "ActionId",
                table: "FeaturedCollectionPermissions");

            // Drop the Actions table
            migrationBuilder.DropTable(
                name: "Actions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Recreate the Actions table
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(getdate())"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Actions__3214EC0701FE5DAF", x => x.Id);
                });

            // Add back the ActionId column
            migrationBuilder.AddColumn<long>(
                name: "ActionId",
                table: "FeaturedCollectionPermissions",
                type: "bigint",
                nullable: true);

            // Recreate the foreign key constraint
            migrationBuilder.AddForeignKey(
                name: "FK__FeaturedC__Actio__7E37BEF6",
                table: "FeaturedCollectionPermissions",
                column: "ActionId",
                principalTable: "Actions",
                principalColumn: "Id");
        }
    }
} 