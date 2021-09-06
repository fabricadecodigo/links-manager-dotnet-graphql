using LinkManager.Domain.Entities;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkManager.Domain.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        IMongoQueryable<TEntity> GetQuery();
        Task<List<TEntity>> GetAllAsync(IMongoQueryable<TEntity> query);
        Task<bool> ExistsAsync(IMongoQueryable<TEntity> query);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(Guid id, TEntity entity);
        Task DeleteAsync(Guid id);
    }
}