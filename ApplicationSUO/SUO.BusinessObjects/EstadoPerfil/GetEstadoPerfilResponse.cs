using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.EstadoPerfil
{
    public class GetEstadoPerfilResponse
    {
        public GetEstadoPerfilResponse(int idEstado, string descripcionEstado)
        {
            IdEstado = idEstado;
            DescripcionEstado = descripcionEstado;
        }

        [JsonPropertyName("idEstado")]
        public int IdEstado { get; set; }

        [JsonPropertyName("descripcionEstado")]
        public string DescripcionEstado { get; set; }
    }
}
