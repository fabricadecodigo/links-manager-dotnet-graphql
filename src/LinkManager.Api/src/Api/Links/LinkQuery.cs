using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using LinkManager.Api.src.BusinessRules.Links.Handlers;
using LinkManager.Api.src.BusinessRules.Links.Requests;
using LinkManager.Api.src.BusinessRules.Links.Responses;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LinkManager.Api.src.Api.Links
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class LinkQuery
    {
        [Authorize]
        public async Task<LinkResponse> GetLink([Service] IGetLinkByIdHandler handler, ClaimsPrincipal claimsPrincipal, GetLinkByIdRequest request)
        {
            request.CompanyId = Guid.Parse(claimsPrincipal.FindFirstValue("companyId"));
            return await handler.ExecuteAsync(request);
        }

        [Authorize]
        public async Task<LinkListResponse> GetLinks([Service] IGetLinkListHandler handler, ClaimsPrincipal claimsPrincipal, GetLinkListRequest request)
        {
            request.CompanyId = Guid.Parse(claimsPrincipal.FindFirstValue("companyId"));
            return await handler.ExecuteAsync(request);
        }

        public async Task<LinkListResponse> GetLinksBySlug([Service] IGetLinkListByCompanySlugHandler handler, GetLinkLinkByCompanySlugRequest request)
        {
            return await handler.ExecuteAsync(request);
        }
    }
}