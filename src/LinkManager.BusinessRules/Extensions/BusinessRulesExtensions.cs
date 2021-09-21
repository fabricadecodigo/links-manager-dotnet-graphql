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

                // users
                .AddScoped<ICreateUserHandler, CreateUserHandler>();
        }
    }
}