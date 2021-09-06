using FluentValidation;
using LinkManager.BusinessRules.Companies.Requests;
using LinkManager.Domain.Repositories;

namespace LinkManager.BusinessRules.Companies.Validators
{
    public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyRequest>, IUpdateCompanyValidator
    {
        public UpdateCompanyValidator(
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

            RuleFor(r => r.Slug)
                .MustAsync(async (slug, cancellation) =>
                {
                    var company = await companyRepository.GetBySlugAsync(slug);
                    return company == null;
                })
                .WithMessage("O slug informado já está sendo usado.");
        }
    }
}