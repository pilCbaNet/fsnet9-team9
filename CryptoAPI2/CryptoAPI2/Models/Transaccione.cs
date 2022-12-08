using System;
using System.Collections.Generic;

namespace CryptoAPI2.Models
{
    public partial class Transaccione
    {
        public int IdTransaccion { get; set; }
        public int IdTipoTransaccion { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public int IdCuenta { get; set; }

        public virtual Cuenta IdCuentaNavigation { get; set; } = null!;
        public virtual TipoTransaccion IdTipoTransaccionNavigation { get; set; } = null!;
    }
}
