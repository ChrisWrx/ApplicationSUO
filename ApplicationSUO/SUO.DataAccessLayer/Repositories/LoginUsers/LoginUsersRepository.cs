using SUO.BusinessObjects.LoginUsers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.LoginUsers
{
    public class LoginUsersRepository : ILoginUsersRepository
    {
        private readonly SQLConfiguration _connectionStrings;


        public LoginUsersRepository(SQLConfiguration connectionStrings)
        {
            _connectionStrings = connectionStrings;

        }
        public SQLConfiguration dbConnection()
        {
            return new SQLConfiguration(_connectionStrings.ConnectionString);
        }
        
        public async Task<IEnumerable<GetLoginUsersResponse>> LoginUsers(string usuario, string password)
        {
            try
            {
                string connectionStrings = _connectionStrings.ConnectionString;

                List<GetLoginUsersResponse> login = new List<GetLoginUsersResponse>();

                using (SqlConnection connection = new SqlConnection(connectionStrings))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_Login_Suo", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@RUT", usuario));
                        cmd.Parameters.Add(new SqlParameter("@PASSWORD", password));

                        using (SqlDataReader reader = (SqlDataReader)await cmd.ExecuteReaderAsync())
                        {

                            while (await reader.ReadAsync())
                            {

                                string nombreUsuario = reader.GetString(reader.GetOrdinal("NombreUsuario"));
                                string apellidoPaterno = reader.GetString(reader.GetOrdinal("ApellidoPaterno"));
                                string apellidoMaterno = reader.GetString(reader.GetOrdinal("ApellidoMaterno"));
                                string correoUsuario = reader.GetString(reader.GetOrdinal("CorreoUsuario"));
                                string nombreEntidad = reader.GetString(reader.GetOrdinal("NombreEntidad"));
                                string rutEntidad = reader.GetString(reader.GetOrdinal("RutEntidad"));
                                int idPerfil = reader.GetInt32(reader.GetOrdinal("idPerfil"));
                                int idEntidad = reader.GetInt32(reader.GetOrdinal("idEntidad"));                               
                                string ultimaSession = reader.GetString(reader.GetOrdinal("UltimaSession"));                                                               

                                GetLoginUsersResponse user = new GetLoginUsersResponse(

                                    nombreUsuario,
                                    apellidoPaterno,
                                    apellidoMaterno,
                                    correoUsuario,
                                    nombreEntidad,
                                    rutEntidad,
                                    idPerfil,
                                    idEntidad,                                  
                                    ultimaSession                                                                      
                                );

                                login.Add(user);
                            }

                        }
                    }
                }

                return login;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
