using System;
using System.Collections.Generic;

namespace API_BestWallet.Models;

public partial class Transaccion
{
    public int IdTransaccion { get; set; }

    public int IdTipoTransaccion { get; set; }

    public DateTime Fecha { get; set; }

    public double Monto { get; set; }

    public int IdCuenta { get; set; }

    public virtual Cuenta IdCuentaNavigation { get; set; } = null!;

    public virtual TipoTransaccion IdTipoTransaccionNavigation { get; set; } = null!;
}
