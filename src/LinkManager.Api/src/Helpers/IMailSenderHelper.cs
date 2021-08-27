using System.Threading.Tasks;

namespace LinkManager.Api.src.Helpers
{
    public interface IMailSenderHelper
    {
        IMailSenderHelper SetSubject(string subject);
        IMailSenderHelper SetTo(string name, string email);
        IMailSenderHelper SetHtml(string html);
        Task SendMail();
    }
}