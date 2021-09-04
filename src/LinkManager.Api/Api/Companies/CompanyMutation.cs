using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using LinkManager.BusinessRules.Companies.Handlers;
using LinkManager.BusinessRules.Companies.Requests;
using LinkManager.BusinessRules.Companies.Responses;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LinkManager.Api.Api.Companies
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