using LinkManager.Api.src.BusinessRules.Onboarding.Handlers;
using LinkManager.Api.src.BusinessRules.Authentication.Handlers;
using LinkManager.Api.src.BusinessRules.Users.Handlers;
using Microsoft.Extensions.DependencyInjection;
using LinkManager.Api.src.BusinessRules.Companies.Handlers;
using LinkManager.Api.src.BusinessRules.Links.Handlers;
using LinkManager.Api.src.BusinessRules.Emails.Handlers;

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
                .AddScoped<IForgotPassowordHandler, ForgotPassowordHandler>()
                .AddScoped<IForgotPasswordExpiredHandler, ForgotPasswordExpiredHandler>()
                .AddScoped<IResetPasswordHandler, ResetPasswordHandler>()

                // Companies
                .AddScoped<IUpdateCompanyHandler, UpdateCompanyHandler>()
                .AddScoped<IGetCompanyByIdHandler, GetCompanyByIdHandler>()
                
                // Links
                .AddScoped<ICreateLinkHandler, CreateLinkHandler>()
                .AddScoped<IUpdateLinkHandler, UpdateLinkHandler>()
                .AddScoped<IDeleteLinkHandler, DeleteLinkHandler>()
                .AddScoped<IGetLinkByIdHandler, GetLinkByIdHandler>()
                .AddScoped<IGetLinkListHandler, GetLinkListHandler>()
                
                // Emails
                .AddScoped<ISendWellcomeEmailHandler, SendWellcomeEmailHandler>()
                .AddScoped<ISendForgotPasswordEmailHandler, SendForgotPasswordEmailHandler>();
        }
    }
}