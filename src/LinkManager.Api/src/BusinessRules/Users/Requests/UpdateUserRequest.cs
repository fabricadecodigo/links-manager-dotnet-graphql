using HotChocolate;
using System;

namespace LinkManager.Api.src.BusinessRules.Users.Requests
{
    public class UpdateUserRequest : BusinessRuleRequest
    {
        [GraphQLIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}