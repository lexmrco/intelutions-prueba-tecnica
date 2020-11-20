using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

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
        [DataMember(Name = "nombreEmpleado")]
        public string NombreEmpleado { get; set; }
        [DataMember(Name = "apellidosEmpleado")]
        [Required]
        public string ApellidosEmpleado { get; set; }
        [DataMember(Name = "tipoPermisoId")]
        [Required]
        public int TipoPermisoId { get; set; }
        [DataMember(Name = "fechaPermiso")]
        [Required]
        public string FechaPermiso { get; set; }
    }
}
