using System;

namespace LinkManager.Api.src.BusinessRules.Users.Requests
{
    public class ResetPasswordRequest : BusinessRuleRequest
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
    }
}