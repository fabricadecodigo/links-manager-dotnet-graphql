using FluentValidation;
using LinkManager.Api.src.BusinessRules.Emails.Handlers;
using LinkManager.Api.src.BusinessRules.Emails.Requests;
using LinkManager.Api.src.BusinessRules.Exceptions;
using LinkManager.Api.src.BusinessRules.Onboarding.Requests;
using LinkManager.Api.src.BusinessRules.Onboarding.Responses;
using LinkManager.Api.src.BusinessRules.Onboarding.Validators;
using LinkManager.Api.src.Helpers;
using LinkManager.Domain.src.Entities;
using LinkManager.Domain.src.Repositories;
using MongoDB.Driver.Linq;
using System;
using System.Threading.Tasks;

namespace LinkManager.Api.src.BusinessRules.Onboarding.Handlers
{
    public class CreateAccountHandler : ICreateAccountHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ICryptHelper _cryptHelper;
        private readonly ISendWellcomeMailHandler _sendWellcomeMailHandler;

        public CreateAccountHandler(
            IUserRepository userRepository,
            ICompanyRepository companyRepository,
            ICryptHelper cryptHelper,
            ISendWellcomeMailHandler sendWellcomeMailHandler
        )
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _cryptHelper = cryptHelper;
            _sendWellcomeMailHandler = sendWellcomeMailHandler;
        }

        public async Task<CreateAccountResponse> ExecuteAsync(CreateAccountRequest request)
        {
            await ValidateUser(request.User);
            await ValidateCompany(request.Company);

            var user = await CreateUser(request.User);
            await CreateCompany(request.Company, user.Id);            

            // send wellcome email
            await _sendWellcomeMailHandler.ExecuteAsync(new SendMailRequest
            {
                Name = user.Name,
                Email = user.Email
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
            var existsUserQuery = _userRepository.GetQuery().Where(q => q.Email == request.Email);
            var existsUsers = await _userRepository.GetOneAsync(existsUserQuery);
            if (existsUsers != null)
            {
                throw new ConflictException("O email informado já está sendo usado.");
            }
        }

        private async Task ValidateCompany(CreateAccountRequestCompany request)
        {
            // validar se já existe uma empresa com esse slug
            var existsCompanyQuery = _companyRepository.GetQuery().Where(q => q.Slug == request.Slug);
            var existsCompany = await _companyRepository.GetOneAsync(existsCompanyQuery);
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