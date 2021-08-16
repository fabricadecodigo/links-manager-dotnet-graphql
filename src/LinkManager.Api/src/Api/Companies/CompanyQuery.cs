using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using LinkManager.Api.src.BusinessRules.Companies.Handlers;
using LinkManager.Api.src.BusinessRules.Companies.Requests;
using LinkManager.Api.src.BusinessRules.Companies.Responses;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LinkManager.Api.src.Api.Companies
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class CompanyQuery
    {
        [Authorize]
        public async Task<GetCompanyByIdResponse> GetCompany([Service] IGetCompanyByIdHandler handler, ClaimsPrincipal claimsPrincipal, GetCompanyByIdRequest request)
        {
            request.UserId = Guid.Parse(claimsPrincipal.FindFirstValue("id"));
            return await handler.ExecuteAsync(request);
        }
    }
}