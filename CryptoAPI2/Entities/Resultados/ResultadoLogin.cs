using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Resultados
{
    public class ResultadoLogin : ResultadoBase
    {
        public int IdUsuario { get; set; }

        public string Email { get; set; } = null!;
    }
}
