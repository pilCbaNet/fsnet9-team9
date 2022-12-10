using Entities;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API_BestWallet.Controllers
{
    public class TransaccionesController : Controller
    {
        private readonly BestWalletContext _context;

        public TransaccionesController(BestWalletContext context)
        {
            _context = context;

        }

        //Traigo todas las transacciones para probar

        [HttpGet]
        [Route("/get/transacciones")]
        public List<Transaccion> get2()
        {
            using (var db = new BestWalletContext())
            {
                var transacciones = db.Transacciones.ToList();
                return transacciones.ToList();
            }
        }

        //POST RETIRO 

        [HttpPost]
        [Route("/agregarTransaccion/retiro/{IdTipo}")]
        public async Task<ActionResult> PostRetiro([FromBody] TransaccionesDTO transaccionesDTO, int IdTipo = 2)
        {


            var nuevaTransaccion = new Transaccion()
            {
                IdTipoTransaccion = IdTipo,
                Fecha = transaccionesDTO.Fecha,
                Monto = transaccionesDTO.Monto,
                IdCuenta = transaccionesDTO.IdCuenta

            };


            await _context.Transacciones.AddAsync(nuevaTransaccion);
            await _context.SaveChangesAsync();

            return Ok();

        }

        //POST DEPOSITO

        [HttpPost]
        [Route("/agregarTransaccion/deposito/{IdTipo}")]
        public async Task<ActionResult> PostDeposito([FromBody] TransaccionesDTO transaccionesDTO, int IdTipo = 3)
        {


            var nuevaTransaccion = new Transaccion()
            {
                IdTipoTransaccion = IdTipo,
                Fecha = transaccionesDTO.Fecha,
                Monto = transaccionesDTO.Monto,
                IdCuenta = transaccionesDTO.IdCuenta

            };


            await _context.Transacciones.AddAsync(nuevaTransaccion);
            await _context.SaveChangesAsync();

            return Ok();

        }
    }
}
