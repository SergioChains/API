using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;
        public ClienteServices(ApplicationDbContext context)
        {
            _context = context;
        }
        //Creaciones de funciones CRUD
        public async Task<Response<List<Cliente>>> GetCliente()
        {
            try
            {
                Mensaje = "La lista de Clientes";

                var response = await _context.Clientes.ToListAsync();

                if (response.Count > 0)
                {
                    Mensaje = "La lista de Clientes";
                    return new Response<List<Cliente>>(response, Mensaje);
                }
                else
                {
                    Mensaje = "No se encontra ningun registro";
                    return new Response<List<Cliente>>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Response<Cliente>> CrearClientes(ClienteResponse request)
        {
            try
            {
                Cliente cli = new Cliente()
                {
                    //User = request.User,
                    Nombre= request.Nombre,
                    Apellidos= request.Apellidos,
                    Telefono= request.Telefono,
                    Email= request.Email,
                    Direccion= request.Direccion
                };

                _context.Clientes.Add(cli);
                await _context.SaveChangesAsync();

                return new Response<Cliente>(cli);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<Cliente>> ActualizarCliente([FromBody] ClienteResponse i, int id)
        {
            try
            {
                var res = _context.Clientes.Find(id);
                if (res != null)
                {
                    //res.User = i.User;
                    res.Nombre= i.Nombre;
                    res.Apellidos= i.Apellidos;
                    res.Telefono = i.Telefono;
                    res.Email= i.Email;
                    res.Direccion= i.Direccion;

                    _context.Clientes.Update(res);
                    await _context.SaveChangesAsync();
                }
                return new Response<Cliente>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<Cliente>> EliminarCliente(int id)
        {
            var res = _context.Clientes.Find(id);
            _context.Clientes.Remove(res);
            await _context.SaveChangesAsync();
            return new Response<Cliente>(res);
        }

        public ActionResult<Response<Cliente>> ObtenerCliId(int id)
        {
            var res = _context.Clientes.Find(id); 

            try
            {
                if (res != null)
                {
                    res = _context.Clientes.FirstOrDefault(x => x.Pk == id);
                    return new Response<Cliente>(res);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<Cliente>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
    }
}
