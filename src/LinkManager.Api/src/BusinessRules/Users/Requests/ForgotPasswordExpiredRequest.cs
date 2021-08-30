using System;

namespace LinkManager.Api.src.BusinessRules.Users.Requests
{
    public class ForgotPasswordExpiredRequest : BusinessRuleRequest
    {
        public Guid Id { get; set; }
    }
}