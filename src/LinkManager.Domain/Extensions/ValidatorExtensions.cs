using LinkManager.Domain.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace LinkManager.Domain.Extensions
{

    public static class ValidatorExtensions
    {
        public static IServiceCollection AddDomainValidators(this IServiceCollection services)
        {
            return services
                .AddScoped<IPasswordValidator, PasswordValidator>()
                .AddScoped<IEmailValidator, EmailValidator>()
                .AddScoped<IUserValidator, UserValidator>()
                .AddScoped<ICompanyValidator, CompanyValidator>()
                .AddScoped<ILinkValidator, LinkValidator>()
                .AddScoped<IForgotPasswordValidator, ForgotPasswordValidator>();
        }
    }
}