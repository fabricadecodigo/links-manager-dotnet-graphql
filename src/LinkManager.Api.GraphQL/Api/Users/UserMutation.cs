using HotChocolate;
using HotChocolate.Types;
using LinkManager.BusinessRules.Users.Handlers;
using LinkManager.BusinessRules.Users.Requests;
using LinkManager.BusinessRules.Users.Responses;
using System.Threading.Tasks;

namespace LinkManager.Api.GraphQL.Api.Users
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class UserMutation
    {
        public async Task<UserResponse> CreateUser([Service] ICreateUserHandler handler, CreateUserRequest request)
        {
            return await handler.ExecuteAsync(request);
        }
    }
}