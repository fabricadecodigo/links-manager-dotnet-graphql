using System.Threading.Tasks;

namespace LinkManager.Helpers.Email
{
    public interface IEmailSenderHelper
    {
        IEmailSenderHelper SetSubject(string subject);
        IEmailSenderHelper SetTo(string name, string email);
        IEmailSenderHelper SetHtml(string html);
        Task SendMail();
    }
}