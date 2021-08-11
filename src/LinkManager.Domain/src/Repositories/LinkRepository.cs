using LinkManager.Domain.src.Entities;
using MongoDB.Driver;

namespace LinkManager.Domain.src.Repositories
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
    }
}