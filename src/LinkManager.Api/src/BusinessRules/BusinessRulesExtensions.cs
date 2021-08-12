using LinkManager.Api.src.BusinessRules.Authentication.Handlers;
using LinkManager.Api.src.BusinessRules.Users.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace LinkManager.Api.src.BusinessRules
{
    public static class BusinessRulesExtensions
    {
        public static IServiceCollection AddBusinessRules(this IServiceCollection services)
        {
            return services
                // Authentication
                .AddScoped<ILoginHandler, LoginHandler>()
                // users
                .AddScoped<ICreateUserHandler, CreateUserHandler>()
                .AddScoped<IUpdateUserHandler, UpdateUserHandler>()
                .AddScoped<IGetUserByIdHandler, GetUserByIdHandler>()
                .AddScoped<IUpdatePasswordHandler, UpdatePasswordHandler>();
        }
    }
}