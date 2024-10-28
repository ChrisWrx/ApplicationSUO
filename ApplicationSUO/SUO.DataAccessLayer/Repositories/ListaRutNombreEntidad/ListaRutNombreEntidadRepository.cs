using SUO.BusinessObjects.Entidad;
using SUO.BusinessObjects.ListaRutNombreEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.ListaRutNombreEntidad
{
    public class ListaRutNombreEntidadRepository : IListaRutNombreEntidadRepository
    {
        private readonly SQLConfiguration _connectionStrings;

        public ListaRutNombreEntidadRepository(SQLConfiguration connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public SQLConfiguration dbConnection()
        {
            return new SQLConfiguration(_connectionStrings.ConnectionString);
        }
        public async Task<IEnumerable<GetListaRutNombreEntidadResponse>> ListaEntidades()
        {
            try
            {
                string connectionString = _connectionStrings.ConnectionString;
                List<GetListaRutNombreEntidadResponse> entidad = new List<GetListaRutNombreEntidadResponse>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_Lista_Entidades", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = (SqlDataReader)await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                int idEntidad = reader.GetInt32(reader.GetOrdinal("idEntidad"));
                                string nombreEntidad = reader.GetString(reader.GetOrdinal("nombreEntidad"));

                                GetListaRutNombreEntidadResponse listEntidades = new GetListaRutNombreEntidadResponse(
                                    idEntidad,
                                    nombreEntidad,
                                    string.Empty

                                );

                                entidad.Add(listEntidades);
                            }
                        }
                    }
                }

                return entidad;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        public async Task<IEnumerable<GetListaRutNombreEntidadResponse>> ListaRutPorNombre(int ID)
        {
            try
            {
                string connectionString = _connectionStrings.ConnectionString;
                List<GetListaRutNombreEntidadResponse> rutNombre = new List<GetListaRutNombreEntidadResponse>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_ListarRutPorNombreEntidad", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@IdEntidad", ID));

                        using (SqlDataReader reader = (SqlDataReader)await cmd.ExecuteReaderAsync())
                        {

                            if (await reader.ReadAsync())
                            {
                                int idEntidad = reader.GetInt32(reader.GetOrdinal("idEntidad"));
                                string nombreEntidad = reader.GetString(reader.GetOrdinal("nombreEntidad"));                                

                                if (await reader.NextResultAsync())
                                {
                                    while (await reader.ReadAsync())
                                    {
                                        int IdEntidad = reader.GetInt32(reader.GetOrdinal("idEntidad"));
                                        string rutEntidad = reader.GetString(reader.GetOrdinal("rutEntidad"));

                                        GetListaRutNombreEntidadResponse list = new GetListaRutNombreEntidadResponse(
                                            idEntidad,
                                            nombreEntidad,
                                            rutEntidad
                                            
                                        );

                                        rutNombre.Add(list);
                                    }
                                }
                            }
                        }
                    }
                }

                return rutNombre;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
