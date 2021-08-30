using LinkManager.Domain.src.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;

namespace LinkManager.Domain.src.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext db) : base(db)
        {
        }

        public override IMongoCollection<User> GetCollection()
        {
            return _db.User;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var query = GetQuery()
                .Where(q => q.Email == email);

            var entity = await GetOneAsync(query);

            return entity;
        }
    }
}