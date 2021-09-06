using LinkManager.BusinessRules.Companies.Requests;
using LinkManager.BusinessRules.Companies.Responses;
using LinkManager.BusinessRules.Exceptions;
using LinkManager.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Companies.Handlers
{
    public class UpdateCompanyHandler : IUpdateCompanyHandler
    {
        private readonly ICompanyRepository _repository;

        public UpdateCompanyHandler(ICompanyRepository repository) => _repository = repository;

        public async Task<UpdateCompanyResponse> ExecuteAsync(UpdateCompanyRequest request)
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

            company.Name = request.Name;
            company.Slug = request.Slug;
            company.UpdateAt = DateTime.Now;

            await _repository.UpdateAsync(company.Id, company);

            return new UpdateCompanyResponse
            {
                Payload = new CompanyReponseItem()
                {
                    Id = company.Id,
                    Name = company.Name,
                    Slug = company.Slug,
                    CreateAt = company.CreateAt,
                    UpdateAt = company.UpdateAt
                }
            };
        }
    }
}