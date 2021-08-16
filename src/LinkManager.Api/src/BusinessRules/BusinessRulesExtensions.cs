using LinkManager.Api.src.BusinessRules.Onboarding.Handlers;
using LinkManager.Api.src.BusinessRules.Authentication.Handlers;
using LinkManager.Api.src.BusinessRules.Users.Handlers;
using Microsoft.Extensions.DependencyInjection;
using LinkManager.Api.src.BusinessRules.Companies.Handlers;

namespace LinkManager.Api.src.BusinessRules
{
    public static class BusinessRulesExtensions
    {
        public static IServiceCollection AddBusinessRules(this IServiceCollection services)
        {
            return services
                // Onboarding
                .AddScoped<ICreateAccountHandler, CreateAccountHandler>()
                // Authentication
                .AddScoped<ILoginHandler, LoginHandler>()
                // users
                .AddScoped<IUpdateUserHandler, UpdateUserHandler>()
                .AddScoped<IGetUserByIdHandler, GetUserByIdHandler>()
                .AddScoped<IUpdatePasswordHandler, UpdatePasswordHandler>()
                // Companies
                .AddScoped<IUpdateCompanyHandler, UpdateCompanyHandler>();
        }
    }
}