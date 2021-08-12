using LinkManager.Api.src.BusinessRules.Exceptions;
using LinkManager.Api.src.BusinessRules.Users.Requests;
using LinkManager.Api.src.BusinessRules.Users.Responses;
using LinkManager.Api.src.Helpers;
using LinkManager.Domain.src.Repositories;
using System;
using System.Threading.Tasks;

namespace LinkManager.Api.src.BusinessRules.Users.Handlers
{
    public class UpdatePasswordHandler : IUpdatePasswordHandler
    {
        private readonly IUserRepository _repository;

        public UpdatePasswordHandler(IUserRepository repository) => _repository = repository;

        public async Task<UpdatePasswordResponse> ExecuteAsync(UpdatePasswordRequest request)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }

            if (!CryptHelper.IsValid(request.CurrentPassword, user.Password))
            {
                throw new HotChocolate.GraphQLException("Senha inválida");
            }

            var newPasswordHash = CryptHelper.Encrypt(request.NewPassword);

            user.Password = newPasswordHash;
            user.UpdateAt = DateTime.Now;
            await _repository.UpdateAsync(user.Id, user);

            return new UpdatePasswordResponse
            {
                Payload = new UserResponse
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