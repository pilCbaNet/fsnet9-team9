using Entities;

namespace API_BestWallet.Resultados.Usuarios
{
    public class ResultadoRegistro :ResultadoBase
    {

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

    }
}
