using LinkManager.Domain.src.Entities;
using System;
using System.Threading.Tasks;

namespace LinkManager.Domain.src.Repositories
{
    public interface ILinkRepository : IRepository<Link>
    {
         Task<Link> GetByCompanyIdAsync(Guid id, Guid companyId);
    }
}