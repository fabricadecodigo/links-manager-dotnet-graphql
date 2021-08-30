using LinkManager.Api.src.Helpers;

namespace LinkManager.Api.src.BusinessRules.Emails.Handlers
{
    public abstract class SendEmailHandler
    {
        protected readonly IMailSenderHelper _mailSenderHelper;
        protected readonly IEmailTemplateHelper _emailTemplateHelper;

        public SendEmailHandler(
            IMailSenderHelper mailSenderHelper, 
            IEmailTemplateHelper emailTemplateHelper) 
        => (_mailSenderHelper, _emailTemplateHelper) = (mailSenderHelper, emailTemplateHelper);
    }
}