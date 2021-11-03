using LinkManager.BusinessRules.Emails.Requests;
using LinkManager.Helpers.Email;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Emails.Handlers
{
    public class SendForgotPasswordEmailHandler : SendEmailHandler, ISendForgotPasswordEmailHandler
    {
        public SendForgotPasswordEmailHandler(
            IEmailSenderHelper emailSenderHelper,
            IEmailTemplateHelper emailTemplateHelper)
            : base(emailSenderHelper, emailTemplateHelper)
        {
        }

        public override async Task ExecuteAsync(SendEmailRequest request)
        {
            request.Template = EmailTemplate.FORGOT_PASSWORD;
            request.Subject = "Recuperar sua senha do LinksManager";
            await base.ExecuteAsync(request);
        }
    }
}