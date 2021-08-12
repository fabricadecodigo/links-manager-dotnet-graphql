using HotChocolate;
using HotChocolate.Types;
using LinkManager.Api.src.BusinessRules.Authentication.Handlers;
using LinkManager.Api.src.BusinessRules.Authentication.Requests;
using LinkManager.Api.src.BusinessRules.Authentication.Responses;
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