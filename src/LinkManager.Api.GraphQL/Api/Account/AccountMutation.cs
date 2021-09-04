using HotChocolate;
using HotChocolate.Types;
using LinkManager.BusinessRules.Account.Handlers;
using LinkManager.BusinessRules.Account.Requests;
using LinkManager.BusinessRules.Account.Responses;
using System.Threading.Tasks;

namespace LinkManager.Api.GraphQL.Api.Account
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
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