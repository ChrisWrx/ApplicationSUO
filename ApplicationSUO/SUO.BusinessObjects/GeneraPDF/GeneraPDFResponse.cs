using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.GeneraPDF
{
    public class GeneraPDFResponse
    {
        public GeneraPDFResponse(int id, string rutPaciente, string nombresPaciente, string apellidoPaterno, string apellidoMaterno, string direccionPaciente, string comunaPaciente,
                                        string regionPaciente, string rutEntidad, string nombreEntidad, string direccionEntidad, string comunaEntidad, string regionEntidad, string horaAtencion, string fechaAtencion,
                                        string fechaAlta, string estado, string diagnostico)
        {
            Id = id;
            RutPaciente = rutPaciente;
            NombresPaciente = nombresPaciente;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            DireccionPaciente = direccionPaciente;
            ComunaPaciente = comunaPaciente;
            RegionPaciente = regionPaciente;
            RutEntidad = rutEntidad;
            NombreEntidad = nombreEntidad;
            DireccionEntidad = direccionEntidad;
            ComunaEntidad = comunaEntidad;
            RegionEntidad = regionEntidad;
            HoraAtencion = horaAtencion;
            FechaAtencion = fechaAtencion;
            FechaAlta = fechaAlta;
            Estado = estado;
            Diagnostico = diagnostico;
        }


        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("rutPaciente")]
        public string RutPaciente { get; set; }

        [JsonPropertyName("nombresPaciente")]
        public string NombresPaciente { get; set; }

        [JsonPropertyName("apellidoPaterno")]
        public string ApellidoPaterno { get; set; }

        [JsonPropertyName("apellidoMaterno")]
        public string ApellidoMaterno { get; set; }

        [JsonPropertyName("direccionPaciente")]
        public string DireccionPaciente { get; set; }

        [JsonPropertyName("comunaPaciente")]
        public string ComunaPaciente { get; set; }

        [JsonPropertyName("regionPaciente")]
        public string RegionPaciente { get; set; }

        [JsonPropertyName("rutEntidad")]
        public string RutEntidad { get; set; }

        [JsonPropertyName("nombreEntidad")]
        public string NombreEntidad { get; set; }

        [JsonPropertyName("direccionEntidad")]
        public string DireccionEntidad { get; set; }

        [JsonPropertyName("comunaEntidad")]
        public string ComunaEntidad { get; set; }

        [JsonPropertyName("regionEntidad")]
        public string RegionEntidad { get; set; }

        [JsonPropertyName("horaAtencion")]
        public string HoraAtencion { get; set; }

        [JsonPropertyName("fechaAtencion")]
        public string FechaAtencion { get; set; }

        [JsonPropertyName("fechaAlta")]
        public string FechaAlta { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; }

        [JsonPropertyName("diagnostico")]
        public string Diagnostico { get; set; }
    }
}
