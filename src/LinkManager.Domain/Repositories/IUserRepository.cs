using LinkManager.Domain.Entities;
using System.Threading.Tasks;

namespace LinkManager.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}