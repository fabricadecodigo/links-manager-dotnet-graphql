namespace LinkManager.BusinessRules.Authentication.Requests
{
    public class LoginRequest : BusinessRuleRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}