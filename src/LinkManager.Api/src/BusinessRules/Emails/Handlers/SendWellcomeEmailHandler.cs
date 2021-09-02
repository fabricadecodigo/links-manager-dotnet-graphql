using HandlebarsDotNet;
using LinkManager.Api.src.BusinessRules.Emails.Requests;
using LinkManager.Api.src.Helpers;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace LinkManager.Api.src.BusinessRules.Emails.Handlers
{
    public class SendWellcomeEmailHandler : SendEmailHandler, ISendWellcomeEmailHandler
    {
        public SendWellcomeEmailHandler(
            IMailSenderHelper mailSenderHelper,
            IEmailTemplateHelper emailTemplateHelper
            ) : base(mailSenderHelper, emailTemplateHelper)
        {
        }

        public async Task ExecuteAsync(SendEmailRequest request)
        {
            var html = _emailTemplateHelper
                .SetTemplate(EmailTemplate.WELLCOME)
                .SetData(request.Data)
                .Build();

            await _mailSenderHelper
                .SetSubject("Bem vindo ao LinksManager")
                .SetTo(request.Name, request.Email)
                .SetHtml(html)
                .SendMail();
        }
    }
}