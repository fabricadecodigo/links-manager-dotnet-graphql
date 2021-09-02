using LinkManager.Domain.src.Entities;
using MongoDB.Driver;

namespace LinkManager.Domain.src
{
    public class DbContext
    {
        private readonly IMongoDatabase _db;

        public DbContext(IMongoDatabase db) => _db = db;

        public IMongoCollection<User> User =>
            _db.GetCollection<User>("users");

        public IMongoCollection<Company> Companies =>
            _db.GetCollection<Company>("companies");
        
        public IMongoCollection<Link> Links =>
            _db.GetCollection<Link>("links");

        public IMongoCollection<ForgotPassword> ForgotPasswords =>
            _db.GetCollection<ForgotPassword>("forgotPasswords");
    }
}