using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.TipoPerfil
{
    public class GetTipoPerfilResponse
    {
        public GetTipoPerfilResponse(int idPerfil, string descripcionPerfil) 
        {
          IdPerfil = idPerfil;
          DescripcionPerfil = descripcionPerfil;
        }

        [JsonPropertyName("idPerfil")]
        public int IdPerfil { get; set; }

        [JsonPropertyName("descripcionPerfil")]
        public string DescripcionPerfil { get; set; }
    }
}
