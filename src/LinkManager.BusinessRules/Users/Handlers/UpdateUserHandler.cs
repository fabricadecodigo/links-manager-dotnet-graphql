using AutoMapper;
using LinkManager.BusinessRules.Exceptions;
using LinkManager.BusinessRules.Users.Requests;
using LinkManager.BusinessRules.Users.Responses;
using LinkManager.Domain.Repositories;
using LinkManager.Domain.Validators;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Users.Handlers
{
    public class UpdateUserHandler : IUpdateUserHandler
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUserValidator _userValidator;

        public UpdateUserHandler(
            IMapper mapper,
            IUserRepository userRepository,
            IUserValidator userValidator
        )
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userValidator = userValidator;
        }

        public async Task<UserResponse> ExecuteAsync(UpdateUserRequest request)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }

            _mapper.Map(request, user);

            var validationResult = _userValidator.Validate(user);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Erro ao alterar um usuário", validationResult.Errors);
            };

            await _userRepository.UpdateAsync(user.Id, user);

            return new UserResponse
            {
                Payload = _mapper.Map<UserResponseItem>(user)
            };
        }
    }
}