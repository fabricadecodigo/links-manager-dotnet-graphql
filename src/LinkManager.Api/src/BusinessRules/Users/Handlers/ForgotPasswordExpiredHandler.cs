using LinkManager.Api.src.BusinessRules.Exceptions;
using LinkManager.Api.src.BusinessRules.Users.Requests;
using LinkManager.Api.src.BusinessRules.Users.Responses;
using LinkManager.Domain.src.Repositories;
using System;
using System.Threading.Tasks;

namespace LinkManager.Api.src.BusinessRules.Users.Handlers
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