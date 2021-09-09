using AutoMapper;
using LinkManager.BusinessRules.Companies.Requests;
using LinkManager.BusinessRules.Companies.Responses;
using LinkManager.BusinessRules.Exceptions;
using LinkManager.Domain.Repositories;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Companies.Handlers
{
    public class GetCompanyByIdHandler : IGetCompanyByIdHandler
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _repository;

        public GetCompanyByIdHandler(IMapper mapper, ICompanyRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CompanyResponse> ExecuteAsync(GetCompanyByIdRequest request)
        {
            var company = await _repository.GetByUserIdAsync(request.UserId);
            if (company == null)
            {
                throw new NotFoundException("Empresa não encontrada");
            }

            return new CompanyResponse
            {
                Payload = _mapper.Map<CompanyResponseItem>(company)
            };
        }
    }
}