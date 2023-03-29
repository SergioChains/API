using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IUsuarioServices
    {
        public Task<Response<Usuario>> CrearUsuario(UsuarioResponse request);

        public  Task<Response<List<Usuario>>> GetUsers();

        public Task<Response<Usuario>> ActualizarUsuario([FromBody] UsuarioResponse i, int id);
        public  Task<Response<Usuario>> EliminarUser(int id);

        public ActionResult<Response<Usuario>> ObtenerUserId(int id);
    }
}
