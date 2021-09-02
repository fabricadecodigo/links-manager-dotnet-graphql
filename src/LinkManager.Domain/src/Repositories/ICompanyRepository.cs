using LinkManager.Domain.src.Entities;
using System.Threading.Tasks;

namespace LinkManager.Domain.src.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
         Task<Company> GetBySlugAsync(string slug);
    }
}