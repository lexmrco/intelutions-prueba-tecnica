using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intelutions.DAL
{
    public abstract class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity: Entities.EntityBase
    {
        readonly IntelutionsDbContext _intelutionsDbContext;
        public DataRepository(IntelutionsDbContext context)
        {
            _intelutionsDbContext = context;
        }
        public abstract DbSet<TEntity> Dbset { get; }

        public virtual void Add(TEntity entity)
        {
            Dbset.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            Dbset.Remove(entity);
        }

        public virtual TEntity Get(int id)
        {
            return Dbset.FirstOrDefault(e => e.Id == id);
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await Dbset.FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
           return Dbset.ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Dbset.ToListAsync();
        }

        public void Update(TEntity entity)
        {
            Dbset.Update(entity);
        }

        public void SaveChanges() {
           _intelutionsDbContext.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _intelutionsDbContext.SaveChangesAsync();
        }
    }
}
