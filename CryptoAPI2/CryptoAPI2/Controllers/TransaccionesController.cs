
using CryptoAPI2.Models;
using Entities.DTO;
using Entities.Resultados;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CryptoAPI2.Controllers
{
    public class TransaccionesController : Controller
    {
        private readonly BestWalletContext _context;

        public TransaccionesController(BestWalletContext context)
        {
            _context = context;
            
        }

        //Pruebo traer todas las transacciones
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


        //POST agregar retiro
        [HttpPost]
        [Route("/agregarTransaccion/retiro")]
        public async Task<ActionResult<ResultadoOperaciones>> PostRetiro([FromBody] TransaccionesDTO transaccionesDTO)
        {
            try
            {
                var result = new ResultadoOperaciones();
                var nuevaTransaccion = new Transaccione();

                nuevaTransaccion.IdTipoTransaccion = 2;
                nuevaTransaccion.Fecha = transaccionesDTO.Fecha;
                nuevaTransaccion.Monto = transaccionesDTO.Monto;
                nuevaTransaccion.IdCuenta = transaccionesDTO.IdCuenta;

                if (nuevaTransaccion.IdTipoTransaccion.Equals(0) || nuevaTransaccion.Fecha.Equals(0) || nuevaTransaccion.Monto.Equals(0) || nuevaTransaccion.IdCuenta.Equals(0))
                {
                    result.SetError("Transaccion no resgistrada");
                    result.StatusCode = 500;
                    return Ok(result);
                }
                else
                {
                    await _context.Transacciones.AddAsync(nuevaTransaccion);
                    await _context.SaveChangesAsync();

                    result.IdCuenta = nuevaTransaccion.IdCuenta;
                    result.IdTipoTransaccion = nuevaTransaccion.IdTipoTransaccion;
                    result.Monto = nuevaTransaccion.Monto;
                    result.StatusCode = 200;
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error al registrar transaccion");
            }

        }


        //POST agregar deposito
        [HttpPost]
        [Route("/agregarTransaccion/deposito")]
        public async Task<ActionResult<ResultadoOperaciones>> PostDeposito([FromBody] TransaccionesDTO transaccionesDTO)
        {
            try
            {
                var result = new ResultadoOperaciones();
                var nuevaTransaccion = new Transaccione();

                nuevaTransaccion.IdTipoTransaccion = 3;
                nuevaTransaccion.Fecha = transaccionesDTO.Fecha;
                nuevaTransaccion.Monto = transaccionesDTO.Monto;
                nuevaTransaccion.IdCuenta = transaccionesDTO.IdCuenta;

                if (nuevaTransaccion.IdTipoTransaccion.Equals(0) || nuevaTransaccion.Fecha.Equals(0) || nuevaTransaccion.Monto.Equals(0) || nuevaTransaccion.IdCuenta.Equals(0))
                {
                    result.SetError("Transaccion no resgistrada");
                    result.StatusCode = 500;
                    return Ok(result);
                }
                else
                {
                    await _context.Transacciones.AddAsync(nuevaTransaccion);
                    await _context.SaveChangesAsync();

                    result.IdCuenta = nuevaTransaccion.IdCuenta;
                    result.IdTipoTransaccion = nuevaTransaccion.IdTipoTransaccion;
                    result.Monto = nuevaTransaccion.Monto;
                    result.StatusCode = 200;
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error al registrar transaccion");
            }

        }









    }
}
