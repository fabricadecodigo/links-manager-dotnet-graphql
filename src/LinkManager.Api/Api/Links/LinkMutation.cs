using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using LinkManager.BusinessRules.Links.Handlers;
using LinkManager.BusinessRules.Links.Requests;
using LinkManager.BusinessRules.Links.Responses;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LinkManager.Api.Api.Links
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class LinkMutation
    {
        [Authorize]
        public async Task<LinkResponse> CreateLink([Service] ICreateLinkHandler handler, ClaimsPrincipal claimsPrincipal, CreateLinkRequest request)
        {
            request.CompanyId = Guid.Parse(claimsPrincipal.FindFirstValue("company"));
            return await handler.ExecuteAsync(request);
        }

        [Authorize]
        public async Task<LinkResponse> UpdateLink([Service] IUpdateLinkHandler handler, ClaimsPrincipal claimsPrincipal, UpdateLinkRequest request)
        {
            request.CompanyId = Guid.Parse(claimsPrincipal.FindFirstValue("company"));
            return await handler.ExecuteAsync(request);
        }

        [Authorize]
        public async Task<DeleteLinkResponse> DeleteLink([Service] IDeleteLinkHandler handler, ClaimsPrincipal claimsPrincipal, DeleteLinkRequest request)
        {
            request.CompanyId = Guid.Parse(claimsPrincipal.FindFirstValue("company"));
            return await handler.ExecuteAsync(request);
        }
    }
}