using LinkManager.Api.src.BusinessRules.Companies.Requests;
using LinkManager.Api.src.BusinessRules.Companies.Responses;
using LinkManager.Api.src.BusinessRules.Exceptions;
using LinkManager.Domain.src.Repositories;
using MongoDB.Driver.Linq;
using System;
using System.Threading.Tasks;

namespace LinkManager.Api.src.BusinessRules.Companies.Handlers
{
    public class GetCompanyByIdHandler : IGetCompanyByIdHandler
    {
        private readonly ICompanyRepository _repository;

        public GetCompanyByIdHandler(ICompanyRepository repository) => _repository = repository;

        public async Task<CompanyResponse> ExecuteAsync(GetCompanyByIdRequest request)
        {
            var companyQuery = _repository.GetQuery()
                .Where(q =>
                    q.Id == request.Id
                    && q.UserId == request.UserId
                );
            var company = await _repository.GetOneAsync(companyQuery);
            if (company == null)
            {
                throw new NotFoundException("Empresa não encontrada");
            }

            return new CompanyResponse
            {
                Payload = new CompanyReponseItem
                {
                    Id = company.Id,
                    Name = company.Name,
                    Slug = company.Slug
                }
            };
        }
    }
}