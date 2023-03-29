using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;
using Proyecto25AM.Services.Services;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoServices _empleadoServices;
        public EmpleadoController(IEmpleadoServices empleadoServices)
        {
            _empleadoServices = empleadoServices;
        }
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] EmpleadoResponse i)
        {
            return Ok(await _empleadoServices.CrearEmpleado(i));
        }
        [HttpGet]
        public async Task<IActionResult> GetEmpleados()
        {
            return Ok(await _empleadoServices.GetEmpleados());
        }
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _empleadoServices.EliminarEmpleado(id));
        }
        [HttpPut]
        public async Task<IActionResult> ActualizarEmpleado([FromBody] EmpleadoResponse i, int id)
        {
            return Ok(await _empleadoServices.ActualizarEmpleado(i, id));
        }
        [HttpGet("{id}")]
        public ActionResult ObtenerUserID(int id)
        {
            return Ok(_empleadoServices.ObtenerEmpleadoId(id));
        }
    }
}
