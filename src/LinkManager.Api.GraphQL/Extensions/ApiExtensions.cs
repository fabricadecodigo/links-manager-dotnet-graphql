using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LinkManager.Api.GraphQL.Extensions
{


    public static class ApiExtensions
    {
        public static IRequestExecutorBuilder AddQueriesAndMutations(this IRequestExecutorBuilder services)
        {
            return services
                .AddQueryType()
                .AddMutationType();
        }
    }
}