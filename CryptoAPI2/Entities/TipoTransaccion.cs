using System;
using System.Collections.Generic;

namespace CryptoAPI2.Models
{
    public partial class TipoTransaccion
    {
        public TipoTransaccion()
        {
            Transacciones = new HashSet<Transaccione>();
        }

        public int IdTipoTransaccion { get; set; }
        public string NombreTipoTransaccion { get; set; } = null!;
        public string Codigo { get; set; } = null!;

        public virtual ICollection<Transaccione> Transacciones { get; set; }
    }
}
