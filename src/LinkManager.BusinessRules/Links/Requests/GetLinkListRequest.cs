namespace LinkManager.BusinessRules.Links.Requests
{
    using HotChocolate;
    using System;

    public class GetLinkListRequest : BusinessRuleRequest
    {
        public string Title { get; set; }
        public string Uri { get; set; }
        public bool? Active { get; set; }
        [GraphQLIgnore]
        public Guid CompanyId { get; set; }
    }
}