using FluentValidation;
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
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ICryptHelper _cryptHelper;
        private readonly ISendWellcomeEmailHandler _sendWellcomeEmailHandler;

        public CreateAccountHandler(
            IUserRepository userRepository,
            ICompanyRepository companyRepository,
            ICryptHelper cryptHelper,
            ISendWellcomeEmailHandler sendWellcomeMailHandler
        )
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _cryptHelper = cryptHelper;
            _sendWellcomeEmailHandler = sendWellcomeMailHandler;
        }

        public async Task<CreateAccountResponse> ExecuteAsync(CreateAccountRequest request)
        {
            await ValidateUser(request.User);
            await ValidateCompany(request.Company);

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

        private async Task ValidateUser(CreateAccountRequestUser request)
        {
            // // Validação
            new CreateUserValidator().ValidateAndThrow(request);

            // validar se já existe um usuário
            var existsUsers = await _userRepository.GetByEmailAsync(request.Email);
            if (existsUsers != null)
            {
                throw new ConflictException("O email informado já está sendo usado.");
            }
        }

        private async Task ValidateCompany(CreateAccountRequestCompany request)
        {
            // validar se já existe uma empresa com esse slug
            var existsCompany = await _companyRepository.GetBySlugAsync(request.Slug);
            if (existsCompany != null)
            {
                throw new ConflictException("O slug informado já está sendo usado.");
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