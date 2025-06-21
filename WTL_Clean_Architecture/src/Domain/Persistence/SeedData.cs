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
                Id = "1a2b3c4d-5e6f-7g8h-9i0j-1k2l3m4n5o6p",
                Name = "Admin",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Role
            {
                Id = "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                Name = "Reader",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Role
            {
                Id = "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
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
                Id = "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s",
                Name = "Action",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Genere
            {
                Id = "5e6f7g8h-9i0j-1k2l-3m4n-5o6p7q8r9s0t",
                Name = "Adventure",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Genere
            {
                Id = "6f7g8h9i-0j1k-2l3m-4n5o-6p7q8r9s0t1u",
                Name = "Comedy",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Genere
            {
                Id = "7g8h9i0j-1k2l-3m4n-5o6p-7q8r9s0t1u2v",
                Name = "Drama",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Genere
            {
                Id = "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w",
                Name = "Fantasy",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Genere
            {
                Id = "9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x",
                Name = "Horror",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Genere
            {
                Id = "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y",
                Name = "Romance",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Genere
            {
                Id = "1k2l3m4n-5o6p-7q8r-9s0t-1u2v3w4x5y6z",
                Name = "Sci-Fi",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Genere
            {
                Id = "2l3m4n5o-6p7q-8r9s-0t1u-2v3w4x5y6z7a8b",
                Name = "Mystery",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Genere
            {
                Id = "3m4n5o6p-7q8r-9s0t-1u2v-3w4x5y6z7a8b9c",
                Name = "Thriller",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Genere
            {
                Id = "4n5o6p7q-8r9s-0t1u-2v3w-4x5y6z7a8b9c0d",
                Name = "Slice of Life",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Genere
            {
                Id = "5o6p7q8r-9s0t-1u2v-3w4x-5y6z7a8b9c0d1e",
                Name = "Sports",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Genere
            {
                Id = "6p7q8r9s-0t1u-2v3w-4x5y-6z7a8b9c0d1e2f",
                Name = "Supernatural",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Genere
            {
                Id = "7q8r9s0t-1u2v-3w4x-5y6z-7a8b9c0d1e2f3g",
                Name = "Psychological",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Genere
            {
                Id = "8r9s0t1u-2v3w-4x5y-6z7a-8b9c0d1e2f3g4h",
                Name = "Martial Arts",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Genere
            {
                Id = "9s0t1u2v-3w4x-5y6z-7a8b-9c0d1e2f3g4h5i",
                Name = "School Life",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Genere
            {
                Id = "0t1u2v3w-4x5y-6z7a-8b9c-0d1e2f3g4h5i6j",
                Name = "Music",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Genere
            {
                Id = "1u2v3w4x-5y6z-7a8b-9c0d-1e2f3g4h5i6j7k",
                Name = "Cooking",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Genere
            {
                Id = "2v3w4x5y-6z7a-8b9c-0d1e-2f3g4h5i6j7k8l",
                Name = "Historical",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Genere
            {
                Id = "3w4x5y6z-7a8b-9c0d-1e2f-3g4h5i6j7k8l9m",
                Name = "Military",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            }
        );

        // Seed Users
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n",
                FullName = "Phuc Lo",
                Email = "phuc123@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = "1a2b3c4d-5e6f-7g8h-9i0j-1k2l3m4n5o6p",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "male",
                PhoneNumber = "0912345678",
                Address = "123 Le Duan Street, District 1, Ho Chi Minh City"
            },
            new User
            {
                Id = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o",
                FullName = "Sarah Johnson",
                Email = "sarah.johnson@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "female",
                PhoneNumber = "0987654321",
                Address = "45 Tran Hung Dao Street, Hai Ba Trung District, Hanoi"
            },
            new User
            {
                Id = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p",
                FullName = "Michael Chen",
                Email = "michael.chen@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "male",
                PhoneNumber = "0978123456",
                Address = "78 Nguyen Thi Minh Khai Street, Da Nang City"
            },
            new User
            {
                Id = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q",
                FullName = "Emma Wilson",
                Email = "emma.wilson@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "female",
                PhoneNumber = "0965432109",
                Address = "156 Le Loi Street, Hue City, Thua Thien Hue Province"
            },
            new User
            {
                Id = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r",
                FullName = "Alex Rivera",
                Email = "alex.rivera@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "others",
                PhoneNumber = "0956789012",
                Address = "234 Tran Phu Street, Nha Trang City, Khanh Hoa Province"
            },
            new User
            {
                Id = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s",
                FullName = "Hiroshi Tanaka",
                Email = "hiroshi.tanaka@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "male",
                PhoneNumber = "0945678901",
                Address = "89 Ly Thai To Street, Can Tho City"
            },
            new User
            {
                Id = "0d1e2f3g-4h5i-6j7k-8l9m-0n1o2p3q4r5s6t",
                FullName = "Yuki Sato",
                Email = "yuki.sato@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "female",
                PhoneNumber = "0934567890",
                Address = "67 Nguyen Van Linh Street, Vung Tau City, Ba Ria-Vung Tau Province"
            },
            new User
            {
                Id = "1e2f3g4h-5i6j-7k8l-9m0n-1o2p3q4r5s6t7u",
                FullName = "David Kim",
                Email = "david.kim@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "male",
                PhoneNumber = "0923456789",
                Address = "123 Quang Trung Street, Hai Phong City"
            },
            new User
            {
                Id = "2f3g4h5i-6j7k-8l9m-0n1o-2p3q4r5s6t7u8v",
                FullName = "Lisa Park",
                Email = "lisa.park@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "female",
                PhoneNumber = "0912345678",
                Address = "45 Le Duan Street, Bien Hoa City, Dong Nai Province"
            },
            new User
            {
                Id = "3g4h5i6j-7k8l-9m0n-1o2p-3q4r5s6t7u8v9w",
                FullName = "James Wilson",
                Email = "james.wilson@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "male",
                PhoneNumber = "0901234567",
                Address = "78 Tran Hung Dao Street, Thai Nguyen City, Thai Nguyen Province"
            },
            new User
            {
                Id = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x",
                FullName = "Maria Garcia",
                Email = "maria.garcia@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "female",
                PhoneNumber = "0890123456",
                Address = "156 Nguyen Trai Street, Nam Dinh City, Nam Dinh Province"
            },
            new User
            {
                Id = "5i6j7k8l-9m0n-1o2p-3q4r-5s6t7u8v9w0x1y",
                FullName = "Taylor Smith",
                Email = "taylor.smith@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "others",
                PhoneNumber = "0889012345",
                Address = "234 Le Hong Phong Street, Quy Nhon City, Binh Dinh Province"
            },
            new User
            {
                Id = "6j7k8l9m-0n1o-2p3q-4r5s-6t7u8v9w0x1y2z",
                FullName = "Wei Chen",
                Email = "wei.chen@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "male",
                PhoneNumber = "0878901234",
                Address = "67 Phan Chu Trinh Street, Pleiku City, Gia Lai Province"
            },
            new User
            {
                Id = "7k8l9m0n-1o2p-3q4r-5s6t-7u8v9w0x1y2z3a",
                FullName = "Sofia Rodriguez",
                Email = "sofia.rodriguez@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                Gender = "female",
                PhoneNumber = "0867890123",
                Address = "89 Nguyen Van Cu Street, Long Xuyen City, An Giang Province"
            },
            new User
            {
                Id = "8l9m0n1o-2p3q-4r5s-6t7u-8v9w0x1y2z3a4b",
                FullName = "Jordan Lee",
                Email = "jordan.lee@gmail.com",
                PasswordHash = "nld7cvF70f2JNhIOie8Wy1/VZza04zDXmZ8BtGjFBBE=",
                SecurityStamp = "d6a69959-ab31-4653-a52d-299e0174503e",
                RoleId = "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
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
            // Admin User Auth Methods
            new AuthMethod
            {
                Id = "a1b2c3d4-e5f6-7g8h-9i0j-1k2l3m4n5o6p",
                UserId = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n", // Admin User
                AuthType = "Email",
                AuthId = "admin@webtruyenlo.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new AuthMethod
            {
                Id = "b2c3d4e5-f6g7-8h9i-0j1k-2l3m4n5o6p7q",
                UserId = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n", // Admin User
                AuthType = "Google",
                AuthId = "admin.webtruyenlo@gmail.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },

            // Editor User Auth Methods
            new AuthMethod
            {
                Id = "c3d4e5f6-g7h8-9i0j-1k2l-3m4n5o6p7q8r",
                UserId = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o", // Editor User
                AuthType = "Email",
                AuthId = "editor@webtruyenlo.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new AuthMethod
            {
                Id = "d4e5f6g7-h8i9-0j1k-2l3m-4n5o6p7q8r9s",
                UserId = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o", // Editor User
                AuthType = "Google",
                AuthId = "editor.webtruyenlo@gmail.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },

            // Translator User Auth Methods
            new AuthMethod
            {
                Id = "e5f6g7h8-i9j0-1k2l-3m4n-5o6p7q8r9s0t",
                UserId = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p", // Translator User
                AuthType = "Email",
                AuthId = "translator@webtruyenlo.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new AuthMethod
            {
                Id = "f6g7h8i9-j0k1-2l3m-4n5o-6p7q8r9s0t1u",
                UserId = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p", // Translator User
                AuthType = "Google",
                AuthId = "translator.webtruyenlo@gmail.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },

            // Artist User Auth Methods
            new AuthMethod
            {
                Id = "g7h8i9j0-k1l2-3m4n-5o6p-7q8r9s0t1u2v",
                UserId = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q", // Artist User
                AuthType = "Email",
                AuthId = "artist@webtruyenlo.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new AuthMethod
            {
                Id = "h8i9j0k1-l2m3-4n5o-6p7q-8r9s0t1u2v3w",
                UserId = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q", // Artist User
                AuthType = "Google",
                AuthId = "artist.webtruyenlo@gmail.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },

            // Publisher User Auth Methods
            new AuthMethod
            {
                Id = "i9j0k1l2-m3n4-5o6p-7q8r-9s0t1u2v3w4x",
                UserId = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r", // Publisher User
                AuthType = "Email",
                AuthId = "publisher@webtruyenlo.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new AuthMethod
            {
                Id = "j0k1l2m3-n4o5-6p7q-8r9s-0t1u2v3w4x5y",
                UserId = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r", // Publisher User
                AuthType = "Google",
                AuthId = "publisher.webtruyenlo@gmail.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },

            // Reader User Auth Methods
            new AuthMethod
            {
                Id = "k1l2m3n4-o5p6-7q8r-9s0t-1u2v3w4x5y6z",
                UserId = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s", // Reader User
                AuthType = "Email",
                AuthId = "reader@webtruyenlo.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new AuthMethod
            {
                Id = "l2m3n4o5-p6q7-8r9s-0t1u-2v3w4x5y6z7a",
                UserId = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s", // Reader User
                AuthType = "Google",
                AuthId = "reader.webtruyenlo@gmail.com",
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            }
        );

        // Seed Manga
        modelBuilder.Entity<Manga>().HasData(
            // Week 1 - Monday
            new Manga
            {
                Id = "m1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                Title = "The Last Samurai's Legacy",
                PublishedDate = new DateTime(2024, 1, 1, 9, 0, 0, DateTimeKind.Utc), // Monday
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                Preface = "A tale of honor and tradition",
                HasAdult = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n", // Phuc Lo
                SubAuthor = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o", // Sarah Johnson
                Publishor = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p", // Michael Chen
                Artist = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q", // Emma Wilson
                Translator = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r", // Alex Rivera
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 1 - Tuesday
            new Manga
            {
                Id = "m2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p",
                Title = "Cyberpunk Dreams",
                PublishedDate = new DateTime(2024, 1, 2, 9, 0, 0, DateTimeKind.Utc), // Tuesday
                Format = MangaFormat.Novel,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.ComingSoon,
                Preface = "A futuristic tale of technology and humanity",
                HasAdult = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s", // Hiroshi Tanaka
                SubAuthor = "0d1e2f3g-4h5i-6j7k-8l9m-0n1o2p3q4r5s6t", // Yuki Sato
                Publishor = "1e2f3g4h-5i6j-7k8l-9m0n-1o2p3q4r5s6t7u", // David Kim
                Artist = "2f3g4h5i-6j7k-8l9m-0n1o-2p3q4r5s6t7u8v", // Lisa Park
                Translator = "3g4h5i6j-7k8l-9m0n-1o2p-3q4r5s6t7u8v9w", // James Wilson
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 1 - Wednesday
            new Manga
            {
                Id = "m3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                Title = "Magical Academy",
                PublishedDate = new DateTime(2024, 1, 3, 9, 0, 0, DateTimeKind.Utc), // Wednesday
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Vietnam,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                Preface = "A school for young wizards and witches",
                HasAdult = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x", // Maria Garcia
                SubAuthor = "5i6j7k8l-9m0n-1o2p-3q4r-5s6t7u8v9w0x1y", // Taylor Smith
                Publishor = "6j7k8l9m-0n1o-2p3q-4r5s-6t7u8v9w0x1y2z", // Wei Chen
                Artist = "7k8l9m0n-1o2p-3q4r-5s6t-7u8v9w0x1y2z3a", // Sofia Rodriguez
                Translator = "8l9m0n1o-2p3q-4r5s-6t7u-8v9w0x1y2z3a4b", // Jordan Lee
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 1 - Thursday
            new Manga
            {
                Id = "m4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                Title = "The Detective's Case",
                PublishedDate = new DateTime(2024, 1, 4, 9, 0, 0, DateTimeKind.Utc), // Thursday
                Format = MangaFormat.Novel,
                Region = MangaRegion.China,
                ReleaseStatus = MangaReleaseStatus.ComingSoon,
                Preface = "Solving mysteries in the city",
                HasAdult = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n", // Phuc Lo
                SubAuthor = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o", // Sarah Johnson
                Publishor = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p", // Michael Chen
                Artist = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q", // Emma Wilson
                Translator = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r", // Alex Rivera
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 1 - Friday
            new Manga
            {
                Id = "m5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                Title = "The Sports Star",
                PublishedDate = new DateTime(2024, 1, 5, 9, 0, 0, DateTimeKind.Utc), // Friday
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                Preface = "A journey to become a professional athlete",
                HasAdult = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s", // Hiroshi Tanaka
                SubAuthor = "0d1e2f3g-4h5i-6j7k-8l9m-0n1o2p3q4r5s6t", // Yuki Sato
                Publishor = "1e2f3g4h-5i6j-7k8l-9m0n-1o2p3q4r5s6t7u", // David Kim
                Artist = "2f3g4h5i-6j7k-8l9m-0n1o-2p3q4r5s6t7u8v", // Lisa Park
                Translator = "3g4h5i6j-7k8l-9m0n-1o2p-3q4r5s6t7u8v9w", // James Wilson
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 1 - Saturday
            new Manga
            {
                Id = "m6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                Title = "The Cooking Master",
                PublishedDate = new DateTime(2024, 1, 6, 9, 0, 0, DateTimeKind.Utc), // Saturday
                Format = MangaFormat.Novel,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.Completed,
                Preface = "A culinary journey through Japan",
                HasAdult = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x", // Maria Garcia
                SubAuthor = "5i6j7k8l-9m0n-1o2p-3q4r-5s6t7u8v9w0x1y", // Taylor Smith
                Publishor = "6j7k8l9m-0n1o-2p3q-4r5s-6t7u8v9w0x1y2z", // Wei Chen
                Artist = "7k8l9m0n-1o2p-3q4r-5s6t-7u8v9w0x1y2z3a", // Sofia Rodriguez
                Translator = "8l9m0n1o-2p3q-4r5s-6t7u-8v9w0x1y2z3a4b", // Jordan Lee
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 1 - Sunday
            new Manga
            {
                Id = "m7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                Title = "Starlight Academy",
                PublishedDate = new DateTime(2024, 1, 7, 9, 0, 0, DateTimeKind.Utc), // Sunday
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Vietnam,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                Preface = "A magical school life story",
                HasAdult = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n", // Phuc Lo
                SubAuthor = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o", // Sarah Johnson
                Publishor = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p", // Michael Chen
                Artist = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q", // Emma Wilson
                Translator = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r", // Alex Rivera
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 2 - Monday
            new Manga
            {
                Id = "m8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                Title = "The Last Hero",
                PublishedDate = new DateTime(2024, 1, 8, 9, 0, 0, DateTimeKind.Utc), // Monday
                Format = MangaFormat.Novel,
                Region = MangaRegion.China,
                ReleaseStatus = MangaReleaseStatus.ComingSoon,
                Preface = "A superhero story with a twist",
                HasAdult = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s", // Hiroshi Tanaka
                SubAuthor = "0d1e2f3g-4h5i-6j7k-8l9m-0n1o2p3q4r5s6t", // Yuki Sato
                Publishor = "1e2f3g4h-5i6j-7k8l-9m0n-1o2p3q4r5s6t7u", // David Kim
                Artist = "2f3g4h5i-6j7k-8l9m-0n1o-2p3q4r5s6t7u8v", // Lisa Park
                Translator = "3g4h5i6j-7k8l-9m0n-1o2p-3q4r5s6t7u8v9w", // James Wilson
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 2 - Tuesday
            new Manga
            {
                Id = "m9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                Title = "The Cooking Master",
                PublishedDate = new DateTime(2024, 1, 9, 9, 0, 0, DateTimeKind.Utc), // Tuesday
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                Preface = "A culinary journey through Japan",
                HasAdult = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n", // Phuc Lo
                SubAuthor = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o", // Sarah Johnson
                Publishor = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p", // Michael Chen
                Artist = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q", // Emma Wilson
                Translator = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r", // Alex Rivera
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 2 - Wednesday
            new Manga
            {
                Id = "m0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                Title = "The Music Prodigy",
                PublishedDate = new DateTime(2024, 1, 10, 9, 0, 0, DateTimeKind.Utc), // Wednesday
                Format = MangaFormat.Novel,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                Preface = "A young musician's journey to stardom",
                HasAdult = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s", // Hiroshi Tanaka
                SubAuthor = "0d1e2f3g-4h5i-6j7k-8l9m-0n1o2p3q4r5s6t", // Yuki Sato
                Publishor = "1e2f3g4h-5i6j-7k8l-9m0n-1o2p3q4r5s6t7u", // David Kim
                Artist = "2f3g4h5i-6j7k-8l9m-0n1o-2p3q4r5s6t7u8v", // Lisa Park
                Translator = "3g4h5i6j-7k8l-9m0n-1o2p-3q4r5s6t7u8v9w", // James Wilson
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 2 - Thursday
            new Manga
            {
                Id = "m1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y",
                Title = "The Martial Arts Master",
                PublishedDate = new DateTime(2024, 1, 11, 9, 0, 0, DateTimeKind.Utc), // Thursday
                Format = MangaFormat.WebToon,
                Region = MangaRegion.China,
                ReleaseStatus = MangaReleaseStatus.ComingSoon,
                Preface = "A journey through ancient martial arts",
                HasAdult = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x", // Maria Garcia
                SubAuthor = "5i6j7k8l-9m0n-1o2p-3q4r-5s6t7u8v9w0x1y", // Taylor Smith
                Publishor = "6j7k8l9m-0n1o-2p3q-4r5s-6t7u8v9w0x1y2z", // Wei Chen
                Artist = "7k8l9m0n-1o2p-3q4r-5s6t-7u8v9w0x1y2z3a", // Sofia Rodriguez
                Translator = "8l9m0n1o-2p3q-4r5s-6t7u-8v9w0x1y2z3a4b", // Jordan Lee
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 2 - Friday
            new Manga
            {
                Id = "m2l3m4n6-o6p7-8q9r-0s1t-2u3v4w5x6y7z",
                Title = "The Psychological Thriller",
                PublishedDate = new DateTime(2024, 1, 12, 9, 0, 0, DateTimeKind.Utc), // Friday
                Format = MangaFormat.Novel,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                Preface = "A mind-bending psychological journey",
                HasAdult = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n", // Phuc Lo
                SubAuthor = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o", // Sarah Johnson
                Publishor = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p", // Michael Chen
                Artist = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q", // Emma Wilson
                Translator = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r", // Alex Rivera
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 2 - Saturday
            new Manga
            {
                Id = "m3m4n5o7-p7q8-9r0s-1t2u-3v4w5x6y7z8a",
                Title = "The Military Academy",
                PublishedDate = new DateTime(2024, 1, 13, 9, 0, 0, DateTimeKind.Utc), // Saturday
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.ComingSoon,
                Preface = "Life in a prestigious military academy",
                HasAdult = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s", // Hiroshi Tanaka
                SubAuthor = "0d1e2f3g-4h5i-6j7k-8l9m-0n1o2p3q4r5s6t", // Yuki Sato
                Publishor = "1e2f3g4h-5i6j-7k8l-9m0n-1o2p3q4r5s6t7u", // David Kim
                Artist = "2f3g4h5i-6j7k-8l9m-0n1o-2p3q4r5s6t7u8v", // Lisa Park
                Translator = "3g4h5i6j-7k8l-9m0n-1o2p-3q4r5s6t7u8v9w", // James Wilson
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 2 - Sunday
            new Manga
            {
                Id = "m4n5o6p7-q8r9-0s1t-2u3v-4w5x6y7z8a9b",
                Title = "The Supernatural Detective",
                PublishedDate = new DateTime(2024, 1, 14, 9, 0, 0, DateTimeKind.Utc), // Sunday
                Format = MangaFormat.Novel,
                Region = MangaRegion.Vietnam,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                Preface = "Solving supernatural mysteries",
                HasAdult = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x", // Maria Garcia
                SubAuthor = "5i6j7k8l-9m0n-1o2p-3q4r-5s6t7u8v9w0x1y", // Taylor Smith
                Publishor = "6j7k8l9m-0n1o-2p3q-4r5s-6t7u8v9w0x1y2z", // Wei Chen
                Artist = "7k8l9m0n-1o2p-3q4r-5s6t-7u8v9w0x1y2z3a", // Sofia Rodriguez
                Translator = "8l9m0n1o-2p3q-4r5s-6t7u-8v9w0x1y2z3a4b", // Jordan Lee
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 3 - Monday
            new Manga
            {
                Id = "m5o6p7q8-r9s0-1t2u-3v4w-5x6y7z8a9b0c",
                Title = "The Historical Romance",
                PublishedDate = new DateTime(2024, 1, 15, 9, 0, 0, DateTimeKind.Utc), // Monday
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.ComingSoon,
                Preface = "A love story set in ancient times",
                HasAdult = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n", // Phuc Lo
                SubAuthor = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o", // Sarah Johnson
                Publishor = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p", // Michael Chen
                Artist = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q", // Emma Wilson
                Translator = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r", // Alex Rivera
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 3 - Tuesday
            new Manga
            {
                Id = "m6p7q8r9-s0t1-2u3v-4w5x-6y7z8a9b0c1d",
                Title = "The Horror Mansion",
                PublishedDate = new DateTime(2024, 1, 16, 9, 0, 0, DateTimeKind.Utc), // Tuesday
                Format = MangaFormat.Novel,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                Preface = "A terrifying journey through a haunted mansion",
                HasAdult = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s", // Hiroshi Tanaka
                SubAuthor = "0d1e2f3g-4h5i-6j7k-8l9m-0n1o2p3q4r5s6t", // Yuki Sato
                Publishor = "1e2f3g4h-5i6j-7k8l-9m0n-1o2p3q4r5s6t7u", // David Kim
                Artist = "2f3g4h5i-6j7k-8l9m-0n1o-2p3q4r5s6t7u8v", // Lisa Park
                Translator = "3g4h5i6j-7k8l-9m0n-1o2p-3q4r5s6t7u8v9w", // James Wilson
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 3 - Wednesday
            new Manga
            {
                Id = "m7q8r9s0-t1u2-3v4w-5x6y-7z8a9b0c1d2e",
                Title = "The Adventure Quest",
                PublishedDate = new DateTime(2024, 1, 17, 9, 0, 0, DateTimeKind.Utc), // Wednesday
                Format = MangaFormat.WebToon,
                Region = MangaRegion.China,
                ReleaseStatus = MangaReleaseStatus.ComingSoon,
                Preface = "An epic adventure in a fantasy world",
                HasAdult = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x", // Maria Garcia
                SubAuthor = "5i6j7k8l-9m0n-1o2p-3q4r-5s6t7u8v9w0x1y", // Taylor Smith
                Publishor = "6j7k8l9m-0n1o-2p3q-4r5s-6t7u8v9w0x1y2z", // Wei Chen
                Artist = "7k8l9m0n-1o2p-3q4r-5s6t-7u8v9w0x1y2z3a", // Sofia Rodriguez
                Translator = "8l9m0n1o-2p3q-4r5s-6t7u-8v9w0x1y2z3a4b", // Jordan Lee
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 3 - Thursday
            new Manga
            {
                Id = "m8r9s0t1-u2v3-4w5x-6y7z-8a9b0c1d2e3f",
                Title = "The Comedy Club",
                PublishedDate = new DateTime(2024, 1, 18, 9, 0, 0, DateTimeKind.Utc), // Thursday
                Format = MangaFormat.Novel,
                Region = MangaRegion.Vietnam,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                Preface = "Laughs and life lessons in a comedy club",
                HasAdult = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n", // Phuc Lo
                SubAuthor = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o", // Sarah Johnson
                Publishor = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p", // Michael Chen
                Artist = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q", // Emma Wilson
                Translator = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r", // Alex Rivera
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 3 - Friday
            new Manga
            {
                Id = "m9s0t1u2-v3w4-5x6y-7z8a-9b0c1d2e3f4g",
                Title = "The Drama Queen",
                PublishedDate = new DateTime(2024, 1, 19, 9, 0, 0, DateTimeKind.Utc), // Friday
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.ComingSoon,
                Preface = "A story of love, betrayal, and redemption",
                HasAdult = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s", // Hiroshi Tanaka
                SubAuthor = "0d1e2f3g-4h5i-6j7k-8l9m-0n1o2p3q4r5s6t", // Yuki Sato
                Publishor = "1e2f3g4h-5i6j-7k8l-9m0n-1o2p3q4r5s6t7u", // David Kim
                Artist = "2f3g4h5i-6j7k-8l9m-0n1o-2p3q4r5s6t7u8v", // Lisa Park
                Translator = "3g4h5i6j-7k8l-9m0n-1o2p-3q4r5s6t7u8v9w", // James Wilson
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 3 - Saturday
            new Manga
            {
                Id = "m0t1u2v3-w4x5-6y7z-8a9b-0c1d2e3f4g5h",
                Title = "The Sports Tournament",
                PublishedDate = new DateTime(2024, 1, 20, 9, 0, 0, DateTimeKind.Utc), // Saturday
                Format = MangaFormat.Novel,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                Preface = "A high-stakes sports competition story",
                HasAdult = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x", // Maria Garcia
                SubAuthor = "5i6j7k8l-9m0n-1o2p-3q4r-5s6t7u8v9w0x1y", // Taylor Smith
                Publishor = "6j7k8l9m-0n1o-2p3q-4r5s-6t7u8v9w0x1y2z", // Wei Chen
                Artist = "7k8l9m0n-1o2p-3q4r-5s6t-7u8v9w0x1y2z3a", // Sofia Rodriguez
                Translator = "8l9m0n1o-2p3q-4r5s-6t7u-8v9w0x1y2z3a4b", // Jordan Lee
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 3 - Sunday
            new Manga
            {
                Id = "m1u2v3w4-x5y6-7z8a-9b0c-1d2e3f4g5h6i",
                Title = "The Mystery Box",
                PublishedDate = new DateTime(2024, 1, 21, 9, 0, 0, DateTimeKind.Utc), // Sunday
                Format = MangaFormat.WebToon,
                Region = MangaRegion.China,
                ReleaseStatus = MangaReleaseStatus.ComingSoon,
                Preface = "Unraveling the secrets of a mysterious box",
                HasAdult = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n", // Phuc Lo
                SubAuthor = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o", // Sarah Johnson
                Publishor = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p", // Michael Chen
                Artist = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q", // Emma Wilson
                Translator = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r", // Alex Rivera
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 4 - Monday
            new Manga
            {
                Id = "m2v3w4x5-y6z7-8a9b-0c1d-2e3f4g5h6i7j",
                Title = "The Fantasy Kingdom",
                PublishedDate = new DateTime(2024, 1, 22, 9, 0, 0, DateTimeKind.Utc), // Monday
                Format = MangaFormat.Novel,
                Region = MangaRegion.Vietnam,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                Preface = "A magical kingdom's rise and fall",
                HasAdult = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s", // Hiroshi Tanaka
                SubAuthor = "0d1e2f3g-4h5i-6j7k-8l9m-0n1o2p3q4r5s6t", // Yuki Sato
                Publishor = "1e2f3g4h-5i6j-7k8l-9m0n-1o2p3q4r5s6t7u", // David Kim
                Artist = "2f3g4h5i-6j7k-8l9m-0n1o-2p3q4r5s6t7u8v", // Lisa Park
                Translator = "3g4h5i6j-7k8l-9m0n-1o2p-3q4r5s6t7u8v9w", // James Wilson
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 4 - Tuesday
            new Manga
            {
                Id = "m3w4x5y6-z7a8-9b0c-1d2e-3f4g5h6i7j8k",
                Title = "The School Festival",
                PublishedDate = new DateTime(2024, 1, 23, 9, 0, 0, DateTimeKind.Utc), // Tuesday
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.ComingSoon,
                Preface = "A memorable school festival experience",
                HasAdult = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x", // Maria Garcia
                SubAuthor = "5i6j7k8l-9m0n-1o2p-3q4r-5s6t7u8v9w0x1y", // Taylor Smith
                Publishor = "6j7k8l9m-0n1o-2p3q-4r5s-6t7u8v9w0x1y2z", // Wei Chen
                Artist = "7k8l9m0n-1o2p-3q4r-5s6t-7u8v9w0x1y2z3a", // Sofia Rodriguez
                Translator = "8l9m0n1o-2p3q-4r5s-6t7u-8v9w0x1y2z3a4b", // Jordan Lee
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 4 - Wednesday
            new Manga
            {
                Id = "m4x5y6z7-a8b9-0c1d-2e3f-4g5h6i7j8k9l",
                Title = "The Cooking Competition",
                PublishedDate = new DateTime(2024, 1, 24, 9, 0, 0, DateTimeKind.Utc), // Wednesday
                Format = MangaFormat.Novel,
                Region = MangaRegion.Korea,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                Preface = "A culinary battle of skills and passion",
                HasAdult = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n", // Phuc Lo
                SubAuthor = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o", // Sarah Johnson
                Publishor = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p", // Michael Chen
                Artist = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q", // Emma Wilson
                Translator = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r", // Alex Rivera
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 4 - Thursday
            new Manga
            {
                Id = "m5y6z7a8-b9c0-1d2e-3f4g-5h6i7j8k9l0m",
                Title = "The Martial Arts Tournament",
                PublishedDate = new DateTime(2024, 1, 25, 9, 0, 0, DateTimeKind.Utc), // Thursday
                Format = MangaFormat.WebToon,
                Region = MangaRegion.China,
                ReleaseStatus = MangaReleaseStatus.ComingSoon,
                Preface = "A tournament of martial arts masters",
                HasAdult = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s", // Hiroshi Tanaka
                SubAuthor = "0d1e2f3g-4h5i-6j7k-8l9m-0n1o2p3q4r5s6t", // Yuki Sato
                Publishor = "1e2f3g4h-5i6j-7k8l-9m0n-1o2p3q4r5s6t7u", // David Kim
                Artist = "2f3g4h5i-6j7k-8l9m-0n1o-2p3q4r5s6t7u8v", // Lisa Park
                Translator = "3g4h5i6j-7k8l-9m0n-1o2p-3q4r5s6t7u8v9w", // James Wilson
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 4 - Friday
            new Manga
            {
                Id = "m6z7a8b9-c0d1-2e3f-4g5h-6i7j8k9l0m1n",
                Title = "The Psychological Game",
                PublishedDate = new DateTime(2024, 1, 26, 9, 0, 0, DateTimeKind.Utc), // Friday
                Format = MangaFormat.Novel,
                Region = MangaRegion.Vietnam,
                ReleaseStatus = MangaReleaseStatus.OnGoing,
                Preface = "A mind-bending psychological battle",
                HasAdult = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x", // Maria Garcia
                SubAuthor = "5i6j7k8l-9m0n-1o2p-3q4r-5s6t7u8v9w0x1y", // Taylor Smith
                Publishor = "6j7k8l9m-0n1o-2p3q-4r5s-6t7u8v9w0x1y2z", // Wei Chen
                Artist = "7k8l9m0n-1o2p-3q4r-5s6t-7u8v9w0x1y2z3a", // Sofia Rodriguez
                Translator = "8l9m0n1o-2p3q-4r5s-6t7u-8v9w0x1y2z3a4b", // Jordan Lee
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Week 4 - Saturday
            new Manga
            {
                Id = "m7a8b9c0-d1e2-3f4g-5h6i-7j8k9l0m1n2o",
                Title = "The Supernatural Academy",
                PublishedDate = new DateTime(2024, 1, 27, 9, 0, 0, DateTimeKind.Utc), // Saturday
                Format = MangaFormat.WebToon,
                Region = MangaRegion.Japan,
                ReleaseStatus = MangaReleaseStatus.ComingSoon,
                Preface = "A school for supernatural abilities",
                HasAdult = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n", // Phuc Lo
                SubAuthor = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o", // Sarah Johnson
                Publishor = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p", // Michael Chen
                Artist = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q", // Emma Wilson
                Translator = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r", // Alex Rivera
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            }
        );

        // Seed MangaGenre
        modelBuilder.Entity<MangaGenre>().HasData(
            // The Last Samurai's Legacy - Action, Historical
            new MangaGenre
            {
                Id = "mg1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                MangaId = "m1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                GenreId = "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s", // Action
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p",
                MangaId = "m1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                GenreId = "2v3w4x5y-6z7a-8b9c-0d1e-2f3g4h5i6j7k8l", // Historical
                IsDeleted = false
            },

            // Cyberpunk Dreams - Sci-Fi, Thriller
            new MangaGenre
            {
                Id = "mg3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                MangaId = "m2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p",
                GenreId = "1k2l3m4n-5o6p-7q8r-9s0t-1u2v3w4x5y6z", // Sci-Fi
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                MangaId = "m2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p",
                GenreId = "3m4n5o6p-7q8r-9s0t-1u2v-3w4x5y6z7a8b9c", // Thriller
                IsDeleted = false
            },

            // Magical Academy - Fantasy, School Life
            new MangaGenre
            {
                Id = "mg5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                MangaId = "m3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                GenreId = "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w", // Fantasy
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                MangaId = "m3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                GenreId = "9s0t1u2v-3w4x-5y6z-7a8b-9c0d1e2f3g4h5i", // School Life
                IsDeleted = false
            },

            // The Detective's Case - Mystery, Thriller
            new MangaGenre
            {
                Id = "mg7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                MangaId = "m4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                GenreId = "2l3m4n5o-6p7q-8r9s-0t1u-2v3w4x5y6z7a8b", // Mystery
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                MangaId = "m4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                GenreId = "3m4n5o6p-7q8r-9s0t-1u2v-3w4x5y6z7a8b9c", // Thriller
                IsDeleted = false
            },

            // The Sports Star - Sports, School Life
            new MangaGenre
            {
                Id = "mg9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                MangaId = "m5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                GenreId = "5o6p7q8r-9s0t-1u2v-3w4x-5y6z7a8b9c0d1e", // Sports
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                MangaId = "m5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                GenreId = "9s0t1u2v-3w4x-5y6z-7a8b-9c0d1e2f3g4h5i", // School Life
                IsDeleted = false
            },

            // The Cooking Master - Cooking, Slice of Life
            new MangaGenre
            {
                Id = "mg1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y",
                MangaId = "m6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                GenreId = "1u2v3w4x-5y6z-7a8b-9c0d-1e2f3g4h5i6j7k", // Cooking
                IsDeleted = false,
            },
            new MangaGenre
            {
                Id = "mg2l3m4n6-o6p7-8q9r-0s1t-2u3v4w5x6y7z",
                MangaId = "m6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                GenreId = "4n5o6p7q-8r9s-0t1u-2v3w-4x5y6z7a8b9c0d", // Slice of Life
                IsDeleted = false
            },

            // Starlight Academy - Fantasy, School Life
            new MangaGenre
            {
                Id = "mg3m4n5o7-p7q8-9r0s-1t2u-3v4w5x6y7z8a",
                MangaId = "m7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                GenreId = "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w", // Fantasy
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg4n5o6p7-q8r9-0s1t-2u3v-4w5x6y7z8a9b",
                MangaId = "m7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                GenreId = "9s0t1u2v-3w4x-5y6z-7a8b-9c0d1e2f3g4h5i", // School Life
                IsDeleted = false
            },

            // The Last Hero - Action, Sci-Fi
            new MangaGenre
            {
                Id = "mg5o6p7q8-r9s0-1t2u-3v4w-5x6y7z8a9b0c",
                MangaId = "m8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                GenreId = "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s", // Action
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg6p7q8r9-s0t1-2u3v-4w5x-6y7z8a9b0c1d",
                MangaId = "m8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                GenreId = "1k2l3m4n-5o6p-7q8r-9s0t-1u2v3w4x5y6z", // Sci-Fi
                IsDeleted = false
            },

            // The Cooking Master - Cooking, Slice of Life
            new MangaGenre
            {
                Id = "mg7q8r9s0-t1u2-3v4w-5x6y-7z8a9b0c1d2e",
                MangaId = "m9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                GenreId = "1u2v3w4x-5y6z-7a8b-9c0d-1e2f3g4h5i6j7k", // Cooking
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg8r9s0t1-u2v3-4w5x-6y7z-8a9b0c1d2e3f",
                MangaId = "m9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                GenreId = "4n5o6p7q-8r9s-0t1u-2v3w-4x5y6z7a8b9c0d", // Slice of Life
                IsDeleted = false
            },
            // The Music Prodigy - Music, Slice of Life
            new MangaGenre
            {
                Id = "mg9s0t1u2-v3w4-5x6y-7z8a-9b0c1d2e3f4g",
                MangaId = "m0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                GenreId = "0t1u2v3w-4x5y-6z7a-8b9c-0d1e2f3g4h5i6j", // Music
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg0t1u2v3-w4x5-6y7z-8a9b-0c1d2e3f4g5h",
                MangaId = "m0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                GenreId = "4n5o6p7q-8r9s-0t1u-2v3w-4x5y6z7a8b9c0d", // Slice of Life
                IsDeleted = false
            },
            // The Martial Arts Master - Martial Arts, Action
            new MangaGenre
            {
                Id = "mg1u2v3w4-x5y6-7z8a-9b0c-1d2e3f4g5h6i",
                MangaId = "m1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y",
                GenreId = "8r9s0t1u-2v3w-4x5y-6z7a-8b9c0d1e2f3g4h", // Martial Arts
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg2v3w4x5-y6z7-8a9b-0c1d-2e3f4g5h6i7j",
                MangaId = "m1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y",
                GenreId = "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s", // Action
                IsDeleted = false
            },
            // The Psychological Thriller - Psychological, Thriller
            new MangaGenre
            {
                Id = "mg3w4x5y6-z7a8-9b0c-1d2e-3f4g5h6i7j8k",
                MangaId = "m2l3m4n6-o6p7-8q9r-0s1t-2u3v4w5x6y7z",
                GenreId = "7q8r9s0t-1u2v-3w4x-5y6z-7a8b9c0d1e2f3g", // Psychological
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg4x5y6z7-a8b9-0c1d-2e3f-4g5h6i7j8k9l",
                MangaId = "m2l3m4n6-o6p7-8q9r-0s1t-2u3v4w5x6y7z",
                GenreId = "3m4n5o6p-7q8r-9s0t-1u2v-3w4x5y6z7a8b9c", // Thriller
                IsDeleted = false
            },
            // The Military Academy - Military, School Life
            new MangaGenre
            {
                Id = "mg5y6z7a8-b9c0-1d2e-3f4g-5h6i7j8k9l0m",
                MangaId = "m3m4n5o7-p7q8-9r0s-1t2u-3v4w5x6y7z8a",
                GenreId = "3w4x5y6z-7a8b-9c0d-1e2f-3g4h5i6j7k8l9m", // Military
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg6z7a8b9-c0d1-2e3f-4g5h-6i7j8k9l0m1n",
                MangaId = "m3m4n5o7-p7q8-9r0s-1t2u-3v4w5x6y7z8a",
                GenreId = "9s0t1u2v-3w4x-5y6z-7a8b-9c0d1e2f3g4h5i", // School Life
                IsDeleted = false
            },
            // The Supernatural Detective - Supernatural, Mystery
            new MangaGenre
            {
                Id = "mg7a8b9c0-d1e2-3f4g-5h6i-7j8k9l0m1n2o",
                MangaId = "m4n5o6p7-q8r9-0s1t-2u3v-4w5x6y7z8a9b",
                GenreId = "6p7q8r9s-0t1u-2v3w-4x5y-6z7a8b9c0d1e2f", // Supernatural
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg8b9c0d1-e2f3-4g5h-6i7j-8k9l0m1n2o3p",
                MangaId = "m4n5o6p7-q8r9-0s1t-2u3v-4w5x6y7z8a9b",
                GenreId = "2l3m4n5o-6p7q-8r9s-0t1u-2v3w4x5y6z7a8b", // Mystery
                IsDeleted = false
            },
            // The Historical Romance - Historical, Romance
            new MangaGenre
            {
                Id = "mg9c0d1e2-f3g4-5h6i-7j8k-9l0m1n2o3p4q",
                MangaId = "m5o6p7q8-r9s0-1t2u-3v4w-5x6y7z8a9b0c",
                GenreId = "2v3w4x5y-6z7a-8b9c-0d1e-2f3g4h5i6j7k8l", // Historical
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg0d1e2f3-g4h5-6i7j-8k9l-0m1n2o3p4q5r",
                MangaId = "m5o6p7q8-r9s0-1t2u-3v4w-5x6y7z8a9b0c",
                GenreId = "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y", // Romance
                IsDeleted = false
            },
            // The Horror Mansion - Horror, Thriller
            new MangaGenre
            {
                Id = "mg1e2f3g4-h5i6-7j8k-9l0m-1n2o3p4q5r6s",
                MangaId = "m6p7q8r9-s0t1-2u3v-4w5x-6y7z8a9b0c1d",
                GenreId = "9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x", // Horror
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg2f3g4h5-i6j7-8k9l-0m1n-2o3p4q5r6s7t",
                MangaId = "m6p7q8r9-s0t1-2u3v-4w5x-6y7z8a9b0c1d",
                GenreId = "3m4n5o6p-7q8r-9s0t-1u2v-3w4x5y6z7a8b9c", // Thriller
                IsDeleted = false
            },
            // The Adventure Quest - Adventure, Fantasy
            new MangaGenre
            {
                Id = "mg3g4h5i6-j7k8-9l0m-1n2o-3p4q5r6s7t8u",
                MangaId = "m7q8r9s0-t1u2-3v4w-5x6y-7z8a9b0c1d2e",
                GenreId = "5e6f7g8h-9i0j-1k2l-3m4n-5o6p7q8r9s0t", // Adventure
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg4h5i6j7-k8l9-0m1n-2o3p-4q5r6s7t8u9v",
                MangaId = "m7q8r9s0-t1u2-3v4w-5x6y-7z8a9b0c1d2e",
                GenreId = "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w", // Fantasy
                IsDeleted = false
            },
            // The Comedy Club - Comedy, Slice of Life
            new MangaGenre
            {
                Id = "mg5i6j7k8-l9m0-1n2o-3p4q-5r6s7t8u9v0w",
                MangaId = "m8r9s0t1-u2v3-4w5x-6y7z-8a9b0c1d2e3f",
                GenreId = "6f7g8h9i-0j1k-2l3m-4n5o-6p7q8r9s0t1u", // Comedy
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg6j7k8l9-m0n1-2o3p-4q5r-6s7t8u9v0w1x",
                MangaId = "m8r9s0t1-u2v3-4w5x-6y7z-8a9b0c1d2e3f",
                GenreId = "4n5o6p7q-8r9s-0t1u-2v3w-4x5y6z7a8b9c0d", // Slice of Life
                IsDeleted = false
            },
            // The Drama Queen - Drama, Romance
            new MangaGenre
            {
                Id = "mg7k8l9m0-n1o2-3p4q-5r6s-7t8u9v0w1x2y",
                MangaId = "m9s0t1u2-v3w4-5x6y-7z8a-9b0c1d2e3f4g",
                GenreId = "7g8h9i0j-1k2l-3m4n-5o6p-7q8r9s0t1u2v", // Drama
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg8l9m0n1-o2p3-4q5r-6s7t-8u9v0w1x2y3z",
                MangaId = "m9s0t1u2-v3w4-5x6y-7z8a-9b0c1d2e3f4g",
                GenreId = "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y", // Romance
                IsDeleted = false
            },
            // The Sports Tournament - Sports, Action
            new MangaGenre
            {
                Id = "mg9m0n1o2-p3q4-5r6s-7t8u-9v0w1x2y3z4a",
                MangaId = "m0t1u2v3-w4x5-6y7z-8a9b-0c1d2e3f4g5h",
                GenreId = "5o6p7q8r-9s0t-1u2v-3w4x-5y6z7a8b9c0d1e", // Sports
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg0n1o2p3-q4r5-6s7t-8u9v-0w1x2y3z4a5b",
                MangaId = "m0t1u2v3-w4x5-6y7z-8a9b-0c1d2e3f4g5h",
                GenreId = "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s", // Action
                IsDeleted = false
            },
            // The Mystery Box - Mystery, Thriller
            new MangaGenre
            {
                Id = "mg1o2p3q4-r5s6-7t8u-9v0w-1x2y3z4a5b6c",
                MangaId = "m1u2v3w4-x5y6-7z8a-9b0c-1d2e3f4g5h6i",
                GenreId = "2l3m4n5o-6p7q-8r9s-0t1u-2v3w4x5y6z7a8b", // Mystery
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg2p3q4r5-s6t7-8u9v-0w1x-2y3z4a5b6c7d",
                MangaId = "m1u2v3w4-x5y6-7z8a-9b0c-1d2e3f4g5h6i",
                GenreId = "3m4n5o6p-7q8r-9s0t-1u2v-3w4x5y6z7a8b9c", // Thriller
                IsDeleted = false
            },
            // The Fantasy Kingdom - Fantasy, Adventure
            new MangaGenre
            {
                Id = "mg3q4r5s6-t7u8-9v0w-1x2y-3z4a5b6c7d8e",
                MangaId = "m2v3w4x5-y6z7-8a9b-0c1d-2e3f4g5h6i7j",
                GenreId = "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w", // Fantasy
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg4r5s6t7-u8v9-0w1x-2y3z-4a5b6c7d8e9f",
                MangaId = "m2v3w4x5-y6z7-8a9b-0c1d-2e3f4g5h6i7j",
                GenreId = "5e6f7g8h-9i0j-1k2l-3m4n-5o6p7q8r9s0t", // Adventure
                IsDeleted = false
            },
            // The School Festival - Slice of Life, Comedy
            new MangaGenre
            {
                Id = "mg5s6t7u8-v9w0-1x2y-3z4a-5b6c7d8e9f0g",
                MangaId = "m3w4x5y6-z7a8-9b0c-1d2e-3f4g5h6i7j8k",
                GenreId = "4n5o6p7q-8r9s-0t1u-2v3w-4x5y6z7a8b9c0d", // Slice of Life
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg6t7u8v9-w0x1-2y3z-4a5b-6c7d8e9f0g1h",
                MangaId = "m3w4x5y6-z7a8-9b0c-1d2e-3f4g5h6i7j8k",
                GenreId = "6f7g8h9i-0j1k-2l3m-4n5o-6p7q8r9s0t1u", // Comedy
                IsDeleted = false
            },
            // The Cooking Competition - Slice of Life, Drama
            new MangaGenre
            {
                Id = "mg7u8v9w0-x1y2-3z4a-5b6c-7d8e9f0g1h2i",
                MangaId = "m4x5y6z7-a8b9-0c1d-2e3f-4g5h6i7j8k9l",
                GenreId = "4n5o6p7q-8r9s-0t1u-2v3w-4x5y6z7a8b9c0d", // Slice of Life
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg8v9w0x1-y2z3-4a5b-6c7d-8e9f0g1h2i3j",
                MangaId = "m4x5y6z7-a8b9-0c1d-2e3f-4g5h6i7j8k9l",
                GenreId = "7g8h9i0j-1k2l-3m4n-5o6p-7q8r9s0t1u2v", // Drama
                IsDeleted = false
            },
            // The Martial Arts Tournament - Action, Martial Arts
            new MangaGenre
            {
                Id = "mg9w0x1y2-z3a4-5b6c-7d8e-9f0g1h2i3j4k",
                MangaId = "m5y6z7a8-b9c0-1d2e-3f4g-5h6i7j8k9l0m",
                GenreId = "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s", // Action
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg0x1y2z3-a4b5-6c7d-8e9f-0g1h2i3j4k5l",
                MangaId = "m5y6z7a8-b9c0-1d2e-3f4g-5h6i7j8k9l0m",
                GenreId = "8r9s0t1u-2v3w-4x5y-6z7a-8b9c0d1e2f3g4h", // Martial Arts
                IsDeleted = false
            },
            // The Psychological Game - Psychological, Thriller
            new MangaGenre
            {
                Id = "mg1y2z3a4-b5c6-7d8e-9f0g-1h2i3j4k5l6m",
                MangaId = "m6z7a8b9-c0d1-2e3f-4g5h-6i7j8k9l0m1n",
                GenreId = "7q8r9s0t-1u2v-3w4x-5y6z-7a8b9c0d1e2f3g", // Psychological
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg2z3a4b5-c6d7-8e9f-0g1h-2i3j4k5l6m7n",
                MangaId = "m6z7a8b9-c0d1-2e3f-4g5h-6i7j8k9l0m1n",
                GenreId = "3m4n5o6p-7q8r-9s0t-1u2v-3w4x5y6z7a8b9c", // Thriller
                IsDeleted = false
            },
            // The Supernatural Academy - Supernatural, Fantasy
            new MangaGenre
            {
                Id = "mg3a4b5c6-d7e8-9f0g-1h2i-3j4k5l6m7n8o",
                MangaId = "m7a8b9c0-d1e2-3f4g-5h6i-7j8k9l0m1n2o",
                GenreId = "6p7q8r9s-0t1u-2v3w-4x5y-6z7a8b9c0d1e2f", // Supernatural
                IsDeleted = false
            },
            new MangaGenre
            {
                Id = "mg4b5c6d7-e8f9-0g1h-2i3j-4k5l6m7n8o9p",
                MangaId = "m7a8b9c0-d1e2-3f4g-5h6i-7j8k9l0m1n2o",
                GenreId = "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w", // Fantasy
                IsDeleted = false
            }
        );

        // Seed Chapters
        modelBuilder.Entity<Chapter>().HasData(
            // The Last Samurai's Legacy - Chapter 1
            new Chapter
            {
                Id = "c1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                MangaId = "m1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o", // The Last Samurai's Legacy
                Name = "The Beginning",
                NovelContent = "The samurai's journey begins...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                ChapterNumber = 1,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n"
            },
            // Cyberpunk Dreams - Chapter 1
            new Chapter
            {
                Id = "c2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p",
                MangaId = "m2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p", // Cyberpunk Dreams
                Name = "First Contact",
                NovelContent = "A new world of technology opens up...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                ChapterNumber = 1,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            // Magical Academy - Chapter 1
            new Chapter
            {
                Id = "c3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                MangaId = "m3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q", // Magical Academy
                Name = "First Spell",
                NovelContent = "Students learn their first spell at the academy...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                ChapterNumber = 1,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x"
            },
            // The Detective's Case - Chapter 1
            new Chapter
            {
                Id = "c4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                MangaId = "m4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r", // The Detective's Case
                Name = "The Case Opens",
                NovelContent = "A mysterious case arrives at the detective's desk...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                ChapterNumber = 1,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n"
            },
            // The Sports Star - Chapter 1
            new Chapter
            {
                Id = "c5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                MangaId = "m5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s", // The Sports Star
                Name = "The First Match",
                NovelContent = "The protagonist enters their first big match...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                ChapterNumber = 1,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            // The Cooking Master - Chapter 1
            new Chapter
            {
                Id = "c6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                MangaId = "m6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t", // The Cooking Master
                Name = "The First Recipe",
                NovelContent = "A young chef discovers their passion for cooking...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                ChapterNumber = 1,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x"
            },
            // Starlight Academy - Chapter 1
            new Chapter
            {
                Id = "c7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                MangaId = "m7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y", // Starlight Academy
                Name = "Welcome to Starlight",
                NovelContent = "New students arrive at the magical Starlight Academy...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                ChapterNumber = 1,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n"
            },
            // The Last Hero - Chapter 1
            new Chapter
            {
                Id = "c8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                MangaId = "m8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b", // The Last Hero
                Name = "The Awakening",
                NovelContent = "A hero awakens to their true power...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                ChapterNumber = 1,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            // The Music Prodigy - Chapter 1
            new Chapter
            {
                Id = "c9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                MangaId = "m0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x", // The Music Prodigy
                Name = "First Note",
                NovelContent = "A young musician discovers their extraordinary talent...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                ChapterNumber = 1,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            // The Martial Arts Master - Chapter 1
            new Chapter
            {
                Id = "c0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                MangaId = "m1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y", // The Martial Arts Master
                Name = "The Training Begins",
                NovelContent = "A student begins their journey in martial arts...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                ChapterNumber = 1,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x"
            },
            // The Psychological Thriller - Chapter 1
            new Chapter
            {
                Id = "c1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y",
                MangaId = "m2l3m4n6-o6p7-8q9r-0s1t-2u3v4w5x6y7z", // The Psychological Thriller
                Name = "The First Dream",
                NovelContent = "A mysterious dream leads to a psychological journey...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                ChapterNumber = 1,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n"
            },
            // The Military Academy - Chapter 1
            new Chapter
            {
                Id = "c2l3m4n6-o6p7-8q9r-0s1t-2u3v4w5x6y7z",
                MangaId = "m3m4n5o7-p7q8-9r0s-1t2u-3v4w5x6y7z8a", // The Military Academy
                Name = "Enrollment Day",
                NovelContent = "New cadets arrive at the prestigious military academy...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                ChapterNumber = 1,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            // The Supernatural Detective - Chapter 1
            new Chapter
            {
                Id = "c3m4n5o7-p7q8-9r0s-1t2u-3v4w5x6y7z8a",
                MangaId = "m4n5o6p7-q8r9-0s1t-2u3v-4w5x6y7z8a9b", // The Supernatural Detective
                Name = "The First Case",
                NovelContent = "A detective encounters their first supernatural case...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                ChapterNumber = 1,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x"
            },
            // The Historical Romance - Chapter 1
            new Chapter
            {
                Id = "c4n5o6p7-q8r9-0s1t-2u3v-4w5x6y7z8a9b",
                MangaId = "m5o6p7q8-r9s0-1t2u-3v4w-5x6y7z8a9b0c", // The Historical Romance
                Name = "The Meeting",
                NovelContent = "Two souls meet in a historical setting...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                ChapterNumber = 1,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n"
            },
            // The Horror Mansion - Chapter 1
            new Chapter
            {
                Id = "c5o6p7q8-r9s0-1t2u-3v4w-5x6y7z8a9b0c",
                MangaId = "m6p7q8r9-s0t1-2u3v-4w5x-6y7z8a9b0c1d", // The Horror Mansion
                Name = "The Arrival",
                NovelContent = "A group enters the haunted mansion...",
                HasDraft = false,
                ThumbnailImage = COVER_IMAGE_URL,
                PublishedDate = SEED_DATE,
                HasComment = true,
                StatusChapter = 1,
                ChapterNumber = 1,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            }
        );

        // Seed ChapterImages
        modelBuilder.Entity<ChapterImage>().HasData(
            // Chapter 1 Images
            new ChapterImage
            {
                Id = "ci1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                Name = "Chapter 1 Page 1",
                FileSize = "2.5MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/chapter-1/page-1.jpg",
                ChapterId = "c1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                IsDeleted = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n"
            },
            new ChapterImage
            {
                Id = "ci2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p",
                Name = "Chapter 1 Page 2",
                FileSize = "2.3MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/chapter-1/page-2.jpg",
                ChapterId = "c1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                IsDeleted = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n"
            },
            // The Cooking Master - Chapter 1 Images
            new ChapterImage
            {
                Id = "ci3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                Name = "The First Recipe Page 1",
                FileSize = "2.8MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/cooking-master-ch1/page-1.jpg",
                ChapterId = "c6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                IsDeleted = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x"
            },
            new ChapterImage
            {
                Id = "ci4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                Name = "The First Recipe Page 2",
                FileSize = "2.6MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/cooking-master-ch1/page-2.jpg",
                ChapterId = "c6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                IsDeleted = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x"
            },
            // Starlight Academy - Chapter 1 Images
            new ChapterImage
            {
                Id = "ci5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                Name = "Welcome to Starlight Page 1",
                FileSize = "3.1MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/starlight-academy-ch1/page-1.jpg",
                ChapterId = "c7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                IsDeleted = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n"
            },
            new ChapterImage
            {
                Id = "ci6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                Name = "Welcome to Starlight Page 2",
                FileSize = "2.9MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/starlight-academy-ch1/page-2.jpg",
                ChapterId = "c7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                IsDeleted = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n"
            },
            // The Last Hero - Chapter 1 Images
            new ChapterImage
            {
                Id = "ci7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                Name = "The Awakening Page 1",
                FileSize = "2.7MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/last-hero-ch1/page-1.jpg",
                ChapterId = "c8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                IsDeleted = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            new ChapterImage
            {
                Id = "ci8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                Name = "The Awakening Page 2",
                FileSize = "2.4MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/last-hero-ch1/page-2.jpg",
                ChapterId = "c8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                IsDeleted = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            // The Music Prodigy - Chapter 1 Images
            new ChapterImage
            {
                Id = "ci9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                Name = "First Note Page 1",
                FileSize = "2.2MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/music-prodigy-ch1/page-1.jpg",
                ChapterId = "c9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                IsDeleted = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            new ChapterImage
            {
                Id = "ci0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                Name = "First Note Page 2",
                FileSize = "2.0MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/music-prodigy-ch1/page-2.jpg",
                ChapterId = "c9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                IsDeleted = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            // The Martial Arts Master - Chapter 1 Images
            new ChapterImage
            {
                Id = "ci1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y",
                Name = "The Training Begins Page 1",
                FileSize = "3.2MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/martial-arts-master-ch1/page-1.jpg",
                ChapterId = "c0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                IsDeleted = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x"
            },
            new ChapterImage
            {
                Id = "ci2l3m4n6-o6p7-8q9r-0s1t-2u3v4w5x6y7z",
                Name = "The Training Begins Page 2",
                FileSize = "2.8MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/martial-arts-master-ch1/page-2.jpg",
                ChapterId = "c0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                IsDeleted = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x"
            },
            // The Psychological Thriller - Chapter 1 Images
            new ChapterImage
            {
                Id = "ci3m4n5o7-p7q8-9r0s-1t2u-3v4w5x6y7z8a",
                Name = "The First Dream Page 1",
                FileSize = "2.6MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/psychological-thriller-ch1/page-1.jpg",
                ChapterId = "c1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y",
                IsDeleted = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n"
            },
            new ChapterImage
            {
                Id = "ci4n5o6p7-q8r9-0s1t-2u3v-4w5x6y7z8a9b",
                Name = "The First Dream Page 2",
                FileSize = "2.3MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/psychological-thriller-ch1/page-2.jpg",
                ChapterId = "c1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y",
                IsDeleted = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n"
            },
            // The Military Academy - Chapter 1 Images
            new ChapterImage
            {
                Id = "ci5o6p7q8-r9s0-1t2u-3v4w-5x6y7z8a9b0c",
                Name = "Enrollment Day Page 1",
                FileSize = "3.0MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/military-academy-ch1/page-1.jpg",
                ChapterId = "c2l3m4n6-o6p7-8q9r-0s1t-2u3v4w5x6y7z",
                IsDeleted = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            new ChapterImage
            {
                Id = "ci6p7q8r9-s0t1-2u3v-4w5x-6y7z8a9b0c1d",
                Name = "Enrollment Day Page 2",
                FileSize = "2.7MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/military-academy-ch1/page-2.jpg",
                ChapterId = "c2l3m4n6-o6p7-8q9r-0s1t-2u3v4w5x6y7z",
                IsDeleted = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            // The Supernatural Detective - Chapter 1 Images
            new ChapterImage
            {
                Id = "ci7q8r9s0-t1u2-3v4w-5x6y-7z8a9b0c1d2e",
                Name = "The First Case Page 1",
                FileSize = "2.9MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/supernatural-detective-ch1/page-1.jpg",
                ChapterId = "c3m4n5o7-p7q8-9r0s-1t2u-3v4w5x6y7z8a",
                IsDeleted = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x"
            },
            new ChapterImage
            {
                Id = "ci8r9s0t1-u2v3-4w5x-6y7z-8a9b0c1d2e3f",
                Name = "The First Case Page 2",
                FileSize = "2.5MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/supernatural-detective-ch1/page-2.jpg",
                ChapterId = "c3m4n5o7-p7q8-9r0s-1t2u-3v4w5x6y7z8a",
                IsDeleted = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x"
            },
            // The Historical Romance - Chapter 1 Images
            new ChapterImage
            {
                Id = "ci9s0t1u2-v3w4-5x6y-7z8a-9b0c1d2e3f4g",
                Name = "The Meeting Page 1",
                FileSize = "2.4MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/historical-romance-ch1/page-1.jpg",
                ChapterId = "c4n5o6p7-q8r9-0s1t-2u3v-4w5x6y7z8a9b",
                IsDeleted = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n"
            },
            new ChapterImage
            {
                Id = "ci0t1u2v3-w4x5-6y7z-8a9b-0c1d2e3f4g5h",
                Name = "The Meeting Page 2",
                FileSize = "2.1MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/historical-romance-ch1/page-2.jpg",
                ChapterId = "c4n5o6p7-q8r9-0s1t-2u3v-4w5x6y7z8a9b",
                IsDeleted = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n"
            },
            // The Horror Mansion - Chapter 1 Images
            new ChapterImage
            {
                Id = "ci1u2v3w4-x5y6-7z8a-9b0c-1d2e3f4g5h6i",
                Name = "The Arrival Page 1",
                FileSize = "3.3MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/horror-mansion-ch1/page-1.jpg",
                ChapterId = "c5o6p7q8-r9s0-1t2u-3v4w-5x6y7z8a9b0c",
                IsDeleted = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            new ChapterImage
            {
                Id = "ci2v3w4x5-y6z7-8a9b-0c1d-2e3f4g5h6i7j",
                Name = "The Arrival Page 2",
                FileSize = "2.8MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/horror-mansion-ch1/page-2.jpg",
                ChapterId = "c5o6p7q8-r9s0-1t2u-3v4w-5x6y7z8a9b0c",
                IsDeleted = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            // Additional Chapter Images for existing chapters
            // The Last Samurai's Legacy - Additional Pages
            new ChapterImage
            {
                Id = "ci3w4x5y6-z7a8-9b0c-1d2e-3f4g5h6i7j8k",
                Name = "Chapter 1 Page 3",
                FileSize = "2.4MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/chapter-1/page-3.jpg",
                ChapterId = "c1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                IsDeleted = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n"
            },
            new ChapterImage
            {
                Id = "ci4x5y6z7-a8b9-0c1d-2e3f-4g5h6i7j8k9l",
                Name = "Chapter 1 Page 4",
                FileSize = "2.6MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/chapter-1/page-4.jpg",
                ChapterId = "c1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                IsDeleted = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n"
            },
            // Cyberpunk Dreams - Additional Pages
            new ChapterImage
            {
                Id = "ci5y6z7a8-b9c0-1d2e-3f4g-5h6i7j8k9l0m",
                Name = "First Contact Page 3",
                FileSize = "2.9MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/cyberpunk-dreams-ch1/page-3.jpg",
                ChapterId = "c2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p",
                IsDeleted = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            new ChapterImage
            {
                Id = "ci6z7a8b9-c0d1-2e3f-4g5h-6i7j8k9l0m1n",
                Name = "First Contact Page 4",
                FileSize = "2.7MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/cyberpunk-dreams-ch1/page-4.jpg",
                ChapterId = "c2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p",
                IsDeleted = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            // Magical Academy - Additional Pages
            new ChapterImage
            {
                Id = "ci7a8b9c0-d1e2-3f4g-5h6i-7j8k9l0m1n2o",
                Name = "First Spell Page 3",
                FileSize = "3.0MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/magical-academy-ch1/page-3.jpg",
                ChapterId = "c3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                IsDeleted = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x"
            },
            new ChapterImage
            {
                Id = "ci8b9c0d1-e2f3-4g5h-6i7j-8k9l0m1n2o3p",
                Name = "First Spell Page 4",
                FileSize = "2.8MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/magical-academy-ch1/page-4.jpg",
                ChapterId = "c3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                IsDeleted = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x"
            },
            // The Detective's Case - Additional Pages
            new ChapterImage
            {
                Id = "ci9c0d1e2-f3g4-5h6i-7j8k-9l0m1n2o3p4q",
                Name = "The Case Opens Page 3",
                FileSize = "2.5MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/detective-case-ch1/page-3.jpg",
                ChapterId = "c4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                IsDeleted = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n"
            },
            new ChapterImage
            {
                Id = "ci0d1e2f3-g4h5-6i7j-8k9l-0m1n2o3p4q5r",
                Name = "The Case Opens Page 4",
                FileSize = "2.3MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/detective-case-ch1/page-4.jpg",
                ChapterId = "c4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                IsDeleted = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n"
            },
            // The Sports Star - Additional Pages
            new ChapterImage
            {
                Id = "ci1e2f3g4-h5i6-7j8k-9l0m-1n2o3p4q5r6s",
                Name = "The First Match Page 3",
                FileSize = "2.9MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/sports-star-ch1/page-3.jpg",
                ChapterId = "c5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                IsDeleted = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            new ChapterImage
            {
                Id = "ci2f3g4h5-i6j7-8k9l-0m1n-2o3p4q5r6s7t",
                Name = "The First Match Page 4",
                FileSize = "2.6MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/sports-star-ch1/page-4.jpg",
                ChapterId = "c5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                IsDeleted = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            // The Cooking Master - Additional Pages
            new ChapterImage
            {
                Id = "ci3g4h5i6-j7k8-9l0m-1n2o-3p4q5r6s7t8u",
                Name = "The First Recipe Page 3",
                FileSize = "2.7MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/cooking-master-ch1/page-3.jpg",
                ChapterId = "c6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                IsDeleted = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x"
            },
            new ChapterImage
            {
                Id = "ci4h5i6j7-k8l9-0m1n-2o3p-4q5r6s7t8u9v",
                Name = "The First Recipe Page 4",
                FileSize = "2.4MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/cooking-master-ch1/page-4.jpg",
                ChapterId = "c6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                IsDeleted = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x"
            },
            // Starlight Academy - Additional Pages
            new ChapterImage
            {
                Id = "ci5i6j7k8-l9m0-1n2o-3p4q-5r6s7t8u9v0w",
                Name = "Welcome to Starlight Page 3",
                FileSize = "3.2MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/starlight-academy-ch1/page-3.jpg",
                ChapterId = "c7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                IsDeleted = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n"
            },
            new ChapterImage
            {
                Id = "ci6j7k8l9-m0n1-2o3p-4q5r-6s7t8u9v0w1x",
                Name = "Welcome to Starlight Page 4",
                FileSize = "2.8MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/starlight-academy-ch1/page-4.jpg",
                ChapterId = "c7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                IsDeleted = false,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n"
            },
            // The Last Hero - Additional Pages
            new ChapterImage
            {
                Id = "ci7k8l9m0-n1o2-3p4q-5r6s-7t8u9v0w1x2y",
                Name = "The Awakening Page 3",
                FileSize = "2.6MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/last-hero-ch1/page-3.jpg",
                ChapterId = "c8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                IsDeleted = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            new ChapterImage
            {
                Id = "ci8l9m0n1-o2p3-4q5r-6s7t-8u9v0w1x2y3z",
                Name = "The Awakening Page 4",
                FileSize = "2.3MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/last-hero-ch1/page-4.jpg",
                ChapterId = "c8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                IsDeleted = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            // The Music Prodigy - Additional Pages
            new ChapterImage
            {
                Id = "ci9m0n1o2-p3q4-5r6s-7t8u-9v0w1x2y3z4a",
                Name = "First Note Page 3",
                FileSize = "2.1MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/music-prodigy-ch1/page-3.jpg",
                ChapterId = "c9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                IsDeleted = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            new ChapterImage
            {
                Id = "ci0n1o2p3-q4r5-6s7t-8u9v-0w1x2y3z4a5b",
                Name = "First Note Page 4",
                FileSize = "1.9MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/music-prodigy-ch1/page-4.jpg",
                ChapterId = "c9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                IsDeleted = false,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s"
            },
            // The Martial Arts Master - Additional Pages
            new ChapterImage
            {
                Id = "ci1o2p3q4-r5s6-7t8u-9v0w-1x2y3z4a5b6c",
                Name = "The Training Begins Page 3",
                FileSize = "3.4MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/martial-arts-master-ch1/page-3.jpg",
                ChapterId = "c0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                IsDeleted = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x"
            },
            new ChapterImage
            {
                Id = "ci2p3q4r5-s6t7-8u9v-0w1x-2y3z4a5b6c7d",
                Name = "The Training Begins Page 4",
                FileSize = "3.0MB",
                MimeType = "image/jpeg",
                FilePath = "chapters/martial-arts-master-ch1/page-4.jpg",
                ChapterId = "c0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                IsDeleted = false,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x"
            }
        );

        // Seed FeaturedCollections
        modelBuilder.Entity<FeaturedCollection>().HasData(
            new FeaturedCollection
            {
                Id = "fc1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                Name = "Best Action Manga",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n" // Phuc Lo
            },
            new FeaturedCollection
            {
                Id = "fc2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p",
                Name = "Romance Collection",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o" // Sarah Johnson
            },
            new FeaturedCollection
            {
                Id = "fc3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                Name = "Fantasy Adventures",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p" // Michael Chen
            },
            new FeaturedCollection
            {
                Id = "fc4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                Name = "School Life Stories",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = false,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q" // Emma Wilson
            },
            new FeaturedCollection
            {
                Id = "fc5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                Name = "Mystery & Thriller",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r" // Alex Rivera
            },
            new FeaturedCollection
            {
                Id = "fc6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                Name = "Sports & Competition",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s" // Hiroshi Tanaka
            },
            new FeaturedCollection
            {
                Id = "fc7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                Name = "Cooking & Food",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "0d1e2f3g-4h5i-6j7k-8l9m-0n1o2p3q4r5s6t" // Yuki Sato
            },
            new FeaturedCollection
            {
                Id = "fc8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                Name = "Historical Tales",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = false,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "1e2f3g4h-5i6j-7k8l-9m0n-1o2p3q4r5s6t7u" // David Kim
            },
            new FeaturedCollection
            {
                Id = "fc9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                Name = "Supernatural & Horror",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "2f3g4h5i-6j7k-8l9m-0n1o-2p3q4r5s6t7u8v" // Lisa Park
            },
            new FeaturedCollection
            {
                Id = "fc0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                Name = "Music & Arts",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "3g4h5i6j-7k8l-9m0n-1o2p-3q4r5s6t7u8v9w" // James Wilson
            }
        );

        // Additional FeaturedCollections
        modelBuilder.Entity<FeaturedCollection>().HasData(
            new FeaturedCollection
            {
                Id = "fc1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y",
                Name = "Adventure & Exploration",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "5i6j7k8l-9m0n-1o2p-3q4r-5s6t7u8v9w0x1y" // Taylor Smith
            },
            new FeaturedCollection
            {
                Id = "fc2l3m4n6-o6p7-8q9r-0s1t-2u3v4w5x6y7z",
                Name = "Comedy & Humor",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "6j7k8l9m-0n1o-2p3q-4r5s-6t7u8v9w0x1y2z" // Wei Chen
            },
            new FeaturedCollection
            {
                Id = "fc3m4n5o7-p7q8-9r0s-1t2u-3v4w5x6y7z8a",
                Name = "Drama & Emotion",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "7k8l9m0n-1o2p-3q4r-5s6t-7u8v9w0x1y2z3a" // Sofia Rodriguez
            },
            new FeaturedCollection
            {
                Id = "fc4n5o6p8-q8r9-0s1t-2u3v-4w5x6y7z8a9b",
                Name = "Military & Strategy",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = false,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "8l9m0n1o-2p3q-4r5s-6t7u-8v9w0x1y2z3a4b" // Jordan Lee
            },
            new FeaturedCollection
            {
                Id = "fc5o6p7q9-r9s0-1t2u-3v4w-5x6y7z8a9b0c",
                Name = "Psychological & Mind Games",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x" // Maria Garcia
            },
            new FeaturedCollection
            {
                Id = "fc6p7q8r0-s0t1-2u3v-4w5x-6y7z8a9b0c1d",
                Name = "Slice of Life & Daily Stories",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "5i6j7k8l-9m0n-1o2p-3q4r-5s6t7u8v9w0x1y" // Taylor Smith
            },
            new FeaturedCollection
            {
                Id = "fc7q8r9s1-t1u2-3v4w-5x6y-7z8a9b0c1d2e",
                Name = "Supernatural & Magic",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "6j7k8l9m-0n1o-2p3q-4r5s-6t7u8v9w0x1y2z" // Wei Chen
            },
            new FeaturedCollection
            {
                Id = "fc8r9s0t2-u2v3-4w5x-6y7z-8a9b0c1d2e3f",
                Name = "Martial Arts & Combat",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "7k8l9m0n-1o2p-3q4r-5s6t-7u8v9w0x1y2z3a" // Sofia Rodriguez
            },
            new FeaturedCollection
            {
                Id = "fc9s0t1u3-v3w4-5x6y-7z8a-9b0c1d2e3f4g",
                Name = "Sci-Fi & Technology",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = true,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "8l9m0n1o-2p3q-4r5s-6t7u-8v9w0x1y2z3a4b" // Jordan Lee
            },
            new FeaturedCollection
            {
                Id = "fc0t1u2v4-w4x5-6y7z-8a9b-0c1d2e3f4g5h",
                Name = "Horror & Suspense",
                CoverImage = COVER_IMAGE_URL,
                IsPublish = false,
                IsDeleted = false,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                CreatedBy = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x" // Maria Garcia
            }
        );

        // Seed FeaturedCollectionMangas
        modelBuilder.Entity<FeaturedCollectionManga>().HasData(
            // Best Action Manga Collection
            new FeaturedCollectionManga
            {
                Id = "fcm1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                FeaturedCollectionId = "fc1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                MangaId = "m1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o", // The Last Samurai's Legacy
                IsDeleted = false
            },
            new FeaturedCollectionManga
            {
                Id = "fcm2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p",
                FeaturedCollectionId = "fc1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                MangaId = "m8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b", // The Last Hero
                IsDeleted = false
            },
            new FeaturedCollectionManga
            {
                Id = "fcm3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                FeaturedCollectionId = "fc1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                MangaId = "m1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y", // The Martial Arts Master
                IsDeleted = false
            },

            // Romance Collection
            new FeaturedCollectionManga
            {
                Id = "fcm4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                FeaturedCollectionId = "fc2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p",
                MangaId = "m5o6p7q8-r9s0-1t2u-3v4w-5x6y7z8a9b0c", // The Historical Romance
                IsDeleted = false
            },
            new FeaturedCollectionManga
            {
                Id = "fcm5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                FeaturedCollectionId = "fc2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p",
                MangaId = "m9s0t1u2-v3w4-5x6y-7z8a-9b0c1d2e3f4g", // The Drama Queen
                IsDeleted = false
            },

            // Fantasy Adventures
            new FeaturedCollectionManga
            {
                Id = "fcm6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                FeaturedCollectionId = "fc3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                MangaId = "m3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q", // Magical Academy
                IsDeleted = false
            },
            new FeaturedCollectionManga
            {
                Id = "fcm7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                FeaturedCollectionId = "fc3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                MangaId = "m7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y", // Starlight Academy
                IsDeleted = false
            },
            new FeaturedCollectionManga
            {
                Id = "fcm8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                FeaturedCollectionId = "fc3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                MangaId = "m2v3w4x5-y6z7-8a9b-0c1d-2e3f4g5h6i7j", // The Fantasy Kingdom
                IsDeleted = false
            },

            // School Life Stories
            new FeaturedCollectionManga
            {
                Id = "fcm9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                FeaturedCollectionId = "fc4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                MangaId = "m3w4x5y6-z7a8-9b0c-1d2e-3f4g5h6i7j8k", // The School Festival
                IsDeleted = false
            },
            new FeaturedCollectionManga
            {
                Id = "fcm0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                FeaturedCollectionId = "fc4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                MangaId = "m7a8b9c0-d1e2-3f4g-5h6i-7j8k9l0m1n2o", // The Supernatural Academy
                IsDeleted = false
            },

            // Mystery & Thriller
            new FeaturedCollectionManga
            {
                Id = "fcm1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y",
                FeaturedCollectionId = "fc5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                MangaId = "m4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r", // The Detective's Case
                IsDeleted = false
            },
            new FeaturedCollectionManga
            {
                Id = "fcm2l3m4n6-o6p7-8q9r-0s1t-2u3v4w5x6y7z",
                FeaturedCollectionId = "fc5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                MangaId = "m2l3m4n6-o6p7-8q9r-0s1t-2u3v4w5x6y7z", // The Psychological Thriller
                IsDeleted = false
            },
            new FeaturedCollectionManga
            {
                Id = "fcm3m4n5o7-p7q8-9r0s-1t2u-3v4w5x6y7z8a",
                FeaturedCollectionId = "fc5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                MangaId = "m1u2v3w4-x5y6-7z8a-9b0c-1d2e3f4g5h6i", // The Mystery Box
                IsDeleted = false
            },

            // Sports & Competition
            new FeaturedCollectionManga
            {
                Id = "fcm4n5o6p7-q8r9-0s1t-2u3v-4w5x6y7z8a9b",
                FeaturedCollectionId = "fc6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                MangaId = "m5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s", // The Sports Star
                IsDeleted = false
            },
            new FeaturedCollectionManga
            {
                Id = "fcm5o6p7q8-r9s0-1t2u-3v4w-5x6y7z8a9b0c",
                FeaturedCollectionId = "fc6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                MangaId = "m0t1u2v3-w4x5-6y7z-8a9b-0c1d2e3f4g5h", // The Sports Tournament
                IsDeleted = false
            },

            // Cooking & Food
            new FeaturedCollectionManga
            {
                Id = "fcm6p7q8r9-s0t1-2u3v-4w5x-6y7z8a9b0c1d",
                FeaturedCollectionId = "fc7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                MangaId = "m6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t", // The Cooking Master
                IsDeleted = false
            },
            new FeaturedCollectionManga
            {
                Id = "fcm7q8r9s0-t1u2-3v4w-5x6y-7z8a9b0c1d2e",
                FeaturedCollectionId = "fc7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                MangaId = "m4x5y6z7-a8b9-0c1d-2e3f-4g5h6i7j8k9l", // The Cooking Competition
                IsDeleted = false
            },

            // Historical Tales
            new FeaturedCollectionManga
            {
                Id = "fcm8r9s0t1-u2v3-4w5x-6y7z-8a9b0c1d2e3f",
                FeaturedCollectionId = "fc8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                MangaId = "m5o6p7q8-r9s0-1t2u-3v4w-5x6y7z8a9b0c", // The Historical Romance
                IsDeleted = false
            },

            // Supernatural & Horror
            new FeaturedCollectionManga
            {
                Id = "fcm9s0t1u2-v3w4-5x6y-7z8a-9b0c1d2e3f4g",
                FeaturedCollectionId = "fc9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                MangaId = "m6p7q8r9-s0t1-2u3v-4w5x-6y7z8a9b0c1d", // The Horror Mansion
                IsDeleted = false
            },
            new FeaturedCollectionManga
            {
                Id = "fcm0t1u2v3-w4x5-6y7z-8a9b-0c1d2e3f4g5h",
                FeaturedCollectionId = "fc9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                MangaId = "m4n5o6p7-q8r9-0s1t-2u3v-4w5x6y7z8a9b", // The Supernatural Detective
                IsDeleted = false
            },

            // Music & Arts
            new FeaturedCollectionManga
            {
                Id = "fcm1u2v3w4-x5y6-7z8a-9b0c-1d2e3f4g5h6i",
                FeaturedCollectionId = "fc0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                MangaId = "m0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x", // The Music Prodigy
                IsDeleted = false
            },

            // Additional FeaturedCollectionMangas for new collections
            // Adventure & Exploration
            new FeaturedCollectionManga
            {
                Id = "fcm2v3w4x5-y6z7-8a9b-0c1d-2e3f4g5h6i7j",
                FeaturedCollectionId = "fc1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y",
                MangaId = "m7q8r9s0-t1u2-3v4w-5x6y-7z8a9b0c1d2e", // The Adventure Quest
                IsDeleted = false
            },
            new FeaturedCollectionManga
            {
                Id = "fcm3w4x5y6-z7a8-9b0c-1d2e-3f4g5h6i7j8k",
                FeaturedCollectionId = "fc1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y",
                MangaId = "m2v3w4x5-y6z7-8a9b-0c1d-2e3f4g5h6i7j", // The Fantasy Kingdom
                IsDeleted = false
            },

            // Comedy & Humor
            new FeaturedCollectionManga
            {
                Id = "fcm4x5y6z7-a8b9-0c1d-2e3f-4g5h6i7j8k9l",
                FeaturedCollectionId = "fc2l3m4n6-o6p7-8q9r-0s1t-2u3v4w5x6y7z",
                MangaId = "m8r9s0t1-u2v3-4w5x-6y7z-8a9b0c1d2e3f", // The Comedy Club
                IsDeleted = false
            },

            // Drama & Emotion
            new FeaturedCollectionManga
            {
                Id = "fcm5y6z7a8-b9c0-1d2e-3f4g-5h6i7j8k9l0m",
                FeaturedCollectionId = "fc3m4n5o7-p7q8-9r0s-1t2u-3v4w5x6y7z8a",
                MangaId = "m9s0t1u2-v3w4-5x6y-7z8a-9b0c1d2e3f4g", // The Drama Queen
                IsDeleted = false
            },

            // Military & Strategy
            new FeaturedCollectionManga
            {
                Id = "fcm6z7a8b9-c0d1-2e3f-4g5h-6i7j8k9l0m1n",
                FeaturedCollectionId = "fc4n5o6p8-q8r9-0s1t-2u3v-4w5x6y7z8a9b",
                MangaId = "m3m4n5o7-p7q8-9r0s-1t2u-3v4w5x6y7z8a", // The Military Academy
                IsDeleted = false
            },

            // Psychological & Mind Games
            new FeaturedCollectionManga
            {
                Id = "fcm7a8b9c0-d1e2-3f4g-5h6i-7j8k9l0m1n2o",
                FeaturedCollectionId = "fc5o6p7q9-r9s0-1t2u-3v4w-5x6y7z8a9b0c",
                MangaId = "m2l3m4n6-o6p7-8q9r-0s1t-2u3v4w5x6y7z", // The Psychological Thriller
                IsDeleted = false
            },
            new FeaturedCollectionManga
            {
                Id = "fcm8b9c0d1-e2f3-4g5h-6i7j-8k9l0m1n2o3p",
                FeaturedCollectionId = "fc5o6p7q9-r9s0-1t2u-3v4w-5x6y7z8a9b0c",
                MangaId = "m6z7a8b9-c0d1-2e3f-4g5h-6i7j8k9l0m1n", // The Psychological Game
                IsDeleted = false
            },

            // Slice of Life & Daily Stories
            new FeaturedCollectionManga
            {
                Id = "fcm9c0d1e2-f3g4-5h6i-7j8k-9l0m1n2o3p4q",
                FeaturedCollectionId = "fc6p7q8r0-s0t1-2u3v-4w5x-6y7z8a9b0c1d",
                MangaId = "m6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t", // The Cooking Master
                IsDeleted = false
            },
            new FeaturedCollectionManga
            {
                Id = "fcm1e2f3g4-h5i6-7j8k-9l0m-1n2o3p4q5r6s",
                FeaturedCollectionId = "fc7q8r9s1-t1u2-3v4w-5x6y-7z8a9b0c1d2e",
                MangaId = "m3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q", // Magical Academy
                IsDeleted = false
            },
            new FeaturedCollectionManga
            {
                Id = "fcm2f3g4h5-i6j7-8k9l-0m1n-2o3p4q5r6s7t",
                FeaturedCollectionId = "fc7q8r9s1-t1u2-3v4w-5x6y-7z8a9b0c1d2e",
                MangaId = "m7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y", // Starlight Academy
                IsDeleted = false
            },
            new FeaturedCollectionManga
            {
                Id = "fcm3g4h5i6-j7k8-9l0m-1n2o-3p4q5r6s7t8u",
                FeaturedCollectionId = "fc7q8r9s1-t1u2-3v4w-5x6y-7z8a9b0c1d2e",
                MangaId = "m7a8b9c0-d1e2-3f4g-5h6i-7j8k9l0m1n2o", // The Supernatural Academy
                IsDeleted = false
            },

            // Martial Arts & Combat
            new FeaturedCollectionManga
            {
                Id = "fcm4h5i6j7-k8l9-0m1n-2o3p-4q5r6s7t8u9v",
                FeaturedCollectionId = "fc8r9s0t2-u2v3-4w5x-6y7z-8a9b0c1d2e3f",
                MangaId = "m1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y", // The Martial Arts Master
                IsDeleted = false
            },
            new FeaturedCollectionManga
            {
                Id = "fcm5i6j7k8-l9m0-1n2o-3p4q-5r6s7t8u9v0w",
                FeaturedCollectionId = "fc8r9s0t2-u2v3-4w5x-6y7z-8a9b0c1d2e3f",
                MangaId = "m5y6z7a8-b9c0-1d2e-3f4g-5h6i7j8k9l0m", // The Martial Arts Tournament
                IsDeleted = false
            },

            // Sci-Fi & Technology
            new FeaturedCollectionManga
            {
                Id = "fcm6j7k8l9-m0n1-2o3p-4q5r-6s7t8u9v0w1x",
                FeaturedCollectionId = "fc9s0t1u3-v3w4-5x6y-7z8a-9b0c1d2e3f4g",
                MangaId = "m2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p", // Cyberpunk Dreams
                IsDeleted = false
            },
            new FeaturedCollectionManga
            {
                Id = "fcm7k8l9m0-n1o2-3p4q-5r6s-7t8u9v0w1x2y",
                FeaturedCollectionId = "fc9s0t1u3-v3w4-5x6y-7z8a-9b0c1d2e3f4g",
                MangaId = "m8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b", // The Last Hero
                IsDeleted = false
            },

            // Horror & Suspense
            new FeaturedCollectionManga
            {
                Id = "fcm8l9m0n1-o2p3-4q5r-6s7t-8u9v0w1x2y3z",
                FeaturedCollectionId = "fc0t1u2v4-w4x5-6y7z-8a9b-0c1d2e3f4g5h",
                MangaId = "m6p7q8r9-s0t1-2u3v-4w5x-6y7z8a9b0c1d", // The Horror Mansion
                IsDeleted = false
            },
            new FeaturedCollectionManga
            {
                Id = "fcm9m0n1o2-p3q4-5r6s-7t8u-9v0w1x2y3z4a",
                FeaturedCollectionId = "fc0t1u2v4-w4x5-6y7z-8a9b-0c1d2e3f4g5h",
                MangaId = "m4n5o6p7-q8r9-0s1t-2u3v-4w5x6y7z8a9b", // The Supernatural Detective
                IsDeleted = false
            }
        );

        // Seed FeaturedCollectionPermissions
        modelBuilder.Entity<FeaturedCollectionPermission>().HasData(
            // Best Action Manga Collection Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                FeaturedCollectionId = "fc1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                UserId = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n", // Phuc Lo
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p",
                FeaturedCollectionId = "fc1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                UserId = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o", // Sarah Johnson
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            },

            // Romance Collection Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                FeaturedCollectionId = "fc2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p",
                UserId = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o", // Sarah Johnson
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                FeaturedCollectionId = "fc2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p",
                UserId = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p", // Michael Chen
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            },

            // Fantasy Adventures Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                FeaturedCollectionId = "fc3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                UserId = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p", // Michael Chen
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                FeaturedCollectionId = "fc3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                UserId = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q", // Emma Wilson
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            },

            // School Life Stories Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                FeaturedCollectionId = "fc4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                UserId = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q", // Emma Wilson
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                FeaturedCollectionId = "fc4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                UserId = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r", // Alex Rivera
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            },

            // Mystery & Thriller Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                FeaturedCollectionId = "fc5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                UserId = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r", // Alex Rivera
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                FeaturedCollectionId = "fc5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                UserId = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s", // Hiroshi Tanaka
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            },

            // Sports & Competition Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y",
                FeaturedCollectionId = "fc6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                UserId = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s", // Hiroshi Tanaka
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp2l3m4n6-o6p7-8q9r-0s1t-2u3v4w5x6y7z",
                FeaturedCollectionId = "fc6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                UserId = "0d1e2f3g-4h5i-6j7k-8l9m-0n1o2p3q4r5s6t", // Yuki Sato
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            },

            // Cooking & Food Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp3m4n5o7-p7q8-9r0s-1t2u-3v4w5x6y7z8a",
                FeaturedCollectionId = "fc7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                UserId = "0d1e2f3g-4h5i-6j7k-8l9m-0n1o2p3q4r5s6t", // Yuki Sato
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp4n5o6p7-q8r9-0s1t-2u3v-4w5x6y7z8a9b",
                FeaturedCollectionId = "fc7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                UserId = "1e2f3g4h-5i6j-7k8l-9m0n-1o2p3q4r5s6t7u", // David Kim
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            },

            // Historical Tales Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp5o6p7q8-r9s0-1t2u-3v4w-5x6y7z8a9b0c",
                FeaturedCollectionId = "fc8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                UserId = "1e2f3g4h-5i6j-7k8l-9m0n-1o2p3q4r5s6t7u", // David Kim
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp6p7q8r9-s0t1-2u3v-4w5x-6y7z8a9b0c1d",
                FeaturedCollectionId = "fc8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                UserId = "2f3g4h5i-6j7k-8l9m-0n1o-2p3q4r5s6t7u8v", // Lisa Park
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            },

            // Supernatural & Horror Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp7q8r9s0-t1u2-3v4w-5x6y-7z8a9b0c1d2e",
                FeaturedCollectionId = "fc9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                UserId = "2f3g4h5i-6j7k-8l9m-0n1o-2p3q4r5s6t7u8v", // Lisa Park
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp8r9s0t1-u2v3-4w5x-6y7z-8a9b0c1d2e3f",
                FeaturedCollectionId = "fc9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                UserId = "3g4h5i6j-7k8l-9m0n-1o2p-3q4r5s6t7u8v9w", // James Wilson
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            },

            // Music & Arts Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp9s0t1u2-v3w4-5x6y-7z8a-9b0c1d2e3f4g",
                FeaturedCollectionId = "fc0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                UserId = "3g4h5i6j-7k8l-9m0n-1o2p-3q4r5s6t7u8v9w", // James Wilson
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp0t1u2v3-w4x5-6y7z-8a9b-0c1d2e3f4g5h",
                FeaturedCollectionId = "fc0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                UserId = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x", // Maria Garcia
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            },

            // Additional FeaturedCollectionPermissions for new collections
            // Adventure & Exploration Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp1u2v3w4-x5y6-7z8a-9b0c-1d2e3f4g5h6i",
                FeaturedCollectionId = "fc1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y",
                UserId = "5i6j7k8l-9m0n-1o2p-3q4r-5s6t7u8v9w0x1y", // Taylor Smith
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp2v3w4x5-y6z7-8a9b-0c1d-2e3f4g5h6i7j",
                FeaturedCollectionId = "fc1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y",
                UserId = "6j7k8l9m-0n1o-2p3q-4r5s-6t7u8v9w0x1y2z", // Wei Chen
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            },

            // Comedy & Humor Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp3w4x5y6-z7a8-9b0c-1d2e-3f4g5h6i7j8k",
                FeaturedCollectionId = "fc2l3m4n6-o6p7-8q9r-0s1t-2u3v4w5x6y7z",
                UserId = "6j7k8l9m-0n1o-2p3q-4r5s-6t7u8v9w0x1y2z", // Wei Chen
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp4x5y6z7-a8b9-0c1d-2e3f-4g5h6i7j8k9l",
                FeaturedCollectionId = "fc2l3m4n6-o6p7-8q9r-0s1t-2u3v4w5x6y7z",
                UserId = "7k8l9m0n-1o2p-3q4r-5s6t-7u8v9w0x1y2z3a", // Sofia Rodriguez
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            },

            // Drama & Emotion Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp5y6z7a8-b9c0-1d2e-3f4g-5h6i7j8k9l0m",
                FeaturedCollectionId = "fc3m4n5o7-p7q8-9r0s-1t2u-3v4w5x6y7z8a",
                UserId = "7k8l9m0n-1o2p-3q4r-5s6t-7u8v9w0x1y2z3a", // Sofia Rodriguez
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp6z7a8b9-c0d1-2e3f-4g5h-6i7j8k9l0m1n",
                FeaturedCollectionId = "fc3m4n5o7-p7q8-9r0s-1t2u-3v4w5x6y7z8a",
                UserId = "8l9m0n1o-2p3q-4r5s-6t7u-8v9w0x1y2z3a4b", // Jordan Lee
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            },

            // Military & Strategy Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp7a8b9c0-d1e2-3f4g-5h6i-7j8k9l0m1n2o",
                FeaturedCollectionId = "fc4n5o6p8-q8r9-0s1t-2u3v-4w5x6y7z8a9b",
                UserId = "8l9m0n1o-2p3q-4r5s-6t7u-8v9w0x1y2z3a4b", // Jordan Lee
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp8b9c0d1-e2f3-4g5h-6i7j-8k9l0m1n2o3p",
                FeaturedCollectionId = "fc4n5o6p8-q8r9-0s1t-2u3v-4w5x6y7z8a9b",
                UserId = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x", // Maria Garcia
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            },

            // Psychological & Mind Games Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp9c0d1e2-f3g4-5h6i-7j8k-9l0m1n2o3p4q",
                FeaturedCollectionId = "fc5o6p7q9-r9s0-1t2u-3v4w-5x6y7z8a9b0c",
                UserId = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x", // Maria Garcia
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp0d1e2f3-g4h5-6i7j-8k9l-0m1n2o3p4q5r",
                FeaturedCollectionId = "fc5o6p7q9-r9s0-1t2u-3v4w-5x6y7z8a9b0c",
                UserId = "5i6j7k8l-9m0n-1o2p-3q4r-5s6t7u8v9w0x1y", // Taylor Smith
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            },

            // Slice of Life & Daily Stories Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp1e2f3g4-h5i6-7j8k-9l0m-1n2o3p4q5r6s",
                FeaturedCollectionId = "fc6p7q8r0-s0t1-2u3v-4w5x-6y7z8a9b0c1d",
                UserId = "5i6j7k8l-9m0n-1o2p-3q4r-5s6t7u8v9w0x1y", // Taylor Smith
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp2f3g4h5-i6j7-8k9l-0m1n-2o3p4q5r6s7t",
                FeaturedCollectionId = "fc6p7q8r0-s0t1-2u3v-4w5x-6y7z8a9b0c1d",
                UserId = "6j7k8l9m-0n1o-2p3q-4r5s-6t7u8v9w0x1y2z", // Wei Chen
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            },

            // Supernatural & Magic Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp3g4h5i6-j7k8-9l0m-1n2o-3p4q5r6s7t8u",
                FeaturedCollectionId = "fc7q8r9s1-t1u2-3v4w-5x6y-7z8a9b0c1d2e",
                UserId = "6j7k8l9m-0n1o-2p3q-4r5s-6t7u8v9w0x1y2z", // Wei Chen
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp4h5i6j7-k8l9-0m1n-2o3p-4q5r6s7t8u9v",
                FeaturedCollectionId = "fc7q8r9s1-t1u2-3v4w-5x6y-7z8a9b0c1d2e",
                UserId = "7k8l9m0n-1o2p-3q4r-5s6t-7u8v9w0x1y2z3a", // Sofia Rodriguez
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            },

            // Martial Arts & Combat Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp5i6j7k8-l9m0-1n2o-3p4q-5r6s7t8u9v0w",
                FeaturedCollectionId = "fc8r9s0t2-u2v3-4w5x-6y7z-8a9b0c1d2e3f",
                UserId = "7k8l9m0n-1o2p-3q4r-5s6t-7u8v9w0x1y2z3a", // Sofia Rodriguez
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp6j7k8l9-m0n1-2o3p-4q5r-6s7t8u9v0w1x",
                FeaturedCollectionId = "fc8r9s0t2-u2v3-4w5x-6y7z-8a9b0c1d2e3f",
                UserId = "8l9m0n1o-2p3q-4r5s-6t7u-8v9w0x1y2z3a4b", // Jordan Lee
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            },

            // Sci-Fi & Technology Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp7k8l9m0-n1o2-3p4q-5r6s-7t8u9v0w1x2y",
                FeaturedCollectionId = "fc9s0t1u3-v3w4-5x6y-7z8a-9b0c1d2e3f4g",
                UserId = "8l9m0n1o-2p3q-4r5s-6t7u-8v9w0x1y2z3a4b", // Jordan Lee
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp8l9m0n1-o2p3-4q5r-6s7t-8u9v0w1x2y3z",
                FeaturedCollectionId = "fc9s0t1u3-v3w4-5x6y-7z8a-9b0c1d2e3f4g",
                UserId = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x", // Maria Garcia
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            },

            // Horror & Suspense Permissions
            new FeaturedCollectionPermission
            {
                Id = "fcp9m0n1o2-p3q4-5r6s-7t8u-9v0w1x2y3z4a",
                FeaturedCollectionId = "fc0t1u2v4-w4x5-6y7z-8a9b-0c1d2e3f4g5h",
                UserId = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x", // Maria Garcia
                PermissionType = CollectionPermissionType.Write,
                IsDeleted = false
            },
            new FeaturedCollectionPermission
            {
                Id = "fcp0n1o2p3-q4r5-6s7t-8u9v-0w1x2y3z4a5b",
                FeaturedCollectionId = "fc0t1u2v4-w4x5-6y7z-8a9b-0c1d2e3f4g5h",
                UserId = "5i6j7k8l-9m0n-1o2p-3q4r-5s6t7u8v9w0x1y", // Taylor Smith
                PermissionType = CollectionPermissionType.Read,
                IsDeleted = false
            }
        );

        // Seed MangaInteractions
        modelBuilder.Entity<MangaInteraction>().HasData(
            // User 1 - Phuc Lo interactions
            new MangaInteraction
            {
                Id = "mi1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                UserId = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n", // Phuc Lo
                MangaId = "m1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o", // The Last Samurai's Legacy
                ChapterId = "c1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o", // Chapter 1
                InteractionType = MangaInteractionType.Like,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                IsDeleted = false
            },
            new MangaInteraction
            {
                Id = "mi2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p",
                UserId = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n", // Phuc Lo
                MangaId = "m2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p", // Cyberpunk Dreams
                ChapterId = "c2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p", // Chapter 1
                InteractionType = MangaInteractionType.Bookmark,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                IsDeleted = false
            },

            // User 2 - Sarah Johnson interactions
            new MangaInteraction
            {
                Id = "mi3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                UserId = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o", // Sarah Johnson
                MangaId = "m3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q", // Magical Academy
                ChapterId = "c3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q", // Chapter 1
                InteractionType = MangaInteractionType.Read,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                IsDeleted = false
            },
            new MangaInteraction
            {
                Id = "mi4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                UserId = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o", // Sarah Johnson
                MangaId = "m4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r", // The Detective's Case
                ChapterId = "c4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r", // Chapter 1
                InteractionType = MangaInteractionType.Share,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                IsDeleted = false
            },

            // User 3 - Michael Chen interactions
            new MangaInteraction
            {
                Id = "mi5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                UserId = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p", // Michael Chen
                MangaId = "m5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s", // The Sports Star
                ChapterId = "c5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s", // Chapter 1
                InteractionType = MangaInteractionType.Like,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                IsDeleted = false
            },
            new MangaInteraction
            {
                Id = "mi6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                UserId = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p", // Michael Chen
                MangaId = "m6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t", // The Cooking Master
                ChapterId = "c6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t", // Chapter 1
                InteractionType = MangaInteractionType.Bookmark,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                IsDeleted = false
            },

            // User 4 - Emma Wilson interactions
            new MangaInteraction
            {
                Id = "mi7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                UserId = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q", // Emma Wilson
                MangaId = "m7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y", // Starlight Academy
                ChapterId = "c7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y", // Chapter 1
                InteractionType = MangaInteractionType.Report,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                IsDeleted = false
            },
            new MangaInteraction
            {
                Id = "mi8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                UserId = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q", // Emma Wilson
                MangaId = "m8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b", // The Last Hero
                ChapterId = "c8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b", // Chapter 1
                InteractionType = MangaInteractionType.Share,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                IsDeleted = false
            },

            // User 5 - Alex Rivera interactions
            new MangaInteraction
            {
                Id = "mi9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                UserId = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r", // Alex Rivera
                MangaId = "m9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w", // The Music Prodigy
                ChapterId = "c9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w", // Chapter 1
                InteractionType = MangaInteractionType.Like,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                IsDeleted = false
            },
            new MangaInteraction
            {
                Id = "mi0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                UserId = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r", // Alex Rivera
                MangaId = "m0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x", // The Martial Arts Master
                ChapterId = "c0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x", // Chapter 1
                InteractionType = MangaInteractionType.Read,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE,
                IsDeleted = false
            }
        );

        // Seed Comments
        modelBuilder.Entity<Comment>().HasData(
            // Parent Comments (no ParentCommentId)
            new Comment
            {
                Id = "cm1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                MangaId = "m1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o", // The Last Samurai's Legacy
                UserId = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o", // Sarah Johnson
                ParentCommentId = null,
                Content = "This manga has such beautiful artwork! The samurai theme is really well executed.",
                IsSpoiler = false,
                ChapterId = "c1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o", // Chapter 1
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Comment
            {
                Id = "cm2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p",
                MangaId = "m2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p", // Cyberpunk Dreams
                UserId = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p", // Michael Chen
                ParentCommentId = null,
                Content = "The cyberpunk setting is amazing! Love the futuristic elements.",
                IsSpoiler = false,
                ChapterId = "c2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p", // Chapter 1
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Comment
            {
                Id = "cm3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                MangaId = "m3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q", // Magical Academy
                UserId = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q", // Emma Wilson
                ParentCommentId = null,
                Content = "I wish I could go to a magical academy! The spells are so creative.",
                IsSpoiler = false,
                ChapterId = "c3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q", // Chapter 1
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Additional comments
            new Comment
            {
                Id = "cm4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                MangaId = "m4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                UserId = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r",
                ParentCommentId = null,
                Content = "The detective's logic is so sharp! Love the suspense.",
                IsSpoiler = false,
                ChapterId = "c4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Comment
            {
                Id = "cm5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                MangaId = "m5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                UserId = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s",
                ParentCommentId = null,
                Content = "The main character's growth is inspiring!",
                IsSpoiler = false,
                ChapterId = "c5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Comment
            {
                Id = "cm6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                MangaId = "m6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                UserId = "0d1e2f3g-4h5i-6j7k-8l9m-0n1o2p3q4r5s6t",
                ParentCommentId = null,
                Content = "I tried the recipe from this chapter, it was delicious!",
                IsSpoiler = false,
                ChapterId = "c6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Comment
            {
                Id = "cm7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                MangaId = "m7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                UserId = "1e2f3g4h-5i6j-7k8l-9m0n-1o2p3q4r5s6t7u",
                ParentCommentId = null,
                Content = "The magical creatures are so cute!",
                IsSpoiler = false,
                ChapterId = "c7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Child comment (reply)
            new Comment
            {
                Id = "cm8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                MangaId = "m8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                UserId = "2f3g4h5i-6j7k-8l9m-0n1o-2p3q4r5s6t7u8v",
                ParentCommentId = "cm4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                Content = "I agree, the suspense is killing me!",
                IsSpoiler = false,
                ChapterId = "c8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Spoiler comment
            new Comment
            {
                Id = "cm9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                MangaId = "m0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                UserId = "3g4h5i6j-7k8l-9m0n-1o2p-3q4r5s6t7u8v9w",
                ParentCommentId = null,
                Content = "Spoiler: The protagonist gets a new rival in the next chapter!",
                IsSpoiler = true,
                ChapterId = "c9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // General manga comment (no chapter)
            new Comment
            {
                Id = "cm0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                MangaId = "m1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y",
                UserId = "4h5i6j7k-8l9m-0n1o-2p3q-4r5s6t7u8v9w0x",
                ParentCommentId = null,
                Content = "This series is underrated!",
                IsSpoiler = false,
                ChapterId = null,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Another reply
            new Comment
            {
                Id = "cm1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y",
                MangaId = "m1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                UserId = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p",
                ParentCommentId = "cm1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                Content = "Absolutely! The art is top-notch.",
                IsSpoiler = false,
                ChapterId = "c1a2b3c4-d5e6-7f8g-9h0i-1j2k3l4m5n6o",
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // General comment, different user
            new Comment
            {
                Id = "cm2l3m4n6-o6p7-8q9r-0s1t-2u3v4w5x6y7z",
                MangaId = "m2b3c4d5-e6f7-8g9h-0i1j-2k3l4m5n6o7p",
                UserId = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q",
                ParentCommentId = null,
                Content = "The world-building is so immersive!",
                IsSpoiler = false,
                ChapterId = null,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Another spoiler
            new Comment
            {
                Id = "cm3m4n5o7-p7q8-9r0s-1t2u-3v4w5x6y7z8a",
                MangaId = "m3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                UserId = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r",
                ParentCommentId = null,
                Content = "Spoiler: The headmaster is not who they seem!",
                IsSpoiler = true,
                ChapterId = "c3c4d5e6-f7g8-9h0i-1j2k-3l4m5n6o7p8q",
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Additional comments
            new Comment
            {
                Id = "cm4n5o6p8-q8r9-0s1t-2u3v-4w5x6y7z8a9b",
                MangaId = "m4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                UserId = "5i6j7k8l-9m0n-1o2p-3q4r-5s6t7u8v9w0x1y",
                ParentCommentId = null,
                Content = "The character development is so well written!",
                IsSpoiler = false,
                ChapterId = "c4d5e6f7-g8h9-0i1j-2k3l-4m5n6o7p8q9r",
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            new Comment
            {
                Id = "cm5o6p7q9-r9s0-1t2u-3v4w-5x6y7z8a9b0c",
                MangaId = "m5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                UserId = "6j7k8l9m-0n1o-2p3q-4r5s-6t7u8v9w0x1y2z",
                ParentCommentId = null,
                Content = "The action scenes are so dynamic!",
                IsSpoiler = false,
                ChapterId = "c5e6f7g8-h9i0-1j2k-3l4m-5n6o7p8q9r0s",
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Reply to a previous comment
            new Comment
            {
                Id = "cm6p7q8r0-s0t1-2u3v-4w5x-6y7z8a9b0c1d",
                MangaId = "m6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                UserId = "7k8l9m0n-1o2p-3q4r-5s6t-7u8v9w0x1y2z3a",
                ParentCommentId = "cm6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                Content = "I tried it too! Which recipe did you make?",
                IsSpoiler = false,
                ChapterId = "c6f7g8h9-i0j1-2k3l-4m5n-6o7p8q9r0s1t",
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Spoiler comment
            new Comment
            {
                Id = "cm7q8r9s1-t1u2-3v4w-5x6y-7z8a9b0c1d2e",
                MangaId = "m7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                UserId = "8l9m0n1o-2p3q-4r5s-6t7u-8v9w0x1y2z3a4b",
                ParentCommentId = null,
                Content = "Spoiler: The magical creatures are actually humans in disguise!",
                IsSpoiler = true,
                ChapterId = "c7g8h9i1-j1k2-3l4m-5n6o-7p8q9r0s1t2y",
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // General manga comment (no chapter)
            new Comment
            {
                Id = "cm8r9s0t2-u2v3-4w5x-6y7z-8a9b0c1d2e3f",
                MangaId = "m8h9i0j2-k2l3-4m5n-6o7p-8q9r0s1t2u3b",
                UserId = "4x5y6z7a-8b9c-0d1e-2f3g-4h5i6j7k8l9m0n",
                ParentCommentId = null,
                Content = "This is my favorite manga series!",
                IsSpoiler = false,
                ChapterId = null,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Another reply
            new Comment
            {
                Id = "cm9s0t1u3-v3w4-5x6y-7z8a-9b0c1d2e3f4g",
                MangaId = "m9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                UserId = "5y6z7a8b-9c0d-1e2f-3g4h-5i6j7k8l9m0n1o",
                ParentCommentId = "cm9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                Content = "I can't wait to see how this rivalry develops!",
                IsSpoiler = false,
                ChapterId = "c9i0j1k3-l3m4-5n6o-7p8q-9r0s1t2u3v4w",
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Parent comment
            new Comment
            {
                Id = "cm0t1u2v4-w4x5-6y7z-8a9b-0c1d2e3f4g5h",
                MangaId = "m0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                UserId = "6z7a8b9c-0d1e-2f3g-4h5i-6j7k8l9m0n1o2p",
                ParentCommentId = null,
                Content = "The music scenes are so emotional!",
                IsSpoiler = false,
                ChapterId = "c0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Reply to music comment
            new Comment
            {
                Id = "cm1u2v3w5-x5y6-7z8a-9b0c-1d2e3f4g5h6i",
                MangaId = "m0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                UserId = "7a8b9c0d-1e2f-3g4h-5i6j-7k8l9m0n1o2p3q",
                ParentCommentId = "cm0t1u2v4-w4x5-6y7z-8a9b-0c1d2e3f4g5h",
                Content = "The soundtrack would be amazing!",
                IsSpoiler = false,
                ChapterId = "c0j1k2l4-m4n5-6o7p-8q9r-0s1t2u3v4w5x",
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // General comment
            new Comment
            {
                Id = "cm2v3w4x6-y6z7-8a9b-0c1d-2e3f4g5h6i7j",
                MangaId = "m1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y",
                UserId = "8b9c0d1e-2f3g-4h5i-6j7k-8l9m0n1o2p3q4r",
                ParentCommentId = null,
                Content = "The art style is so unique and beautiful!",
                IsSpoiler = false,
                ChapterId = null,
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            },
            // Final spoiler comment
            new Comment
            {
                Id = "cm3w4x5y7-z7a8-9b0c-1d2e-3f4g5h6i7j8k",
                MangaId = "m2l3m4n6-o6p7-8q9r-0s1t-2u3v4w5x6y7z",
                UserId = "9c0d1e2f-3g4h-5i6j-7k8l-9m0n1o2p3q4r5s",
                ParentCommentId = null,
                Content = "Spoiler: The main character discovers their true identity!",
                IsSpoiler = true,
                ChapterId = "c1k2l3m5-n5o6-7p8q-9r0s-1t2u3v4w5x6y",
                CreatedAt = SEED_DATE,
                UpdatedAt = SEED_DATE
            }
        );
    }
}