using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFeaturedCollectionPermissionConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__FeaturedC__Featu__6D0D32F4",
                table: "FeaturedCollectionPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK__FeaturedC__UserI__6C190EBB",
                table: "FeaturedCollectionPermissions");

            migrationBuilder.AddForeignKey(
                name: "FK__FeaturedC__Featu__6D0D32F4",
                table: "FeaturedCollectionPermissions",
                column: "FeaturedCollectionId",
                principalTable: "FeaturedCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__FeaturedC__UserI__6C190EBB",
                table: "FeaturedCollectionPermissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
    }
}
