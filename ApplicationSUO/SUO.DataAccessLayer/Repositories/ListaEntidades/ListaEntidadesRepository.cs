using SUO.BusinessObjects.ListaEntidades;
using SUO.BusinessObjects.ListaPerfilUsuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.ListaEntidades
{
    public class ListaEntidadesRepository : IListaEntidadesRepository
    {
        private readonly SQLConfiguration _connectionStrings;


        public ListaEntidadesRepository(SQLConfiguration connectionStrings)
        {
            _connectionStrings = connectionStrings;

        }

        public SQLConfiguration dbConnection()
        {
            return new SQLConfiguration(_connectionStrings.ConnectionString);
        }
        public async Task<IEnumerable<GetListaEntidadesResponse>> ListaEntidades()
        {
            try
            {
                string connectionString = _connectionStrings.ConnectionString;

                List<GetListaEntidadesResponse> listEntidades = new List<GetListaEntidadesResponse>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_Obtener_Lista_Entidades", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = (SqlDataReader)await cmd.ExecuteReaderAsync())
                        {

                            while (await reader.ReadAsync())
                            {
                                int idEntidad = reader.GetInt32(reader.GetOrdinal("idEntidad"));
                                string rutEntidad = reader.GetString(reader.GetOrdinal("rutEntidad"));
                                string nombreEntidad = reader.GetString(reader.GetOrdinal("nombreEntidad"));
                                string direccionEntidad = reader.GetString(reader.GetOrdinal("direccionEntidad"));
                                string comunaEntidad = reader.GetString(reader.GetOrdinal("comunaEntidad"));
                                string regionEntidad = reader.GetString(reader.GetOrdinal("regionEntidad"));
                                string contactoEntidad = reader.GetString(reader.GetOrdinal("contactoEntidad"));
                                string telefonoEntidad = reader.GetString(reader.GetOrdinal("telefonoEntidad"));                              

                                GetListaEntidadesResponse list = new GetListaEntidadesResponse(

                                    idEntidad,
                                    rutEntidad,
                                    nombreEntidad,
                                    direccionEntidad,
                                    comunaEntidad,
                                    regionEntidad,
                                    contactoEntidad,
                                    telefonoEntidad

                                );

                                listEntidades.Add(list);
                            }

                        }
                    }
                }

                return listEntidades;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
