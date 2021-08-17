using LinkManager.Api.src.BusinessRules.Links.Requests;
using LinkManager.Api.src.BusinessRules.Links.Responses;
using LinkManager.Domain.src.Entities;
using LinkManager.Domain.src.Repositories;
using System;
using System.Threading.Tasks;

namespace LinkManager.Api.src.BusinessRules.Links.Handlers
{
    public class CreateLinkHandler : ICreateLinkHandler
    {
        private readonly ILinkRepository _repository;

        public CreateLinkHandler(ILinkRepository repository) => _repository = repository;

        public async Task<LinkResponse> ExecuteAsync(CreateLinkRequest request)
        {
            var link = await _repository.CreateAsync(new Link
            {
                Title = request.Title,
                Uri = request.Uri,
                Active = request.Active,
                CompanyId = request.CompanyId,
                CreateAt = DateTime.Now,
            });

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