using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intelutions.Entities
{
    public class TipoPermiso:EntityBase
    {
        [Required]
        public string Descripcion { get; set; }
        public virtual ICollection<Permiso> Permisos { get; set; }

    }
}
