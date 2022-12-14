using CryptoAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Resultados
{
    public class ResultadoOperaciones : ResultadoBase
    {
        public int IdTipoTransaccion { get; set; }
        public double Monto { get; set; }
        public int IdCuenta { get; set; }
    }
}
