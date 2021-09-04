using System;

namespace LinkManager.BusinessRules.Links.Requests
{
    public class CreateLinkRequest : BusinessRuleRequest
    {
        public string Title { get; set; }
        public string Uri { get; set; }
        public bool Active { get; set; }
        public Guid CompanyId { get; set; }
    }
}