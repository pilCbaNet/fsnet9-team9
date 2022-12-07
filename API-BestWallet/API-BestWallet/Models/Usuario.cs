using System;
using System.Collections.Generic;

namespace API_BestWallet.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int Dni { get; set; }

    public DateTime FechaNac { get; set; }

    public long Teléfono { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime FechaAlta { get; set; }

    public DateTime? FechaBaja { get; set; }

    public virtual ICollection<Cuenta> Cuenta { get; } = new List<Cuenta>();
}
