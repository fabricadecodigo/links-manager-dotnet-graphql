using Microsoft.Extensions.DependencyInjection;

namespace LinkManager.Api.src.Helpers
{
    public static class HelpersExtensions
    {
        public static IServiceCollection AddHelpers(this IServiceCollection services)
        {
            return services
                .AddScoped<ICryptHelper, CryptHelper>()
                .AddScoped<IJwtToken, JwtToken>()
                .AddScoped<IMailSenderHelper, MailSenderHelper>()
                .AddScoped<IEmailTemplateHelper, EmailTemplateHelper>();
        }
    }
}