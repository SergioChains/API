using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;
using Proyecto25AM.Services.Services;

namespace David_Stephen.Controllers
{
    [ApiController]
    [Route("clientes")]

    public class ClienteController : Controller
    {
        private readonly IClienteServices _clienteServices;
        public ClienteController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ClienteResponse i)
        {
            return Ok(await _clienteServices.CrearClientes(i));
        }
        [HttpGet]
        public async Task<IActionResult> GetCli()
        {
            return Ok(await _clienteServices.GetCliente());
        }
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _clienteServices.EliminarCliente(id));
        }
        [HttpPut]
        public async Task<IActionResult> ActualizarCli([FromBody] ClienteResponse i, int id)
        {
            return Ok(await _clienteServices.ActualizarCliente(i, id));
        }
        [HttpGet("{id}")]
        public ActionResult ObtenerCliID(int id)
        {
            return Ok(_clienteServices.ObtenerCliId(id));
        }
    }
}
