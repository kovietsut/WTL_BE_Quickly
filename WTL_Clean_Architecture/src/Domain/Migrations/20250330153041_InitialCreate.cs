using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(getdate())"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Generes__3214EC07C42CC74C", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(getdate())"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__3214EC07CE933FCB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(getdate())"),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    PasswordHash = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    SecurityStamp = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3214EC0768201A46", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Users__RoleId__4222D4EF",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuthMethods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    AuthType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AuthId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(getdate())"),
                    AccessToken = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    RefreshToken = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    JwtId = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    AccessTokenExpiration = table.Column<DateTime>(type: "datetime", nullable: true),
                    RefreshTokenExpiration = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AuthMeth__3214EC078CF7B1CD", x => x.Id);
                    table.ForeignKey(
                        name: "FK__AuthMetho__UserI__49C3F6B7",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NovelContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasDraft = table.Column<bool>(type: "bit", nullable: true),
                    ThumbnailImage = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    HasComment = table.Column<bool>(type: "bit", nullable: true),
                    StatusChapter = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Chapters__3214EC07F52585A5", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Chapters__Create__22751F6C",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Chapters__Modifi__236943A5",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FeaturedCollections",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(getdate())"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublish = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Featured__3214EC0736CEA38B", x => x.Id);
                    table.ForeignKey(
                        name: "FK__FeaturedC__Creat__6754599E",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__FeaturedC__Modif__68487DD7",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mangas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(getdate())"),
                    Title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Format = table.Column<int>(type: "int", nullable: true),
                    Region = table.Column<int>(type: "int", nullable: true),
                    ReleaseStatus = table.Column<int>(type: "int", nullable: true),
                    Preface = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    HasAdult = table.Column<bool>(type: "bit", nullable: true),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    SubAuthor = table.Column<long>(type: "bigint", nullable: true),
                    Publishor = table.Column<long>(type: "bigint", nullable: true),
                    Artist = table.Column<long>(type: "bigint", nullable: true),
                    Translator = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mangas__3214EC07903C34BB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mangas_Artist",
                        column: x => x.Artist,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mangas_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mangas_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mangas_Publishor",
                        column: x => x.Publishor,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mangas_SubAuthor",
                        column: x => x.SubAuthor,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mangas_Translator",
                        column: x => x.Translator,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChapterImages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileSize = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    MimeType = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    FilePath = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ChapterId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChapterI__3214EC07E2B6F532", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ChapterIm__Chapt__2A164134",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__ChapterIm__Creat__282DF8C2",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__ChapterIm__Modif__29221CFB",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FeaturedCollectionPermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(getdate())"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    FeaturedCollectionId = table.Column<long>(type: "bigint", nullable: true),
                    PermissionType = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Featured__3214EC07DA4FFC3C", x => x.Id);
                    table.ForeignKey(
                        name: "FK__FeaturedC__Featu__6D0D32F4",
                        column: x => x.FeaturedCollectionId,
                        principalTable: "FeaturedCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__FeaturedC__UserI__6C190EBB",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MangaId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ParentCommentId = table.Column<long>(type: "bigint", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(getdate())"),
                    IsSpoiler = table.Column<bool>(type: "bit", nullable: false),
                    ChapterId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comments__3214EC07CE8527B9", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Comments__MangaI__0E6E26BF",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Comments__Parent__0F624AF8",
                        column: x => x.ParentCommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FeaturedCollectionMangas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MangaId = table.Column<long>(type: "bigint", nullable: false),
                    FeaturedCollectionId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Featured__3214EC07A35C926C", x => x.Id);
                    table.ForeignKey(
                        name: "FK__FeaturedC__Featu__6EF57B66",
                        column: x => x.FeaturedCollectionId,
                        principalTable: "FeaturedCollections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__FeaturedC__Manga__6E01572D",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MangaGenres",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MangaId = table.Column<long>(type: "bigint", nullable: false),
                    GenreId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MangaGen__3214EC077172674E", x => x.Id);
                    table.ForeignKey(
                        name: "FK__MangaGenr__Genre__60A75C0F",
                        column: x => x.GenreId,
                        principalTable: "Generes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__MangaGenr__Manga__5FB337D6",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MangaInteractions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    MangaId = table.Column<long>(type: "bigint", nullable: true),
                    ChapterId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(getdate())"),
                    InteractionType = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MangaInt__3214EC075D87671E", x => x.Id);
                    table.ForeignKey(
                        name: "FK__MangaInte__Chapt__32AB8735",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__MangaInte__Manga__31B762FC",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__MangaInte__UserI__30C33EC3",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommentReactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ReactionType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CommentR__3214EC072CADC68D", x => x.Id);
                    table.ForeignKey(
                        name: "FK__CommentRe__Comme__14270015",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__CommentRe__UserI__151B244E",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthMethods_UserId",
                table: "AuthMethods",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterImages_ChapterId",
                table: "ChapterImages",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterImages_CreatedBy",
                table: "ChapterImages",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterImages_ModifiedBy",
                table: "ChapterImages",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_CreatedBy",
                table: "Chapters",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_ModifiedBy",
                table: "Chapters",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReactions_CommentId",
                table: "CommentReactions",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReactions_UserId",
                table: "CommentReactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ChapterId",
                table: "Comments",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MangaId",
                table: "Comments",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedCollectionMangas_FeaturedCollectionId",
                table: "FeaturedCollectionMangas",
                column: "FeaturedCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedCollectionMangas_MangaId",
                table: "FeaturedCollectionMangas",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedCollectionPermissions_FeaturedCollectionId",
                table: "FeaturedCollectionPermissions",
                column: "FeaturedCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedCollectionPermissions_UserId",
                table: "FeaturedCollectionPermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedCollections_CreatedBy",
                table: "FeaturedCollections",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedCollections_ModifiedBy",
                table: "FeaturedCollections",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MangaGenres_GenreId",
                table: "MangaGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaGenres_MangaId",
                table: "MangaGenres",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaInteractions_ChapterId",
                table: "MangaInteractions",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaInteractions_MangaId",
                table: "MangaInteractions",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaInteractions_UserId",
                table: "MangaInteractions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_Artist",
                table: "Mangas",
                column: "Artist");

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_CreatedBy",
                table: "Mangas",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_ModifiedBy",
                table: "Mangas",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_Publishor",
                table: "Mangas",
                column: "Publishor");

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_SubAuthor",
                table: "Mangas",
                column: "SubAuthor");

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_Translator",
                table: "Mangas",
                column: "Translator");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D1053495D01949",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthMethods");

            migrationBuilder.DropTable(
                name: "ChapterImages");

            migrationBuilder.DropTable(
                name: "CommentReactions");

            migrationBuilder.DropTable(
                name: "FeaturedCollectionMangas");

            migrationBuilder.DropTable(
                name: "FeaturedCollectionPermissions");

            migrationBuilder.DropTable(
                name: "MangaGenres");

            migrationBuilder.DropTable(
                name: "MangaInteractions");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "FeaturedCollections");

            migrationBuilder.DropTable(
                name: "Generes");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "Mangas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
