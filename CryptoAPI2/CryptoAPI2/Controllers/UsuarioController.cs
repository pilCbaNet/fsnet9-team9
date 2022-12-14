
using CryptoAPI2.Models;
using Entities.DTO;
using Entities.Services;
using Entities.Resultados;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CryptoAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly BestWalletContext _context;
        private readonly IUsuarioService _service;
        public UsuarioController(BestWalletContext context, IUsuarioService service)
        {
            _context = context;
            _service = service;
        }

        [HttpPost]
        [Route("API-BestWallet/usuario/login")]
        public async Task<ActionResult<ResultadoLogin>> Login([FromBody] ComandoLogin comando)
        {
            try
            {
                var result = new ResultadoLogin();
                var usuario = await _context.Usuarios.Where(x => x.FechaBaja == null &&
                x.Email.Equals(comando.Email) && x.Password.Equals(comando.Password)).FirstOrDefaultAsync();

                if (usuario != null)
                {
                    result.IdUsuario = usuario.IdUsuario;
                    result.Email = usuario.Email;
                    result.StatusCode = 200;
                    return Ok(result);
                }
                else
                {
                    result.SetError("Usuario no encontrado en la base de datos");
                    result.StatusCode = 500;
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error al obtener el usuario");
            }
        }

        [HttpPost]
        [Route("API-BestWallet/usuario/registrar")]
        public async Task<ActionResult<ResultadoLogin>> RegistrarUsuario([FromBody] ComandoRegistrar comando)
        {

            return await _service.RegistrarUsuario(comando);


        }



    }
}
