namespace LinkManager.Api.src.BusinessRules.Onboarding.Requests
{
    public class CreateAccountRequest : BusinessRuleRequest
    {
        public CreateAccountRequestUser User { get; set; }
        public CreateAccountRequestCompany Company { get; set; }
    }

    public class CreateAccountRequestUser 
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class CreateAccountRequestCompany
    {
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}