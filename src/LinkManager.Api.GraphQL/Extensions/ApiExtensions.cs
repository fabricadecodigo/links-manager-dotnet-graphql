using HotChocolate.Execution.Configuration;
using LinkManager.Api.GraphQL.Api.Users;
using Microsoft.Extensions.DependencyInjection;

namespace LinkManager.Api.GraphQL.Extensions
{


    public static class ApiExtensions
    {
        public static IRequestExecutorBuilder AddQueriesAndMutations(this IRequestExecutorBuilder services)
        {
            return services
                .AddQueryType()
                    .AddTypeExtension<UserQuery>()
                .AddMutationType()
                    .AddTypeExtension<UserMutation>();
        }
    }
}