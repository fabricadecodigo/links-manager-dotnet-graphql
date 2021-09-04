using HotChocolate;
using HotChocolate.Types;
using LinkManager.BusinessRules.Authentication.Handlers;
using LinkManager.BusinessRules.Authentication.Requests;
using LinkManager.BusinessRules.Authentication.Responses;
using System.Threading.Tasks;

namespace LinkManager.Api.src.Api.Authentication
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class AuthenticationMutation
    {
        public async Task<LoginResponse> Login([Service] ILoginHandler handler, LoginRequest request)
        {
            return await handler.ExecuteAsync(request);
        }
    }
}