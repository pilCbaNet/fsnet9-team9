using CryptoAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Resultados
{
    public class ResultadoOperaciones
    {
        public int IdCuenta { get; set; }
        public virtual ICollection<Transaccione> Transacciones { get; set; }
    }
}
