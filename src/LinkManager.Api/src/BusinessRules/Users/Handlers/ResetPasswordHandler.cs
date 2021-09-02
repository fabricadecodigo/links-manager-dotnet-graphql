using LinkManager.Api.src.BusinessRules.Exceptions;
using LinkManager.Api.src.BusinessRules.Users.Requests;
using LinkManager.Api.src.BusinessRules.Users.Responses;
using LinkManager.Domain.src.Repositories;
using LinkManager.Helpers.Crypt;
using System.Threading.Tasks;

namespace LinkManager.Api.src.BusinessRules.Users.Handlers
{
    public class ResetPasswordHandler : IResetPasswordHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IForgotPasswordRepository _forgotPasswordRepository;
        private readonly IForgotPasswordExpiredHandler _forgotPasswordExpiredHandler;
        private readonly ICryptHelper _cryptHelper;

        public ResetPasswordHandler(
            IUserRepository userRepository,
            IForgotPasswordRepository forgotPasswordRepository,
            IForgotPasswordExpiredHandler forgotPasswordExpiredHandler,
            ICryptHelper cryptHelper
        )
        {
            _userRepository = userRepository;
            _forgotPasswordRepository = forgotPasswordRepository;
            _forgotPasswordExpiredHandler = forgotPasswordExpiredHandler;
            _cryptHelper = cryptHelper;
        }

        public async Task<ResetPasswordResponse> ExecuteAsync(ResetPasswordRequest request)
        {
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