using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using LinkManager.BusinessRules.Companies.Handlers;
using LinkManager.BusinessRules.Companies.Requests;
using LinkManager.BusinessRules.Companies.Responses;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LinkManager.Api.GraphQL.Api.Companies
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class CompanyMutation
    {
        public async Task<CompanyResponse> CreateCompany([Service] ICreateCompanyHandler handler, ClaimsPrincipal claimsPrincipal, CreateCompanyRequest request)
        {
            return await handler.ExecuteAsync(request);
        }

        [Authorize]
        public async Task<CompanyResponse> UpdateCompany([Service] IUpdateCompanyHandler handler, ClaimsPrincipal claimsPrincipal, UpdateCompanyRequest request)
        {
            request.UserId = Guid.Parse(claimsPrincipal.FindFirstValue("id"));
            return await handler.ExecuteAsync(request);
        }
    }
}