using LinkManager.Domain.src.Entities;
using System.Threading.Tasks;

namespace LinkManager.Domain.src.Repositories
{
    public interface IForgotPasswordRepository : IRepository<ForgotPassword>
    {
        Task<ForgotPassword> GetByEmailAsync(string email);
    }
}