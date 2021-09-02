using LinkManager.Api.src.BusinessRules.Exceptions;
using LinkManager.Api.src.BusinessRules.Users.Requests;
using LinkManager.Api.src.BusinessRules.Users.Responses;
using LinkManager.Domain.src.Repositories;
using LinkManager.Helpers.Crypt;
using System;
using System.Threading.Tasks;

namespace LinkManager.Api.src.BusinessRules.Users.Handlers
{
    public class UpdatePasswordHandler : IUpdatePasswordHandler
    {
        private readonly ICryptHelper _cryptHelper;
        private readonly IUserRepository _repository;

        public UpdatePasswordHandler(ICryptHelper cryptHelper, IUserRepository repository)
            => (_cryptHelper, _repository) = (cryptHelper, repository);

        public async Task<UserResponse> ExecuteAsync(UpdatePasswordRequest request)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }

            if (!_cryptHelper.IsValid(request.CurrentPassword, user.Password))
            {
                throw new HotChocolate.GraphQLException("Senha inválida");
            }

            var newPasswordHash = _cryptHelper.Encrypt(request.NewPassword);

            user.Password = newPasswordHash;
            user.UpdateAt = DateTime.Now;
            await _repository.UpdateAsync(user.Id, user);

            return new UserResponse
            {
                Payload = new UserResponseItem
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