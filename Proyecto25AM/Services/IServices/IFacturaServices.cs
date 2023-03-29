using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IFacturaServices
    {
        public Task<Response<List<Factura>>> GetFact();
        public Task<Response<Factura>> CrearFactura(FacturaResponse request);
        public Task<Response<Factura>> ActualizarFactura([FromBody] FacturaResponse i, int id);
        public Task<Response<Factura>> EliminarFac(int id);
        public ActionResult<Response<Factura>> ObtenerFacId(int id);
    }
}
