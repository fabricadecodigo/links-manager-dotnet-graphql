using HotChocolate;
using HotChocolate.Types;
using LinkManager.Api.src.BusinessRules.Users.Handlers;
using LinkManager.Api.src.BusinessRules.Users.Requests;
using LinkManager.Api.src.BusinessRules.Users.Responses;
using System.Threading.Tasks;

namespace LinkManager.Api.src.Api.Users
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class UserMutation
    {
        public async Task<CreateUserResponse> CreateUser([Service] ICreateUserHandler handler, CreateUserRequest request)
        {
            return await handler.ExecuteAsync(request);
        }

        public async Task<UpdateUserResponse> UpdateUser([Service] IUpdateUserHandler handler, UpdateUserRequest request)
        {
            return await handler.ExecuteAsync(request);
        }

        public async Task<UpdatePasswordResponse> UpdateUserPassword([Service] IUpdatePasswordHandler handler, UpdatePasswordRequest request)
        {
            return await handler.ExecuteAsync(request);
        }
    }
}