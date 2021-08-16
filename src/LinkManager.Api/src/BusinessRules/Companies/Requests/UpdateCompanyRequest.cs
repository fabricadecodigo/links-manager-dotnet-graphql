using System;

namespace LinkManager.Api.src.BusinessRules.Companies.Requests
{
    public class UpdateCompanyRequest : BusinessRuleRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public Guid UserId { get; set; }
    }
}