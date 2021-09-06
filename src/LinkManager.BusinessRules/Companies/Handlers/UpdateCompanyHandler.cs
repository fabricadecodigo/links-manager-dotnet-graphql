using LinkManager.BusinessRules.Companies.Requests;
using LinkManager.BusinessRules.Companies.Responses;
using LinkManager.BusinessRules.Companies.Validators;
using LinkManager.BusinessRules.Exceptions;
using LinkManager.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Companies.Handlers
{
    public class UpdateCompanyHandler : IUpdateCompanyHandler
    {
        private readonly ICompanyRepository _repository;
        private readonly IUpdateCompanyValidator _updateCompanyValidator;

        public UpdateCompanyHandler(
            ICompanyRepository repository,
            IUpdateCompanyValidator updateCompanyValidator
        )
        {
            _repository = repository;
            _updateCompanyValidator = updateCompanyValidator;
        }

        public async Task<UpdateCompanyResponse> ExecuteAsync(UpdateCompanyRequest request)
        {
            var validationResult = _updateCompanyValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Erro ao alterar a empresa", validationResult.Errors);
            }

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