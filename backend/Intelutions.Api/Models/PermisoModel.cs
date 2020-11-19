using System;
using System.ComponentModel.DataAnnotations;

namespace Intelutions.Api.Models
{
    public class PermisoListModel
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public int TipoPermisoId { get; set; }
        public string TipoPermisoDescripcion { get; set; }
        public string FechaPermiso { get; set; }
    }

    public class PermisoEditModel
    {
        [Required]
        public string NombreEmpleado { get; set; }
        [Required]
        public string ApellidosEmpleado { get; set; }
        [Required]
        public int TipoPermisoId { get; set; }
        [Required]
        public string FechaPermiso { get; set; }
    }
}
