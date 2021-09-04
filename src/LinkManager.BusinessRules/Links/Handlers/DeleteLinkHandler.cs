using LinkManager.BusinessRules.Exceptions;
using LinkManager.BusinessRules.Links.Requests;
using LinkManager.BusinessRules.Links.Responses;
using LinkManager.Domain.src.Repositories;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;


namespace LinkManager.BusinessRules.Links.Handlers
{
    public class DeleteLinkHandler : IDeleteLinkHandler
    {
        private readonly ILinkRepository _repository;

        public DeleteLinkHandler(ILinkRepository repository) => _repository = repository;

        public async Task<DeleteLinkResponse> ExecuteAsync(DeleteLinkRequest request)
        {
            var existsLinkQuery = _repository.GetQuery()
                .Where(q =>
                    q.CompanyId == request.CompanyId
                    && q.Id == request.Id
                );
            var existsLink = await _repository.ExistsAsync(existsLinkQuery);
            if (!existsLink)
            {
                throw new NotFoundException("Link não encontrado");
            }

            await _repository.DeleteAsync(request.Id);

            return new DeleteLinkResponse
            {
                Payload = true
            };
        }
    }
}