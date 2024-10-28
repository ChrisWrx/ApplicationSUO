using ApplicationSUOWeb.Models.ListaImgCarrusel;
using ApplicationSUOWeb.Models.ListaRutNombreEntidad;
using ApplicationSUOWeb.Models.Login;
using ApplicationSUOWeb.Models.RegionesComunas;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace ApplicationSUOWeb.Controllers.ListaImgCarrusel
{   
    public class ListaImgCarruselController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;
        public ListaImgCarruselController(HttpClient httpClient, ApiSettings apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings;
        }
        [HttpGet]
        public async Task<IActionResult> obtenerImages(int IdEntidad)
        {
            string apiUrl = $"{_apiSettings.BaseUrl}/ApplicationSUOWebApi/ListaImagesCarruselById?ID={IdEntidad}";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var Imagenes = JsonConvert.DeserializeObject<List<ListaImgCarruselResponse>>(jsonResponse);                

                if (Imagenes == null)
                {
                    return Json(new { Code = "8014", Message = "No se encontraron imágenes para la entidad seleccionada." });
                }

                return Json(Imagenes);
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

    }
}
