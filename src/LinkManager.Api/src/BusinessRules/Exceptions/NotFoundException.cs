using HotChocolate;

namespace LinkManager.Api.src.BusinessRules.Exceptions
{
    public class NotFoundException : GraphQLException
    {
        public NotFoundException() : base(ErrorBuilder.New().SetCode("NOT_FOUND_EXCEPTION").Build())
        {
        }

        public NotFoundException(string message) : base(ErrorBuilder.New().SetMessage(message).SetCode("NOT_FOUND_EXCEPTION").Build())
        {
        }
    }
}