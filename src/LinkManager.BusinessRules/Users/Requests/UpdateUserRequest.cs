using System;

namespace LinkManager.BusinessRules.Users.Requests
{
    public class UpdateUserRequest : BusinessRuleRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}