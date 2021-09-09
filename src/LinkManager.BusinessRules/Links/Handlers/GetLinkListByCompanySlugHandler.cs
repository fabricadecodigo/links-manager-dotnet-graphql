using AutoMapper;
using LinkManager.BusinessRules.Exceptions;
using LinkManager.BusinessRules.Links.Requests;
using LinkManager.BusinessRules.Links.Responses;
using LinkManager.Domain.Repositories;
using MongoDB.Driver.Linq;
using System.Linq;
using System.Threading.Tasks;
namespace LinkManager.BusinessRules.Links.Handlers
{
    public class GetLinkListByCompanySlugHandler : IGetLinkListByCompanySlugHandler
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        private readonly ILinkRepository _linkRepository;

        public GetLinkListByCompanySlugHandler(
            IMapper mapper,
            ICompanyRepository companyRepository,
            ILinkRepository linkRepository
        )
        {
            _mapper = mapper;
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
                    .Select(l => _mapper.Map<LinkResponseItem>(l))
                    .ToList()
            };
        }
    }
}