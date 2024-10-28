using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.DeletePerfilUsuario
{
    public class GetDeletePerfilUsuarioResponse
    {
        public GetDeletePerfilUsuarioResponse()
        {
        }

        public GetDeletePerfilUsuarioResponse(int filaEliminada)
        {
            FilaEliminada = filaEliminada;
        }

        [JsonPropertyName("filaEliminada")]
        public int FilaEliminada { get; set; }
    }
}
