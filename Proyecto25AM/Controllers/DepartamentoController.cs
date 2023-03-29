using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;
using Proyecto25AM.Services.Services;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoServices _departamentoServices;
        public DepartamentoController(IDepartamentoServices departamentoServices)
        {
            _departamentoServices = departamentoServices;
        }

        [HttpGet]
        public async Task<IActionResult> Getdepa()
        {
            return Ok(await _departamentoServices.Getdep());
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] DepartamentoResponse i)
        {
            return Ok(await _departamentoServices.CrearDepartamento(i));
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _departamentoServices.EliminarDepa(id));
        }
        [HttpPut]
        public async Task<IActionResult>ActualizarDepa([FromBody] DepartamentoResponse i, int id)
        {
            return Ok(await _departamentoServices.ActualizarDepartamento(i, id));
        }
        [HttpGet("{id}")]
        public ActionResult ObtenerDepaID(int id)
        {
            return Ok(_departamentoServices.ObtenerDepId(id));
        }
    }
}
