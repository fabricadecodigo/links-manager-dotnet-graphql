using LinkManager.Api.src.BusinessRules.Companies.Requests;
using LinkManager.Api.src.BusinessRules.Companies.Responses;

namespace LinkManager.Api.src.BusinessRules.Companies.Handlers
{
    public interface IGetCompanyByIdHandler : IBusinessRuleHandler<GetCompanyByIdRequest, GetCompanyByIdResponse, CompanyReponse>
    {
         
    }
}