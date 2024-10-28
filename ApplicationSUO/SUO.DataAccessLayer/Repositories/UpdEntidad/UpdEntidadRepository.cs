using SUO.BusinessObjects.AddEntidades;
using SUO.BusinessObjects.UpdEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.UpdEntidad
{
    public class UpdEntidadRepository : IUpdEntidadRepository
    {
        private readonly SQLConfiguration _connectionStrings;

        private readonly RutaArchivoConfiguration _rutaArchivoConfiguration;

        public UpdEntidadRepository(SQLConfiguration connectionStrings, RutaArchivoConfiguration rutaArchivoConfiguration)
        {
            _connectionStrings = connectionStrings;

            _rutaArchivoConfiguration = rutaArchivoConfiguration;
        }
        public SQLConfiguration dbConnection()
        {
            return new SQLConfiguration(_connectionStrings.ConnectionString);
        }
        public async Task<UpdEntidadResponse> ActualizaEntidad(UpdEntidadRequest updEntidadRequest)
        {
            UpdEntidadResponse updEntidadResponse = new();
            try
            {
                string rutaArchivoConfiguration = _rutaArchivoConfiguration.RutaArchivoString;


                string base64String1 = CleanBase64String(updEntidadRequest.ImgEntidad1);
                string base64String2 = CleanBase64String(updEntidadRequest.ImgEntidad2);
                string base64String3 = CleanBase64String(updEntidadRequest.ImgEntidad3);


                int maxLength = 20 * 1024 * 1024;


                string Img1 = base64String1.Length > maxLength ? base64String1.Substring(0, maxLength) : base64String1;
                string Img2 = base64String2.Length > maxLength ? base64String2.Substring(0, maxLength) : base64String2;
                string Img3 = base64String3.Length > maxLength ? base64String3.Substring(0, maxLength) : base64String3;

                byte[] imageBytes1 = Convert.FromBase64String(Img1);
                byte[] imageBytes2 = Convert.FromBase64String(Img2);
                byte[] imageBytes3 = Convert.FromBase64String(Img3);

                string rutaImagen1 = Path.Combine(rutaArchivoConfiguration, $"imagen1_{DateTime.Now:yyyyMMdd-HHmm}.png");
                string rutaImagen2 = Path.Combine(rutaArchivoConfiguration, $"imagen2_{DateTime.Now:yyyyMMdd-HHmm}.png");
                string rutaImagen3 = Path.Combine(rutaArchivoConfiguration, $"imagen3_{DateTime.Now:yyyyMMdd-HHmm}.png");

                File.WriteAllBytes(rutaImagen1, imageBytes1);
                File.WriteAllBytes(rutaImagen2, imageBytes2);
                File.WriteAllBytes(rutaImagen3, imageBytes3);

                string connectionString = _connectionStrings.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_Update_Entidad", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdEntidad", updEntidadRequest.IdEntidad);
                        cmd.Parameters.AddWithValue("@RutEntidad", updEntidadRequest.RutEntidad);                        
                        cmd.Parameters.AddWithValue("@TelefonoEntidad", updEntidadRequest.TelefonoEntidad);
                        cmd.Parameters.AddWithValue("@ContactoEntidad", updEntidadRequest.ContactoEntidad);
                        cmd.Parameters.AddWithValue("@ImgEntidad1", Img1);
                        cmd.Parameters.AddWithValue("@ImgEntidad2", Img2);
                        cmd.Parameters.AddWithValue("@ImgEntidad3", Img3);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            updEntidadResponse = await GetDataEntidades(reader);
                        }
                    }
                }

                File.Delete(rutaImagen1);
                File.Delete(rutaImagen2);
                File.Delete(rutaImagen3);

                return updEntidadResponse;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        private string CleanBase64String(string base64Image)
        {
            if (base64Image.Contains(","))
            {
                return base64Image.Split(',')[1];
            }
            return base64Image;
        }

        private static async Task<UpdEntidadResponse> GetDataEntidades(DbDataReader reader)
        {
            try
            {
                if (await reader.ReadAsync())
                {
                    int filaModificada = reader.GetInt32(reader.GetOrdinal("filaModificada"));

                    UpdEntidadResponse updEntidadResponse = new UpdEntidadResponse(

                        filaModificada

                    );

                    return updEntidadResponse;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
