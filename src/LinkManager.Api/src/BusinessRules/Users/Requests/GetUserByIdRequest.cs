using System;

namespace LinkManager.Api.src.BusinessRules.Users.Requests
{
    public class GetUserByIdRequest : BusinessRuleRequest
    {
        public Guid Id { get; set; }
    }
}