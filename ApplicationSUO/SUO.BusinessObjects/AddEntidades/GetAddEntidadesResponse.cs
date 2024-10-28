using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.AddEntidades
{
    public class GetAddEntidadesResponse
    {
        public GetAddEntidadesResponse()
        {
        }

        public GetAddEntidadesResponse(int filaAgregada)
        {
            FilaAgregada = filaAgregada;
        }

        [JsonPropertyName("filaAgregada")]
        public int FilaAgregada { get; set; }
    }
}
