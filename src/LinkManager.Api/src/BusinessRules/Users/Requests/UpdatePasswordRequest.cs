using HotChocolate;
using System;

namespace LinkManager.Api.src.BusinessRules.Users.Requests
{
    public class UpdatePasswordRequest : BusinessRuleRequest
    {

        [GraphQLIgnore]
        public Guid Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}