using LinkManager.BusinessRules.Authentication.Handlers;
using LinkManager.BusinessRules.Companies.Handlers;
using LinkManager.BusinessRules.Emails.Handlers;
using LinkManager.BusinessRules.Users.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace LinkManager.BusinessRules.Extensions
{
    public static class BusinessRulesExtensions
    {
        public static IServiceCollection AddBusinessRules(this IServiceCollection services)
        {
            return services
                // Emails
                .AddScoped<ISendWellcomeEmailHandler, SendWellcomeEmailHandler>()
                .AddScoped<ISendForgotPasswordEmailHandler, SendForgotPasswordEmailHandler>()

                // authentication
                .AddScoped<ILoginHandler, LoginHandler>()

                // users
                .AddScoped<ICreateUserHandler, CreateUserHandler>()

                // companies
                .AddScoped<ICreateCompanyHandler, CreateCompanyHandler>();
        }
    }
}