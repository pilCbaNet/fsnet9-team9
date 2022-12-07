namespace API_BestWallet.Resultados;
public class ResultadoBase 
{
    public bool OK {get; set;}=true;
    public string ?Error {get; set;}
    public int ?StatusCode {get; set;}

    public void SetError(string mensajeError)
    {
        OK=false;
        Error=mensajeError;
    }
}


