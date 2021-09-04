namespace LinkManager.Helpers.Email
{
    using System.Reflection;

    public interface IEmailTemplateHelper
    {
         IEmailTemplateHelper SetTemplateAssembly(Assembly assembly);
         IEmailTemplateHelper SetTemplate(EmailTemplate identifier);
         IEmailTemplateHelper SetData(object data);
         string Build();
    }
}