using HotChocolate;
using HotChocolate.Types;
using LinkManager.Api.src.BusinessRules.Onboarding.Handlers;
using LinkManager.Api.src.BusinessRules.Onboarding.Requests;
using LinkManager.Api.src.BusinessRules.Onboarding.Responses;
using System.Threading.Tasks;

namespace LinkManager.Api.src.Api.Onboarding
{

    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class OnboardingMutation
    {
        public async Task<CreateAccountResponse> CreateAccount([Service] ICreateAccountHandler handler, CreateAccountRequest request)
        {
            return await handler.ExecuteAsync(request);
        }
    }
}