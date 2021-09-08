namespace LinkManager.BusinessRules.Companies.Requests
{
    using System;

    public class CreateCompanyRequest : BusinessRuleRequest
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public Guid UserId { get; set; }
    }
}