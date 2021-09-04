namespace LinkManager.BusinessRules.Account.Requests
{
    public class ForgotPasswordRequest : BusinessRuleRequest
    {
        public string Email { get; set; }
    }
}