using FluentValidation;
using LinkManager.Domain.Entities;

namespace LinkManager.Domain.Validators
{
    public class LinkValidator : AbstractValidator<Link>, ILinkValidator
    {
        public LinkValidator()
        {
            RuleFor(r => r.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(150)
                .WithName("Título");

            RuleFor(r => r.Uri)
                .NotEmpty()
                .NotNull()
                .MinimumLength(11) // http://a.io
                .MaximumLength(250)
                .WithName("Url");

            RuleFor(r => r.CompanyId)
                .NotEmpty()
                .WithName("Empresa");
        }
    }
}