using LinkManager.Domain.Entities;
using System.Threading.Tasks;

namespace LinkManager.Domain.Repositories
{
    public interface IForgotPasswordRepository : IRepository<ForgotPassword>
    {
        Task<ForgotPassword> GetByEmailAsync(string email);
    }
}