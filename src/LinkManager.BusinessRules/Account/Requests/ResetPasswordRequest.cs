using System;

namespace LinkManager.BusinessRules.Account.Requests
{
    public class ResetPasswordRequest : BusinessRuleRequest
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
    }
}