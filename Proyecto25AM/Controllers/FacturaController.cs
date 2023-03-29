using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturaController : Controller
    {
        private readonly IFacturaServices _facturaServices;
        public FacturaController(IFacturaServices facturaServices)
        {
            _facturaServices = facturaServices;
        }
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] FacturaResponse i)
        {
            return Ok(await _facturaServices.CrearFactura(i));
        }
        [HttpGet]
        public async Task<IActionResult> GetFacts()
        {
            return Ok(await _facturaServices.GetFact());
        }
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _facturaServices.EliminarFac(id));
        }
        [HttpPut]
        public async Task<IActionResult> ActualizarFact([FromBody] FacturaResponse i, int id)
        {
            return Ok(await _facturaServices.ActualizarFactura(i, id));
        }
        [HttpGet("{id}")]
        public ActionResult ObtenerFacID(int id)
        {
            return Ok(_facturaServices.ObtenerFacId(id));
        }
    }
}
