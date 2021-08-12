using HotChocolate;

namespace LinkManager.Api.src.BusinessRules.Exceptions
{
    public class NotFoundException : GraphQLException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}