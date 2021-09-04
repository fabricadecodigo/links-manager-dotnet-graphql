using HotChocolate;

namespace LinkManager.Api.GraphQL.Exceptions
{
    public class ApiConflictException : GraphQLException
    {
        public ApiConflictException(string message) : base(ErrorBuilder.New().SetMessage(message).SetCode("CONFLICT_EXCEPTION").Build())
        {
        }
    }
}