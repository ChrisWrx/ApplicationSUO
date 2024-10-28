using ApplicationSUOWeb.Models.AddPerfilUsuario;
using ApplicationSUOWeb.Models.ListaEntidadByRut;
using ApplicationSUOWeb.Models.ListaEntidades;
using ApplicationSUOWeb.Models.ListaPerfilUsuario;
using ApplicationSUOWeb.Models.ListaPerfilUsuarioByIdRutResponse;
using ApplicationSUOWeb.Models.RegionesComunas;
using ApplicationSUOWeb.Models.UpdEntidad;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SUO.BusinessObjects.AddEntidades;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSUOWeb.Controllers.Entidades
{
    public class EntidadController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;

        public EntidadController(HttpClient httpClient, ApiSettings apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings;
        }

        public IActionResult Index()
        {
            return View();
        }
               
        [HttpGet]
        public async Task<IActionResult> ObtenerRegiones()
        {
            
            string apiUrl = $"{_apiSettings.BaseUrl}/ApplicationSUOWebApi/ListaRegiones";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var regiones = JsonConvert.DeserializeObject<List<RegionesComunasResponse>>(jsonResponse);

                if (regiones == null || regiones.Count == 0)
                {
                    return Json(new { Code = "8014", Message = "No se encontraron regiones." });
                }

                return Json(regiones);
            }
            catch (HttpRequestException e)
            {
                return Json(new { Code = "8015", Message = "Error de conexión: " + e.Message });
            }
            catch (Exception ex)
            {
                return Json(new { Code = "5000", Message = "Error inesperado: " + ex.Message });
            }
        }
       
        [HttpGet]
        public async Task<IActionResult> ObtenerComunasPorRegiones(int IdRegion)
        {
            string apiUrl = $"{_apiSettings.BaseUrl}/ApplicationSUOWebApi/ListaComunasPorRegion?IDREGION={IdRegion}";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var comunas = JsonConvert.DeserializeObject<List<RegionesComunasResponse>>(jsonResponse);

                if (comunas == null || comunas.Count == 0)
                {
                    return Json(new { Code = "8014", Message = "No se encontraron comunas para la región seleccionada." });
                }

                return Json(comunas);
            }
            catch (HttpRequestException e)
            {
                return Json(new { Code = "8015", Message = "Error de conexión: " + e.Message });
            }
            catch (Exception ex)
            {
                return Json(new { Code = "5000", Message = "Error inesperado: " + ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtineneListadoEntidades()
        {
            var response = await _httpClient.GetAsync($"{_apiSettings.BaseUrl}/ApplicationSUOWebApi/ListaDeEntidades");

            if (response.IsSuccessStatusCode)
            {
                var listEntidades = await response.Content.ReadAsAsync<IEnumerable<ListaEntidadesResponse>>();
                return Json(listEntidades);
            }
            else
            {
                return Json(new { Code = "8014", Message = "No existe lista de entidades" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CrearNuevaEntidad([FromForm] Models.AddEntidades.AddEntidadesRequest addEntidadesRequest)
        {
            if (addEntidadesRequest == null || !ModelState.IsValid)
            {
                return BadRequest(new { Code = "400", Message = "Los datos enviados no son válidos o están vacíos" });
            }
            
            string jsonRequest = JsonConvert.SerializeObject(addEntidadesRequest);
            StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            string apiUrl = $"{_apiSettings.BaseUrl}/ApplicationSUOWebApi/AddNuevaEntidad";

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var entidadCreada = JsonConvert.DeserializeObject<GetAddEntidadesResponse>(jsonResponse);

                    return Ok(new { Code = "1", Message = "Entidad agregada exitosamente", Data = entidadCreada });
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return BadRequest(new { Code = "500", Message = "Error al agregar la entidad", Details = errorMessage });
                }
            }
            catch (HttpRequestException e)
            {
                return BadRequest(new { Code = "500", Message = $"Error de conexión: {e.Message}" });
            }
        }
        [HttpPut]
        public async Task<IActionResult> ActualizaEntidad([FromBody] Models.UpdEntidad.UpdEntidadRequest updEntidadRequest)
        {
            if (updEntidadRequest == null || !ModelState.IsValid)
            {
                return BadRequest(new { Code = "400", Message = "Los datos enviados no son válidos o están vacíos" });
            }

            string jsonRequest = JsonConvert.SerializeObject(updEntidadRequest);
            StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            string apiUrl = $"{_apiSettings.BaseUrl}/ApplicationSUOWebApi/UpdateEntidad";

            try
            {

                HttpResponseMessage response = await _httpClient.PutAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var entidadActualizada = JsonConvert.DeserializeObject<UpdEntidadResponse>(jsonResponse);

                    return Ok(new { Code = "1", Message = "Entidad actualizada exitosamente", Data = entidadActualizada });
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return BadRequest(new { Code = "500", Message = "Error al actualizar la entidad", Details = errorMessage });
                }
            }
            catch (HttpRequestException e)
            {
                return BadRequest(new { Code = "500", Message = $"Error de conexión: {e.Message}" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtienerEntidadByIdRut(int ID, string RUT)
        {
            var response = await _httpClient.GetAsync($"{_apiSettings.BaseUrl}/ApplicationSUOWebApi/ListaEntidadByIdRut?ID={ID}&RUT={RUT}");

            if (response.IsSuccessStatusCode)
            {
                var listEnt = await response.Content.ReadAsAsync<List<ListaEntidadByIdRutResponse>>();

                var listEnts = listEnt.FirstOrDefault();

                if (listEnt != null)
                {
                    return Json(listEnt);
                }
                else
                {
                    return Json(new { Code = "8014", Message = "No se encontró la entidad seleccionada." });
                }
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error en la llamada a la API: {errorContent}");
                return Json(new { Code = "8014", Message = "No se encontró la entidad seleccionada." });
            }
        }

    }
}
