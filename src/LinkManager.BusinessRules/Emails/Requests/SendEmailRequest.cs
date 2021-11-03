using LinkManager.Helpers.Email;

namespace LinkManager.BusinessRules.Emails.Requests
{
    public class SendEmailRequest : BusinessRuleRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public EmailTemplate Template { get; set; }
        public string Subject { get; set; }
        public object Data { get; set; }
    }
}