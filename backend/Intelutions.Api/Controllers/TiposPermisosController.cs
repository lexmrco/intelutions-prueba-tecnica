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

namespace Nexos.PruebaTecnica.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TiposPermisosController : ControllerBase
    {
        private readonly ITipoPermisoManager _repository;

        public TiposPermisosController(ITipoPermisoManager repository)
        {
            _repository = repository;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectListModel>> SelectList()
        {
            var list =  await _repository.GetAllAsync();
            return list.Select(x => new SelectListModel() { 
                Value = x.Id.ToString(),
                Text = x.Descripcion
            });
        }
    }
}
