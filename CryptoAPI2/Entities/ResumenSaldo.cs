using System;
using System.Collections.Generic;

namespace CryptoAPI2.Models
{
    public partial class ResumenSaldo
    {
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public long Cvu { get; set; }
        public string Moneda { get; set; } = null!;
    }
}
