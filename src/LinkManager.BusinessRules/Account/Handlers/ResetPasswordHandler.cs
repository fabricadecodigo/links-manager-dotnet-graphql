using LinkManager.BusinessRules.Account.Requests;
using LinkManager.BusinessRules.Account.Responses;
using LinkManager.BusinessRules.Exceptions;
using LinkManager.Domain.Repositories;
using LinkManager.Domain.Validators;
using LinkManager.Helpers.Crypt;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Account.Handlers
{
    public class ResetPasswordHandler : IResetPasswordHandler
    {
        private readonly ICryptHelper _cryptHelper;
        private readonly IPasswordValidator _passwordValidator;
        private readonly IUserRepository _userRepository;
        private readonly IForgotPasswordRepository _forgotPasswordRepository;
        private readonly IForgotPasswordExpiredHandler _forgotPasswordExpiredHandler;

        public ResetPasswordHandler(
            ICryptHelper cryptHelper,
            IUserRepository userRepository,
            IPasswordValidator passwordValidator,
            IForgotPasswordRepository forgotPasswordRepository,
            IForgotPasswordExpiredHandler forgotPasswordExpiredHandler
        )
        {
            _cryptHelper = cryptHelper;
            _userRepository = userRepository;
            _passwordValidator = passwordValidator;
            _forgotPasswordRepository = forgotPasswordRepository;
            _forgotPasswordExpiredHandler = forgotPasswordExpiredHandler;
        }

        public async Task<ResetPasswordResponse> ExecuteAsync(ResetPasswordRequest request)
        {
            var validationResult = _passwordValidator.Validate(request.Password);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Erro ao resetar a senha", validationResult.Errors);
            }

            var forgotPassword = await _forgotPasswordRepository.GetByIdAsync(request.Id);
            if (forgotPassword == null)
            {
                throw new NotFoundException("Solicitação não encontrada");
            };

            var expiredResponse = await _forgotPasswordExpiredHandler.ExecuteAsync(new ForgotPasswordExpiredRequest
            {
                Id = request.Id
            });
            if (expiredResponse.Payload)
            {
                throw new UnprocessableEntityException("A solicitação de reset de senha está expirada. Por favor inicie o processo novamente.");
            }

            var user = await _userRepository.GetByEmailAsync(forgotPassword.Email);
            if (user == null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }

            user.Password = _cryptHelper.Encrypt(request.Password);
            await _userRepository.UpdateAsync(user.Id, user);

            await _forgotPasswordRepository.DeleteAsync(forgotPassword.Id);

            return new ResetPasswordResponse
            {
                Payload = true
            };
        }
    }
}