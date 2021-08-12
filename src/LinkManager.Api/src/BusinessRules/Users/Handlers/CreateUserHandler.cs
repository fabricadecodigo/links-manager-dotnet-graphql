using FluentValidation;
using LinkManager.Api.src.BusinessRules.Exceptions;
using LinkManager.Api.src.BusinessRules.Users.Requests;
using LinkManager.Api.src.BusinessRules.Users.Responses;
using LinkManager.Api.src.BusinessRules.Users.Validators;
using LinkManager.Api.src.Helpers;
using LinkManager.Domain.src.Entities;
using LinkManager.Domain.src.Repositories;
using MongoDB.Driver.Linq;
using System;
using System.Threading.Tasks;

namespace LinkManager.Api.src.BusinessRules.Users.Handlers
{
    public class CreateUserHandler : ICreateUserHandler
    {
        private readonly ICryptHelper _cryptHelper;
        private readonly IUserRepository _repository;

        public CreateUserHandler(ICryptHelper cryptHelper, IUserRepository repository)
            => (_cryptHelper, _repository) = (cryptHelper, repository);

        public async Task<CreateUserResponse> ExecuteAsync(CreateUserRequest request)
        {
            // Validação
            new CreateUserRequestValidator().ValidateAndThrow(request);

            // validar se já existe um usuário
            var existsUserQuery = _repository.GetQuery().Where(q => q.Email == request.Email);
            var existsUsers = await _repository.GetOneAsync(existsUserQuery);
            if (existsUsers != null)
            {
                throw new ConflictException("O email informado já está sendo usado.");
            }

            // encriptografar a senha            
            request.Password = _cryptHelper.Encrypt(request.Password);

            var response = await _repository.CreateAsync(new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                CreateAt = DateTime.Now,
            });

            return new CreateUserResponse
            {
                Payload = new UserResponse()
                {
                    Id = response.Id,
                    Name = response.Name,
                    Email = response.Email,
                    CreateAt = response.CreateAt,
                }
            };
        }
    }
}