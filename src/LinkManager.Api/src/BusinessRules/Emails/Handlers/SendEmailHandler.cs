

namespace LinkManager.Api.src.BusinessRules.Emails.Handlers
{
    using LinkManager.Helpers.Email;

    public abstract class SendEmailHandler
    {
        protected readonly IEmailSenderHelper _emailSenderHelper;
        protected readonly IEmailTemplateHelper _emailTemplateHelper;

        public SendEmailHandler(
            IEmailSenderHelper mailSenderHelper, 
            IEmailTemplateHelper emailTemplateHelper) 
        => (_emailSenderHelper, _emailTemplateHelper) = (mailSenderHelper, emailTemplateHelper);
    }
}