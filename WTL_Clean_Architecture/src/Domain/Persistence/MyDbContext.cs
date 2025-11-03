using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Enums;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Domain.Persistence;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthMethod> AuthMethods { get; set; }

    public virtual DbSet<Chapter> Chapters { get; set; }

    public virtual DbSet<ChapterImage> ChapterImages { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<CommentReaction> CommentReactions { get; set; }

    public virtual DbSet<FeaturedCollection> FeaturedCollections { get; set; }

    public virtual DbSet<FeaturedCollectionManga> FeaturedCollectionMangas { get; set; }

    public virtual DbSet<FeaturedCollectionPermission> FeaturedCollectionPermissions { get; set; }

    public virtual DbSet<Genere> Generes { get; set; }

    public virtual DbSet<Manga> Mangas { get; set; }

    public virtual DbSet<MangaGenre> MangaGenres { get; set; }

    public virtual DbSet<MangaInteraction> MangaInteractions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings =>
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Prefer configuration classes from Infrastructure
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Infrastructure.DependencyInjection).Assembly);
        modelBuilder.Entity<AuthMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AuthMeth__3214EC078CF7B1CD");

            entity.Property(e => e.AccessToken).IsUnicode(false);
            entity.Property(e => e.AccessTokenExpiration).HasColumnType("datetime");
            entity.Property(e => e.AuthId).HasMaxLength(255);
            entity.Property(e => e.AuthType).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.JwtId).IsUnicode(false);
            entity.Property(e => e.RefreshToken).IsUnicode(false);
            entity.Property(e => e.RefreshTokenExpiration).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.AuthMethods)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__AuthMetho__UserI__49C3F6B7");
        });

        modelBuilder.Entity<Chapter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Chapters__3214EC07F52585A5");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PublishedDate).HasColumnType("datetime");
            entity.Property(e => e.ThumbnailImage).IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ChapterNumber).IsRequired(false);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ChapterCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Chapters__Create__22751F6C");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ChapterModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Chapters__Modifi__236943A5");

            entity.HasOne(d => d.Manga).WithMany(p => p.Chapters)
                .HasForeignKey(d => d.MangaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Chapters_Manga");
        });

        modelBuilder.Entity<ChapterImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChapterI__3214EC07E2B6F532");

            entity.Property(e => e.FilePath).IsUnicode(false);
            entity.Property(e => e.FileSize)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MimeType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Chapter).WithMany(p => p.ChapterImages)
                .HasForeignKey(d => d.ChapterId)
                .HasConstraintName("FK__ChapterIm__Chapt__2A164134");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ChapterImageCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__ChapterIm__Creat__282DF8C2");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ChapterImageModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__ChapterIm__Modif__29221CFB");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3214EC07CE8527B9");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Chapter).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ChapterId)
                .HasConstraintName("FK_Comments_ChapterId");

            entity.HasOne(d => d.Manga).WithMany(p => p.Comments)
                .HasForeignKey(d => d.MangaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Comments__MangaI__0E6E26BF");

            entity.HasOne(d => d.ParentComment).WithMany(p => p.InverseParentComment)
                .HasForeignKey(d => d.ParentCommentId)
                .HasConstraintName("FK__Comments__Parent__0F624AF8");
        });

        modelBuilder.Entity<CommentReaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CommentR__3214EC072CADC68D");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Reason).HasMaxLength(500);

            entity.HasOne(d => d.Comment).WithMany(p => p.CommentReactions)
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("FK__CommentRe__Comme__14270015");

            entity.HasOne(d => d.User).WithMany(p => p.CommentReactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CommentRe__UserI__151B244E");
        });

        modelBuilder.Entity<FeaturedCollection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Featured__3214EC0736CEA38B");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.FeaturedCollectionCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__FeaturedC__Creat__6754599E");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.FeaturedCollectionModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__FeaturedC__Modif__68487DD7");
        });

        modelBuilder.Entity<FeaturedCollectionManga>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Featured__3214EC07A35C926C");

            entity.HasOne(d => d.FeaturedCollection).WithMany(p => p.FeaturedCollectionMangas)
                .HasForeignKey(d => d.FeaturedCollectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FeaturedC__Featu__6EF57B66");

            entity.HasOne(d => d.Manga).WithMany(p => p.FeaturedCollectionMangas)
                .HasForeignKey(d => d.MangaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FeaturedC__Manga__6E01572D");
        });

        modelBuilder.Entity<FeaturedCollectionPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Featured__3214EC07DA4FFC3C");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PermissionType)
                .HasConversion<int>()
                .IsRequired();

            entity.HasOne(d => d.FeaturedCollection).WithMany(p => p.FeaturedCollectionPermissions)
                .HasForeignKey(d => d.FeaturedCollectionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__FeaturedC__Featu__6D0D32F4");

            entity.HasOne(d => d.User).WithMany(p => p.FeaturedCollectionPermissions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__FeaturedC__UserI__6C190EBB");
        });

        modelBuilder.Entity<Genere>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Generes__3214EC07C42CC74C");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Manga>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Mangas__3214EC07903C34BB");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Preface)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PublishedDate).HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
            
            // Configure enum properties
            entity.Property(e => e.Format)
                .HasConversion<int>();
            entity.Property(e => e.Region)
                .HasConversion<int>();
            entity.Property(e => e.ReleaseStatus)
                .HasConversion<int>();

            entity.HasOne(d => d.ArtistNavigation).WithMany(p => p.MangaArtistNavigations)
                .HasForeignKey(d => d.Artist)
                .HasConstraintName("FK_Mangas_Artist");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MangaCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Mangas_CreatedBy");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.MangaModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK_Mangas_ModifiedBy");

            entity.HasOne(d => d.PublishorNavigation).WithMany(p => p.MangaPublishorNavigations)
                .HasForeignKey(d => d.Publishor)
                .HasConstraintName("FK_Mangas_Publishor");

            entity.HasOne(d => d.SubAuthorNavigation).WithMany(p => p.MangaSubAuthorNavigations)
                .HasForeignKey(d => d.SubAuthor)
                .HasConstraintName("FK_Mangas_SubAuthor");

            entity.HasOne(d => d.TranslatorNavigation).WithMany(p => p.MangaTranslatorNavigations)
                .HasForeignKey(d => d.Translator)
                .HasConstraintName("FK_Mangas_Translator");
        });

        modelBuilder.Entity<MangaGenre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MangaGen__3214EC077172674E");

            entity.HasOne(d => d.Genre).WithMany(p => p.MangaGenres)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MangaGenr__Genre__60A75C0F");

            entity.HasOne(d => d.Manga).WithMany(p => p.MangaGenres)
                .HasForeignKey(d => d.MangaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MangaGenr__Manga__5FB337D6");
        });

        modelBuilder.Entity<MangaInteraction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MangaInt__3214EC075D87671E");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Chapter).WithMany(p => p.MangaInteractions)
                .HasForeignKey(d => d.ChapterId)
                .HasConstraintName("FK__MangaInte__Chapt__32AB8735");

            entity.HasOne(d => d.Manga).WithMany(p => p.MangaInteractions)
                .HasForeignKey(d => d.MangaId)
                .HasConstraintName("FK__MangaInte__Manga__31B762FC");

            entity.HasOne(d => d.User).WithMany(p => p.MangaInteractions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MangaInte__UserI__30C33EC3");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07CE933FCB");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0768201A46");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053495D01949").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.PasswordHash).IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SecurityStamp).IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleId__4222D4EF");
        });

        OnModelCreatingPartial(modelBuilder);
        
        // Add seed data
        SeedData.Seed(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
