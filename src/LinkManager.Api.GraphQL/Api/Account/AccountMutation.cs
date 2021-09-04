using HotChocolate;
using LinkManager.BusinessRules.Account.Handlers;
using LinkManager.BusinessRules.Account.Requests;
using LinkManager.BusinessRules.Account.Responses;
using System.Threading.Tasks;

namespace LinkManager.Api.GraphQL.Api.Account
{
    public class AccountMutation
    {
        public async Task<ForgotPasswordResponse> ForgotPassword([Service] IForgotPassowordHandler handler, ForgotPasswordRequest request)
        {
            return await handler.ExecuteAsync(request);
        }

        public async Task<ResetPasswordResponse> ResetPassword([Service] IResetPasswordHandler handler, ResetPasswordRequest request)
        {
            return await handler.ExecuteAsync(request);
        }
    }
}