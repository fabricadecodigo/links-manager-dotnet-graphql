using LinkManager.Domain.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkManager.Domain.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        protected readonly DbContext _db;

        public Repository(DbContext db) => _db = db;

        public abstract IMongoCollection<TEntity> GetCollection();

        public IMongoQueryable<TEntity> GetQuery() => GetCollection().AsQueryable();

        public async Task<List<TEntity>> GetAllAsync(IMongoQueryable<TEntity> query)
        {
            var entities = await query.ToListAsync();
            return entities;
        }

        public async Task<bool> ExistsAsync(IMongoQueryable<TEntity> query)
        {
            var exists = await query.AnyAsync();
            return exists;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var entity = await GetQuery()
                .SingleOrDefaultAsync(f => f.Id == id);

            return entity;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            entity.CreateAt = DateTime.Now;

            await GetCollection()
                .InsertOneAsync(entity);

            return entity;
        }

        public async Task<TEntity> UpdateAsync(Guid id, TEntity entity)
        {
            entity.UpdateAt = DateTime.Now;

            await GetCollection()
                .ReplaceOneAsync(
                    filter => filter.Id == id,
                    entity
                );

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            await GetCollection()
                .DeleteOneAsync(filter => filter.Id == id);
        }

        protected async Task<TEntity> GetOneAsync(IMongoQueryable<TEntity> query)
        {
            var entity = await query.SingleOrDefaultAsync();
            return entity;
        }
    }
}