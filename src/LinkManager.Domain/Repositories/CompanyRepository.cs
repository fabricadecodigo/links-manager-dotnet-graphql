using LinkManager.Domain.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Threading.Tasks;

namespace LinkManager.Domain.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(DbContext db) : base(db)
        {
        }

        public override IMongoCollection<Company> GetCollection()
        {
            return _db.Companies;
        }

        public async Task<Company> GetByUserIdAsync(Guid userId)
        {
            var query = GetQuery()
                            .Where(q => q.UserId == userId);

            var entity = await GetOneAsync(query);

            return entity;
        }

        public async Task<Company> GetBySlugAsync(string slug)
        {
            var query = GetQuery()
                .Where(q => q.Slug == slug);

            var entity = await GetOneAsync(query);

            return entity;
        }
    }
}