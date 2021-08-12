using LinkManager.Api.src.BusinessRules.Authentication.Requests;
using LinkManager.Api.src.BusinessRules.Authentication.Responses;
using LinkManager.Api.src.BusinessRules.Exceptions;
using LinkManager.Api.src.Helpers;
using LinkManager.Domain.src.Entities;
using LinkManager.Domain.src.Repositories;
using MongoDB.Driver.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LinkManager.Api.src.BusinessRules.Authentication.Handlers
{
    public class LoginHandler : ILoginHandler
    {
        private readonly ICryptHelper _cryptHelper;
        private readonly IJwtToken _jwtToken;
        private readonly IUserRepository _repository;

        public LoginHandler(
            ICryptHelper cryptHelper,
            IJwtToken jwtToken,
            IUserRepository repository
        ) => (_cryptHelper, _jwtToken, _repository) = (cryptHelper, jwtToken, repository);

        public async Task<LoginResponse> ExecuteAsync(LoginRequest request)
        {
            var query = _repository.GetQuery()
                .Where(q => q.Email == request.Email);

            var user = await _repository.GetOneAsync(query);
            if (user == null || !_cryptHelper.IsValid(request.Password, user.Password))
            {
                throw new NotFoundException("Usuário/Senha inválido(s)");
            }

            var token = GenerateToken(user);

            return new LoginResponse
            {
                Payload = new LoginResponseData
                {
                    AccessToken = token,
                    User = new LoginResponseUser
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email
                    }
                }
            };
        }

        private string GenerateToken(User user)
        {
            var claims = new ClaimsIdentity(new Claim[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
            });

            return _jwtToken.GenerateToken(claims);
        }
    }
}