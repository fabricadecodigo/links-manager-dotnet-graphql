using AutoMapper;
using LinkManager.BusinessRules.Exceptions;
using LinkManager.BusinessRules.Links.Requests;
using LinkManager.BusinessRules.Links.Responses;
using LinkManager.Domain.Repositories;
using LinkManager.Domain.Validators;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Links.Handlers
{
    public class UpdateLinkHandler : IUpdateLinkHandler
    {
        private readonly IMapper _mapper;
        private readonly ILinkRepository _repository;
        private readonly ILinkValidator _linkValidator;

        public UpdateLinkHandler(
            IMapper mapper,
            ILinkRepository repository,
            ILinkValidator linkValidator
        )
        {
            _mapper = mapper;
            _repository = repository;
            _linkValidator = linkValidator;
        }

        public async Task<LinkResponse> ExecuteAsync(UpdateLinkRequest request)
        {
            var link = await _repository.GetByCompanyIdAsync(request.Id, request.CompanyId);
            if (link == null)
            {
                throw new NotFoundException("Link não encontrado");
            }

            _mapper.Map(request, link);
            var validationResult = _linkValidator.Validate(link);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Erro ao alterar um link", validationResult.Errors);
            }

            link = await _repository.UpdateAsync(link.Id, link);

            return new LinkResponse
            {
                Payload = _mapper.Map<LinkResponseItem>(link)
            };
        }
    }
}