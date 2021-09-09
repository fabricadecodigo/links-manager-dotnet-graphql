using FluentValidation;
using LinkManager.Domain.Entities;
using LinkManager.Domain.Repositories;

namespace LinkManager.Domain.Validators
{
    public class CompanyValidator : AbstractValidator<Company>, ICompanyValidator
    {
        public CompanyValidator(
            ICompanyRepository companyRepository
        )
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(250)
                .WithName("Nome");

            RuleFor(r => r.Slug)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(50)
                .WithName("Slug");

            RuleFor(r => r)
                .MustAsync(async (company, cancellation) =>
                {
                    var entity = await companyRepository.GetBySlugAsync(company.Slug);
                    if (entity != null)
                    {
                        return company.Id == entity.Id;
                    }

                    return true;
                })
                .WithMessage("O slug informado já está sendo usado.");
        }
    }
}