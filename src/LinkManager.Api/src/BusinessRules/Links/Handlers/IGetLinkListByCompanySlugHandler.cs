using LinkManager.Api.src.BusinessRules.Links.Requests;
using LinkManager.Api.src.BusinessRules.Links.Responses;
using System.Collections.Generic;

namespace LinkManager.Api.src.BusinessRules.Links.Handlers
{
    public interface IGetLinkListByCompanySlugHandler : IBusinessRuleHandler<GetLinkLinkByCompanySlugRequest, LinkListResponse, List<LinkResponseItem>>
    {
         
    }
}