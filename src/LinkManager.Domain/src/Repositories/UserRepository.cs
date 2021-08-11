using LinkManager.Domain.src.Entities;
using MongoDB.Driver;

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
    }
}