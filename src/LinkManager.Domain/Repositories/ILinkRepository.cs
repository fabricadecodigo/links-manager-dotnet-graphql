using LinkManager.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace LinkManager.Domain.Repositories
{
    public interface ILinkRepository : IRepository<Link>
    {
         Task<Link> GetByCompanyIdAsync(Guid id, Guid companyId);
    }
}