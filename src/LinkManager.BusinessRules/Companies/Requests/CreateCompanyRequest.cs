namespace LinkManager.BusinessRules.Companies.Requests
{
    using HotChocolate;
    using System;

    public class CreateCompanyRequest : BusinessRuleRequest
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        [GraphQLIgnore]
        public Guid UserId { get; set; }
    }
}