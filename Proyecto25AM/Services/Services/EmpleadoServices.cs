using Azure.Core;
using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class EmpleadoServices : IEmpleadoServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;
        public EmpleadoServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Empleado>>> GetEmpleados()
        {
            try
            {
                Mensaje = "La lista de Empleado";

                var response = await _context.Empleados.Include(x=>x.Departamento).Include(x=>x.Puesto).ToListAsync();
                if (response.Count > 0)
                {
                    Mensaje = "La lista de Empleados";
                    return new Response<List<Empleado>>(response, Mensaje);
                }
                else
                {
                    Mensaje = "No se encontra ningun registro";
                    return new Response<List<Empleado>>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Response<Empleado>> CrearEmpleado(EmpleadoResponse request)
        {
            try
            {
                var puesto = _context.Puestos.Find(request.FkPuesto);
                var departamento = _context.Departamentos.Find(request.FkDepartamento);

                if (puesto == null)
                {
                    return new Response<Empleado>("no exite ese codigo de puesto actualmente");
                }
                if (departamento == null)
                {
                    return new Response<Empleado>("no exite ese codigo de departamento actualmente");
                }
               

                Empleado Emple = new Empleado()
                {
                    //User = request.User,
                    Nombre= request.Nombre,
                    Apellidos= request.Apellidos,
                    Direccion= request.Direccion,
                    Ciudad= request.Ciudad,
                    FkPuesto= request.FkPuesto,
                    FkDepartamento= request.FkDepartamento
                };

                _context.Empleados.Add(Emple);
                await _context.SaveChangesAsync();

                return new Response<Empleado>(Emple);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Empleado>> ActualizarEmpleado([FromBody] EmpleadoResponse i, int id)
        {
            try
            {
                var res = _context.Empleados.Find(id);

                if (res != null)
                {
                    var puesto = _context.Puestos.Find(i.FkPuesto);
                    var departamento = _context.Departamentos.Find(i.FkDepartamento);

                    if (puesto == null)
                    {
                        return new Response<Empleado>("no exite ese codigo de puesto actualmente");
                    }
                    if (departamento == null)
                    {
                        return new Response<Empleado>("no exite ese codigo de departamento actualmente");
                    }


                    res.Nombre= i.Nombre;
                    res.Apellidos = i.Apellidos;
                    res.Direccion= i.Direccion;
                    res.Ciudad = i.Ciudad;
                    res.FkPuesto = i.FkPuesto;
                    res.FkDepartamento = i.FkDepartamento;
                    
                    _context.Empleados.Update(res);
                    await _context.SaveChangesAsync();
                }
                return new Response<Empleado>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Empleado>> EliminarEmpleado(int id)
        {
            var res = _context.Empleados.Find(id);
            _context.Empleados.Remove(res);
            await _context.SaveChangesAsync();
            return new Response<Empleado>(res);
        }
        public ActionResult<Response<Empleado>> ObtenerEmpleadoId(int id)
        {
            var res = _context.Empleados.Find(id);
            try
            {
                if (res != null)
                {
                    res = _context.Empleados.Include(x => x.Departamento).Include(x => x.Puesto).FirstOrDefault(x => x.Pk == id);
                    return new Response<Empleado>(res);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<Empleado>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
    }
}
