namespace LinkManager.Api.src.BusinessRules.Emails.Requests
{
    public class SendEmailRequest : BusinessRuleRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public object Data { get; set; }
    }
}