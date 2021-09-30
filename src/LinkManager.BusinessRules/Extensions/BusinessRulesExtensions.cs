using LinkManager.BusinessRules.Account.Handlers;
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

                // account
                .AddScoped<IForgotPassowordHandler, ForgotPassowordHandler>()
                .AddScoped<IForgotPasswordExpiredHandler, ForgotPasswordExpiredHandler>()
                .AddScoped<IResetPasswordHandler, ResetPasswordHandler>()

                // users
                .AddScoped<ICreateUserHandler, CreateUserHandler>()
                .AddScoped<IUpdateUserHandler, UpdateUserHandler>()
                .AddScoped<IUpdatePasswordHandler, UpdatePasswordHandler>()
                .AddScoped<IGetUserByIdHandler, GetUserByIdHandler>()

                // companies
                .AddScoped<ICreateCompanyHandler, CreateCompanyHandler>();
        }
    }
}