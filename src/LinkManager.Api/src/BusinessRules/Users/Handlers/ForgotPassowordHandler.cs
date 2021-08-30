using LinkManager.Api.src.BusinessRules.Emails.Handlers;
using LinkManager.Api.src.BusinessRules.Emails.Requests;
using LinkManager.Api.src.BusinessRules.Exceptions;
using LinkManager.Api.src.BusinessRules.Users.Requests;
using LinkManager.Api.src.BusinessRules.Users.Responses;
using LinkManager.Domain.src.Entities;
using LinkManager.Domain.src.Repositories;
using System;
using System.Threading.Tasks;

namespace LinkManager.Api.src.BusinessRules.Users.Handlers
{
    public class ForgotPassowordHandler : IForgotPassowordHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IForgotPasswordRepository _forgotPasswordRepository;
        private readonly ISendForgotPasswordEmailHandler _sendForgotPasswordEmailHandler;

        public ForgotPassowordHandler(
            IUserRepository userRepository,
            IForgotPasswordRepository forgotPasswordRepository,
            ISendForgotPasswordEmailHandler sendForgotPasswordEmailHandler
        )
        {
            _userRepository = userRepository;
            _forgotPasswordRepository = forgotPasswordRepository;
            _sendForgotPasswordEmailHandler = sendForgotPasswordEmailHandler;
        }

        public async Task<ForgotPasswordResponse> ExecuteAsync(ForgotPasswordRequest request)
        {
            const int TIME_EXPIRE_RESET_PASSWORD_IN_MINUTES = 2;

            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }

            var forgotPassword = await _forgotPasswordRepository.GetByEmailAsync(request.Email);
            if (forgotPassword == null)
            {
                forgotPassword = await _forgotPasswordRepository.CreateAsync(new ForgotPassword
                {
                    CreateAt = DateTime.Now,
                    Email = request.Email,
                    ExpireIn = DateTime.Now.AddMinutes(TIME_EXPIRE_RESET_PASSWORD_IN_MINUTES),
                });
            }
            else
            {
                forgotPassword.UpdateAt = DateTime.Now;
                forgotPassword.ExpireIn = DateTime.Now.AddMinutes(TIME_EXPIRE_RESET_PASSWORD_IN_MINUTES);
                forgotPassword = await _forgotPasswordRepository.UpdateAsync(forgotPassword.Id, forgotPassword);
            }

            if (forgotPassword == null)
            {
                throw new UnprocessableEntityException("Não foi possível processar a solicitação.");
            }


            // enviar o email
            await _sendForgotPasswordEmailHandler.ExecuteAsync(new SendEmailRequest()
            {
                Name = user.Name,
                Email = user.Email
            });

            return new ForgotPasswordResponse()
            {
                Payload = true
            };
        }
    }
}