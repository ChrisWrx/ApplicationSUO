using SUO.BusinessObjects.Paciente;
using SUO.BusinessObjects.TipoPerfil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.TipoPerfil
{
    public class TipoPerfilRepository : ITipoPerfilRepository
    {
        private readonly SQLConfiguration _connectionStrings;


        public TipoPerfilRepository(SQLConfiguration connectionStrings)
        {
            _connectionStrings = connectionStrings;

        }

        public SQLConfiguration dbConnection()
        {
            return new SQLConfiguration(_connectionStrings.ConnectionString);
        }
        public async Task<IEnumerable<GetTipoPerfilResponse>> ListaTipoPerfil()
        {
            try
            {
                string connectionString = _connectionStrings.ConnectionString;

                List<GetTipoPerfilResponse> perfil = new List<GetTipoPerfilResponse>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_Lista_Tipo_Perfil", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;                       

                        using (SqlDataReader reader = (SqlDataReader)await cmd.ExecuteReaderAsync())
                        {

                            while (await reader.ReadAsync())
                            {
                                int idPerfil = reader.GetInt32(reader.GetOrdinal("idPerfil"));
                                string descripcionPerfil = reader.GetString(reader.GetOrdinal("descripcionPerfil"));


                                GetTipoPerfilResponse list = new GetTipoPerfilResponse(

                                    idPerfil,
                                    descripcionPerfil

                                );

                                perfil.Add(list);
                            }

                        }
                    }
                }

                return perfil;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
