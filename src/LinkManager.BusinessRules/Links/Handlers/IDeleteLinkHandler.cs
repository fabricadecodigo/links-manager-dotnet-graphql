using LinkManager.BusinessRules.Links.Requests;
using LinkManager.BusinessRules.Links.Responses;

namespace LinkManager.BusinessRules.Links.Handlers
{
    public interface IDeleteLinkHandler : IBusinessRuleHandler<DeleteLinkRequest, DeleteLinkResponse, bool>
    {         
    }
}