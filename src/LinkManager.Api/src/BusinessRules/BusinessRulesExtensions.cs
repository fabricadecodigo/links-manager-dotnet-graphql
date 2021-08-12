using LinkManager.Api.src.BusinessRules.Users.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace LinkManager.Api.src.BusinessRules
{
    public static class BusinessRulesExtensions
    {
        public static IServiceCollection AddBusinessRules(this IServiceCollection services)
        {
            return services
                // users
                .AddScoped<ICreateUserHandler, CreateUserHandler>()
                .AddScoped<IUpdateUserHandler, UpdateUserHandler>()
                .AddScoped<IUpdatePasswordHandler, UpdatePasswordHandler>();
        }
    }
}