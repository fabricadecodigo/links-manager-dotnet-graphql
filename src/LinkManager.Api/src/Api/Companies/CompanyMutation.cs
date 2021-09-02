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
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class CompanyMutation
    {
        [Authorize]
        public async Task<UpdateCompanyResponse> UpdateCompany([Service] IUpdateCompanyHandler handler, ClaimsPrincipal claimsPrincipal, UpdateCompanyRequest request)
        {
            request.UserId = Guid.Parse(claimsPrincipal.FindFirstValue("id"));
            return await handler.ExecuteAsync(request);
        }
    }
}