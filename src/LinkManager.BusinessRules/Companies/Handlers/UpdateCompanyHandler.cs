using AutoMapper;
using LinkManager.BusinessRules.Companies.Requests;
using LinkManager.BusinessRules.Companies.Responses;
using LinkManager.BusinessRules.Exceptions;
using LinkManager.Domain.Repositories;
using LinkManager.Domain.Validators;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Companies.Handlers
{

    public class UpdateCompanyHandler : IUpdateCompanyHandler
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _repository;
        private readonly ICompanyValidator _companyValidator;
        
        public UpdateCompanyHandler(
            IMapper mapper,
            ICompanyRepository repository,
            ICompanyValidator companyValidator
        )
        {
            _mapper = mapper;
            _repository = repository;
            _companyValidator = companyValidator;
        }

        public async Task<CompanyResponse> ExecuteAsync(UpdateCompanyRequest request)
        {
            var company = await _repository.GetByUserIdAsync(request.UserId);
            if (company == null)
            {
                throw new NotFoundException("Empresa não encontrada");
            }

            if (company.UserId != request.UserId)
            {
                throw new UnauthorizedException("Você não pode alterar essa empresa");
            }

            _mapper.Map(request, company);
            var validationResult = _companyValidator.Validate(company);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Erro ao alterar a empresa", validationResult.Errors);
            }

            company = await _repository.UpdateAsync(company.Id, company);

            return new CompanyResponse
            {
                Payload = _mapper.Map<CompanyResponseItem>(company)
            };
        }
    }
}