using AutoMapper;
using LinkManager.BusinessRules.Exceptions;
using LinkManager.BusinessRules.Links.Requests;
using LinkManager.BusinessRules.Links.Responses;
using LinkManager.Domain.Repositories;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Links.Handlers
{
    public class GetLinkByIdHandler : IGetLinkByIdHandler
    {
        private readonly IMapper _mapper;
        private readonly ILinkRepository _repository;

        public GetLinkByIdHandler(
            IMapper mapper,
            ILinkRepository repository
        )
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<LinkResponse> ExecuteAsync(GetLinkByIdRequest request)
        {
            var link = await _repository.GetByCompanyIdAsync(request.Id, request.CompanyId);
            if (link == null)
            {
                throw new NotFoundException("Link não encontrado");
            }

            return new LinkResponse
            {
                Payload = _mapper.Map<LinkResponseItem>(link)
            };
        }
    }
}