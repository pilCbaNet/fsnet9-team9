using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class TransaccionesDTO
    {
        //public int IdTipoTransaccion { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public int IdCuenta { get; set; }

       
    }
}
