using LinkManager.Api.src.BusinessRules.Authentication.Requests;
using LinkManager.Api.src.BusinessRules.Authentication.Responses;

namespace LinkManager.Api.src.BusinessRules.Authentication.Handlers
{
    public interface ILoginHandler : IBusinessRuleHandler<LoginRequest, LoginResponse, LoginResponseData>
    {
         
    }
}