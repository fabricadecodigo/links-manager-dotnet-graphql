using HotChocolate.Execution.Configuration;
using LinkManager.Api.src.Api.Authentication;
using LinkManager.Api.src.Api.Users;
using Microsoft.Extensions.DependencyInjection;

namespace LinkManager.Api.src.Api
{
    public static class ApiExtensions
    {
        public static IRequestExecutorBuilder AddQueriesAndMutations(this IRequestExecutorBuilder services)
        {
            return services
                .AddQueryType()
                    .AddTypeExtension<UserQuery>()                    
                .AddMutationType()
                    .AddTypeExtension<AuthenticationMutation>()
                    .AddTypeExtension<UserMutation>();
        }
    }
}