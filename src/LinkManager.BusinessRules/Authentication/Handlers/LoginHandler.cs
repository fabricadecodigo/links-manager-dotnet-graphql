
using LinkManager.BusinessRules.Authentication.Requests;
using LinkManager.BusinessRules.Authentication.Responses;
using LinkManager.BusinessRules.Exceptions;
using LinkManager.Domain.src.Entities;
using LinkManager.Domain.src.Repositories;
using LinkManager.Helpers.Crypt;
using LinkManager.Helpers.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Authentication.Handlers
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
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || !_cryptHelper.IsValid(request.Password, user.Password))
            {
                throw new NotFoundException("Usuário/Senha inválido(s)");
            }

            var company = await _companyRepository.GetByUserIdAsync(user.Id);
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