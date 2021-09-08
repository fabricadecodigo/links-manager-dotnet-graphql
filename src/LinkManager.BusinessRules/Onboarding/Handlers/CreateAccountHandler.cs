using AutoMapper;
using LinkManager.BusinessRules.Companies.Handlers;
using LinkManager.BusinessRules.Companies.Requests;
using LinkManager.BusinessRules.Emails.Handlers;
using LinkManager.BusinessRules.Emails.Requests;
using LinkManager.BusinessRules.Onboarding.Requests;
using LinkManager.BusinessRules.Onboarding.Responses;
using LinkManager.BusinessRules.Users.Handlers;
using LinkManager.BusinessRules.Users.Requests;
using LinkManager.Domain.Entities;
using LinkManager.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Onboarding.Handlers
{
    public class CreateAccountHandler : ICreateAccountHandler
    {
        private readonly IMapper _mapper;
        private readonly ICreateUserHandler _createUserHandler;
        private readonly ICreateCompanyHandler _createCompanyHandler;
        private readonly ISendWellcomeEmailHandler _sendWellcomeEmailHandler;

        public CreateAccountHandler(
            IMapper mapper,
            ICreateUserHandler createUserHandler,
            ICreateCompanyHandler createCompanyHandler,
            ISendWellcomeEmailHandler sendWellcomeMailHandler
        )
        {
            _mapper = mapper;
            _createCompanyHandler = createCompanyHandler;
            _createUserHandler = createUserHandler;
            _sendWellcomeEmailHandler = sendWellcomeMailHandler;
        }

        public async Task<CreateAccountResponse> ExecuteAsync(CreateAccountRequest request)
        {
            var userRequest = _mapper.Map<CreateUserRequest>(request.User);
            var userResponse = await _createUserHandler.ExecuteAsync(userRequest);

            // send wellcome email
            await _sendWellcomeEmailHandler.ExecuteAsync(new SendEmailRequest
            {
                Name = userResponse.Payload.Name,
                Email = userResponse.Payload.Email,
                Data = new
                {
                    name = userResponse.Payload.Name
                }
            });

            var companyRequest = _mapper.Map<CreateCompanyRequest>(request.Company);
            companyRequest.UserId = userResponse.Payload.Id;
            
            await _createCompanyHandler.ExecuteAsync(companyRequest);

            return new CreateAccountResponse
            {
                Payload = true
            };
        }
    }
}