namespace LinkManager.Api.src.Helpers
{
    public interface IEmailTemplateHelper
    {
         IEmailTemplateHelper SetTemplate(EmailTemplate identifier);
         IEmailTemplateHelper SetData(object data);
         string Build();
    }
}