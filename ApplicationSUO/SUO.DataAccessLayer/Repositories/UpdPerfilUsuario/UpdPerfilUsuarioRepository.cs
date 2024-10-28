using SUO.BusinessObjects.AddPerfilUsuario;
using SUO.BusinessObjects.UpdPerfilUsuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.UpdPerfilUsuario
{
    public class UpdPerfilUsuarioRepository : IUpdPerfilUsuarioRepository
    {
        private readonly SQLConfiguration _connectionStrings;


        public UpdPerfilUsuarioRepository(SQLConfiguration connectionStrings)
        {
            _connectionStrings = connectionStrings;

        }

        public SQLConfiguration dbConnection()
        {
            return new SQLConfiguration(_connectionStrings.ConnectionString);
        }
        public async Task<UpdPerfilUsuarioResponse> UpdatePerfilUsuario(UpdPerfilUsuarioRequest updUsersSystemRequest)
        {
            UpdPerfilUsuarioResponse updPerfilUsuarioResponse = new();

            try
            {

                string connectionString = _connectionStrings.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_Update_Perfil_Usuario", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@idLogin", updUsersSystemRequest.IdLogin);
                        cmd.Parameters.AddWithValue("@rutUsuario", updUsersSystemRequest.RutUsuario);
                        cmd.Parameters.AddWithValue("@correoUsuario", updUsersSystemRequest.CorreoUsuario);
                        cmd.Parameters.AddWithValue("@rutEntidad", updUsersSystemRequest.RutEntidad);
                        cmd.Parameters.AddWithValue("@idEntidad", updUsersSystemRequest.IdEntidad);
                        cmd.Parameters.AddWithValue("@idPerfil", updUsersSystemRequest.IdPerfil);
                        cmd.Parameters.AddWithValue("@idEstado", updUsersSystemRequest.IdEstado);
                   
                        var reader = await cmd.ExecuteReaderAsync();

                        updPerfilUsuarioResponse = await GetDataPerfilUsuario(reader);
                    }
                }


                return updPerfilUsuarioResponse;

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        private static async Task<UpdPerfilUsuarioResponse> GetDataPerfilUsuario(DbDataReader reader)
        {
            try
            {
                if (await reader.ReadAsync())
                {
                    int FilaActualizada = reader.GetInt32(reader.GetOrdinal("filaActualizada"));

                    UpdPerfilUsuarioResponse updPerfilUsuarioResponse = new UpdPerfilUsuarioResponse(

                        FilaActualizada

                    );

                    return updPerfilUsuarioResponse;
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
