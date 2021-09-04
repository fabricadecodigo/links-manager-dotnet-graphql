using HotChocolate;
using System;

namespace LinkManager.BusinessRules.Users.Requests
{
    public class UpdatePasswordRequest : BusinessRuleRequest
    {
        [GraphQLIgnore]
        public Guid Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}