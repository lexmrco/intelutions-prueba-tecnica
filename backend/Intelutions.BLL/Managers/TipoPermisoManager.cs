using Microsoft.EntityFrameworkCore;
using Intelutions.DAL;
using Intelutions.Entities;

namespace Intelutions.BLL.Managers
{
    public interface ITipoPermisoManager : IDataRepository<TipoPermiso>
    {
    }
    public class TipoPermisoManager : DataRepository<TipoPermiso>, ITipoPermisoManager
    {
        public TipoPermisoManager(IntelutionsDbContext context) : base(context)
        {
            _dbset = context.TiposPermisos;
        }

        readonly DbSet<TipoPermiso> _dbset;
        public override DbSet<TipoPermiso> Dbset => _dbset;
    }
}
