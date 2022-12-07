using System;
using System.Collections.Generic;

namespace API_BestWallet.Models;

public partial class Moneda
{
    public int IdMoneda { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Codigo { get; set; }

    public virtual ICollection<Cuenta> Cuenta { get; } = new List<Cuenta>();
}
