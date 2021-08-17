using LinkManager.Api.src.BusinessRules.Links.Requests;
using LinkManager.Api.src.BusinessRules.Links.Responses;

namespace LinkManager.Api.src.BusinessRules.Links.Handlers
{
    public interface IUpdateLinkHandler : IBusinessRuleHandler<UpdateLinkRequest, LinkResponse, LinkResponseItem>
    {
         
    }
}