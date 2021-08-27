namespace LinkManager.Api.src.BusinessRules.Emails.Requests
{
    public class SendMailRequest : BusinessRuleRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}