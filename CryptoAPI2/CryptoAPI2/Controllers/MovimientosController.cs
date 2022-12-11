using CryptoAPI2.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAPI2.Controllers
{
    public class MovimientosController : Controller
    {
        private readonly BestWalletContext _context;

        public MovimientosController(BestWalletContext context)
        {
            _context = context;

        }

        //Obtenemos los ultimos movimientos por Id de cuenta.
        [HttpGet]
        [Route("/movimientos/cuenta")]
        public List<Transaccione> getId(int idCuenta)
        {
            var operaciones = _context.Transacciones.Where(x => x.IdCuenta == idCuenta).ToList();
            return operaciones;

        }
    }
}
