using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using LinkManager.BusinessRules.Users.Handlers;
using LinkManager.BusinessRules.Users.Requests;
using LinkManager.BusinessRules.Users.Responses;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LinkManager.Api.Api.Users
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class UserQuery
    {
        [Authorize]
        public async Task<UserResponse> GetMe([Service] IGetUserByIdHandler handler, ClaimsPrincipal claimsPrincipal)
        {
            var userId = claimsPrincipal.FindFirstValue("id");
            return await handler.ExecuteAsync(new GetUserByIdRequest {
                Id = Guid.Parse(userId),
            });
        }
    }
}