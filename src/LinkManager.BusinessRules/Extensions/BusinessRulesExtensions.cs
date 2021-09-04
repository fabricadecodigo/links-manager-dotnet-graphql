using LinkManager.BusinessRules.Account.Handlers;
using LinkManager.BusinessRules.Authentication.Handlers;
using LinkManager.BusinessRules.Companies.Handlers;
using LinkManager.BusinessRules.Emails.Handlers;
using LinkManager.BusinessRules.Links.Handlers;
using LinkManager.BusinessRules.Onboarding.Handlers;
using LinkManager.BusinessRules.Users.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace LinkManager.BusinessRules
{
    public static class BusinessRulesExtensions
    {
        public static IServiceCollection AddBusinessRules(this IServiceCollection services)
        {
            return services
                // Emails
                .AddScoped<ISendWellcomeEmailHandler, SendWellcomeEmailHandler>()
                .AddScoped<ISendForgotPasswordEmailHandler, SendForgotPasswordEmailHandler>()

                // Onboarding
                .AddScoped<ICreateAccountHandler, CreateAccountHandler>()

                // Authentication
                .AddScoped<ILoginHandler, LoginHandler>()

                // account
                .AddScoped<IForgotPassowordHandler, ForgotPassowordHandler>()
                .AddScoped<IForgotPasswordExpiredHandler, ForgotPasswordExpiredHandler>()
                .AddScoped<IResetPasswordHandler, ResetPasswordHandler>()

                // users
                .AddScoped<IUpdateUserHandler, UpdateUserHandler>()
                .AddScoped<IGetUserByIdHandler, GetUserByIdHandler>()
                .AddScoped<IUpdatePasswordHandler, UpdatePasswordHandler>()

                // Companies
                .AddScoped<IUpdateCompanyHandler, UpdateCompanyHandler>()
                .AddScoped<IGetCompanyByIdHandler, GetCompanyByIdHandler>()

                // Links
                .AddScoped<ICreateLinkHandler, CreateLinkHandler>()
                .AddScoped<IUpdateLinkHandler, UpdateLinkHandler>()
                .AddScoped<IDeleteLinkHandler, DeleteLinkHandler>()
                .AddScoped<IGetLinkByIdHandler, GetLinkByIdHandler>()
                .AddScoped<IGetLinkListHandler, GetLinkListHandler>()
                .AddScoped<IGetLinkListByCompanySlugHandler, GetLinkListByCompanySlugHandler>();
        }
    }
}