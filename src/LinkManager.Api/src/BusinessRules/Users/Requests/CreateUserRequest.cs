namespace LinkManager.Api.src.BusinessRules.Users.Requests
{
    public class CreateUserRequest : BusinessRuleRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}