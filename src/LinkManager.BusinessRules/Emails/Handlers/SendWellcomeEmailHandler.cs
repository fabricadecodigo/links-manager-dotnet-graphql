using LinkManager.BusinessRules.Emails.Requests;
using LinkManager.Helpers.Email;
using System.Reflection;
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

        public async Task ExecuteAsync(SendEmailRequest request)
        {
            var html = _emailTemplateHelper
                .SetTemplateAssembly(Assembly.GetAssembly(typeof(SendEmailRequest)))
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