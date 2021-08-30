using LinkManager.Domain.src.Entities;
using System.Threading.Tasks;

namespace LinkManager.Domain.src.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
         Task<User> GetByEmailAsync(string email);
    }
}