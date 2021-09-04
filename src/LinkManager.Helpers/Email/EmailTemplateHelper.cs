using HandlebarsDotNet;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace LinkManager.Helpers.Email
{
    public class EmailTemplateHelper : IEmailTemplateHelper
    {
        private static readonly Dictionary<EmailTemplate, string> EmailTemplateValues = new Dictionary<EmailTemplate, string>()
        {
            [EmailTemplate.WELLCOME] = "wellcome",
            [EmailTemplate.FORGOT_PASSWORD] = "forgot-password"
        };

        private EmailTemplate Identifier { get; set; }
        private object Data { get; set; }

        public IEmailTemplateHelper SetTemplate(EmailTemplate identifier)
        {
            Identifier = identifier;
            return this;
        }

        public IEmailTemplateHelper SetData(object data)
        {
            Data = data;
            return this;
        }

        public string Build()
        {
            var source = GetEmailTempalte(Identifier);
            var template = Handlebars.Compile(source);
            var result = template(Data);
            return result;
        }

        private string GetEmailTempalte(EmailTemplate identifier)
        {
            var templateName = GetTemplateName(identifier);
            var templateFullName = $"LinkManager.BusinessRules.Emails.Templates.{templateName}.html";

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(templateFullName))
            {
                using (var reader = new StreamReader(stream))
                {
                    var source = reader.ReadToEnd();
                    return source;
                }
            }
        }

        private string GetTemplateName(EmailTemplate identifier)
        {
            return EmailTemplateValues[identifier];
        }
    }
}