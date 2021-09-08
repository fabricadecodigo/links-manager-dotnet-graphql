using AutoMapper;
using LinkManager.BusinessRules.Exceptions;
using LinkManager.BusinessRules.Users.Requests;
using LinkManager.BusinessRules.Users.Responses;
using LinkManager.Domain.Entities;
using LinkManager.Domain.Repositories;
using LinkManager.Domain.Validators;
using LinkManager.Helpers.Crypt;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Users.Handlers
{
    public class CreateUserHandler : ICreateUserHandler
    {
        private readonly IMapper _mapper;
        private readonly ICryptHelper _cryptHelper;
        private readonly IUserRepository _userRepository;
        private readonly IUserValidator _userValidator;

        public CreateUserHandler(
            IMapper mapper,
            ICryptHelper cryptHelper,
            IUserRepository userRepository,
            IUserValidator userValidator
        )
        {
            _mapper = mapper;
            _cryptHelper = cryptHelper;
            _userRepository = userRepository;
            _userValidator = userValidator;
        }

        public async Task<UserResponse> ExecuteAsync(CreateUserRequest request)
        {
            var user = _mapper.Map<User>(request);
            var validationResult = _userValidator.Validate(user);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Erro ao criar um usuário", validationResult.Errors);
            };

            request.Password = _cryptHelper.Encrypt(request.Password);
            user = await _userRepository.CreateAsync(user);

            return new UserResponse
            {
                Payload = _mapper.Map<UserResponseItem>(user)
            };
        }
    }
}