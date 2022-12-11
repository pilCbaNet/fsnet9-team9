
using CryptoAPI2.Models;
using Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAPI2.Controllers
{
    public class TransaccionesController : Controller
    {
        private readonly BestWalletContext _context;

        public TransaccionesController(BestWalletContext context)
        {
            _context = context;
            
        }

        [HttpGet]
        [Route("/get/transacciones")]
        public List<Transaccione> get2()
        {
            using (var db = new BestWalletContext())
            {
                var transacciones = db.Transacciones.ToList();
                return transacciones.ToList();
            }
        }


        [HttpPost]
        [Route("/agregarTransaccion")]
        public void Post2([FromBody] Transaccione comando)
        {
            using (var db = new BestWalletContext())
            {
                db.Transacciones.Add(comando);
                db.SaveChanges();
            }
        }

        //[HttpPost]
        //[Route("/agregarTransaccion/mapeo")]
        //public async Task<ActionResult> Post([FromBody] TransaccionesDTO transaccionesDTO)
        //{
        //    var nuevaTransaccion = new Transaccione()
        //    {
        //        IdTipoTransaccion = transaccionesDTO.IdTipoTransaccion,
        //        Fecha = transaccionesDTO.Fecha,
        //        Monto = transaccionesDTO.Monto,
        //        IdCuenta = transaccionesDTO.IdCuenta
        //    };

           
        //        await _context.Transacciones.AddAsync(nuevaTransaccion);
        //        await _context.SaveChangesAsync();

        //    return Ok(); 

        //}

        [HttpPost]
        [Route("/agregarTransaccion/retiro/{IdTipo}")]
        public async Task<ActionResult> PostRetiro([FromBody] TransaccionesDTO transaccionesDTO, int IdTipo = 2)
        {

            
            var nuevaTransaccion = new Transaccione()
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

        [HttpPost]
        [Route("/agregarTransaccion/deposito/{IdTipo}")]
        public async Task<ActionResult> PostDeposito([FromBody] TransaccionesDTO transaccionesDTO, int IdTipo = 3)
        {


            var nuevaTransaccion = new Transaccione()
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
