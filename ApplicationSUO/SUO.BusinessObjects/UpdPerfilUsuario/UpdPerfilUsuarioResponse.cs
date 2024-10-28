using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.UpdPerfilUsuario
{
    public class UpdPerfilUsuarioResponse
    {
        public UpdPerfilUsuarioResponse()
        {
        }

        public UpdPerfilUsuarioResponse(int filaActualizada)
        {
            FilaActualizada = filaActualizada;
        }

        [JsonPropertyName("filaActualizada")]
        public int FilaActualizada { get; set; }
    }
}
