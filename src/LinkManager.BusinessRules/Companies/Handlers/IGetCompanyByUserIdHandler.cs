using LinkManager.BusinessRules.Companies.Requests;
using LinkManager.BusinessRules.Companies.Responses;

namespace LinkManager.BusinessRules.Companies.Handlers
{
    public interface IGetCompanyByUserIdHandler : 
        IBusinessRuleHandler<GetCompanyByUserIdRequest, CompanyResponse, CompanyResponseItem>
    {
         
    }
}