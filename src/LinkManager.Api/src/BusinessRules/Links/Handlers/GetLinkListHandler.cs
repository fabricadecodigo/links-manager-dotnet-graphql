using LinkManager.Api.src.BusinessRules.Links.Requests;
using LinkManager.Api.src.BusinessRules.Links.Responses;
using LinkManager.Domain.src.Repositories;
using MongoDB.Driver.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace LinkManager.Api.src.BusinessRules.Links.Handlers
{
    public class GetLinkListHandler : IGetLinkListHandler
    {
        private readonly ILinkRepository _repository;

        public GetLinkListHandler(ILinkRepository repository) => _repository = repository;

        public async Task<LinkListResponse> ExecuteAsync(GetLinkListRequest request)
        {
            var query = _repository.GetQuery()
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

            var links = await _repository.GetAllAsync(query);

            return new LinkListResponse
            {
                Payload = links
                    .Select(l => new LinkResponseItem()
                    {
                        Id = l.Id,
                        Title = l.Title,
                        Uri = l.Uri,
                        Active = l.Active
                    })
                    .ToList()
            };
        }
    }
}