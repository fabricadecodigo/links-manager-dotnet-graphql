using System;

namespace LinkManager.BusinessRules.Users.Requests
{
    public class GetUserByIdRequest : BusinessRuleRequest
    {
        public Guid Id { get; set; }
    }
}