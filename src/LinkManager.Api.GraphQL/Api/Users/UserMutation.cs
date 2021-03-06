using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using LinkManager.BusinessRules.Users.Handlers;
using LinkManager.BusinessRules.Users.Requests;
using LinkManager.BusinessRules.Users.Responses;
using System;
using System.Security.Claims;
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

        [Authorize]
        public async Task<UserResponse> UpdateUser(
            [Service] IUpdateUserHandler handler, 
            ClaimsPrincipal claimsPrincipal, 
            UpdateUserRequest request)
        {
            request.Id = Guid.Parse(claimsPrincipal.FindFirstValue("id"));
            return await handler.ExecuteAsync(request);
        }

        [Authorize]
        public async Task<UserResponse> UpdateUserPassword(
            [Service] IUpdatePasswordHandler handler, 
            ClaimsPrincipal claimsPrincipal, 
            UpdatePasswordRequest request)
        {
            request.Id = Guid.Parse(claimsPrincipal.FindFirstValue("id"));
            return await handler.ExecuteAsync(request);
        }
    }
}