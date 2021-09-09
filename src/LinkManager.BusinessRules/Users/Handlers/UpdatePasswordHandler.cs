using AutoMapper;
using LinkManager.BusinessRules.Exceptions;
using LinkManager.BusinessRules.Users.Requests;
using LinkManager.BusinessRules.Users.Responses;
using LinkManager.Domain.Entities;
using LinkManager.Domain.Repositories;
using LinkManager.Domain.Validators;
using LinkManager.Helpers.Crypt;
using System;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Users.Handlers
{
    public class UpdatePasswordHandler : IUpdatePasswordHandler
    {
        private readonly IMapper _mapper;
        private readonly ICryptHelper _cryptHelper;
        private readonly IUserRepository _repository;
        private readonly IUserValidator _userValidator;

        public UpdatePasswordHandler(
            IMapper mapper,
            ICryptHelper cryptHelper,
            IUserRepository repository,
            IUserValidator userValidator
        )
        {
            _mapper = mapper;
            _cryptHelper = cryptHelper;
            _repository = repository;
            _userValidator = userValidator;
        }

        public async Task<UserResponse> ExecuteAsync(UpdatePasswordRequest request)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }

            if (!_cryptHelper.IsValid(request.CurrentPassword, user.Password))
            {
                throw new UnprocessableEntityException("Senha inválida");
            }

            // criptografando a senha
            request.NewPassword = _cryptHelper.Encrypt(request.NewPassword);

            _mapper.Map(request, user);
            await _repository.UpdateAsync(user.Id, user);

            return new UserResponse
            {
                Payload = _mapper.Map<UserResponseItem>(user)
            };
        }
    }
}