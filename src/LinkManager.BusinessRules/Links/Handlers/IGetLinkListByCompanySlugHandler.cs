using LinkManager.BusinessRules.Links.Requests;
using LinkManager.BusinessRules.Links.Responses;
using System.Collections.Generic;

namespace LinkManager.BusinessRules.Links.Handlers
{
    public interface IGetLinkListByCompanySlugHandler : IBusinessRuleHandler<GetLinkLinkByCompanySlugRequest, LinkListResponse, List<LinkResponseItem>>
    {
         
    }
}