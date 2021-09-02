using LinkManager.Api.src.BusinessRules.Emails.Requests;
using LinkManager.Api.src.Helpers;
using System.Threading.Tasks;

namespace LinkManager.Api.src.BusinessRules.Emails.Handlers
{
    public class SendForgotPasswordEmailHandler : SendEmailHandler, ISendForgotPasswordEmailHandler
    {
        public SendForgotPasswordEmailHandler(
            IMailSenderHelper mailSenderHelper, 
            IEmailTemplateHelper emailTemplateHelper) : base(mailSenderHelper, emailTemplateHelper)
        {
        }

        public async Task ExecuteAsync(SendEmailRequest request)
        {
            var html = _emailTemplateHelper
                .SetTemplate(EmailTemplate.FORGOT_PASSWORD)
                .SetData(request.Data)
                .Build();

            await _mailSenderHelper
                .SetSubject("Recuperar sua senha do LinksManager")
                .SetTo(request.Name, request.Email)
                .SetHtml(html)
                .SendMail();
        }
    }
}