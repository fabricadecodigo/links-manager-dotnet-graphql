using LinkManager.Api.src.BusinessRules.Emails.Requests;
using LinkManager.Helpers.Email;
using System.Threading.Tasks;

namespace LinkManager.Api.src.BusinessRules.Emails.Handlers
{
    public class SendWellcomeEmailHandler : SendEmailHandler, ISendWellcomeEmailHandler
    {
        public SendWellcomeEmailHandler(
            IEmailSenderHelper emailSenderHelper,
            IEmailTemplateHelper emailTemplateHelper
            ) : base(emailSenderHelper, emailTemplateHelper)
        {
        }

        public async Task ExecuteAsync(SendEmailRequest request)
        {
            var html = _emailTemplateHelper
                .SetTemplate(EmailTemplate.WELLCOME)
                .SetData(request.Data)
                .Build();

            await _emailSenderHelper
                .SetSubject("Bem vindo ao LinksManager")
                .SetTo(request.Name, request.Email)
                .SetHtml(html)
                .SendMail();
        }
    }
}