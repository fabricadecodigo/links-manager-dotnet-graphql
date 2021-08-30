using LinkManager.Api.src.BusinessRules.Users.Requests;
using LinkManager.Api.src.BusinessRules.Users.Responses;

namespace LinkManager.Api.src.BusinessRules.Users.Handlers
{
    public interface IForgotPasswordExpiredHandler : IBusinessRuleHandler<ForgotPasswordExpiredRequest, ForgotPasswordExpiredResponse, bool>
    {         
    }
}