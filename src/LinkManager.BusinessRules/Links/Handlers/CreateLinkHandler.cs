using AutoMapper;
using LinkManager.BusinessRules.Exceptions;
using LinkManager.BusinessRules.Links.Requests;
using LinkManager.BusinessRules.Links.Responses;
using LinkManager.Domain.Entities;
using LinkManager.Domain.Repositories;
using LinkManager.Domain.Validators;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Links.Handlers
{
    public class CreateLinkHandler : ICreateLinkHandler
    {
        private readonly IMapper _mapper;
        private readonly ILinkRepository _repository;
        private readonly ILinkValidator _linkValidator;

        public CreateLinkHandler(
            IMapper mapper,
            ILinkRepository repository,
            ILinkValidator linkValidator
        )
        {
            _mapper = mapper;
            _repository = repository;
            _linkValidator = linkValidator;
        }

        public async Task<LinkResponse> ExecuteAsync(CreateLinkRequest request)
        {
            var link = _mapper.Map<Link>(request);
            var validationResult = _linkValidator.Validate(link);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Erro ao criar um link", validationResult.Errors);
            }

            await _repository.CreateAsync(link);

            return new LinkResponse
            {
                Payload = _mapper.Map<LinkResponseItem>(link)
            };
        }
    }
}