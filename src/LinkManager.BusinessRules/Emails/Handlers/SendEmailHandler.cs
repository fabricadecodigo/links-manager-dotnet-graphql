using System.Reflection;
using System.Threading.Tasks;
using LinkManager.BusinessRules.Emails.Requests;
using LinkManager.Helpers.Email;

namespace LinkManager.BusinessRules.Emails.Handlers
{
    public abstract class SendEmailHandler : IBusinessRuleHandler<SendEmailRequest>
    {
        private readonly IEmailSenderHelper _emailSenderHelper;
        private readonly IEmailTemplateHelper _emailTemplateHelper;

        public SendEmailHandler(
            IEmailSenderHelper emailSenderHelper,
            IEmailTemplateHelper emailTemplateHelper)
        {
            _emailSenderHelper = emailSenderHelper;
            _emailTemplateHelper = emailTemplateHelper;
        }
        
        public async Task ExecuteAsync(SendEmailRequest request)
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