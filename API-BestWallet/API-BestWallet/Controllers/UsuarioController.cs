using Microsoft.AspNetCore.Mvc;
using API_BestWallet.Models;
using API_BestWallet.Resultados.Usuarios;
using API_BestWallet.Comandos.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace API_BestWallet.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly BestWalletContext _context;
    public UsuarioController(BestWalletContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("API-BestWallet/usuario/login")]
    public async Task<ActionResult<ResultadoLogin>>Login([FromBody] ComandoLogin comando)
    {
        try
        {
            var result = new ResultadoLogin();
            var usuario = await _context.Usuarios.Where(x => x.FechaBaja == null && 
            x.Email.Equals(comando.Email) && x.Password.Equals(comando.Password)).FirstOrDefaultAsync();

            if (usuario!= null)
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
        catch(Exception ex)
        {
            return BadRequest("Error al obtener el usuario");
        }
    }
}
