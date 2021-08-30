namespace LinkManager.Api.src.BusinessRules.Users.Requests
{
    public class ForgotPasswordRequest : BusinessRuleRequest
    {
        public string Email { get; set; }
    }
}