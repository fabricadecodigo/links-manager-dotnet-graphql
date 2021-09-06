using LinkManager.BusinessRules.Emails.Handlers;
using LinkManager.BusinessRules.Emails.Requests;
using LinkManager.BusinessRules.Exceptions;
using LinkManager.BusinessRules.Onboarding.Requests;
using LinkManager.BusinessRules.Onboarding.Responses;
using LinkManager.BusinessRules.Onboarding.Validators;
using LinkManager.Domain.Entities;
using LinkManager.Domain.Repositories;
using LinkManager.Helpers.Crypt;
using System;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Onboarding.Handlers
{
    public class CreateAccountHandler : ICreateAccountHandler
    {
        private readonly ICryptHelper _cryptHelper;
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ICreateUserValidator _createUserValidator;
        private readonly ICreateCompanyValidator _createCompanyValidator;
        private readonly ISendWellcomeEmailHandler _sendWellcomeEmailHandler;

        public CreateAccountHandler(
            ICryptHelper cryptHelper,
            IUserRepository userRepository,
            ICompanyRepository companyRepository,
            ICreateUserValidator createUserValidator,
            ICreateCompanyValidator createCompanyValidator,
            ISendWellcomeEmailHandler sendWellcomeMailHandler
        )
        {
            _cryptHelper = cryptHelper;
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _createUserValidator = createUserValidator;
            _createCompanyValidator = createCompanyValidator;
            _sendWellcomeEmailHandler = sendWellcomeMailHandler;
        }

        public async Task<CreateAccountResponse> ExecuteAsync(CreateAccountRequest request)
        {
            ValidateUser(request.User);
            ValidateCompany(request.Company);

            var user = await CreateUser(request.User);
            await CreateCompany(request.Company, user.Id);

            // send wellcome email
            await _sendWellcomeEmailHandler.ExecuteAsync(new SendEmailRequest
            {
                Name = user.Name,
                Email = user.Email,
                Data = new
                {
                    name = user.Name
                }
            });

            return new CreateAccountResponse
            {
                Payload = true
            };
        }

        private void ValidateUser(CreateAccountRequestUser request)
        {
            var validationResult = _createUserValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Erro ao criar um usuário", validationResult.Errors);
            }
        }

        private void ValidateCompany(CreateAccountRequestCompany request)
        {
            var validationResult = _createCompanyValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Erro ao criar a empresa", validationResult.Errors);
            }
        }

        private async Task<User> CreateUser(CreateAccountRequestUser request)
        {
            // encriptografar a senha            
            request.Password = _cryptHelper.Encrypt(request.Password);

            var response = await _userRepository.CreateAsync(new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                CreateAt = DateTime.Now,
            });

            return response;
        }

        private async Task<Company> CreateCompany(CreateAccountRequestCompany request, Guid userId)
        {
            var response = await _companyRepository.CreateAsync(new Company()
            {
                CreateAt = DateTime.Now,
                Name = request.Name,
                Slug = request.Slug,
                UserId = userId
            });

            return response;
        }
    }
}