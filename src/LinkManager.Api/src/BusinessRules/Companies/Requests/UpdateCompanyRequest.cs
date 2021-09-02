using HotChocolate;
using System;

namespace LinkManager.Api.src.BusinessRules.Companies.Requests
{
    public class UpdateCompanyRequest : BusinessRuleRequest
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        [GraphQLIgnore]
        public Guid UserId { get; set; }
    }
}