using SUO.BusinessObjects.Paciente;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.Pacientes
{
    public class PacientesRepository : IPacientesRepository
    {
        private readonly SQLConfiguration _connectionStrings;


        public PacientesRepository(SQLConfiguration connectionStrings)
        {
            _connectionStrings = connectionStrings;

        }      

        public SQLConfiguration dbConnection()
        {
            return new SQLConfiguration(_connectionStrings.ConnectionString);
        }
        public async Task<IEnumerable<GetPacienteResponse>> BuscaPacienteRut(string RUT)
        {
            try
            {
                string connectionString = _connectionStrings.ConnectionString;

                List<GetPacienteResponse> paciente = new List<GetPacienteResponse>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_Buscar_Pacientes", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@RUT", RUT));

                        using (SqlDataReader reader = (SqlDataReader)await cmd.ExecuteReaderAsync())
                        {

                            while (await reader.ReadAsync())
                            {
                                int idAtenciones = reader.GetInt32(reader.GetOrdinal("idAtenciones"));
                                string rut = reader.GetString(reader.GetOrdinal("rut"));
                                string NombrePaciente = reader.GetString(reader.GetOrdinal("NombrePaciente"));
                                string ApellidoPaterno = reader.GetString(reader.GetOrdinal("ApellidoPaterno"));
                                string ApellidoMaterno = reader.GetString(reader.GetOrdinal("ApellidoMaterno"));
                                string NombreEntidad = reader.GetString(reader.GetOrdinal("NombreEntidad"));
                                string Direccion = reader.GetString(reader.GetOrdinal("Direccion"));
                                string Estado = reader.GetString(reader.GetOrdinal("Estado"));


                                GetPacienteResponse list = new GetPacienteResponse(

                                    idAtenciones,
                                    rut,
                                    NombrePaciente,
                                    ApellidoPaterno,
                                    ApellidoMaterno,
                                    NombreEntidad,
                                    Direccion,
                                    Estado


                                );

                                paciente.Add(list);
                            }

                        }
                    }
                }

                return paciente;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
