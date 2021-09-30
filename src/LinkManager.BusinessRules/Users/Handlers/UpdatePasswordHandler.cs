using AutoMapper;
using LinkManager.BusinessRules.Exceptions;
using LinkManager.BusinessRules.Users.Requests;
using LinkManager.BusinessRules.Users.Responses;
using LinkManager.Domain.Repositories;
using LinkManager.Domain.Validators;
using LinkManager.Helpers.Crypt;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Users.Handlers
{
    public class UpdatePasswordHandler : IUpdatePasswordHandler
    {
        private readonly IMapper _mapper;
        private readonly ICryptHelper _cryptHelper;
        private readonly IUserRepository _repository;
        private readonly IPasswordValidator _passwordValidator;

        public UpdatePasswordHandler(
            IMapper mapper,
            ICryptHelper cryptHelper,
            IUserRepository repository,
            IPasswordValidator passwordValidator
        )
        {
            _mapper = mapper;
            _cryptHelper = cryptHelper;
            _repository = repository;
            _passwordValidator = passwordValidator;
        }

        public async Task<UserResponse> ExecuteAsync(UpdatePasswordRequest request)
        {
            var validationResult = _passwordValidator.Validate(request.NewPassword);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Erro ao alterar a senha", validationResult.Errors);
            }

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