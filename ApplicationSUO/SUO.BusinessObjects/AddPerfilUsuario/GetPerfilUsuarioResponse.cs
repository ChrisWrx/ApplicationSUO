using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.AddPerfilUsuario
{
    public class GetPerfilUsuarioResponse
    {
        public GetPerfilUsuarioResponse()
        {
        }

        public GetPerfilUsuarioResponse(int filaAgregada) 
        {
            FilaAgregada = filaAgregada;
        }

        [JsonPropertyName("filaAgregada")]
        public int FilaAgregada { get; set; }
    }
}
