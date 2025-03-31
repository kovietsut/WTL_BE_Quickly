using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Persistence;

public static class SeedData
{
    private static readonly string COVER_IMAGE_URL = $"https://webtruyenloofficial.blob.core.windows.net/test/876c1396-4246-466d-8b40-1d1da0011d299999aapple.jpg";
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
                PublishedDate = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc),
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
                PublishedDate = new DateTime(2012, 3, 15, 0, 0, 0, DateTimeKind.Utc),
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
                PublishedDate = new DateTime(2014, 7, 20, 0, 0, 0, DateTimeKind.Utc),
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
                PublishedDate = new DateTime(2016, 2, 10, 0, 0, 0, DateTimeKind.Utc),
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
                PublishedDate = new DateTime(2017, 5, 25, 0, 0, 0, DateTimeKind.Utc),
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
                PublishedDate = new DateTime(2018, 8, 30, 0, 0, 0, DateTimeKind.Utc),
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
                PublishedDate = new DateTime(2019, 12, 15, 0, 0, 0, DateTimeKind.Utc),
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
                PublishedDate = new DateTime(2020, 4, 20, 0, 0, 0, DateTimeKind.Utc),
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
                PublishedDate = new DateTime(2021, 6, 10, 0, 0, 0, DateTimeKind.Utc),
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
                Preface = "Denji's life of poverty changes forever when he merges with his pet chainsaw devil.",
                Format = MangaFormat.Novel,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = new DateTime(2022, 9, 5, 0, 0, 0, DateTimeKind.Utc),
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
                PublishedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
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

        // Seed Chapters
        modelBuilder.Entity<Chapter>().HasData(
            // One Piece Chapters
            new Chapter
            {
                Id = 1,
                Name = "Romance Dawn",
                NovelContent = "In a world of pirates and adventure, Monkey D. Luffy begins his journey to become the Pirate King...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 1,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 1
            },
            new Chapter
            {
                Id = 2,
                Name = "Enter the Great Swordsman",
                NovelContent = "Luffy meets Roronoa Zoro, a skilled swordsman who becomes his first crew member...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 1,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 2
            },
            // Attack on Titan Chapters
            new Chapter
            {
                Id = 3,
                Name = "To You, 2000 Years From Now",
                NovelContent = "The story begins with the fall of Wall Maria and the beginning of humanity's struggle...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 2,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 1
            },
            // Solo Leveling Chapters
            new Chapter
            {
                Id = 4,
                Name = "The Weakest Hunter",
                NovelContent = "Sung Jin-Woo is known as the weakest hunter of all mankind...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 3,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 1
            },
            // Demon Slayer Chapters
            new Chapter
            {
                Id = 5,
                Name = "Cruelty",
                NovelContent = "Tanjiro Kamado's peaceful life is shattered when his family is slaughtered by demons...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 4,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 1
            },
            new Chapter
            {
                Id = 6,
                Name = "The Demon Slayer Corps",
                NovelContent = "Tanjiro begins his training to become a Demon Slayer...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 4,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 2
            },
            // Tower of God Chapters
            new Chapter
            {
                Id = 7,
                Name = "The Tower",
                NovelContent = "Twenty-Fifth Bam has spent most of his life trapped beneath a mysterious tower...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 5,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 1
            },
            new Chapter
            {
                Id = 8,
                Name = "The Regulars",
                NovelContent = "Bam meets other Regulars who are also climbing the tower...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 5,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 2
            },
            // My Hero Academia Chapters
            new Chapter
            {
                Id = 9,
                Name = "Izuku Midoriya: Origin",
                NovelContent = "In a world where 80% of the population has some kind of super-powered Quirk...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 6,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 1
            },
            new Chapter
            {
                Id = 10,
                Name = "What It Takes to Be a Hero",
                NovelContent = "All Might begins training Izuku to inherit his power...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 6,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 2
            },
            // The Beginning After The End Chapters
            new Chapter
            {
                Id = 19,
                Name = "The King's Return",
                NovelContent = "King Grey has unrivaled strength, wealth, and prestige in a world governed by martial ability...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 7,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 1
            },
            new Chapter
            {
                Id = 20,
                Name = "The New World",
                NovelContent = "King Grey finds himself in a new world, one where magic and martial arts coexist...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 7,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 2
            },
            // Jujutsu Kaisen Chapters
            new Chapter
            {
                Id = 11,
                Name = "The Origin of Obedience",
                NovelContent = "Yuji Itadori is a boy with tremendous physical strength, though living a normal life...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 8,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 1
            },
            new Chapter
            {
                Id = 12,
                Name = "For Myself",
                NovelContent = "Yuji begins his training as a Jujutsu Sorcerer...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 8,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 2
            },
            // The God of High School Chapters
            new Chapter
            {
                Id = 13,
                Name = "The Tournament Begins",
                NovelContent = "Jin Mori is a 17-year-old high school student who participates in a fighting tournament...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 9,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 1
            },
            new Chapter
            {
                Id = 14,
                Name = "The First Match",
                NovelContent = "Jin faces his first opponent in the tournament...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 9,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 2
            },
            // Chainsaw Man Chapters
            new Chapter
            {
                Id = 15,
                Name = "Dog & Chainsaw",
                NovelContent = "Denji's life of poverty changes forever when he merges with his pet chainsaw devil...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 10,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 1
            },
            new Chapter
            {
                Id = 16,
                Name = "Chainsaw vs. Bat",
                NovelContent = "Denji faces his first major battle as a devil hunter...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 10,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 2
            },
            // Omniscient Reader Chapters
            new Chapter
            {
                Id = 17,
                Name = "The Beginning of the End",
                NovelContent = "Kim Dokja is the only person who knows the ending of a novel called 'Three Ways to Survive the Apocalypse'...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 11,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 1
            },
            new Chapter
            {
                Id = 18,
                Name = "The First Scenario",
                NovelContent = "The world begins to change as the scenarios from the novel become reality...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                MangaId = 11,
                CreatedBy = 1,
                ModifiedBy = 1,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                ChapterNumber = 2
            }
        );

        // Seed ChapterImages
        modelBuilder.Entity<ChapterImage>().HasData(
            // One Piece Chapter 1 Images
            new ChapterImage
            {
                Id = 1,
                Name = "One Piece Chapter 1 Page 1",
                FileSize = "2.5MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/one-piece/chapter-1/page-1.jpg",
                ChapterId = 1,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            new ChapterImage
            {
                Id = 2,
                Name = "One Piece Chapter 1 Page 2",
                FileSize = "2.3MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/one-piece/chapter-1/page-2.jpg",
                ChapterId = 1,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            // One Piece Chapter 2 Images
            new ChapterImage
            {
                Id = 3,
                Name = "One Piece Chapter 2 Page 1",
                FileSize = "2.4MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/one-piece/chapter-2/page-1.jpg",
                ChapterId = 2,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            // Attack on Titan Chapter 1 Images
            new ChapterImage
            {
                Id = 4,
                Name = "Attack on Titan Chapter 1 Page 1",
                FileSize = "2.6MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/attack-on-titan/chapter-1/page-1.jpg",
                ChapterId = 3,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            // Solo Leveling Chapter 1 Images
            new ChapterImage
            {
                Id = 5,
                Name = "Solo Leveling Chapter 1 Page 1",
                FileSize = "2.2MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/solo-leveling/chapter-1/page-1.jpg",
                ChapterId = 4,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            // Demon Slayer Chapter 1 Images
            new ChapterImage
            {
                Id = 6,
                Name = "Demon Slayer Chapter 1 Page 1",
                FileSize = "2.7MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/demon-slayer/chapter-1/page-1.jpg",
                ChapterId = 5,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            new ChapterImage
            {
                Id = 7,
                Name = "Demon Slayer Chapter 1 Page 2",
                FileSize = "2.4MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/demon-slayer/chapter-1/page-2.jpg",
                ChapterId = 5,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            // Demon Slayer Chapter 2 Images
            new ChapterImage
            {
                Id = 8,
                Name = "Demon Slayer Chapter 2 Page 1",
                FileSize = "2.5MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/demon-slayer/chapter-2/page-1.jpg",
                ChapterId = 6,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            // Tower of God Chapter 1 Images
            new ChapterImage
            {
                Id = 9,
                Name = "Tower of God Chapter 1 Page 1",
                FileSize = "2.3MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/tower-of-god/chapter-1/page-1.jpg",
                ChapterId = 7,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            new ChapterImage
            {
                Id = 10,
                Name = "Tower of God Chapter 1 Page 2",
                FileSize = "2.4MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/tower-of-god/chapter-1/page-2.jpg",
                ChapterId = 7,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            // Tower of God Chapter 2 Images
            new ChapterImage
            {
                Id = 11,
                Name = "Tower of God Chapter 2 Page 1",
                FileSize = "2.5MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/tower-of-god/chapter-2/page-1.jpg",
                ChapterId = 8,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            // My Hero Academia Chapter 1 Images
            new ChapterImage
            {
                Id = 12,
                Name = "My Hero Academia Chapter 1 Page 1",
                FileSize = "2.6MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/my-hero-academia/chapter-1/page-1.jpg",
                ChapterId = 9,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            new ChapterImage
            {
                Id = 13,
                Name = "My Hero Academia Chapter 1 Page 2",
                FileSize = "2.4MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/my-hero-academia/chapter-1/page-2.jpg",
                ChapterId = 9,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            // My Hero Academia Chapter 2 Images
            new ChapterImage
            {
                Id = 14,
                Name = "My Hero Academia Chapter 2 Page 1",
                FileSize = "2.5MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/my-hero-academia/chapter-2/page-1.jpg",
                ChapterId = 10,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            // The Beginning After The End Chapter 1 Images
            new ChapterImage
            {
                Id = 27,
                Name = "The Beginning After The End Chapter 1 Page 1",
                FileSize = "2.5MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/the-beginning-after-the-end/chapter-1/page-1.jpg",
                ChapterId = 19,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            new ChapterImage
            {
                Id = 28,
                Name = "The Beginning After The End Chapter 1 Page 2",
                FileSize = "2.4MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/the-beginning-after-the-end/chapter-1/page-2.jpg",
                ChapterId = 19,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            // The Beginning After The End Chapter 2 Images
            new ChapterImage
            {
                Id = 29,
                Name = "The Beginning After The End Chapter 2 Page 1",
                FileSize = "2.6MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/the-beginning-after-the-end/chapter-2/page-1.jpg",
                ChapterId = 20,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            // Jujutsu Kaisen Chapter 1 Images
            new ChapterImage
            {
                Id = 15,
                Name = "Jujutsu Kaisen Chapter 1 Page 1",
                FileSize = "2.5MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/jujutsu-kaisen/chapter-1/page-1.jpg",
                ChapterId = 11,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            new ChapterImage
            {
                Id = 16,
                Name = "Jujutsu Kaisen Chapter 1 Page 2",
                FileSize = "2.4MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/jujutsu-kaisen/chapter-1/page-2.jpg",
                ChapterId = 11,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            // Jujutsu Kaisen Chapter 2 Images
            new ChapterImage
            {
                Id = 17,
                Name = "Jujutsu Kaisen Chapter 2 Page 1",
                FileSize = "2.6MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/jujutsu-kaisen/chapter-2/page-1.jpg",
                ChapterId = 12,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            // The God of High School Chapter 1 Images
            new ChapterImage
            {
                Id = 18,
                Name = "The God of High School Chapter 1 Page 1",
                FileSize = "2.3MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/the-god-of-high-school/chapter-1/page-1.jpg",
                ChapterId = 13,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            new ChapterImage
            {
                Id = 19,
                Name = "The God of High School Chapter 1 Page 2",
                FileSize = "2.4MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/the-god-of-high-school/chapter-1/page-2.jpg",
                ChapterId = 13,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            // The God of High School Chapter 2 Images
            new ChapterImage
            {
                Id = 20,
                Name = "The God of High School Chapter 2 Page 1",
                FileSize = "2.5MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/the-god-of-high-school/chapter-2/page-1.jpg",
                ChapterId = 14,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            // Chainsaw Man Chapter 1 Images
            new ChapterImage
            {
                Id = 21,
                Name = "Chainsaw Man Chapter 1 Page 1",
                FileSize = "2.6MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/chainsaw-man/chapter-1/page-1.jpg",
                ChapterId = 15,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            new ChapterImage
            {
                Id = 22,
                Name = "Chainsaw Man Chapter 1 Page 2",
                FileSize = "2.4MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/chainsaw-man/chapter-1/page-2.jpg",
                ChapterId = 15,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            // Chainsaw Man Chapter 2 Images
            new ChapterImage
            {
                Id = 23,
                Name = "Chainsaw Man Chapter 2 Page 1",
                FileSize = "2.5MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/chainsaw-man/chapter-2/page-1.jpg",
                ChapterId = 16,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            // Omniscient Reader Chapter 1 Images
            new ChapterImage
            {
                Id = 24,
                Name = "Omniscient Reader Chapter 1 Page 1",
                FileSize = "2.3MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/omniscient-reader/chapter-1/page-1.jpg",
                ChapterId = 17,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            new ChapterImage
            {
                Id = 25,
                Name = "Omniscient Reader Chapter 1 Page 2",
                FileSize = "2.4MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/omniscient-reader/chapter-1/page-2.jpg",
                ChapterId = 17,
                CreatedBy = 1,
                ModifiedBy = 1
            },
            // Omniscient Reader Chapter 2 Images
            new ChapterImage
            {
                Id = 26,
                Name = "Omniscient Reader Chapter 2 Page 1",
                FileSize = "2.5MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/omniscient-reader/chapter-2/page-1.jpg",
                ChapterId = 18,
                CreatedBy = 1,
                ModifiedBy = 1
            }
        );
    }
} 