using LinkManager.Api.src.BusinessRules.Exceptions;
using LinkManager.Api.src.BusinessRules.Links.Requests;
using LinkManager.Api.src.BusinessRules.Links.Responses;
using LinkManager.Domain.src.Entities;
using LinkManager.Domain.src.Repositories;
using MongoDB.Driver.Linq;
using System;
using System.Threading.Tasks;

namespace LinkManager.Api.src.BusinessRules.Links.Handlers
{
    public class UpdateLinkHandler : IUpdateLinkHandler
    {
        private readonly ILinkRepository _repository;

        public UpdateLinkHandler(ILinkRepository repository) => _repository = repository;

        public async Task<LinkResponse> ExecuteAsync(UpdateLinkRequest request)
        {
            var linkQuery = _repository.GetQuery()
                .Where(q =>
                    q.CompanyId == request.CompanyId
                    && q.Id == request.Id
                );
            var link = await _repository.GetOneAsync(linkQuery);
            if (link == null)
            {
                throw new NotFoundException("Link não encontrado");
            }

            link.Title = request.Title;
            link.Uri = request.Uri;
            link.Active = request.Active;
            link.UpdateAt = DateTime.Now;

            link = await _repository.UpdateAsync(link.Id, link);

            return new LinkResponse
            {
                Payload = new LinkResponseItem
                {
                    Id = link.Id,
                    Title = link.Title,
                    Uri = link.Uri,
                    Active = link.Active
                }
            };
        }
    }
}