using LinkManager.Helpers.Crypt;
using LinkManager.Helpers.Email;
using LinkManager.Helpers.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace LinkManager.Helpers.Extensions
{
    public static class HelpersExtensions
    {
        public static IServiceCollection AddHelpers(this IServiceCollection services)
        {
            return services
                .AddScoped<ICryptHelper, CryptHelper>()
                .AddScoped<IJwtToken, JwtToken>()
                .AddScoped<IEmailSenderHelper, EmailSenderHelper>()
                .AddScoped<IEmailTemplateHelper, EmailTemplateHelper>();
        }
    }
}