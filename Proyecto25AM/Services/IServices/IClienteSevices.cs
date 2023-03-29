using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IClienteServices
    {
        public Task<Response<List<Cliente>>> GetCliente();
        public Task<Response<Cliente>> CrearClientes(ClienteResponse request);
        public Task<Response<Cliente>> ActualizarCliente([FromBody] ClienteResponse i, int id);
        public Task<Response<Cliente>> EliminarCliente(int id);
        public ActionResult<Response<Cliente>> ObtenerCliId(int id);
    }
}
