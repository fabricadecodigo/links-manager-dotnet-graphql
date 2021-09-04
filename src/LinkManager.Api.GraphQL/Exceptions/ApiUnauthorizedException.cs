using HotChocolate;

namespace LinkManager.Api.GraphQL.Exceptions
{
    public class ApiUnauthorizedException : GraphQLException
    {
        public ApiUnauthorizedException(string message) : base(ErrorBuilder.New().SetMessage(message).SetCode("UNAUTHORIZED_EXCEPTION").Build())
        {
        }
    }
}