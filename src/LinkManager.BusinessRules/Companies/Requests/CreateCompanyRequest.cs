using System;

namespace LinkManager.BusinessRules.Companies.Requests
{

    public class CreateCompanyRequest : BusinessRuleRequest
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public Guid UserId { get; set; }
    }
}