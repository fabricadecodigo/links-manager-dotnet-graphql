using LinkManager.Domain.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Threading.Tasks;

namespace LinkManager.Domain.Repositories
{
    public class LinkRepository : Repository<Link>, ILinkRepository
    {
        public LinkRepository(DbContext db) : base(db)
        {
        }

        public override IMongoCollection<Link> GetCollection()
        {
            return _db.Links;
        }

        public async Task<Link> GetByCompanyIdAsync(Guid id, Guid companyId)
        {
            var linkQuery = GetQuery()
                .Where(q =>
                    q.Id == id
                    && q.CompanyId == companyId
                );

            var link = await GetOneAsync(linkQuery);
            return link;
        }
    }
}