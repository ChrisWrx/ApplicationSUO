using SUO.BusinessObjects.FichaPaciente;
using SUO.BusinessObjects.ListaImgCarrusel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.ListaImgCarrusel
{
    public class ListaImgCarruselRepository : IListaImgCarruselRepository
    {
        private readonly SQLConfiguration _connectionStrings;


        public ListaImgCarruselRepository(SQLConfiguration connectionStrings)
        {
            _connectionStrings = connectionStrings;

        }

        public SQLConfiguration dbConnection()
        {
            return new SQLConfiguration(_connectionStrings.ConnectionString);
        }
        public async Task<IEnumerable<GetListaImgCarruselResponse>> ListaImgCarrusel(int ID)
        {
            try
            {
                string connectionString = _connectionStrings.ConnectionString;

                List<GetListaImgCarruselResponse> imgCarrusel = new List<GetListaImgCarruselResponse>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_Lista_ImgCarrusel", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@IdEntidad", ID));
                        

                        using (SqlDataReader reader = (SqlDataReader)await cmd.ExecuteReaderAsync())
                        {

                            while (await reader.ReadAsync())
                            {
                                int idEntidad = reader.GetInt32(reader.GetOrdinal("idEntidad"));
                                string imgEntidad1 = reader.GetString(reader.GetOrdinal("imgEntidad1"));
                                string imgEntidad2 = reader.GetString(reader.GetOrdinal("imgEntidad2"));
                                string imgEntidad3 = reader.GetString(reader.GetOrdinal("imgEntidad3"));                        


                                GetListaImgCarruselResponse images = new GetListaImgCarruselResponse(

                                    idEntidad,
                                    imgEntidad1,
                                    imgEntidad2,
                                    imgEntidad3


                                );

                                imgCarrusel.Add(images);
                            }

                        }
                    }
                }

                return imgCarrusel;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
