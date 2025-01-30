using Application.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
        services
            .AddScoped(typeof(IRepositoryBase<,,>), typeof(RepositoryBase<,,>))
            .AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>))
            .AddScoped<IEncryptionRepository, EncryptionRepository>()
            .AddScoped<IAuthenticationRepository, AuthenticationRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<ITokenRepository, TokenRepository>()
            ;
    }
}
