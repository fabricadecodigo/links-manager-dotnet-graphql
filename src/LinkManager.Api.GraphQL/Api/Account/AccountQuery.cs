using HotChocolate;
using HotChocolate.Types;
using LinkManager.BusinessRules.Account.Handlers;
using LinkManager.BusinessRules.Account.Requests;
using LinkManager.BusinessRules.Account.Responses;
using System.Threading.Tasks;

namespace LinkManager.Api.GraphQL.Api.Account
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class AccountQuery
    {
        public async Task<ForgotPasswordExpiredResponse> ForgotPasswordExpired([Service] IForgotPasswordExpiredHandler handler, ForgotPasswordExpiredRequest request)
        {
            return await handler.ExecuteAsync(request);
        }
    }
}