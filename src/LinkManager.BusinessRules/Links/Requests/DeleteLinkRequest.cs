using System;

namespace LinkManager.BusinessRules.Links.Requests
{
    public class DeleteLinkRequest : BusinessRuleRequest
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
    }
}