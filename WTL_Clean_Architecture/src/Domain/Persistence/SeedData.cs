using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Persistence;

public static class SeedData
{
    private static readonly string COVER_IMAGE_URL = $"https://webtruyenloofficial.blob.core.windows.net/test/876c1396-4246-466d-8b40-1d1da0011d299999aapple.jpg?sv=2025-01-05&st=2025-03-29T17%3A11%3A10Z&se=2025-03-29T17%3A41%3A10Z&sr=b&sp=r&sig={Environment.GetEnvironmentVariable("AZURE_STORAGE_KEY")}";
    private static readonly DateTime SEED_DATE = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static void Seed(ModelBuilder modelBuilder)
    {
        // Seed Roles
        modelBuilder.Entity<Role>().HasData(
            new Role 
            { 
                Id = 1, 
                Name = "Admin", 
                IsDeleted = false, 
                CreatedAt = SEED_DATE, 
                UpdatedAt = SEED_DATE 
            },
            new Role 
            { 
                Id = 2, 
                Name = "Reader", 
                IsDeleted = false, 
                CreatedAt = SEED_DATE, 
                UpdatedAt = SEED_DATE 
            },
            new Role 
            { 
                Id = 3, 
                Name = "Author", 
                IsDeleted = false, 
                CreatedAt = SEED_DATE, 
                UpdatedAt = SEED_DATE 
            }
        );

        // Seed Genres
        modelBuilder.Entity<Genere>().HasData(
            new Genere 
            { 
                Id = 1, 
                Name = "Action", 
                IsDeleted = false, 
                CreatedAt = SEED_DATE, 
                UpdatedAt = SEED_DATE 
            },
            new Genere 
            { 
                Id = 2, 
                Name = "Adventure", 
                IsDeleted = false, 
                CreatedAt = SEED_DATE, 
                UpdatedAt = SEED_DATE 
            },
            new Genere 
            { 
                Id = 3, 
                Name = "Comedy", 
                IsDeleted = false, 
                CreatedAt = SEED_DATE, 
                UpdatedAt = SEED_DATE 
            },
            new Genere 
            { 
                Id = 4, 
                Name = "Drama", 
                IsDeleted = false, 
                CreatedAt = SEED_DATE, 
                UpdatedAt = SEED_DATE 
            },
            new Genere 
            { 
                Id = 5, 
                Name = "Fantasy", 
                IsDeleted = false, 
                CreatedAt = SEED_DATE, 
                UpdatedAt = SEED_DATE 
            },
            new Genere 
            { 
                Id = 6, 
                Name = "Horror", 
                IsDeleted = false, 
                CreatedAt = SEED_DATE, 
                UpdatedAt = SEED_DATE 
            },
            new Genere 
            { 
                Id = 7, 
                Name = "Romance", 
                IsDeleted = false, 
                CreatedAt = SEED_DATE, 
                UpdatedAt = SEED_DATE 
            },
            new Genere 
            { 
                Id = 8, 
                Name = "Sci-Fi", 
                IsDeleted = false, 
                CreatedAt = SEED_DATE, 
                UpdatedAt = SEED_DATE 
            }
        );

        // Seed Users
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FullName = "Phuc Lo",
                Email = "phuc123@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 1,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new User
            {
                Id = 2,
                FullName = "John Reader",
                Email = "john.reader@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 2,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new User
            {
                Id = 3,
                FullName = "Sarah Author",
                Email = "sarah.author@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 3,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Publishers
            new User
            {
                Id = 4,
                FullName = "Shueisha Publisher",
                Email = "shueisha.publisher@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 3,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new User
            {
                Id = 5,
                FullName = "Kodansha Publisher",
                Email = "kodansha.publisher@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 3,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new User
            {
                Id = 6,
                FullName = "Kakao Publisher",
                Email = "kakao.publisher@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 3,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Artists
            new User
            {
                Id = 7,
                FullName = "Eiichiro Oda",
                Email = "eiichiro.oda@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 3,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new User
            {
                Id = 8,
                FullName = "Hajime Isayama",
                Email = "hajime.isayama@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 3,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new User
            {
                Id = 9,
                FullName = "Chugong",
                Email = "chugong.artist@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 3,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new User
            {
                Id = 10,
                FullName = "Koyoharu Gotouge",
                Email = "koyoharu.gotouge@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 3,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Translators
            new User
            {
                Id = 11,
                FullName = "Stephen Paul",
                Email = "stephen.paul@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 3,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new User
            {
                Id = 12,
                FullName = "Kohei Horikoshi",
                Email = "kohei.horikoshi@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 3,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new User
            {
                Id = 13,
                FullName = "Yoon Ha Lee",
                Email = "yoon.ha.lee@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 3,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            }
        );

        // Seed AuthMethods for Users
        modelBuilder.Entity<AuthMethod>().HasData(
            new AuthMethod
            {
                Id = 1,
                UserId = 1,
                AuthType = "Email",
                AuthId = "phuc123@gmail.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new AuthMethod
            {
                Id = 2,
                UserId = 2,
                AuthType = "Email",
                AuthId = "john.reader@gmail.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new AuthMethod
            {
                Id = 3,
                UserId = 3,
                AuthType = "Email",
                AuthId = "sarah.author@gmail.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Publishers AuthMethods
            new AuthMethod
            {
                Id = 4,
                UserId = 4,
                AuthType = "Email",
                AuthId = "shueisha.publisher@gmail.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new AuthMethod
            {
                Id = 5,
                UserId = 5,
                AuthType = "Email",
                AuthId = "kodansha.publisher@gmail.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new AuthMethod
            {
                Id = 6,
                UserId = 6,
                AuthType = "Email",
                AuthId = "kakao.publisher@gmail.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Artists AuthMethods
            new AuthMethod
            {
                Id = 7,
                UserId = 7,
                AuthType = "Email",
                AuthId = "eiichiro.oda@gmail.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new AuthMethod
            {
                Id = 8,
                UserId = 8,
                AuthType = "Email",
                AuthId = "hajime.isayama@gmail.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new AuthMethod
            {
                Id = 9,
                UserId = 9,
                AuthType = "Email",
                AuthId = "chugong.artist@gmail.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new AuthMethod
            {
                Id = 10,
                UserId = 10,
                AuthType = "Email",
                AuthId = "koyoharu.gotouge@gmail.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Translators AuthMethods
            new AuthMethod
            {
                Id = 11,
                UserId = 11,
                AuthType = "Email",
                AuthId = "stephen.paul@gmail.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new AuthMethod
            {
                Id = 12,
                UserId = 12,
                AuthType = "Email",
                AuthId = "kohei.horikoshi@gmail.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new AuthMethod
            {
                Id = 13,
                UserId = 13,
                AuthType = "Email",
                AuthId = "yoon.ha.lee@gmail.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            }
        );

        // Seed Sample Manga
        modelBuilder.Entity<Manga>().HasData(
            new Manga
            {
                Id = 1,
                Title = "One Piece",
                Preface = "Follow Monkey D. Luffy and his pirate crew in their search for the ultimate treasure, the One Piece.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = SEED_DATE,
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = false,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Publishor = 1,
                Artist = 1,
                Translator = 1,
                SubAuthor = 1
            },
            new Manga
            {
                Id = 2,
                Title = "Attack on Titan",
                Preface = "Humanity lives inside cities surrounded by enormous walls due to the Titans, gigantic humanoid creatures who devour humans seemingly without reason.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = SEED_DATE,
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Publishor = 2,
                Artist = 2,
                Translator = 2,
                SubAuthor = 2
            },
            new Manga
            {
                Id = 3,
                Title = "Solo Leveling",
                Preface = "In a world where hunters must battle deadly monsters to protect the human race from certain annihilation, Sung Jin-Woo is the weakest hunter of all mankind.",
                Format = MangaFormat.Novel,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = SEED_DATE,
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = false,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Publishor = 3,
                Artist = 3,
                Translator = 3,
                SubAuthor = 3
            },
            new Manga
            {
                Id = 4,
                Title = "Demon Slayer",
                Preface = "Tanjiro Kamado's peaceful life is shattered when his family is slaughtered by demons. His sister Nezuko is turned into a demon, but still shows signs of human emotion and thought.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = SEED_DATE,
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Publishor = 2,
                Artist = 4,
                Translator = 1,
                SubAuthor = 1
            },
            new Manga
            {
                Id = 5,
                Title = "Tower of God",
                Preface = "The story follows Twenty-Fifth Bam, who has spent most of his life trapped beneath a mysterious tower, with only his close friend Rachel to keep him company.",
                Format = MangaFormat.Novel,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = SEED_DATE,
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = false,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Publishor = 3,
                Artist = 3,
                Translator = 3,
                SubAuthor = 3
            },
            new Manga
            {
                Id = 6,
                Title = "My Hero Academia",
                Preface = "In a world where 80% of the population has some kind of super-powered Quirk, Izuku Midoriya was unlucky to be born completely normal.",
                Format = MangaFormat.Novel,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = SEED_DATE,
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = false,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Publishor = 2,
                Artist = 1,
                Translator = 2,
                SubAuthor = 2
            },
            new Manga
            {
                Id = 7,
                Title = "The Beginning After The End",
                Preface = "King Grey has unrivaled strength, wealth, and prestige in a world governed by martial ability. However, solitude lingers closely behind those with great power.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = SEED_DATE,
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = false,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Publishor = 3,
                Artist = 3,
                Translator = 3,
                SubAuthor = 3
            },
            new Manga
            {
                Id = 8,
                Title = "Jujutsu Kaisen",
                Preface = "Yuji Itadori is a boy with tremendous physical strength, though living a normal life. One day, to save a friend who has been attacked by curses, he eats a finger of Ryomen Sukuna.",
                Format = MangaFormat.Novel,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = SEED_DATE,
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Publishor = 2,
                Artist = 2,
                Translator = 2,
                SubAuthor = 2
            },
            new Manga
            {
                Id = 9,
                Title = "The God of High School",
                Preface = "Jin Mori is a 17-year-old high school student who participates in a fighting tournament called 'The God of High School' to grant his grandfather's wish.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = SEED_DATE,
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = false,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Publishor = 3,
                Artist = 3,
                Translator = 3,
                SubAuthor = 3
            },
            new Manga
            {
                Id = 10,
                Title = "Chainsaw Man",
                Preface = "Denji's life of poverty changes forever when he merges with his pet chainsaw devil to become a hybrid devil-human.",
                Format = MangaFormat.Novel,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = SEED_DATE,
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Publishor = 2,
                Artist = 4,
                Translator = 1,
                SubAuthor = 1
            },
            new Manga
            {
                Id = 11,
                Title = "Omniscient Reader",
                Preface = "Kim Dokja is the only person who knows the ending of a novel called 'Three Ways to Survive the Apocalypse'. When the novel becomes reality, he must use his knowledge to survive.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = SEED_DATE,
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = false,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Publishor = 3,
                Artist = 3,
                Translator = 3,
                SubAuthor = 3
            }
        );

        // Seed MangaGenres
        modelBuilder.Entity<MangaGenre>().HasData(
            // One Piece genres
            new MangaGenre 
            { 
                Id = 1, 
                MangaId = 1, 
                GenreId = 1, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 2, 
                MangaId = 1, 
                GenreId = 2, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 3, 
                MangaId = 1, 
                GenreId = 3, 
                IsDeleted = false,
            },
            // Attack on Titan genres
            new MangaGenre 
            { 
                Id = 4, 
                MangaId = 2, 
                GenreId = 1, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 5, 
                MangaId = 2, 
                GenreId = 4, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 6, 
                MangaId = 2, 
                GenreId = 6, 
                IsDeleted = false,
            },
            // Solo Leveling genres
            new MangaGenre 
            { 
                Id = 7, 
                MangaId = 3, 
                GenreId = 1, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 8, 
                MangaId = 3, 
                GenreId = 5, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 9, 
                MangaId = 3, 
                GenreId = 8, 
                IsDeleted = false,
            },
            // Demon Slayer genres
            new MangaGenre 
            { 
                Id = 10, 
                MangaId = 4, 
                GenreId = 1, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 11, 
                MangaId = 4, 
                GenreId = 5, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 12, 
                MangaId = 4, 
                GenreId = 6, 
                IsDeleted = false,
            },
            // Tower of God genres
            new MangaGenre 
            { 
                Id = 13, 
                MangaId = 5, 
                GenreId = 1, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 14, 
                MangaId = 5, 
                GenreId = 2, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 15, 
                MangaId = 5, 
                GenreId = 5, 
                IsDeleted = false,
            },
            // My Hero Academia genres
            new MangaGenre 
            { 
                Id = 16, 
                MangaId = 6, 
                GenreId = 1, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 17, 
                MangaId = 6, 
                GenreId = 3, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 18, 
                MangaId = 6, 
                GenreId = 8, 
                IsDeleted = false,
            },
            // The Beginning After The End genres
            new MangaGenre 
            { 
                Id = 19, 
                MangaId = 7, 
                GenreId = 1, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 20, 
                MangaId = 7, 
                GenreId = 5, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 21, 
                MangaId = 7, 
                GenreId = 7, 
                IsDeleted = false,
            },
            // Jujutsu Kaisen genres
            new MangaGenre 
            { 
                Id = 22, 
                MangaId = 8, 
                GenreId = 1, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 23, 
                MangaId = 8, 
                GenreId = 5, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 24, 
                MangaId = 8, 
                GenreId = 6, 
                IsDeleted = false,
            },
            // The God of High School genres
            new MangaGenre 
            { 
                Id = 25, 
                MangaId = 9, 
                GenreId = 1, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 26, 
                MangaId = 9, 
                GenreId = 2, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 27, 
                MangaId = 9, 
                GenreId = 3, 
                IsDeleted = false,
            },
            // Chainsaw Man genres
            new MangaGenre 
            { 
                Id = 28, 
                MangaId = 10, 
                GenreId = 1, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 29, 
                MangaId = 10, 
                GenreId = 6, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 30, 
                MangaId = 10, 
                GenreId = 8, 
                IsDeleted = false,
            },
            // Omniscient Reader genres
            new MangaGenre 
            { 
                Id = 31, 
                MangaId = 11, 
                GenreId = 1, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 32, 
                MangaId = 11, 
                GenreId = 4, 
                IsDeleted = false,
            },
            new MangaGenre 
            { 
                Id = 33, 
                MangaId = 11, 
                GenreId = 8, 
                IsDeleted = false,
            }
        );
    }
} 