using HotChocolate;
using System;

namespace LinkManager.Api.src.BusinessRules.Links.Requests
{
    public class DeleteLinkRequest : BusinessRuleRequest
    {
        public Guid Id { get; set; }
        [GraphQLIgnore]
        public Guid CompanyId { get; set; }
    }
}