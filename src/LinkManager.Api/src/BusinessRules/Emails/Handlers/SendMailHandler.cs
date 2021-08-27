using LinkManager.Api.src.Helpers;

namespace LinkManager.Api.src.BusinessRules.Emails.Handlers
{
    public abstract class SendMailHandler
    {
        protected readonly IMailSenderHelper _mailSenderHelper;

        public SendMailHandler(IMailSenderHelper mailSenderHelper) => _mailSenderHelper = mailSenderHelper;
    }
}