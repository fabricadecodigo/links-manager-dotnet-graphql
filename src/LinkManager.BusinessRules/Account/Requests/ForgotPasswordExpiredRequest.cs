using System;

namespace LinkManager.BusinessRules.Account.Requests
{
    public class ForgotPasswordExpiredRequest : BusinessRuleRequest
    {
        public Guid Id { get; set; }
    }
}