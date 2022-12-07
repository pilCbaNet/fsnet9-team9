using System;
using System.Collections.Generic;

namespace API_BestWallet.Models;

public partial class TipoTransaccion
{
    public int IdTipoTransaccion { get; set; }

    public string NombreTipoTransaccion { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public virtual ICollection<Transaccion> Transacciones { get; } = new List<Transaccion>();
}
