using HotChocolate;
using System;

namespace LinkManager.BusinessRules.Links.Requests
{
    public class GetLinkListRequest : BusinessRuleRequest
    {
        public string Title { get; set; }
        public string Uri { get; set; }
        public bool? Active { get; set; }
        [GraphQLIgnore]
        public Guid CompanyId { get; set; }
    }
}