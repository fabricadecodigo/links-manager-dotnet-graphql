using HotChocolate;
using HotChocolate.Types;
using LinkManager.BusinessRules.Companies.Handlers;
using LinkManager.BusinessRules.Companies.Requests;
using LinkManager.BusinessRules.Companies.Responses;
using System.Threading.Tasks;

namespace LinkManager.Api.GraphQL.Api.Companies
{

    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class CompanyMutation
    {
        public async Task<CompanyResponse> CreateCompany(
            [Service] ICreateCompanyHandler handler,
            CreateCompanyRequest request)
        {
            return await handler.ExecuteAsync(request);
        }
    }
}