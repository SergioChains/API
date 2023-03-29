using Azure.Core;
using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class FacturaServices : IFacturaServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;
        public FacturaServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //Creaciones de funciones CRUD
        public async Task<Response<List<Factura>>> GetFact()
        {
            try
            {
                Mensaje = "La lista de las Facturas";

                var response = await _context.Facturas.Include(x=>x.Cliente).ToListAsync();

                if (response.Count > 0)
                {
                    Mensaje = "La lista de Facturas";
                    return new Response<List<Factura>>(response, Mensaje);
                }
                else
                {
                    Mensaje = "No se encontra ningun registro";
                    return new Response<List<Factura>>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Response< Factura>> CrearFactura(FacturaResponse request)
        {
            try
            {
                var cliente = _context.Clientes.Find(request.FkCliente);
                if(cliente == null)
                {
                    return new Response<Factura>("No esiste ese codigo de cliente actualmete");
                }


                Factura fac = new Factura()
                {
                    
                    RazonSocial=request.RazonSocial,
                    Fecha=request.Fecha,
                    RFC=request.RFC,
                    FkCliente=request.FkCliente
                };

                _context.Facturas.Add(fac);
                await _context.SaveChangesAsync();

                return new Response<Factura>(fac);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<Factura>> ActualizarFactura([FromBody] FacturaResponse i, int id)
        {
            try
            {
                var res = _context.Facturas.Find(id);
                if (res != null)
                {
                    var cliente = _context.Clientes.Find(i.FkCliente);
                    if (cliente == null)
                    {
                        return new Response<Factura>("No esiste ese codigo de cliente actualmete");
                    }

                    res.RazonSocial = i.RazonSocial;
                    res.Fecha = i.Fecha;
                    res.RFC = i.RFC;
                    res.FkCliente = i.FkCliente;

                    _context.Facturas.Update(res);
                    await _context.SaveChangesAsync();
                }
                return new Response<Factura>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response< Factura>> EliminarFac(int id)
        {
            var res = _context.Facturas.Find(id);
            _context.Facturas.Remove(res);
            await _context.SaveChangesAsync();
            return new Response<Factura>(res);
        }

        public ActionResult<Response<Factura>> ObtenerFacId(int id)
        {
            var res = _context.Facturas.Find(id);
            try
            {
                if (res != null)
                {
                    res = _context.Facturas.Include(x => x.Cliente).FirstOrDefault(x => x.Pk == id);
                    return new Response<Factura>(res);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<Factura>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }


    }
}
