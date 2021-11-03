using LinkManager.BusinessRules.Authentication.Requests;
using LinkManager.BusinessRules.Authentication.Responses;

namespace LinkManager.BusinessRules.Authentication.Handlers
{
    public interface ILoginHandler : IBusinessRuleHandler<LoginRequest, LoginResponse, LoginResponseData>
    {
         
    }
}