using LinkManager.BusinessRules.Links.Requests;
using LinkManager.BusinessRules.Links.Responses;

namespace LinkManager.BusinessRules.Links.Handlers
{
    public interface IUpdateLinkHandler : 
        IBusinessRuleHandler<UpdateLinkRequest, LinkResponse, LinkResponseItem>
    {
         
    }
}