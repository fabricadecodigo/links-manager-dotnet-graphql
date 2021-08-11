using LinkManager.Domain.src.Entities;
using MongoDB.Driver;

namespace LinkManager.Domain.src.Repositories
{
    public class CompanyRepository :  Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(DbContext db) : base(db)
        {
        }

        public override IMongoCollection<Company> GetCollection()
        {
            return _db.Companies;
        }
    }
}