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
                UpdatedAt = SEED_DATE,
                Gender = "male",
                PhoneNumber = "0912345678",
                Address = "123 Le Duan Street, District 1, Ho Chi Minh City"
            },
            new User
            {
                Id = 2,
                FullName = "Sarah Johnson",
                Email = "sarah.johnson@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 2,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "female",
                PhoneNumber = "0987654321",
                Address = "45 Tran Hung Dao Street, Hai Ba Trung District, Hanoi"
            },
            new User
            {
                Id = 3,
                FullName = "Michael Chen",
                Email = "michael.chen@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 2,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "male",
                PhoneNumber = "0978123456",
                Address = "78 Nguyen Thi Minh Khai Street, Da Nang City"
            },
            new User
            {
                Id = 4,
                FullName = "Emma Wilson",
                Email = "emma.wilson@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 2,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "female",
                PhoneNumber = "0965432109",
                Address = "156 Le Loi Street, Hue City, Thua Thien Hue Province"
            },
            new User
            {
                Id = 5,
                FullName = "Alex Rivera",
                Email = "alex.rivera@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 2,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "others",
                PhoneNumber = "0956789012",
                Address = "234 Tran Phu Street, Nha Trang City, Khanh Hoa Province"
            },
            new User
            {
                Id = 6,
                FullName = "Hiroshi Tanaka",
                Email = "hiroshi.tanaka@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 3,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "male",
                PhoneNumber = "0945678901",
                Address = "89 Ly Thai To Street, Can Tho City"
            },
            new User
            {
                Id = 7,
                FullName = "Yuki Sato",
                Email = "yuki.sato@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 3,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "female",
                PhoneNumber = "0934567890",
                Address = "67 Nguyen Van Linh Street, Vung Tau City, Ba Ria-Vung Tau Province"
            },
            new User
            {
                Id = 8,
                FullName = "David Kim",
                Email = "david.kim@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 3,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "male",
                PhoneNumber = "0923456789",
                Address = "123 Quang Trung Street, Hai Phong City"
            },
            new User
            {
                Id = 9,
                FullName = "Lisa Park",
                Email = "lisa.park@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 3,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "female",
                PhoneNumber = "0912345678",
                Address = "45 Le Duan Street, Bien Hoa City, Dong Nai Province"
            },
            new User
            {
                Id = 10,
                FullName = "James Wilson",
                Email = "james.wilson@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 2,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "male",
                PhoneNumber = "0901234567",
                Address = "78 Tran Hung Dao Street, Thai Nguyen City, Thai Nguyen Province"
            },
            new User
            {
                Id = 11,
                FullName = "Maria Garcia",
                Email = "maria.garcia@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 2,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "female",
                PhoneNumber = "0890123456",
                Address = "156 Nguyen Trai Street, Nam Dinh City, Nam Dinh Province"
            },
            new User
            {
                Id = 12,
                FullName = "Taylor Smith",
                Email = "taylor.smith@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 2,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "others",
                PhoneNumber = "0889012345",
                Address = "234 Le Hong Phong Street, Quy Nhon City, Binh Dinh Province"
            },
            new User
            {
                Id = 13,
                FullName = "Wei Chen",
                Email = "wei.chen@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 3,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "male",
                PhoneNumber = "0878901234",
                Address = "67 Phan Chu Trinh Street, Pleiku City, Gia Lai Province"
            },
            new User
            {
                Id = 14,
                FullName = "Sofia Rodriguez",
                Email = "sofia.rodriguez@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 3,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "female",
                PhoneNumber = "0867890123",
                Address = "89 Nguyen Van Cu Street, Long Xuyen City, An Giang Province"
            },
            new User
            {
                Id = 15,
                FullName = "Jordan Lee",
                Email = "jordan.lee@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = 3,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "others",
                PhoneNumber = "0856789012",
                Address = "123 Ly Thuong Kiet Street, Rach Gia City, Kien Giang Province"
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
            },
            new Manga
            {
                Id = 12,
                Title = "Dragon Ball Super",
                Preface = "The story of Goku and his friends' continued adventures after the defeat of Majin Buu.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
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
                Id = 13,
                Title = "The Promised Neverland",
                Preface = "A group of orphans discover the dark truth about their idyllic orphanage.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = new DateTime(2024, 1, 8, 0, 0, 0, DateTimeKind.Utc),
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
                Id = 14,
                Title = "Tower of God",
                Preface = "Follow Bam as he climbs the mysterious Tower to find Rachel.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc),
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
                Id = 15,
                Title = "Black Clover",
                Preface = "A young boy born without magic strives to become the Wizard King.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 1, 22, 0, 0, 0, DateTimeKind.Utc),
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = false,
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
                Id = 16,
                Title = "Solo Leveling",
                Preface = "The story of Sung Jin-Woo, the weakest of all hunters.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = new DateTime(2024, 1, 29, 0, 0, 0, DateTimeKind.Utc),
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
                Id = 17,
                Title = "Dr. Stone",
                Preface = "A scientific genius rebuilds civilization after humanity is turned to stone.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 2, 5, 0, 0, 0, DateTimeKind.Utc),
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
                Id = 18,
                Title = "The Beginning After The End",
                Preface = "A king is reborn in a new world of magic and monsters.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 2, 12, 0, 0, 0, DateTimeKind.Utc),
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
                Id = 19,
                Title = "Tokyo Ghoul",
                Preface = "A college student becomes a half-ghoul after a chance encounter.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = new DateTime(2024, 2, 19, 0, 0, 0, DateTimeKind.Utc),
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
                Id = 20,
                Title = "The God of High School",
                Preface = "A martial arts tournament reveals supernatural powers.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 2, 26, 0, 0, 0, DateTimeKind.Utc),
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
                Id = 21,
                Title = "Hunter x Hunter",
                Preface = "A young boy seeks to become a Hunter and find his father.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 3, 4, 0, 0, 0, DateTimeKind.Utc),
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = false,
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
                Id = 22,
                Title = "Noblesse",
                Preface = "A powerful vampire awakens in modern times.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = new DateTime(2024, 3, 11, 0, 0, 0, DateTimeKind.Utc),
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
                Id = 23,
                Title = "Death Note",
                Preface = "A high school student discovers a notebook that can kill anyone.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = new DateTime(2024, 3, 18, 0, 0, 0, DateTimeKind.Utc),
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = true,
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
                Id = 24,
                Title = "Tales of Demons and Gods",
                Preface = "A powerful cultivator is reborn to change his fate.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 3, 25, 0, 0, 0, DateTimeKind.Utc),
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
                Id = 25,
                Title = "Bleach",
                Preface = "A teenager becomes a Soul Reaper to protect the living world.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = new DateTime(2024, 4, 1, 0, 0, 0, DateTimeKind.Utc),
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = false,
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
                Id = 26,
                Title = "The Legendary Moonlight Sculptor",
                Preface = "A skilled gamer becomes a legendary sculptor in a virtual world.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 4, 8, 0, 0, 0, DateTimeKind.Utc),
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
                Id = 27,
                Title = "Naruto",
                Preface = "A young ninja seeks to become the strongest and gain recognition.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = new DateTime(2024, 4, 15, 0, 0, 0, DateTimeKind.Utc),
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = false,
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
                Id = 28,
                Title = "The Gamer",
                Preface = "A high school student gains the ability to live life like a video game.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 4, 22, 0, 0, 0, DateTimeKind.Utc),
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
                Id = 29,
                Title = "Fullmetal Alchemist",
                Preface = "Two brothers seek to restore their bodies using alchemy.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = new DateTime(2024, 4, 29, 0, 0, 0, DateTimeKind.Utc),
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
                Id = 30,
                Title = "Tower of God",
                Preface = "Follow Bam as he climbs the mysterious Tower to find Rachel.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 5, 6, 0, 0, 0, DateTimeKind.Utc),
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
                Id = 31,
                Title = "Attack on Titan",
                Preface = "Humanity fights for survival against giant Titans.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = new DateTime(2024, 5, 13, 0, 0, 0, DateTimeKind.Utc),
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
                Id = 32,
                Title = "The Beginning After The End",
                Preface = "A king is reborn in a new world of magic and monsters.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 5, 20, 0, 0, 0, DateTimeKind.Utc),
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
                Id = 33,
                Title = "One Punch Man",
                Preface = "A hero who can defeat any opponent with a single punch.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 5, 27, 0, 0, 0, DateTimeKind.Utc),
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = false,
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
                Id = 34,
                Title = "Solo Leveling",
                Preface = "The story of Sung Jin-Woo, the weakest of all hunters.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = new DateTime(2024, 6, 3, 0, 0, 0, DateTimeKind.Utc),
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
                Id = 35,
                Title = "Demon Slayer",
                Preface = "A young boy fights demons to save his sister.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = new DateTime(2024, 6, 10, 0, 0, 0, DateTimeKind.Utc),
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = true,
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
                Id = 36,
                Title = "The God of High School",
                Preface = "A martial arts tournament reveals supernatural powers.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 6, 17, 0, 0, 0, DateTimeKind.Utc),
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
                Id = 37,
                Title = "Jujutsu Kaisen",
                Preface = "A boy fights against curses with the help of a powerful sorcerer.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 6, 24, 0, 0, 0, DateTimeKind.Utc), // Monday
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = true,
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
                Id = 38,
                Title = "The Legendary Moonlight Sculptor",
                Preface = "A skilled gamer becomes a legendary sculptor in a virtual world.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 7, 1, 0, 0, 0, DateTimeKind.Utc), // Monday
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
                Id = 39,
                Title = "My Hero Academia",
                Preface = "A world where 80% of the population has superpowers, and a boy without powers dreams of becoming a hero.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 7, 8, 0, 0, 0, DateTimeKind.Utc), // Monday
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = false,
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
                Id = 40,
                Title = "Tales of Demons and Gods",
                Preface = "A powerful cultivator is reborn to change his fate.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 7, 15, 0, 0, 0, DateTimeKind.Utc), // Monday
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
                Id = 41,
                Title = "Chainsaw Man",
                Preface = "A young man becomes a devil hunter after merging with his pet chainsaw devil.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 7, 22, 0, 0, 0, DateTimeKind.Utc), // Monday
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
                Id = 42,
                Title = "The Beginning After The End",
                Preface = "A king is reborn in a new world of magic and monsters.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 7, 29, 0, 0, 0, DateTimeKind.Utc), // Monday
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
                Id = 43,
                Title = "One Punch Man",
                Preface = "A hero who can defeat any opponent with a single punch.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 8, 5, 0, 0, 0, DateTimeKind.Utc), // Monday
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = false,
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
                Id = 44,
                Title = "Solo Leveling",
                Preface = "The story of Sung Jin-Woo, the weakest of all hunters.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = new DateTime(2024, 8, 12, 0, 0, 0, DateTimeKind.Utc), // Monday
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
                Id = 45,
                Title = "Demon Slayer",
                Preface = "A young boy fights demons to save his sister.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = new DateTime(2024, 8, 19, 0, 0, 0, DateTimeKind.Utc), // Monday
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = true,
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
                Id = 46,
                Title = "The God of High School",
                Preface = "A martial arts tournament reveals supernatural powers.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 8, 26, 0, 0, 0, DateTimeKind.Utc), // Monday
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
                Id = 47,
                Title = "Hunter x Hunter",
                Preface = "A young boy seeks to become a Hunter and find his father.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 9, 2, 0, 0, 0, DateTimeKind.Utc), // Monday
                CreatedBy = 1,
                ModifiedBy = 1,
                CoverImage = COVER_IMAGE_URL,
                HasAdult = false,
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
                Id = 48,
                Title = "Noblesse",
                Preface = "A powerful vampire awakens in modern times.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = new DateTime(2024, 9, 9, 0, 0, 0, DateTimeKind.Utc), // Monday
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
                Id = 49,
                Title = "Death Note",
                Preface = "A high school student discovers a notebook that can kill anyone.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.Completed,
                PublishedDate = new DateTime(2024, 9, 16, 0, 0, 0, DateTimeKind.Utc), // Monday
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
                Id = 50,
                Title = "Tales of Demons and Gods",
                Preface = "A powerful cultivator is reborn to change his fate.",
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                PublishedDate = new DateTime(2024, 9, 23, 0, 0, 0, DateTimeKind.Utc), // Monday
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

        // Seed MangaInteractions
        modelBuilder.Entity<MangaInteraction>().HasData(
            // User 1 interactions
            new MangaInteraction
            {
                Id = 1,
                UserId = 1, // Admin User
                MangaId = 1, // One Piece
                ChapterId = null,
                InteractionType = MangaInteractionType.Like,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new MangaInteraction
            {
                Id = 2,
                UserId = 1, // Admin User
                MangaId = null,
                ChapterId = 1, // One Piece Chapter 1
                InteractionType = MangaInteractionType.Read,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            
            // User 2 interactions
            new MangaInteraction
            {
                Id = 3,
                UserId = 2, // John Reader
                MangaId = 2, // Attack on Titan
                ChapterId = null,
                InteractionType = MangaInteractionType.Bookmark,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new MangaInteraction
            {
                Id = 4,
                UserId = 2, // John Reader
                MangaId = null,
                ChapterId = 4, // Solo Leveling Chapter 1
                InteractionType = MangaInteractionType.Read,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            
            // User 3 interactions
            new MangaInteraction
            {
                Id = 5,
                UserId = 3, // Jane Editor
                MangaId = 4, // Demon Slayer
                ChapterId = null,
                InteractionType = MangaInteractionType.Share,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new MangaInteraction
            {
                Id = 6,
                UserId = 3, // Jane Editor
                MangaId = null,
                ChapterId = 7, // Tower of God Chapter 1
                InteractionType = MangaInteractionType.Read,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            
            // User 4 interactions
            new MangaInteraction
            {
                Id = 7,
                UserId = 4, // Bob Publisher
                MangaId = 6, // My Hero Academia
                ChapterId = null,
                InteractionType = MangaInteractionType.Like,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new MangaInteraction
            {
                Id = 8,
                UserId = 4, // Bob Publisher
                MangaId = null,
                ChapterId = 13, // The Beginning After The End Chapter 1
                InteractionType = MangaInteractionType.Read,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            
            // User 5 interactions
            new MangaInteraction
            {
                Id = 9,
                UserId = 5, // Alice Artist
                MangaId = 8, // Jujutsu Kaisen
                ChapterId = null,
                InteractionType = MangaInteractionType.Bookmark,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new MangaInteraction
            {
                Id = 10,
                UserId = 5, // Alice Artist
                MangaId = null,
                ChapterId = 15, // The God of High School Chapter 1
                InteractionType = MangaInteractionType.Read,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            
            // User 6 interactions
            new MangaInteraction
            {
                Id = 11,
                UserId = 6, // Charlie Translator
                MangaId = 10, // Chainsaw Man
                ChapterId = null,
                InteractionType = MangaInteractionType.Share,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new MangaInteraction
            {
                Id = 12,
                UserId = 6, // Charlie Translator
                MangaId = null,
                ChapterId = 17, // Omniscient Reader Chapter 1
                InteractionType = MangaInteractionType.Read,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            
            // User 7 interactions
            new MangaInteraction
            {
                Id = 13,
                UserId = 7, // David SubAuthor
                MangaId = 3, // Solo Leveling
                ChapterId = null,
                InteractionType = MangaInteractionType.Like,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new MangaInteraction
            {
                Id = 14,
                UserId = 7, // David SubAuthor
                MangaId = null,
                ChapterId = 5, // Demon Slayer Chapter 1
                InteractionType = MangaInteractionType.Read,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            
            // User 8 interactions
            new MangaInteraction
            {
                Id = 15,
                UserId = 8, // Eve Reader
                MangaId = 5, // Tower of God
                ChapterId = null,
                InteractionType = MangaInteractionType.Bookmark,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new MangaInteraction
            {
                Id = 16,
                UserId = 8, // Eve Reader
                MangaId = null,
                ChapterId = 9, // My Hero Academia Chapter 1
                InteractionType = MangaInteractionType.Read,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            
            // User 9 interactions
            new MangaInteraction
            {
                Id = 17,
                UserId = 9, // Frank Reader
                MangaId = 7, // The Beginning After The End
                ChapterId = null,
                InteractionType = MangaInteractionType.Share,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new MangaInteraction
            {
                Id = 18,
                UserId = 9, // Frank Reader
                MangaId = null,
                ChapterId = 11, // Jujutsu Kaisen Chapter 1
                InteractionType = MangaInteractionType.Read,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            
            // User 10 interactions
            new MangaInteraction
            {
                Id = 19,
                UserId = 10, // Grace Reader
                MangaId = 9, // The God of High School
                ChapterId = null,
                InteractionType = MangaInteractionType.Like,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new MangaInteraction
            {
                Id = 20,
                UserId = 10, // Grace Reader
                MangaId = null,
                ChapterId = 13, // The God of High School Chapter 1
                InteractionType = MangaInteractionType.Read,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            
            // User 11 interactions
            new MangaInteraction
            {
                Id = 21,
                UserId = 11, // Henry Reader
                MangaId = 11, // Omniscient Reader
                ChapterId = null,
                InteractionType = MangaInteractionType.Bookmark,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new MangaInteraction
            {
                Id = 22,
                UserId = 11, // Henry Reader
                MangaId = null,
                ChapterId = 15, // Chainsaw Man Chapter 1
                InteractionType = MangaInteractionType.Read,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            
            // User 12 interactions
            new MangaInteraction
            {
                Id = 23,
                UserId = 12, // Irene Reader
                MangaId = 1, // One Piece
                ChapterId = null,
                InteractionType = MangaInteractionType.Share,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new MangaInteraction
            {
                Id = 24,
                UserId = 12, // Irene Reader
                MangaId = null,
                ChapterId = 3, // Attack on Titan Chapter 1
                InteractionType = MangaInteractionType.Read,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            }
        );

        // Seed Comments
        modelBuilder.Entity<Comment>().HasData(
            // One Piece Chapter 1 Comments
            new Comment
            {
                Id = 1,
                MangaId = 1,
                ChapterId = 1,
                UserId = 2,
                Content = "This chapter was amazing! Luffy's determination is inspiring.",
                IsSpoiler = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Comment
            {
                Id = 2,
                MangaId = 1,
                ChapterId = 1,
                UserId = 3,
                Content = "The art style is so unique and expressive!",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(1),
                UpdatedAt = SEED_DATE.AddHours(1)
            },
            new Comment
            {
                Id = 3,
                MangaId = 1,
                ChapterId = 1,
                UserId = 4,
                Content = "I can't wait to see how Luffy's journey unfolds!",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(2),
                UpdatedAt = SEED_DATE.AddHours(2)
            },
            // Attack on Titan Chapter 1 Comments
            new Comment
            {
                Id = 4,
                MangaId = 2,
                ChapterId = 3,
                UserId = 2,
                Content = "The tension in this chapter is incredible!",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(3),
                UpdatedAt = SEED_DATE.AddHours(3)
            },
            new Comment
            {
                Id = 5,
                MangaId = 2,
                ChapterId = 3,
                UserId = 3,
                Content = "Eren's determination reminds me of myself.",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(4),
                UpdatedAt = SEED_DATE.AddHours(4)
            },
            // Solo Leveling Chapter 1 Comments
            new Comment
            {
                Id = 6,
                MangaId = 3,
                ChapterId = 4,
                UserId = 4,
                Content = "The world-building is fascinating!",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(5),
                UpdatedAt = SEED_DATE.AddHours(5)
            },
            new Comment
            {
                Id = 7,
                MangaId = 3,
                ChapterId = 4,
                UserId = 5,
                Content = "Sung Jin-Woo's character development is going to be interesting.",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(6),
                UpdatedAt = SEED_DATE.AddHours(6)
            },
            // Demon Slayer Chapter 1 Comments
            new Comment
            {
                Id = 8,
                MangaId = 4,
                ChapterId = 5,
                UserId = 2,
                Content = "The emotional impact of this chapter is powerful.",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(7),
                UpdatedAt = SEED_DATE.AddHours(7)
            },
            new Comment
            {
                Id = 9,
                MangaId = 4,
                ChapterId = 5,
                UserId = 3,
                Content = "Tanjiro's dedication to his sister is touching.",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(8),
                UpdatedAt = SEED_DATE.AddHours(8)
            },
            // Tower of God Chapter 1 Comments
            new Comment
            {
                Id = 10,
                MangaId = 5,
                ChapterId = 7,
                UserId = 4,
                Content = "The mystery of the Tower is intriguing!",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(9),
                UpdatedAt = SEED_DATE.AddHours(9)
            },
            new Comment
            {
                Id = 11,
                MangaId = 5,
                ChapterId = 7,
                UserId = 5,
                Content = "Bam's innocence is refreshing in this world.",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(10),
                UpdatedAt = SEED_DATE.AddHours(10)
            },
            // My Hero Academia Chapter 1 Comments
            new Comment
            {
                Id = 12,
                MangaId = 6,
                ChapterId = 9,
                UserId = 2,
                Content = "All Might's influence on Izuku is inspiring!",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(11),
                UpdatedAt = SEED_DATE.AddHours(11)
            },
            new Comment
            {
                Id = 13,
                MangaId = 6,
                ChapterId = 9,
                UserId = 3,
                Content = "The concept of Quirks is so creative!",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(12),
                UpdatedAt = SEED_DATE.AddHours(12)
            },
            // The Beginning After The End Chapter 1 Comments
            new Comment
            {
                Id = 14,
                MangaId = 7,
                ChapterId = 10,
                UserId = 4,
                Content = "The reincarnation trope is handled well here.",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(13),
                UpdatedAt = SEED_DATE.AddHours(13)
            },
            new Comment
            {
                Id = 15,
                MangaId = 7,
                ChapterId = 10,
                UserId = 5,
                Content = "Arthur's past life adds depth to the story.",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(14),
                UpdatedAt = SEED_DATE.AddHours(14)
            },
            // Jujutsu Kaisen Chapter 1 Comments
            new Comment
            {
                Id = 16,
                MangaId = 8,
                ChapterId = 11,
                UserId = 2,
                Content = "The supernatural elements are well integrated.",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(15),
                UpdatedAt = SEED_DATE.AddHours(15)
            },
            new Comment
            {
                Id = 17,
                MangaId = 8,
                ChapterId = 11,
                UserId = 3,
                Content = "Yuji's character design is striking!",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(16),
                UpdatedAt = SEED_DATE.AddHours(16)
            },
            // The God of High School Chapter 1 Comments
            new Comment
            {
                Id = 18,
                MangaId = 9,
                ChapterId = 12,
                UserId = 4,
                Content = "The martial arts scenes are dynamic!",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(17),
                UpdatedAt = SEED_DATE.AddHours(17)
            },
            new Comment
            {
                Id = 19,
                MangaId = 9,
                ChapterId = 12,
                UserId = 5,
                Content = "Jin Mori's fighting style is unique.",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(18),
                UpdatedAt = SEED_DATE.AddHours(18)
            },
            // Chainsaw Man Chapter 1 Comments
            new Comment
            {
                Id = 20,
                MangaId = 10,
                ChapterId = 13,
                UserId = 2,
                Content = "The dark humor is perfectly balanced.",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(19),
                UpdatedAt = SEED_DATE.AddHours(19)
            },
            new Comment
            {
                Id = 21,
                MangaId = 10,
                ChapterId = 13,
                UserId = 3,
                Content = "Denji's motivation is surprisingly deep.",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(20),
                UpdatedAt = SEED_DATE.AddHours(20)
            },
            // Omniscient Reader Chapter 1 Comments
            new Comment
            {
                Id = 22,
                MangaId = 11,
                ChapterId = 14,
                UserId = 4,
                Content = "The meta-narrative is fascinating!",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(21),
                UpdatedAt = SEED_DATE.AddHours(21)
            },
            new Comment
            {
                Id = 23,
                MangaId = 11,
                ChapterId = 14,
                UserId = 5,
                Content = "Kim Dokja's knowledge adds an interesting twist.",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(22),
                UpdatedAt = SEED_DATE.AddHours(22)
            },
            // Dragon Ball Super Chapter 1 Comments
            new Comment
            {
                Id = 24,
                MangaId = 12,
                ChapterId = 15,
                UserId = 2,
                Content = "The action scenes are as epic as ever!",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(23),
                UpdatedAt = SEED_DATE.AddHours(23)
            },
            new Comment
            {
                Id = 25,
                MangaId = 12,
                ChapterId = 15,
                UserId = 3,
                Content = "Goku's personality never changes, and I love it!",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(24),
                UpdatedAt = SEED_DATE.AddHours(24)
            },
            // The Promised Neverland Chapter 1 Comments
            new Comment
            {
                Id = 26,
                MangaId = 13,
                ChapterId = 16,
                UserId = 4,
                Content = "The psychological thriller elements are masterful.",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(25),
                UpdatedAt = SEED_DATE.AddHours(25)
            },
            new Comment
            {
                Id = 27,
                MangaId = 13,
                ChapterId = 16,
                UserId = 5,
                Content = "Emma's innocence makes the story more impactful.",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(26),
                UpdatedAt = SEED_DATE.AddHours(26)
            },
            // Black Clover Chapter 1 Comments
            new Comment
            {
                Id = 28,
                MangaId = 15,
                ChapterId = 17,
                UserId = 2,
                Content = "Asta's determination despite having no magic is inspiring!",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(27),
                UpdatedAt = SEED_DATE.AddHours(27)
            },
            new Comment
            {
                Id = 29,
                MangaId = 15,
                ChapterId = 17,
                UserId = 3,
                Content = "The magic system is well thought out.",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(28),
                UpdatedAt = SEED_DATE.AddHours(28)
            },
            // Dr. Stone Chapter 1 Comments
            new Comment
            {
                Id = 30,
                MangaId = 17,
                ChapterId = 18,
                UserId = 4,
                Content = "The scientific approach to rebuilding civilization is unique!",
                IsSpoiler = false,
                CreatedAt = SEED_DATE.AddHours(29),
                UpdatedAt = SEED_DATE.AddHours(29)
            }
        );
    }
} 