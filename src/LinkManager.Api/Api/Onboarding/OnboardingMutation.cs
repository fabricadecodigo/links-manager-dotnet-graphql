using HotChocolate;
using HotChocolate.Types;
using LinkManager.BusinessRules.Onboarding.Handlers;
using LinkManager.BusinessRules.Onboarding.Requests;
using LinkManager.BusinessRules.Onboarding.Responses;
using System.Threading.Tasks;

namespace LinkManager.Api.Api.Onboarding
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