using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using LinkManager.Api.src.BusinessRules.Users.Handlers;
using LinkManager.Api.src.BusinessRules.Users.Requests;
using LinkManager.Api.src.BusinessRules.Users.Responses;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LinkManager.Api.src.Api.Users
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class UserQuery
    {
        [Authorize]
        public async Task<GetUserByIdResponse> GetMe([Service] IGetUserByIdHandler handler, ClaimsPrincipal claimsPrincipal)
        {
            var userId = claimsPrincipal.FindFirstValue("id");
            return await handler.ExecuteAsync(new GetUserByIdRequest {
                Id = Guid.Parse(userId),
            });
        }
    }
}