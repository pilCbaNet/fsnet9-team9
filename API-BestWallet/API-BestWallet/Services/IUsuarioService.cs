using API_BestWallet.Comandos.Usuarios;
using API_BestWallet.Resultados.Usuarios;

namespace API_BestWallet.Services
{
    public interface IUsuarioService
    {
        Task<ResultadoLogin> RegistrarUsuario(ComandoRegistrar datos); 
    }
}
