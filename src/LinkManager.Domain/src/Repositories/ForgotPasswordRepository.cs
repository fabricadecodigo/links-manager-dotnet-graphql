using LinkManager.Domain.src.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;

namespace LinkManager.Domain.src.Repositories
{
    public class ForgotPasswordRepository : Repository<ForgotPassword>, IForgotPasswordRepository
    {
        public ForgotPasswordRepository(DbContext db) : base(db)
        {
        }

        public override IMongoCollection<ForgotPassword> GetCollection()
        {
            return _db.ForgotPasswords;
        }

        public async Task<ForgotPassword> GetByEmailAsync(string email)
        {
            var query = GetQuery()
                .Where(q => q.Email == email);

            var entity = await GetOneAsync(query);

            return entity;
        }
    }
}