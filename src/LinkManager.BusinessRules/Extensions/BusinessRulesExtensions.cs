using LinkManager.BusinessRules.Account.Handlers;
using LinkManager.BusinessRules.Authentication.Handlers;
using LinkManager.BusinessRules.Companies.Handlers;
using LinkManager.BusinessRules.Emails.Handlers;
using LinkManager.BusinessRules.Links.Handlers;
using LinkManager.BusinessRules.Onboarding.Handlers;
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
                
                // account
                .AddScoped<ICreateAccountHandler, CreateAccountHandler>()
                .AddScoped<IForgotPassowordHandler, ForgotPassowordHandler>()
                .AddScoped<IForgotPasswordExpiredHandler, ForgotPasswordExpiredHandler>()
                .AddScoped<IResetPasswordHandler, ResetPasswordHandler>()

                // Authentication
                .AddScoped<ILoginHandler, LoginHandler>()

                // users
                .AddScoped<ICreateUserHandler, CreateUserHandler>()
                .AddScoped<IUpdateUserHandler, UpdateUserHandler>()
                .AddScoped<IGetUserByIdHandler, GetUserByIdHandler>()
                .AddScoped<IUpdatePasswordHandler, UpdatePasswordHandler>()

                // Companies
                .AddScoped<ICreateCompanyHandler, CreateCompanyHandler>()
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