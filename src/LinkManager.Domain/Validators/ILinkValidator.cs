using FluentValidation;
using LinkManager.Domain.Entities;

namespace LinkManager.Domain.Validators
{
    public interface ILinkValidator : IValidator<Link>
    {         
    }
}