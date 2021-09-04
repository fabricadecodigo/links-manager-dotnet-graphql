using LinkManager.BusinessRules.Emails.Handlers;
using LinkManager.BusinessRules.Emails.Requests;
using LinkManager.BusinessRules.Exceptions;
using LinkManager.BusinessRules.Account.Requests;
using LinkManager.BusinessRules.Account.Responses;
using LinkManager.Domain.src.Entities;
using LinkManager.Domain.src.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Account.Handlers
{
    public class ForgotPassowordHandler : IForgotPassowordHandler
    {
        private readonly string _forgotPasswordUrl;
        private readonly IUserRepository _userRepository;
        private readonly IForgotPasswordRepository _forgotPasswordRepository;
        private readonly ISendForgotPasswordEmailHandler _sendForgotPasswordEmailHandler;

        public ForgotPassowordHandler(
            IConfiguration configuration,
            IUserRepository userRepository,
            IForgotPasswordRepository forgotPasswordRepository,
            ISendForgotPasswordEmailHandler sendForgotPasswordEmailHandler
        )
        {
            _forgotPasswordUrl = configuration.GetValue("ForgotPasswordUrl", "");
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
                Email = user.Email,
                Data = new {
                    name = user.Name,
                    url = $"{_forgotPasswordUrl}/{forgotPassword.Id}"
                }
            });

            return new ForgotPasswordResponse()
            {
                Payload = true
            };
        }
    }
}