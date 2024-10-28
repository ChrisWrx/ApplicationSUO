using SUO.BusinessObjects.ListaEntidadByIdRut;
using SUO.BusinessObjects.ListaPerfilUsuarioByIdRut;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.ListaEntidadByIdRut
{
    public class ListaEntidadByIdRutRepository : IListaEntidadByIdRutRepository
    {
        private readonly SQLConfiguration _connectionStrings;


        public ListaEntidadByIdRutRepository(SQLConfiguration connectionStrings)
        {
            _connectionStrings = connectionStrings;

        }

        public SQLConfiguration dbConnection()
        {
            return new SQLConfiguration(_connectionStrings.ConnectionString);
        }
        public async Task<IEnumerable<ListaEntidadByIdRutResponse>> ListaEntidadIdRut(int ID, string RUT)
        {
            try
            {
                string connectionString = _connectionStrings.ConnectionString;

                List<ListaEntidadByIdRutResponse> listEntidad = new List<ListaEntidadByIdRutResponse>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_Lista_EntidadByIdRut", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@IdEntidad", ID));
                        cmd.Parameters.Add(new SqlParameter("@RUT", RUT));

                        using (SqlDataReader reader = (SqlDataReader)await cmd.ExecuteReaderAsync())
                        {

                            while (await reader.ReadAsync())
                            {
                                int idEntidad = reader.GetInt32(reader.GetOrdinal("idEntidad"));                               
                                string rutEntidad = reader.GetString(reader.GetOrdinal("rutEntidad"));
                                string nombreEntidad = reader.GetString(reader.GetOrdinal("nombreEntidad"));
                                string direccionEntidad = reader.GetString(reader.GetOrdinal("direccionEntidad"));
                                int idRegion = reader.GetInt32(reader.GetOrdinal("idRegion"));
                                string regionEntidad = reader.GetString(reader.GetOrdinal("regionEntidad"));
                                int idComuna = reader.GetInt32(reader.GetOrdinal("idComuna"));
                                string comunaEntidad = reader.GetString(reader.GetOrdinal("comunaEntidad"));
                                string contactoEntidad = reader.GetString(reader.GetOrdinal("contactoEntidad"));
                                string telefonoEntidad = reader.GetString(reader.GetOrdinal("telefonoEntidad"));
                                string imgEntidad1 = reader.GetString(reader.GetOrdinal("imgEntidad1"));
                                string imgEntidad2 = reader.GetString(reader.GetOrdinal("imgEntidad2"));
                                string imgEntidad3 = reader.GetString(reader.GetOrdinal("imgEntidad3"));                              
                                string fechaModificacion = reader.GetString(reader.GetOrdinal("fechaModificacion"));                               

                                ListaEntidadByIdRutResponse list = new ListaEntidadByIdRutResponse(

                                    idEntidad,
                                    rutEntidad,
                                    nombreEntidad,
                                    direccionEntidad,
                                    idRegion,
                                    regionEntidad,
                                    idComuna,
                                    comunaEntidad,
                                    contactoEntidad,
                                    telefonoEntidad,
                                    imgEntidad1,
                                    imgEntidad2,
                                    imgEntidad3,
                                    fechaModificacion                               

                                );

                                listEntidad.Add(list);
                            }

                        }
                    }
                }

                return listEntidad;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
