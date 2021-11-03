using LinkManager.BusinessRules.Account.Requests;
using LinkManager.BusinessRules.Account.Responses;
using LinkManager.BusinessRules.Exceptions;
using LinkManager.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Account.Handlers
{
    public class ForgotPasswordExpiredHandler : IForgotPasswordExpiredHandler
    {
        private readonly IForgotPasswordRepository _forgotPasswordRepository;

        public ForgotPasswordExpiredHandler(
            IForgotPasswordRepository forgotPasswordRepository
        )
        {
            _forgotPasswordRepository = forgotPasswordRepository;
        }

        public async Task<ForgotPasswordExpiredResponse> ExecuteAsync(ForgotPasswordExpiredRequest request)
        {
            var forgotPassword = await _forgotPasswordRepository.GetByIdAsync(request.Id);
            if (forgotPassword == null)
            {
                throw new NotFoundException("Solicitação não encontrada");
            }

            var exipired = DateTime.Now > forgotPassword.ExpireIn.ToLocalTime();

            return new ForgotPasswordExpiredResponse
            {
                Payload = exipired
            };
        }
    }
}