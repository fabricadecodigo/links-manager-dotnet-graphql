using LinkManager.BusinessRules.Users.Requests;
using LinkManager.BusinessRules.Users.Responses;

namespace LinkManager.BusinessRules.Users.Handlers
{
    public interface IUpdatePasswordHandler : 
        IBusinessRuleHandler<UpdatePasswordRequest, UserResponse, UserResponseItem>
    {
         
    }
}