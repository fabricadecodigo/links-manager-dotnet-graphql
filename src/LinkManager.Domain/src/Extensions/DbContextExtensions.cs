using LinkManager.Domain.src.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace LinkManager.Domain.src.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddMongoDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddScoped(sp =>
                    new DbContext(
                        sp.GetRequiredService<MongoClient>().GetDatabase(configuration.GetConnectionString("MONGODB_DATABASE"))
                    ))
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ICompanyRepository, CompanyRepository>()
                .AddScoped<ILinkRepository, LinkRepository>()
                .AddScoped<IForgotPasswordRepository, ForgotPasswordRepository>();
        }
    }
}