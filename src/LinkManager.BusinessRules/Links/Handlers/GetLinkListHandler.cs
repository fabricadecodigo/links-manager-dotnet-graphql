using AutoMapper;
using LinkManager.BusinessRules.Links.Requests;
using LinkManager.BusinessRules.Links.Responses;
using LinkManager.Domain.Repositories;
using MongoDB.Driver.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Links.Handlers
{
    public class GetLinkListHandler : IGetLinkListHandler
    {
        private readonly IMapper _mapper;
        private readonly ILinkRepository _linkRepository;

        public GetLinkListHandler(
            IMapper mapper,
            ILinkRepository linkRepository
        )
        {
            _mapper = mapper;
            _linkRepository = linkRepository;
        }

        public async Task<LinkListResponse> ExecuteAsync(GetLinkListRequest request)
        {
            var query = _linkRepository.GetQuery()
                .Where(q => q.CompanyId == request.CompanyId);

            if (!string.IsNullOrEmpty(request.Title))
            {
                query = query.Where(q => q.Title.Contains(request.Title));
            }

            if (!string.IsNullOrEmpty(request.Uri))
            {
                query = query.Where(q => q.Uri.Contains(request.Uri));
            }

            if (request.Active.HasValue)
            {
                query = query.Where(q => q.Active == request.Active.Value);
            }

            var links = await _linkRepository.GetAllAsync(query);

            return new LinkListResponse
            {
                Payload = links
                    .Select(link => _mapper.Map<LinkResponseItem>(link))
                    .ToList()
            };
        }
    }
}