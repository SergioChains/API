using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class PuestoServices : IPuestoServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;
        public PuestoServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //Creaciones de funciones CRUD
        public async Task<Response<List<Puesto>>> GetPuesto()
        {
            try
            {
                Mensaje = "La lista de Puestos";

                var response = await _context.Puestos.ToListAsync();

                if (response.Count > 0)
                {
                    Mensaje = "La lista de puestos";
                    return new Response<List<Puesto>>(response, Mensaje);
                }
                else
                {
                    Mensaje = "No se encontra ningun registro";
                    return new Response<List<Puesto>>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Response<Puesto>> CrearPuestos(PuestoResponse request)
        {
            try
            {
                Puesto puesto = new Puesto()
                {
                    Nombre= request.Nombre
                };

                _context.Puestos.Add(puesto);
                await _context.SaveChangesAsync();

                return new Response<Puesto>(puesto);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<Puesto>> ActualizarPuesto([FromBody] PuestoResponse i, int id)
        {
            try
            {
                var res = _context.Puestos.Find(id);
                if (res != null)
                {
                    res.Nombre = i.Nombre;
                    _context.Puestos.Update(res);
                    await _context.SaveChangesAsync();
                }
                return new Response<Puesto>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }


        public async Task<Response<Puesto>> EliminarPuesto(int id)
        {
            var empleados = _context.Empleados.Where(x => x.FkPuesto == id).ToList();
            if (empleados.Count > 0)
            {
                return new Response<Puesto>("No se puede eliminar este puesto por que existen Empledos referidos a el");
            }

            var res = _context.Puestos.Find(id);
            _context.Puestos.Remove(res);
            await _context.SaveChangesAsync();
            return new Response<Puesto>(res);
        }

        public ActionResult<Response<Puesto>> ObtenerPuestoId(int id)
        {
            var res = _context.Puestos.Find(id);

            try
            {

                if (res != null)
                {
                    res = _context.Puestos.FirstOrDefault(x => x.Pk == id);
                    return new Response<Puesto>(res);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<Puesto>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
    }
}
