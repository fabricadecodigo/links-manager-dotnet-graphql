using HotChocolate;
using HotChocolate.Types;
using LinkManager.Api.src.BusinessRules.Users.Handlers;
using LinkManager.Api.src.BusinessRules.Users.Requests;
using LinkManager.Api.src.BusinessRules.Users.Responses;
using System.Threading.Tasks;

namespace LinkManager.Api.src.Api.Users
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class UserQuery
    {
        public async Task<GetUserByIdResponse> GetUser([Service] IGetUserByIdHandler handler, GetUserByIdRequest request)
        {
            return await handler.ExecuteAsync(request);
        }
    }
}