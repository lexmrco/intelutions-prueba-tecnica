using Microsoft.EntityFrameworkCore;
using Intelutions.DAL;
using Intelutions.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intelutions.BLL.Managers
{
    public interface IPermisoManager : IDataRepository<Permiso>
    {
        Task<IEnumerable<Permiso>> GetAllAdvanceAsync();
    }
    public class PermisoManager : DataRepository<Permiso>, IPermisoManager
    {
        public PermisoManager(IntelutionsDbContext context):base(context)
        {
            _dbset = context.Permisos;
        }

        readonly DbSet<Permiso> _dbset;
        public override DbSet<Permiso> Dbset => _dbset;
        public virtual async Task<IEnumerable<Permiso>> GetAllAdvanceAsync()
        {
            return await Dbset.Include("TipoPermiso").ToListAsync();
        }
    }

}
