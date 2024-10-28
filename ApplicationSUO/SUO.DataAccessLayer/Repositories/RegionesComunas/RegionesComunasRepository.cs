using SUO.BusinessObjects.Entidad;
using SUO.BusinessObjects.EstadoPerfil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.RegionesComunas
{
    public class RegionesComunasRepository : IRegionesComunasRepository
    {
        private readonly SQLConfiguration _connectionStrings;

        public RegionesComunasRepository(SQLConfiguration connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public SQLConfiguration dbConnection()
        {
            return new SQLConfiguration(_connectionStrings.ConnectionString);
        }

        public async Task<IEnumerable<GetRegionesComunasResponse>> ListaComunasRegion(int IDREGION)
        {
            try
            {
                string connectionString = _connectionStrings.ConnectionString;
                List<GetRegionesComunasResponse> regionComuna = new List<GetRegionesComunasResponse>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_ObtenerComunasPorRegion", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@IdRegion", IDREGION));

                        using (SqlDataReader reader = (SqlDataReader)await cmd.ExecuteReaderAsync())
                        {
                       
                            if (await reader.ReadAsync())
                            {
                                int idRegion = reader.GetInt32(reader.GetOrdinal("idRegion"));
                                string region = reader.GetString(reader.GetOrdinal("Region"));
                            
                                if (await reader.NextResultAsync())
                                {
                                    while (await reader.ReadAsync())
                                    {
                                        int idComuna = reader.GetInt32(reader.GetOrdinal("idComuna"));
                                        string comuna = reader.GetString(reader.GetOrdinal("Comuna"));

                                        GetRegionesComunasResponse list = new GetRegionesComunasResponse(
                                            idRegion,
                                            region,
                                            idComuna,
                                            comuna
                                        );

                                        regionComuna.Add(list);
                                    }
                                }
                            }
                        }
                    }
                }

                return regionComuna;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<IEnumerable<GetRegionesComunasResponse>> ListaRegiones() 
        {
            try
            {
                string connectionString = _connectionStrings.ConnectionString;
                List<GetRegionesComunasResponse> regiones = new List<GetRegionesComunasResponse>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_ObtenerRegiones", connection)) 
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = (SqlDataReader)await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                int idRegion = reader.GetInt32(reader.GetOrdinal("idRegion"));
                                string region = reader.GetString(reader.GetOrdinal("Region"));

                                GetRegionesComunasResponse listaRegiones = new GetRegionesComunasResponse(
                                    idRegion,
                                    region,
                                    0, 
                                    string.Empty
                                );

                                regiones.Add(listaRegiones);
                            }
                        }
                    }
                }

                return regiones;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
