using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;
using Proyecto25AM.Services.Services;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolController : Controller
    {
        private readonly IRolServices _rolServices;
        public RolController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] RolResponse i)
        {
            return Ok(await _rolServices.CrearRols(i));
        }
        [HttpGet]
        public async Task<IActionResult> GetRols()
        {
            return Ok(await _rolServices.GetRol());
        }
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _rolServices.EliminarRol(id));
        }
        [HttpPut]
        public async Task<IActionResult> ActualizarRol([FromBody] RolResponse i, int id)
        {
            return Ok(await _rolServices.ActualizarRoles(i, id));
        }
        [HttpGet("{id}")]
        public ActionResult ObtenerRolID(int id)
        {
            return Ok(_rolServices.ObtenerRolId(id));
        }
    }
}
