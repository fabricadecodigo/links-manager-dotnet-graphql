using LinkManager.Api.src.BusinessRules.Exceptions;
using LinkManager.Api.src.BusinessRules.Users.Requests;
using LinkManager.Api.src.BusinessRules.Users.Responses;
using LinkManager.Domain.src.Repositories;
using System;
using System.Threading.Tasks;

namespace LinkManager.Api.src.BusinessRules.Users.Handlers
{
    public class UpdateUserHandler : IUpdateUserHandler
    {
        private readonly IUserRepository _repository;

        public UpdateUserHandler(IUserRepository repository) => _repository = repository;

        public async Task<UserResponse> ExecuteAsync(UpdateUserRequest request)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }

            user.Name = request.Name;
            user.UpdateAt = DateTime.Now;

            await _repository.UpdateAsync(user.Id, user);

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