using LinkManager.Domain.src.Repositories;

namespace LinkManager.Api.src.BusinessRules.Links.Handlers
{
    using LinkManager.Api.src.BusinessRules.Exceptions;
    using LinkManager.Api.src.BusinessRules.Links.Requests;
    using LinkManager.Api.src.BusinessRules.Links.Responses;
    using MongoDB.Driver.Linq;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetLinkListByCompanySlugHandler : IGetLinkListByCompanySlugHandler
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILinkRepository _linkRepository;

        public GetLinkListByCompanySlugHandler(
            ICompanyRepository companyRepository,
            ILinkRepository linkRepository
        )
        {
            _companyRepository = companyRepository;
            _linkRepository = linkRepository;
        }

        public async Task<LinkListResponse> ExecuteAsync(GetLinkLinkByCompanySlugRequest request)
        {
            var company = await _companyRepository.GetBySlugAsync(request.Slug);
            if (company == null)
            {
                throw new NotFoundException("Empresa não encontrada");
            }

            var query = _linkRepository.GetQuery()
                .Where(q =>
                    q.CompanyId == company.Id
                    && q.Active
                );

            var links = await _linkRepository.GetAllAsync(query);

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