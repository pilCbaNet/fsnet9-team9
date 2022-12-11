using CryptoAPI2.Models;
using Entities.DTO;
using Entities.Resultados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly BestWalletContext _context;
        public UsuarioService(BestWalletContext context)
        {
            _context = context;
        }
        public async Task<ResultadoLogin> RegistrarUsuario(ComandoRegistrar datos)
        {
            var resultado = new ResultadoLogin();

            if (datos == null)
            {
                resultado.SetError("No se han ingresado datos para registrar un usuario.");
                resultado.StatusCode = (int)HttpStatusCode.NotFound;
                return resultado;

            }

            //Valido que el mail no exista. 
            var validarMailUsuario = await _context.Usuarios.SingleOrDefaultAsync(x => x.Email == datos.Email);
            if (validarMailUsuario != null)
            {
                resultado.SetError("Ya existe un usuario con ese mail.");
                resultado.StatusCode = (int)HttpStatusCode.NotFound;
                return resultado;

            }


            var usuario = new Usuario
            {

                Nombre = datos.Nombre,
                Apellido = datos.Apellido,
                Email = datos.Email,
                Password = datos.Password,
            };

            await _context.Usuarios.AddAsync(usuario);

            var resultadoInsert = await _context.SaveChangesAsync();

            if (resultadoInsert < 1)
            {
                resultado.SetError("No se ha podido registrar el usuario, ha ocurrido un error.");
                resultado.StatusCode = (int)HttpStatusCode.BadRequest;
                return resultado;

            }
            resultado.StatusCode = (int)HttpStatusCode.OK;
            return resultado;


        }
    
    }
    
}
