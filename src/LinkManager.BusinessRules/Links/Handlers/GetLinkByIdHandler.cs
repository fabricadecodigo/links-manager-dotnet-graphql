using LinkManager.BusinessRules.Exceptions;
using LinkManager.BusinessRules.Links.Requests;
using LinkManager.BusinessRules.Links.Responses;
using LinkManager.Domain.Entities;
using LinkManager.Domain.Repositories;
using MongoDB.Driver.Linq;
using System;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Links.Handlers
{
    public class GetLinkByIdHandler : IGetLinkByIdHandler
    {
        private readonly ILinkRepository _repository;

        public GetLinkByIdHandler(ILinkRepository repository) => _repository = repository;

        public async Task<LinkResponse> ExecuteAsync(GetLinkByIdRequest request)
        {
            var link = await _repository.GetByCompanyIdAsync(request.Id, request.CompanyId);
            if (link == null)
            {
                throw new NotFoundException("Link não encontrado");
            }

            return new LinkResponse
            {
                Payload = new LinkResponseItem
                {
                    Id = link.Id,
                    Title = link.Title,
                    Uri = link.Uri,
                    Active = link.Active,
                    CreateAt = link.CreateAt,
                    UpdateAt = link.UpdateAt
                }
            };
        }
    }
}