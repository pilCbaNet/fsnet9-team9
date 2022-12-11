using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class ComandoRegistrar
    {
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public int Dni { get; set; }

        public long Teléfono { get; set; } 

        public DateTime FechaNac { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
