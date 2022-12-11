using Entities.DTO;
using Entities.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Services
{
    public interface IUsuarioService
    {
        Task<ResultadoLogin> RegistrarUsuario(ComandoRegistrar datos);
        
    }
}
