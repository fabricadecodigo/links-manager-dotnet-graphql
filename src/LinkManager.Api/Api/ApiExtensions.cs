using HotChocolate.Execution.Configuration;
using LinkManager.Api.Api.Account;
using LinkManager.Api.Api.Authentication;
using LinkManager.Api.Api.Companies;
using LinkManager.Api.Api.Links;
using LinkManager.Api.Api.Onboarding;
using LinkManager.Api.Api.Users;
using Microsoft.Extensions.DependencyInjection;

namespace LinkManager.Api.Api
{
    public static class ApiExtensions
    {
        public static IRequestExecutorBuilder AddQueriesAndMutations(this IRequestExecutorBuilder services)
        {
            return services
                .AddQueryType()
                    .AddTypeExtension<AccountQuery>()
                    .AddTypeExtension<UserQuery>()
                    .AddTypeExtension<CompanyQuery>()
                    .AddTypeExtension<LinkQuery>()
                .AddMutationType()
                    .AddTypeExtension<OnboardingMutation>()
                    .AddTypeExtension<AuthenticationMutation>()
                    .AddTypeExtension<AccountMutation>()
                    .AddTypeExtension<UserMutation>()
                    .AddTypeExtension<CompanyMutation>()
                    .AddTypeExtension<LinkMutation>();
        }
    }
}