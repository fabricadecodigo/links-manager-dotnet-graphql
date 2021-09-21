using HotChocolate;

namespace LinkManager.BusinessRules.Exceptions
{
    public class NotFoundException : GraphQLException
    {
        public NotFoundException(string message) : base(
            ErrorBuilder.New().SetMessage(message).SetCode("NOT_FOUND_EXCEPTION").Build()
        )
        {
        }
    }
}