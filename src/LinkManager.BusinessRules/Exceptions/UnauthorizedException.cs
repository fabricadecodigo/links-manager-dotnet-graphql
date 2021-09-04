using HotChocolate;

namespace LinkManager.BusinessRules.Exceptions
{
    public class UnauthorizedException : GraphQLException
    {
        public UnauthorizedException(string message) : base(ErrorBuilder.New().SetMessage(message).SetCode("UNAUTHORIZED_EXCEPTION").Build())
        {
        }
    }
}