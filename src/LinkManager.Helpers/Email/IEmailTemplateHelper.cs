using System.Reflection;

namespace LinkManager.Helpers.Email
{
    public interface IEmailTemplateHelper
    {
         IEmailTemplateHelper SetTemplateAssembly(Assembly assembly);
         IEmailTemplateHelper SetTemplate(EmailTemplate identifier);
         IEmailTemplateHelper SetData(object data);
         string Build();
    }
}