using HotChocolate;

namespace LinkManager.BusinessRules.Exceptions
{
    public class ConflictException : GraphQLException
    {
        public ConflictException(string message) : base(
            ErrorBuilder.New().SetMessage(message).SetCode("CONFLICT_EXCEPTION").Build()
        )
        {

        }
    }
}