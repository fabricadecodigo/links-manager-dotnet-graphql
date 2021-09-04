using HotChocolate;

namespace LinkManager.Api.GraphQL.Exceptions
{
    public class ApiUnprocessableEntityException : GraphQLException
    {
        public ApiUnprocessableEntityException(string message) : base(ErrorBuilder.New().SetMessage(message).SetCode("UNPROCESSABLE_ENTITY_EXCEPTION").Build())
        {
        }
    }
}