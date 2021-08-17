using HotChocolate;
using System;

namespace LinkManager.Api.src.BusinessRules.Links.Requests
{
    public class CreateLinkRequest : BusinessRuleRequest
    {
        public string Title { get; set; }
        public string Uri { get; set; }
        public bool Active { get; set; }
        [GraphQLIgnore]
        public Guid CompanyId { get; set; }
    }
}