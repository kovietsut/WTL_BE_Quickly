using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMangaIdFromFeaturedCollectionPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__FeaturedC__Manga__7B5B524B",
                table: "FeaturedCollectionPermissions");

            migrationBuilder.DropColumn(
                name: "MangaId",
                table: "FeaturedCollectionPermissions");

            migrationBuilder.AddForeignKey(
                name: "FK__FeaturedC__Featu__6D0D32F4",
                table: "FeaturedCollectionPermissions",
                column: "FeaturedCollectionId",
                principalTable: "FeaturedCollections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__FeaturedC__UserI__6C190EBB",
                table: "FeaturedCollectionPermissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__FeaturedC__Featu__6D0D32F4",
                table: "FeaturedCollectionPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK__FeaturedC__UserI__6C190EBB",
                table: "FeaturedCollectionPermissions");

            migrationBuilder.AddColumn<long>(
                name: "MangaId",
                table: "FeaturedCollectionPermissions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__FeaturedC__Manga__7B5B524B",
                table: "FeaturedCollectionPermissions",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__FeaturedC__Featu__7C4F7684",
                table: "FeaturedCollectionPermissions",
                column: "FeaturedCollectionId",
                principalTable: "FeaturedCollections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__FeaturedC__UserI__7D439ABD",
                table: "FeaturedCollectionPermissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
