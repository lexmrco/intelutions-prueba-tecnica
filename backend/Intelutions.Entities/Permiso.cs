using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Intelutions.Entities
{
    public class Permiso:EntityBase
    {
        [Required]
        public string NombreEmpleado { get; set; }
        [Required]
        public string ApellidosEmpleado { get; set; }
        [Required]
        public int TipoPermisoId { get; set; }
        public TipoPermiso TipoPermiso { get; set; }

        [Required]
        public DateTime FechaPermiso { get; set; }

    }
}
