using HotChocolate.Types;
using LinkManager.BusinessRules.Users.Responses;

namespace LinkManager.Api.GraphQL.Api.Users
{

    [ExtendObjectType(OperationTypeNames.Query)]
    public class UserQuery
    {
        public UserResponse GetMe()
        {
            return new UserResponse();
        }
    }
}