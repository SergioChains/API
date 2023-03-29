using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IPuestoServices
    {
        public Task<Response<List<Puesto>>> GetPuesto();
        public Task<Response<Puesto>> CrearPuestos(PuestoResponse request);
        public Task<Response<Puesto>> ActualizarPuesto([FromBody] PuestoResponse i, int id);
        public Task<Response<Puesto>> EliminarPuesto(int id);
        public ActionResult<Response<Puesto>> ObtenerPuestoId(int id);

    }
}
