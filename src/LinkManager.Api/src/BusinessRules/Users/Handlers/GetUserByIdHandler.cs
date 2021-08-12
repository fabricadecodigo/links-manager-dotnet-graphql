using LinkManager.Api.src.BusinessRules.Exceptions;
using LinkManager.Api.src.BusinessRules.Users.Requests;
using LinkManager.Api.src.BusinessRules.Users.Responses;
using LinkManager.Domain.src.Repositories;
using System.Threading.Tasks;

namespace LinkManager.Api.src.BusinessRules.Users.Handlers
{
    public class GetUserByIdHandler : IGetUserByIdHandler
    {
        private readonly IUserRepository _repository;

        public GetUserByIdHandler(IUserRepository repository) => _repository = repository;

        public async Task<GetUserByIdResponse> ExecuteAsync(GetUserByIdRequest request)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }

            return new GetUserByIdResponse
            {
                Payload = new UserResponse()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                }
            };
        }
    }
}