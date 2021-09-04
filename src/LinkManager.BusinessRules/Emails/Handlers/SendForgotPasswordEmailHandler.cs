using LinkManager.BusinessRules.Emails.Requests;
using LinkManager.Helpers.Email;
using System.Reflection;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Emails.Handlers
{
    public class SendForgotPasswordEmailHandler : SendEmailHandler, ISendForgotPasswordEmailHandler
    {
        public SendForgotPasswordEmailHandler(
            IEmailSenderHelper emailSenderHelper,
            IEmailTemplateHelper emailTemplateHelper) : base(emailSenderHelper, emailTemplateHelper)
        {
        }

        public async Task ExecuteAsync(SendEmailRequest request)
        {
            var html = _emailTemplateHelper
                .SetTemplateAssembly(Assembly.GetAssembly(typeof(SendEmailRequest)))
                .SetTemplate(EmailTemplate.FORGOT_PASSWORD)
                .SetData(request.Data)
                .Build();

            await _emailSenderHelper
                .SetSubject("Recuperar sua senha do LinksManager")
                .SetTo(request.Name, request.Email)
                .SetHtml(html)
                .SendMail();
        }
    }
}