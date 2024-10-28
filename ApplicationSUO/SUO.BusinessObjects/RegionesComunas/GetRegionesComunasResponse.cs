using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.Entidad
{
    public class GetRegionesComunasResponse
    {
        public GetRegionesComunasResponse(int idRegion, string region, int idComuna, string comuna)
        {
            IdRegion = idRegion;
            Region = region;
            IdComuna = idComuna;
            Comuna = comuna;
        }

        [JsonPropertyName("idRegion")]
        public int IdRegion { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("idComuna")]
        public int IdComuna { get; set; }

        [JsonPropertyName("comuna")]
        public string Comuna { get; set; }
    }
}
