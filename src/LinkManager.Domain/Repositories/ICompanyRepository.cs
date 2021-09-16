using LinkManager.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace LinkManager.Domain.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Company> GetByUserIdAsync(Guid userId);
        Task<Company> GetBySlugAsync(string slug);
    }
}