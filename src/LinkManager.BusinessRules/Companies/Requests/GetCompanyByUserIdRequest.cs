using System;

namespace LinkManager.BusinessRules.Companies.Requests
{
    public class GetCompanyByUserIdRequest : BusinessRuleRequest
    {
        public Guid UserId { get; set; }
    }
}