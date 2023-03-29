using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class DepartamentoServices : IDepartamentoServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;

        public DepartamentoServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //creacion de Crud
        public async Task<Response<List<Departamento>>> Getdep()
        {
            try
            {
                Mensaje = "La lista de Departamentos";

                var response = await _context.Departamentos.ToListAsync();

                if (response.Count > 0)
                {
                    Mensaje = "La lista de usuarios";
                    return new Response<List<Departamento>>(response, Mensaje);
                }
                else
                {
                    Mensaje = "No se encontra ningun registro";
                    return new Response<List<Departamento>>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Response<Departamento>> CrearDepartamento(DepartamentoResponse request)
        {
            try
            {
                Departamento departamento = new Departamento()
                {
                        Nombre= request.Nombre
                };

                _context.Departamentos.Add(departamento);
                await _context.SaveChangesAsync();

                return new Response<Departamento>(departamento);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<Departamento>> ActualizarDepartamento([FromBody] DepartamentoResponse i, int id)
        {
            try
            {
                var res = _context.Departamentos.Find(id);
                if (res != null)
                {

                    res.Nombre = i.Nombre;

                    _context.Departamentos.Update(res);
                    await _context.SaveChangesAsync();
                }
                return new Response<Departamento>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<Departamento>> EliminarDepa(int id)
        {
            var empleados = _context.Empleados.Where(x => x.FkDepartamento == id).ToList();

            if (empleados.Count > 0)
            {
                return new Response<Departamento>("No se puede eliminar este Departamento por que existen Empledos referidos a el");
            }

            var res = _context.Departamentos.Find(id);
            _context.Departamentos.Remove(res);
            await _context.SaveChangesAsync();
            return new Response<Departamento>(res);
        }

        public ActionResult<Response<Departamento>> ObtenerDepId(int id)
        {
            var res = _context.Departamentos.Find(id);

            try
            {
                if (res != null)
                {
                    res = _context.Departamentos.FirstOrDefault(x => x.Pk == id);
                    return new Response<Departamento>(res);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<Departamento>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }

    }
}
