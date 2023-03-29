using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IDepartamentoServices
    {
        public Task<Response<List<Departamento>>> Getdep();
        public Task<Response<Departamento>> CrearDepartamento(DepartamentoResponse request);
        public Task<Response<Departamento>> ActualizarDepartamento([FromBody] DepartamentoResponse i, int id);
        public Task<Response<Departamento>> EliminarDepa(int id);
        public ActionResult<Response<Departamento>> ObtenerDepId(int id);
    }
}
