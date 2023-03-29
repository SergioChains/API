using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class RolServices : IRolServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;

        public RolServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //Creaciones de funciones CRUD
        public async Task<Response<List<Rol>>> GetRol()
        {
            try
            {
                Mensaje = "La lista de Roles";

                var response = await _context.Rols.ToListAsync();

                if (response.Count > 0)
                {
                    Mensaje = "La lista de Roles";
                    return new Response<List<Rol>>(response, Mensaje);
                }
                else
                {
                    Mensaje = "No se encontra ningun registro";
                    return new Response<List<Rol>>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }


        public async Task<Response<Rol>> CrearRols(RolResponse request)
        {
            try
            {
                Rol rol = new Rol()
                {
                    Nombre= request.Nombre
                };

                _context.Rols.Add(rol);
                await _context.SaveChangesAsync();

                return new Response<Rol>(rol);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<Rol>> ActualizarRoles([FromBody] RolResponse i, int id)
        {
            try
            {
                var res = _context.Rols.Find(id);
                if (res != null)
                {
                    
                    res.Nombre= i.Nombre;
                    _context.Rols.Update(res);
                    await _context.SaveChangesAsync();
                }
                return new Response<Rol>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<Rol>> EliminarRol(int id)
        {
            var usuarios = _context.Usuarios.Where(x => x.FkRol == id);
            if(usuarios.Count() > 0)
            {
                return new Response<Rol>("No se puede eliminar este rol por que hay un usuario utilizandolo");
            }

            var res = _context.Rols.Find(id);
            _context.Rols.Remove(res);
            await _context.SaveChangesAsync();
            return new Response<Rol>(res);
        }

        public ActionResult<Response<Rol>> ObtenerRolId(int id)
        {
            var res = _context.Rols.Find(id);
            try
            {
                if (res != null)
                {
                    res = _context.Rols.FirstOrDefault(x => x.Pk == id);
                    return new Response<Rol>(res);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<Rol>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
    }
}
