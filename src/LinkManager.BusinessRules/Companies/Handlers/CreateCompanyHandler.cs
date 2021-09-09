using AutoMapper;
using LinkManager.BusinessRules.Companies.Requests;
using LinkManager.BusinessRules.Companies.Responses;
using LinkManager.BusinessRules.Exceptions;
using LinkManager.Domain.Entities;
using LinkManager.Domain.Repositories;
using LinkManager.Domain.Validators;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Companies.Handlers
{
    public class CreateCompanyHandler : ICreateCompanyHandler
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyValidator _companyValidator;

        public CreateCompanyHandler(
            IMapper mapper,
            ICompanyRepository companyRepository,
            ICompanyValidator companyValidator
        )
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
            _companyValidator = companyValidator;
        }

        public async Task<CompanyResponse> ExecuteAsync(CreateCompanyRequest request)
        {
            var company = _mapper.Map<Company>(request);
            var validationResult = _companyValidator.Validate(company);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Erro ao criar a empresa", validationResult.Errors);
            }

            var userCompany = _companyRepository.GetByUserIdAsync(request.UserId);
            if (userCompany != null)
            {
                throw new ConflictException("Você não pode criar novas empresas");
            };

            company = await _companyRepository.CreateAsync(company);

            return new CompanyResponse
            {
                Payload = _mapper.Map<CompanyResponseItem>(company)
            };
        }
    }
}