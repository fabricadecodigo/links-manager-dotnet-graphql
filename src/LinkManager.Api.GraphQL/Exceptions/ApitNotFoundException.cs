
using HotChocolate;

namespace LinkManager.Api.GraphQL.Exceptions
{
    public class ApiNotFoundException : GraphQLException
    {
        public ApiNotFoundException(string message) : base(ErrorBuilder.New().SetMessage(message).SetCode("NOT_FOUND_EXCEPTION").Build())
        {
        }
    }
}