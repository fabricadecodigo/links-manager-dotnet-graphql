using LinkManager.BusinessRules.Emails.Requests;
using LinkManager.Helpers.Email;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Emails.Handlers
{
    public class SendWellcomeEmailHandler : SendEmailHandler, ISendWellcomeEmailHandler
    {
        public SendWellcomeEmailHandler(
            IEmailSenderHelper emailSenderHelper,
            IEmailTemplateHelper emailTemplateHelper
            ) : base(emailSenderHelper, emailTemplateHelper)
        {
        }

        public override async Task ExecuteAsync(SendEmailRequest request)
        {
            request.Template = EmailTemplate.WELLCOME;
            request.Subject = "Bem vindo ao LinksManager";
            await base.ExecuteAsync(request);
        }
    }
}