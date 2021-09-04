using System;

namespace LinkManager.BusinessRules.Companies.Requests
{
    public class GetCompanyByIdRequest : BusinessRuleRequest
    {
        public Guid UserId { get; set; }
    }
}