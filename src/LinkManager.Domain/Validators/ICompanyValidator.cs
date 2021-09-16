using FluentValidation;
using LinkManager.Domain.Entities;

namespace LinkManager.Domain.Validators
{
    public interface ICompanyValidator : IValidator<Company>
    {
    }
}