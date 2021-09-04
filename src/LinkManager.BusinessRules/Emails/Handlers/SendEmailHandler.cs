using LinkManager.BusinessRules.Emails.Requests;
using LinkManager.Helpers.Email;
using System.Reflection;
using System.Threading.Tasks;

namespace LinkManager.BusinessRules.Emails.Handlers
{
    public abstract class SendEmailHandler : IBusinessRuleHandler<SendEmailRequest>
    {
        private readonly IEmailSenderHelper _emailSenderHelper;
        private readonly IEmailTemplateHelper _emailTemplateHelper;

        public SendEmailHandler(
            IEmailSenderHelper mailSenderHelper,
            IEmailTemplateHelper emailTemplateHelper)
        => (_emailSenderHelper, _emailTemplateHelper) = (mailSenderHelper, emailTemplateHelper);

        public virtual async Task ExecuteAsync(SendEmailRequest request)
        {
            var html = _emailTemplateHelper
                .SetTemplateAssembly(Assembly.GetAssembly(typeof(SendEmailRequest)))
                .SetTemplate(request.Template)
                .SetData(request.Data)
                .Build();

            await _emailSenderHelper
                .SetSubject(request.Subject)
                .SetTo(request.Name, request.Email)
                .SetHtml(html)
                .SendMail();
        }
    }
}