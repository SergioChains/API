using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IRolServices
    {
        public Task<Response<List<Rol>>> GetRol();
        public Task<Response<Rol>> CrearRols(RolResponse request);
        public Task<Response<Rol>> ActualizarRoles([FromBody] RolResponse i, int id);
        public Task<Response<Rol>> EliminarRol(int id);
        public ActionResult<Response<Rol>> ObtenerRolId(int id);
    }
}
