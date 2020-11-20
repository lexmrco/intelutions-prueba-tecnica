using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Intelutions.BLL.Managers;
using Intelutions.DAL;
using Intelutions.Entities;
using Intelutions.Api.Models;
using Intelutions.Api.NLog;
using Intelutions.Api.Helpers;

namespace Intelutions.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        private readonly IPermisoManager _repository;

        public PermisosController(IPermisoManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: permisos
        [HttpGet]
        public async Task<IEnumerable<PermisoListModel>> Get()
        {
            LogReader();

            var data = await _repository.GetAllAdvanceAsync();

            return data.Select(x => MapEntityToModel(x));
        }
        
        // GET: permisos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PermisoListModel>> Get(int id)
        {
            LogReader();
            var permiso = await _repository.GetAsync(id);

            if (permiso == null)
            {
                return NotFound();
            }

            return MapEntityToModel(permiso);
        }

        // PUT: productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PermisoEditModel model)
        {
            DateTime? fechaPermiso = CustomDateTime.Parse(model.FechaPermiso);
            if (!fechaPermiso.HasValue)
            {
                return BadRequest("Fecha de permiso no está en el formato correcto");
            }
            // Convertir la fecha a formato UTC
            fechaPermiso = CustomDateTime.ConvertToUtc(fechaPermiso.Value, GlobalProperties.DefaultTimeZoneId);

            var entity = await _repository.GetAsync(id);

            if(entity == null)
                return NotFound();

            entity.NombreEmpleado = model.NombreEmpleado;
            entity.ApellidosEmpleado = model.ApellidosEmpleado;
            entity.TipoPermisoId = model.TipoPermisoId;
            entity.FechaPermiso = fechaPermiso.Value;

            try
            {
                _repository.Update(entity);
                await _repository.SaveChangesAsync();
            }
            catch
            {
                LogError(id, model);
                throw;
            }

            return Ok(MapEntityToModel(entity));
        }

        // POST: permisos
        [HttpPost]
        public async Task<IActionResult> Post(PermisoEditModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Datos no válidos");
            }

            DateTime? fechaPermiso = CustomDateTime.Parse(model.FechaPermiso);
            if (!fechaPermiso.HasValue)
            {
                return BadRequest("Fecha de permiso no está en el formato correcto");
            }
            // Convertir la fecha a formato UTC
            fechaPermiso = CustomDateTime.ConvertToUtc(fechaPermiso.Value, GlobalProperties.DefaultTimeZoneId);


            Permiso permiso = new Permiso()
            {
                NombreEmpleado = model.NombreEmpleado,
                ApellidosEmpleado = model.ApellidosEmpleado,
                TipoPermisoId = model.TipoPermisoId,
                FechaPermiso = fechaPermiso.Value
            };
            try
            {
                _repository.Add(permiso);
                await _repository.SaveChangesAsync();
            }
            catch
            {
                LogError(0, model);
                throw;
            }
            
            return CreatedAtAction("Get", new { id = permiso.Id }, MapEntityToModel(permiso));
        }

        // DELETE: permisos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            try
            {
                _repository.Delete(entity);
                await _repository.SaveChangesAsync();

            }
            catch (Exception)
            {
                LogError(id, new PermisoEditModel());
                throw;
            }
            
            return Ok();
        }
        private void LogError(int id,PermisoEditModel model)
        {
            string controllerName = ControllerContext.ActionDescriptor.ControllerName;
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            _logger.LogError($"[Controller]{Environment.NewLine}{controllerName}{Environment.NewLine}[Acción]{Environment.NewLine}{actionName}{Environment.NewLine}[Paciente]{Environment.NewLine}[ID]{Environment.NewLine}{id}[Nombre Empleado]{Environment.NewLine}{model.NombreEmpleado}{Environment.NewLine}[Apellidos]{Environment.NewLine}{model.ApellidosEmpleado}{Environment.NewLine}[Tipo permiso]{Environment.NewLine}{model.TipoPermisoId}{Environment.NewLine}[Fecha permiso]{Environment.NewLine}{model.FechaPermiso}");

        }

        private void LogReader()
        {
            string actionName = ControllerContext.ActionDescriptor.ActionName;
            string controllerName = ControllerContext.ActionDescriptor.ControllerName;
            _logger.LogInfo($"[Controller]{Environment.NewLine}{controllerName}{Environment.NewLine}[Acction]{Environment.NewLine}{actionName}");

        }

        private PermisoListModel MapEntityToModel(Permiso entity)
        {
            return new PermisoListModel() {
                Id = entity.Id.Value,
                NombreEmpleado = entity.NombreEmpleado,
                ApellidosEmpleado = entity.ApellidosEmpleado,
                TipoPermisoId = entity.TipoPermisoId,
                TipoPermisoDescripcion = entity.TipoPermiso == null ? "": entity.TipoPermiso.Descripcion,
                FechaPermiso = string.Format("{0:yyyy-MM-dd HH:mm}", CustomDateTime.ConvertFromUtc(entity.FechaPermiso, GlobalProperties.DefaultTimeZoneId), GlobalProperties.DateFormatFilter)

            };
        }
    }
}
