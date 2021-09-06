using LinkManager.BusinessRules.Account.Validators;
using LinkManager.BusinessRules.Companies.Validators;
using LinkManager.BusinessRules.Onboarding.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace LinkManager.BusinessRules.Extensions
{
    public static class ValidadorsExtensions
    {
        public static IServiceCollection AddBusinessRulesValidadors(this IServiceCollection services)
        {
            return services
                .AddScoped<ICreateUserValidator, CreateUserValidator>()
                .AddScoped<ICreateCompanyValidator, CreateCompanyValidator>()
                .AddScoped<IResetPasswordValidator, ResetPasswordValidator>()
                .AddScoped<IUpdateCompanyValidator, UpdateCompanyValidator>();
        }
    }
}