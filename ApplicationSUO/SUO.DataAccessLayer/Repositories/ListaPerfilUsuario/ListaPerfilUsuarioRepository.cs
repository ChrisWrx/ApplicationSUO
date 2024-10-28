using SUO.BusinessObjects.FichaPaciente;
using SUO.BusinessObjects.ListaPerfilUsuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.ListaPerfilUsuario
{
    public class ListaPerfilUsuarioRepository : IListaPerfilUsuarioRepository
    {
        private readonly SQLConfiguration _connectionStrings;


        public ListaPerfilUsuarioRepository(SQLConfiguration connectionStrings)
        {
            _connectionStrings = connectionStrings;

        }

        public SQLConfiguration dbConnection()
        {
            return new SQLConfiguration(_connectionStrings.ConnectionString);
        }
        public async Task<IEnumerable<GetListaPerfilUsuarioResponse>> ListaPerfilUsuario()
        {
            try
            {
                string connectionString = _connectionStrings.ConnectionString;

                List<GetListaPerfilUsuarioResponse> listUsuario = new List<GetListaPerfilUsuarioResponse>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_Lista_Usuarios", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;                       

                        using (SqlDataReader reader = (SqlDataReader)await cmd.ExecuteReaderAsync())
                        {

                            while (await reader.ReadAsync())
                            {
                                int idLogin = reader.GetInt32(reader.GetOrdinal("idLogin"));
                                string rutUsuario = reader.GetString(reader.GetOrdinal("rutUsuario"));
                                string nombreUsuario = reader.GetString(reader.GetOrdinal("nombreUsuario"));
                                string correoUsuario = reader.GetString(reader.GetOrdinal("correoUsuario"));
                                string rutEntidad = reader.GetString(reader.GetOrdinal("rutEntidad"));
                                string nombreEntidad = reader.GetString(reader.GetOrdinal("nombreEntidad"));
                                string estado = reader.GetString(reader.GetOrdinal("estado"));
                                string perfil = reader.GetString(reader.GetOrdinal("perfil"));
                                string fechaRegistro = reader.GetString(reader.GetOrdinal("fechaRegistro"));

                                GetListaPerfilUsuarioResponse list = new GetListaPerfilUsuarioResponse(

                                    idLogin,
                                    rutUsuario,
                                    nombreUsuario,
                                    correoUsuario,
                                    rutEntidad,
                                    nombreEntidad,
                                    estado,
                                    perfil,
                                    fechaRegistro

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
