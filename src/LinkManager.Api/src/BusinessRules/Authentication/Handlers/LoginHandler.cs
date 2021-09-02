using LinkManager.Api.src.BusinessRules.Authentication.Requests;
using LinkManager.Api.src.BusinessRules.Authentication.Responses;
using LinkManager.Api.src.BusinessRules.Exceptions;
using LinkManager.Domain.src.Entities;
using LinkManager.Domain.src.Repositories;
using LinkManager.Helpers.Crypt;
using LinkManager.Helpers.Jwt;
using MongoDB.Driver.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LinkManager.Api.src.BusinessRules.Authentication.Handlers
{
    public class LoginHandler : ILoginHandler
    {
        private readonly ICryptHelper _cryptHelper;
        private readonly IJwtToken _jwtToken;
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;

        public LoginHandler(
            ICryptHelper cryptHelper,
            IJwtToken jwtToken,
            IUserRepository repository,
            ICompanyRepository companyRepository
        ) => (_cryptHelper, _jwtToken, _userRepository, _companyRepository) = (cryptHelper, jwtToken, repository, companyRepository);

        public async Task<LoginResponse> ExecuteAsync(LoginRequest request)
        {
            var userQuery = _userRepository.GetQuery()
                .Where(q => q.Email == request.Email);

            var user = await _userRepository.GetOneAsync(userQuery);
            if (user == null || !_cryptHelper.IsValid(request.Password, user.Password))
            {
                throw new NotFoundException("Usuário/Senha inválido(s)");
            }

            var companyQuery = _companyRepository.GetQuery()
                .Where(q => q.UserId == user.Id);
            var company = await _companyRepository.GetOneAsync(companyQuery);
            if (company == null)
            {
                throw new NotFoundException("Empresa não encontrada");
            }

            var token = GenerateToken(user, company);

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
                    },
                    Company = new LoginResponseCompany
                    {
                        Id = company.Id,
                        Name = company.Name,
                        Slug = company.Slug
                    }
                }
            };
        }

        private string GenerateToken(User user, Company company)
        {
            var claims = new ClaimsIdentity(new Claim[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("company", company.Id.ToString())
            });

            return _jwtToken.GenerateToken(claims);
        }
    }
}