using Application.Interfaces;
using Domain.Configurations;
using Domain.Entities;
using Domain.Persistence;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
           .AddScoped(typeof(IRepositoryBase<,,>), typeof(RepositoryBase<,,>))
           .AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>))
           .AddScoped<IEncryptionRepository, EncryptionRepository>()
           .AddScoped<IAuthenticationRepository, AuthenticationRepository>()
           .AddScoped<IUserRepository, UserRepository>()
           .AddScoped<ITokenRepository, TokenRepository>()
           .AddScoped<IGenreRepository, GenreRepository>()
           .AddScoped<IAzureBlobRepository, AzureBlobRepository>()
           .AddScoped<ISasTokenGenerator, SasTokenGenerator>()
           .AddScoped<IMangaRepository, MangaRepository>()
           .AddScoped<IChapterRepository, ChapterRepository>()
           .AddScoped<IChapterImageRepository, ChapterImageRepository>()
           .AddScoped<IFeaturedCollectionRepository, FeaturedCollectionRepository>()
           .AddScoped<IFeaturedCollectionMangaRepository, FeaturedCollectionMangaRepository>()
           .AddScoped<IMangaGenreRepository, MangaGenreRepository>()
           .AddScoped<IFeaturedCollectionPermissionRepository, FeaturedCollectionPermissionRepository>()
           .AddScoped<IMangaInteractionRepository, MangaInteractionRepository>()
           .AddScoped<ICommentRepository, CommentRepository>()
           .AddScoped<ICommentReactionRepository, CommentReactionRepository>();
            ;
            return services;
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseSettings = services.GetOptions<DatabaseSettings>(nameof(DatabaseSettings));
            if (databaseSettings == null || string.IsNullOrEmpty(databaseSettings.ConnectionString))
                throw new ArgumentNullException("Connection string is not configured.");

            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(databaseSettings.ConnectionString,
                    builder =>
                        builder.MigrationsAssembly(typeof(MyDbContext).Assembly.FullName));
            });
            return services;
        }

        private static IServiceCollection AddAuthenticationInternal(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]!)),
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Issuer"],
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddHttpContextAccessor();
            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices()
                    .AddDatabase(configuration)
                    .AddAuthenticationInternal(configuration);
            return services;
        }

        public static void ConfigureAzureBlob(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AzureBlobSettings>(configuration.GetSection("AzureClient"));
        }
    }
}
