namespace LinkManager.Helpers.Email
{
    public interface IEmailTemplateHelper
    {
         IEmailTemplateHelper SetTemplate(EmailTemplate identifier);
         IEmailTemplateHelper SetData(object data);
         string Build();
    }
}