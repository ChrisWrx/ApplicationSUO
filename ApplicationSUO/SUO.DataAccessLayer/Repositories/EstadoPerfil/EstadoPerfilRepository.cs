using SUO.BusinessObjects.EstadoPerfil;
using SUO.BusinessObjects.TipoPerfil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.EstadoPerfil
{
    public class EstadoPerfilRepository : IEstadoPerfilRepository
    {
        private readonly SQLConfiguration _connectionStrings;


        public EstadoPerfilRepository(SQLConfiguration connectionStrings)
        {
            _connectionStrings = connectionStrings;

        }

        public SQLConfiguration dbConnection()
        {
            return new SQLConfiguration(_connectionStrings.ConnectionString);
        }
        public async Task<IEnumerable<GetEstadoPerfilResponse>> ListaEstadoPerfil()
        {
            try
            {
                string connectionString = _connectionStrings.ConnectionString;

                List<GetEstadoPerfilResponse> estado = new List<GetEstadoPerfilResponse>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_Lista_Estado_Perfil", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = (SqlDataReader)await cmd.ExecuteReaderAsync())
                        {

                            while (await reader.ReadAsync())
                            {
                                int idEstado = reader.GetInt32(reader.GetOrdinal("idEstado"));
                                string descripcionEstado = reader.GetString(reader.GetOrdinal("descripcionEstado"));


                                GetEstadoPerfilResponse list = new GetEstadoPerfilResponse(

                                    idEstado,
                                    descripcionEstado

                                );

                                estado.Add(list);
                            }

                        }
                    }
                }

                return estado;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
