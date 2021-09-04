using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using LinkManager.BusinessRules.Links.Handlers;
using LinkManager.BusinessRules.Links.Requests;
using LinkManager.BusinessRules.Links.Responses;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LinkManager.Api.src.Api.Links
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class LinkQuery
    {
        [Authorize]
        public async Task<LinkResponse> GetLink([Service] IGetLinkByIdHandler handler, ClaimsPrincipal claimsPrincipal, GetLinkByIdRequest request)
        {
            request.CompanyId = Guid.Parse(claimsPrincipal.FindFirstValue("company"));
            return await handler.ExecuteAsync(request);
        }

        [Authorize]
        public async Task<LinkListResponse> GetLinks([Service] IGetLinkListHandler handler, ClaimsPrincipal claimsPrincipal, GetLinkListRequest request)
        {
            request.CompanyId = Guid.Parse(claimsPrincipal.FindFirstValue("company"));
            return await handler.ExecuteAsync(request);
        }

        public async Task<LinkListResponse> GetLinksBySlug([Service] IGetLinkListByCompanySlugHandler handler, GetLinkLinkByCompanySlugRequest request)
        {
            return await handler.ExecuteAsync(request);
        }
    }
}