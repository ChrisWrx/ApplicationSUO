using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.IO;
using System.Threading.Tasks;
using ApplicationSUOWeb.Models.GeneraPDF;
using System.IO;

namespace ApplicationSUOWebApi.Controllers
{
    [ApiController]
    [Route("ApplicationSUOWebApi/")]
    public class GeneraPDFController : Controller
    {      
        
        [HttpPost("GeneraFichaPDF")]
        public async Task<IActionResult> GeneraFichaPDF([FromBody] GeneraPDFResponse fichaPaciente)
        {
            if (fichaPaciente != null)
            {
                try
                {
                  
                    byte[] pdfBytes = GenerateFichaPdf(fichaPaciente);
                    return File(pdfBytes, "application/pdf", "FichaPaciente.pdf");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { Code = "5000", Message = "Error al generar el PDF", Details = ex.Message });
                }
            }
            else
            {
                return NotFound(new { Code = "8014", Message = "No existen registros para este RUT" });
            }
        }
        [HttpGet]
        public byte[] GenerateFichaPdf(GeneraPDFResponse fichaPaciente)
        {
            using var stream = new MemoryStream();
            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12).FontColor(Colors.Black));

                    var logoPath = Path.Combine(Directory.GetCurrentDirectory(), "Imagenes", "logo.jpeg");

                    if (System.IO.File.Exists(logoPath))
                    {
                        page.Header().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(100);
                                columns.RelativeColumn();
                            });

                            table.Cell().Image(logoPath, ImageScaling.FitArea);
                            table.Cell().AlignCenter().Text("FICHA MÉDICA DEL PACIENTE").FontSize(20).Bold().FontColor("#1E3A8A");
                        });
                    }
                    else
                    {
                        page.Header().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(100);
                                columns.RelativeColumn();
                            });

                            table.Cell().Text("Logo no disponible").FontSize(12).FontColor(Colors.Grey.Medium);
                            table.Cell().AlignCenter().Text("FICHA MÉDICA DEL PACIENTE").FontSize(20).Bold().FontColor("#1E3A8A");
                        });
                    }

                    page.Content().PaddingVertical(20).PaddingHorizontal(10).Column(column =>
                    {
                        column.Item().Text("Información del Paciente").FontSize(16).Bold().FontColor("#1E3A8A");
                        column.Item().PaddingVertical(5).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            AddTableRow(table, "Nombre Completo", fichaPaciente.NombresPaciente + ' ' + fichaPaciente.ApellidoPaterno + ' ' + fichaPaciente.ApellidoMaterno);
                            AddTableRow(table, "RUT", fichaPaciente.RutPaciente);
                            AddTableRow(table, "Dirección", fichaPaciente.DireccionPaciente + ", " + fichaPaciente.ComunaPaciente + ", Región " + fichaPaciente.RegionPaciente);
                        });

                        column.Item().PaddingTop(15).Text("Información de la Entidad").FontSize(16).Bold().FontColor("#1E3A8A");
                        column.Item().PaddingVertical(5).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            AddTableRow(table, "Nombre Entidad", fichaPaciente.NombreEntidad);
                            AddTableRow(table, "RUT Entidad", fichaPaciente.RutEntidad);
                            AddTableRow(table, "Dirección", fichaPaciente.DireccionEntidad + ", " + fichaPaciente.ComunaEntidad + ", Región " + fichaPaciente.RegionEntidad);
                        });

                        column.Item().PaddingTop(15).Text("Detalles de la Atención").FontSize(16).Bold().FontColor("#1E3A8A");
                        column.Item().PaddingVertical(5).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            AddTableRow(table, "Fecha de Atención", fichaPaciente.FechaAtencion);
                            AddTableRow(table, "Hora de Atención", fichaPaciente.HoraAtencion);
                            AddTableRow(table, "Fecha de Alta", fichaPaciente.FechaAlta);
                            AddTableRow(table, "Estado", fichaPaciente.Estado);
                            AddTableRow(table, "Diagnóstico", fichaPaciente.Diagnostico);
                        });
                    });
                    page.Footer().AlignCenter().Text($"Generado el {DateTime.Now:dd-MM-yyyy}").FontSize(10).FontColor("#6B7280");
                });
            }).GeneratePdf(stream);

            return stream.ToArray();
        }

        private static void AddTableRow(TableDescriptor table, string label, string value)
        {
            table.Cell().Element(CellStyle).Text(label).FontSize(12).FontColor("#374151");
            table.Cell().Element(CellStyle).Text(value).FontSize(12).FontColor(Colors.Black);
        }


        private static IContainer CellStyle(IContainer container)
        {
            return container.BorderBottom(1).BorderColor("#D1D5DB").Padding(5);
        }
      
    }
}
