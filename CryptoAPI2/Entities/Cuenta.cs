using System;
using System.Collections.Generic;

namespace CryptoAPI2.Models
{
    public partial class Cuenta
    {
        public Cuenta()
        {
            Transacciones = new HashSet<Transaccione>();
        }

        public int IdCuenta { get; set; }
        public long Cvu { get; set; }
        public int IdUsuario { get; set; }
        public int IdMoneda { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

        public virtual Moneda IdMonedaNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Transaccione> Transacciones { get; set; }
    }
}
