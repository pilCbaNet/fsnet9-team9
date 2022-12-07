namespace API_BestWallet.Resultados.Usuarios;

public class ResultadoLogin : ResultadoBase
{
    public int IdUsuario { get; set; }

    public string Email { get; set; } = null!;

}
