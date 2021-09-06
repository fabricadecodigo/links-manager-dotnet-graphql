using LinkManager.BusinessRules.Exceptions;
using LinkManager.BusinessRules.Users.Requests;
using LinkManager.BusinessRules.Users.Responses;
using LinkManager.Domain.Repositories;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Users.Handlers
{
    public class GetUserByIdHandler : IGetUserByIdHandler
    {
        private readonly IUserRepository _repository;

        public GetUserByIdHandler(IUserRepository repository) => _repository = repository;

        public async Task<UserResponse> ExecuteAsync(GetUserByIdRequest request)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }

            return new UserResponse
            {
                Payload = new UserResponseItem()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    CreateAt = user.CreateAt,
                    UpdateAt = user.UpdateAt
                }
            };
        }
    }
}