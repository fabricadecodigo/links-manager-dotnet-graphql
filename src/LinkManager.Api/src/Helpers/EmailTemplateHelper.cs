using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace LinkManager.Api.src.Helpers
{
    public class EmailTemplateHelper : IEmailTemplateHelper
    {


        private static readonly Dictionary<EmailTemplate, string> EmailTemplateValues = new Dictionary<EmailTemplate, string>()
        {
            [EmailTemplate.WELLCOME] = "wellcome"
        };


        private string GetTemplateName(EmailTemplate identifier)
        {
            return EmailTemplateValues[identifier];
        }

        public string GetEmailTempalte(EmailTemplate identifier)
        {
            var templateName = GetEmailTempalte(identifier);
            var templateFullName = $"LinkManager.Api.src.BusinessRules.Emails.Templates.{templateName}.html";

            using var stream = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream(templateFullName);

            using var reader = new StreamReader(stream);
            var source = reader.ReadToEnd();

            return source;
        }
    }
}