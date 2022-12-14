using Microsoft.AspNetCore.Mvc;
using API_BestWallet.Resultados.Usuarios;
using API_BestWallet.Comandos.Usuarios;
using Microsoft.EntityFrameworkCore;
using Entities;
using API_BestWallet.Services;
using Microsoft.AspNetCore.Cors;

namespace API_BestWallet.Controllers;

[ApiController]
[Route("[controller]")]
[EnableCors("BestWallet")]
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

    [HttpPost]
    [Route("API-BestWallet/usuario/registrar")]
    public async Task<ActionResult<Usuario>> RegistrarUsuario([FromBody] ComandoRegistrar comando)
    {
        
        //return await _service.RegistrarUsuario(comando);

        try
        {
            

            var result = new ResultadoRegistro();

            var usuario = new Usuario();

            usuario.Nombre = comando.Nombre;
            usuario.Apellido = comando.Apellido;
            usuario.Email = comando.Email;
            usuario.Password = comando.Password;
            

            if (usuario.Nombre == "" || usuario.Apellido == "" || usuario.Email == "" || usuario.Password == "")
            {
                result.SetError("Error al registrar usuario");
                result.StatusCode = 500;
                return Ok(result);
            }
            else
            {
                await _context.AddAsync(usuario);
                await _context.SaveChangesAsync();

                result.Nombre = usuario.Nombre;
                result.Apellido = usuario.Apellido;
                result.Email = usuario.Email;
                result.Password = usuario.Password;
                result.StatusCode = 200;
                return Ok(result);
            }
        }
        catch (Exception ex)
        {
            return BadRequest("Error al registrar usuario");
        }

    }

}

