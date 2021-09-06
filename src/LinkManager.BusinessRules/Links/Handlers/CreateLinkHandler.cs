using LinkManager.BusinessRules.Links.Requests;
using LinkManager.BusinessRules.Links.Responses;
using LinkManager.Domain.Entities;
using LinkManager.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Links.Handlers
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
                    Active = link.Active,
                    CreateAt = link.CreateAt
                }
            };

        }
    }
}