using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intelutions.DAL
{
    public interface IDataRepository<TEntity> where TEntity : Entities.EntityBase
    {
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        TEntity Get(int id);
        Task<TEntity> GetAsync(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
