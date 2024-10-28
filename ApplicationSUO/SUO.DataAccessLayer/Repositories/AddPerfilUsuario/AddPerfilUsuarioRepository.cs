using SUO.BusinessObjects.AddPerfilUsuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.AddPerfilUsuario
{
    public class AddPerfilUsuarioRepository : IAddPerfilUsuarioRepository
    {
        private readonly SQLConfiguration _connectionStrings;


        public AddPerfilUsuarioRepository(SQLConfiguration connectionStrings)
        {
            _connectionStrings = connectionStrings;

        }

        public SQLConfiguration dbConnection()
        {
            return new SQLConfiguration(_connectionStrings.ConnectionString);
        }
        public async Task<GetPerfilUsuarioResponse> CreaPerfilUsuario(AddPerfilUsuarioRequest addPerfilUsuarioRequest)
        {
            GetPerfilUsuarioResponse getPerfilUsuarioResponse = new();

            try
            {                

                string connectionString = _connectionStrings.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_Add_Nuevo_Usuario", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@rutUsuario", addPerfilUsuarioRequest.RutUsuario);
                        cmd.Parameters.AddWithValue("@nombreUsuario", addPerfilUsuarioRequest.NombreUsuario);
                        cmd.Parameters.AddWithValue("@apellidoPaterno", addPerfilUsuarioRequest.ApellidoPaterno);
                        cmd.Parameters.AddWithValue("@apellidoMaterno", addPerfilUsuarioRequest.ApellidoMaterno);
                        cmd.Parameters.AddWithValue("@correoUsuario", addPerfilUsuarioRequest.CorreoUsuario);                       
                        cmd.Parameters.AddWithValue("@idEntidad", addPerfilUsuarioRequest.IdEntidad);
                        cmd.Parameters.AddWithValue("@rutEntidad", addPerfilUsuarioRequest.RutEntidad);
                        cmd.Parameters.AddWithValue("@password", addPerfilUsuarioRequest.Password);
                        cmd.Parameters.AddWithValue("@idPerfil", addPerfilUsuarioRequest.IdPerfil);
                        cmd.Parameters.AddWithValue("@idEstado", addPerfilUsuarioRequest.IdEstado);                        

                        var reader = await cmd.ExecuteReaderAsync();

                        getPerfilUsuarioResponse = await GetDataPerfilUsuario(reader);
                    }
                }
              

                return getPerfilUsuarioResponse;

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        private static async Task<GetPerfilUsuarioResponse> GetDataPerfilUsuario(DbDataReader reader)
        {
            try
            {
                if (await reader.ReadAsync())
                {
                    int FilaAgregada = reader.GetInt32(reader.GetOrdinal("filaAgregada"));

                    GetPerfilUsuarioResponse getPerfilUsuarioResponse = new GetPerfilUsuarioResponse(

                        FilaAgregada

                    );

                    return getPerfilUsuarioResponse;
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
