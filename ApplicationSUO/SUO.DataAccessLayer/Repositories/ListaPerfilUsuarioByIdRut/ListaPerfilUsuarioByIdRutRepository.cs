using SUO.BusinessObjects.ListaPerfilUsuario;
using SUO.BusinessObjects.ListaPerfilUsuarioByIdRut;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.ListaPerfilUsuarioByIdRut
{
    public class ListaPerfilUsuarioByIdRutRepository : IListaPerfilUsuarioByIdRutRepository
    {
        private readonly SQLConfiguration _connectionStrings;


        public ListaPerfilUsuarioByIdRutRepository(SQLConfiguration connectionStrings)
        {
            _connectionStrings = connectionStrings;

        }

        public SQLConfiguration dbConnection()
        {
            return new SQLConfiguration(_connectionStrings.ConnectionString);
        }
        public async Task<IEnumerable<GetListaPerfilUsuarioByIdRutResponse>> ListaPerfilUsuarioIdRut(int ID, string RUT)
        {
            try
            {
                string connectionString = _connectionStrings.ConnectionString;

                List<GetListaPerfilUsuarioByIdRutResponse> listUsuario = new List<GetListaPerfilUsuarioByIdRutResponse>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_Lista_UsuarioByIdRut", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@ID", ID));
                        cmd.Parameters.Add(new SqlParameter("@RUT", RUT));

                        using (SqlDataReader reader = (SqlDataReader)await cmd.ExecuteReaderAsync())
                        {

                            while (await reader.ReadAsync())
                            {
                                int idLogin = reader.GetInt32(reader.GetOrdinal("idLogin"));
                                int idUsuario = reader.GetInt32(reader.GetOrdinal("idUsuario"));
                                string rutUsuario = reader.GetString(reader.GetOrdinal("rutUsuario"));
                                string nombreUsuario = reader.GetString(reader.GetOrdinal("nombreUsuario"));
                                string apellidoPaterno = reader.GetString(reader.GetOrdinal("apellidoPaterno"));
                                string apellidoMaterno = reader.GetString(reader.GetOrdinal("apellidoMaterno"));
                                string correoUsuario = reader.GetString(reader.GetOrdinal("correoUsuario"));
                                int idEntidad = reader.GetInt32(reader.GetOrdinal("idEntidad"));
                                string rutEntidad = reader.GetString(reader.GetOrdinal("rutEntidad"));
                                string nombreEntidad = reader.GetString(reader.GetOrdinal("nombreEntidad"));
                                int idEstado = reader.GetInt32(reader.GetOrdinal("idEstado"));
                                string descripcionEstado = reader.GetString(reader.GetOrdinal("descripcionEstado"));
                                string descripcionPerfil = reader.GetString(reader.GetOrdinal("descripcionPerfil"));
                                string fechaRegistro = reader.GetString(reader.GetOrdinal("fechaRegistro"));
                                string fechaModificacion = reader.GetString(reader.GetOrdinal("fechaModificacion"));

                                GetListaPerfilUsuarioByIdRutResponse list = new GetListaPerfilUsuarioByIdRutResponse(

                                    idLogin,
                                    idUsuario,
                                    rutUsuario,
                                    nombreUsuario,
                                    apellidoPaterno,
                                    apellidoMaterno,
                                    correoUsuario,
                                    idEntidad,
                                    rutEntidad,
                                    nombreEntidad,
                                    idEstado,
                                    descripcionEstado,
                                    descripcionPerfil,
                                    fechaRegistro,
                                    fechaModificacion

                                );

                                listUsuario.Add(list);
                            }

                        }
                    }
                }

                return listUsuario;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
