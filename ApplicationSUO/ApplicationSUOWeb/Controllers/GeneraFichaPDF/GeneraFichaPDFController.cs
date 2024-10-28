using ApplicationSUOWeb.Models.FichaPaciente;
using ApplicationSUOWeb.Models.GeneraPDF;
using ApplicationSUOWeb.Models.Login;
using ApplicationSUOWeb.Models.Pacientes;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationSUOWeb.Controllers.GeneraFichaPDF
{
    public class GeneraFichaPDFController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;
        private readonly IConverter _converter;

        public GeneraFichaPDFController(IConverter converter, HttpClient httpClient, ApiSettings apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings;
            _converter = converter;
        }

        public async Task<IActionResult> Index()
        {
          
            string loginResponseJson = HttpContext.Session.GetString("LoginResponse");

            if (!string.IsNullOrEmpty(loginResponseJson))
            {
                var loginResponse = JsonSerializer.Deserialize<LoginResponse>(loginResponseJson);
                ViewBag.LoginResponse = loginResponse;
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GeneraPDF([FromBody] GeneraPDFResponse fichaPaciente)
        {
            var url = $"{_apiSettings.BaseUrl}/ApplicationSUOWebApi/GeneraFichaPDF";

            try
            {
               
                var jsonContent = JsonSerializer.Serialize(fichaPaciente);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                
                var response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                var pdfContent = await response.Content.ReadAsByteArrayAsync();

                return File(pdfContent, "application/pdf", "FichaPaciente.pdf");
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, new { Code = "5000", Message = "Error al generar el PDF", Details = ex.Message });
            }
        }
    }
}
