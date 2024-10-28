using SUO.BusinessObjects.DeletePerfilUsuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.DeletePerfilUsuario
{
    public class DeletePerfilUsuarioRepository : IDeletePerfilUsuarioRepository
    {
        private readonly SQLConfiguration _connectionStrings;


        public DeletePerfilUsuarioRepository(SQLConfiguration connectionStrings)
        {
            _connectionStrings = connectionStrings;

        }

        public SQLConfiguration dbConnection()
        {
            return new SQLConfiguration(_connectionStrings.ConnectionString);
        }
        public async Task<GetDeletePerfilUsuarioResponse> EliminaPerfilUsuario(DeletePerfilUsuarioRequest deleteUsuario)
        {
            GetDeletePerfilUsuarioResponse getDeletePerfilUsuarioResponse = new();

            try
            {

                string connectionString = _connectionStrings.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_Delete_Perfil_Usuario", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        cmd.Parameters.AddWithValue("@idLogin", deleteUsuario.IdLogin);
                        cmd.Parameters.AddWithValue("@rutUsuario", deleteUsuario.RutUsuario);

                        var reader = await cmd.ExecuteReaderAsync();

                        getDeletePerfilUsuarioResponse = await GetDataDeletePerfilUsuario(reader);
                    }
                }

                return getDeletePerfilUsuarioResponse;

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        private static async Task<GetDeletePerfilUsuarioResponse> GetDataDeletePerfilUsuario(DbDataReader reader)
        {
            try
            {
                if (await reader.ReadAsync())
                {
                    int filaEliminada = reader.GetInt32(reader.GetOrdinal("filaEliminada"));

                    GetDeletePerfilUsuarioResponse getDeletePerfilUsuarioResponse = new GetDeletePerfilUsuarioResponse(

                        filaEliminada

                    );

                    return getDeletePerfilUsuarioResponse;
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
