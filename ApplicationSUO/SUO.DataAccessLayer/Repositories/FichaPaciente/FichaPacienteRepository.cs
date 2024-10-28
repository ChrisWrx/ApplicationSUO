using SUO.BusinessObjects.FichaPaciente;
using SUO.BusinessObjects.Paciente;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.FichaPaciente
{
    public class FichaPacienteRepository : IFichaPacienteRepository
    {
        private readonly SQLConfiguration _connectionStrings;


        public FichaPacienteRepository(SQLConfiguration connectionStrings)
        {
            _connectionStrings = connectionStrings;

        }

        public SQLConfiguration dbConnection()
        {
            return new SQLConfiguration(_connectionStrings.ConnectionString);
        }
        public async Task<IEnumerable<GetFichaPacienteResponse>> FichaPacienteIdRut(int ID, string RUT)
        {
            try
            {
                string connectionString = _connectionStrings.ConnectionString;

                List<GetFichaPacienteResponse> fichaPaciente = new List<GetFichaPacienteResponse>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SP_Ficha_Paciente", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id_Atencion", ID));
                        cmd.Parameters.Add(new SqlParameter("@RUT", RUT));

                        using (SqlDataReader reader = (SqlDataReader)await cmd.ExecuteReaderAsync())
                        {

                            while (await reader.ReadAsync())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                string rutPaciente = reader.GetString(reader.GetOrdinal("rutPaciente"));
                                string nombresPaciente = reader.GetString(reader.GetOrdinal("nombresPaciente"));
                                string apellidoPaterno = reader.GetString(reader.GetOrdinal("apellidoPaterno"));
                                string apellidoMaterno = reader.GetString(reader.GetOrdinal("apellidoMaterno"));
                                string direccionPaciente = reader.GetString(reader.GetOrdinal("direccionPaciente"));
                                string comunaPaciente = reader.GetString(reader.GetOrdinal("comunaPaciente"));
                                string regionPaciente = reader.GetString(reader.GetOrdinal("regionPaciente"));
                                string rutEntidad = reader.GetString(reader.GetOrdinal("rutEntidad"));
                                string direccionEntidad = reader.GetString(reader.GetOrdinal("direccionEntidad"));
                                string nombreEntidad = reader.GetString(reader.GetOrdinal("nombreEntidad"));
                                string comunaEntidad = reader.GetString(reader.GetOrdinal("comunaEntidad"));
                                string regionEntidad = reader.GetString(reader.GetOrdinal("regionEntidad"));
                                string horaAtencion = reader.GetString(reader.GetOrdinal("horaAtencion"));
                                string fechaAtencion = reader.GetString(reader.GetOrdinal("fechaAtencion"));
                                string fechaAlta = reader.GetString(reader.GetOrdinal("fechaAlta"));
                                string estado = reader.GetString(reader.GetOrdinal("estado"));
                                string diagnostico = reader.GetString(reader.GetOrdinal("diagnostico"));


                                GetFichaPacienteResponse list = new GetFichaPacienteResponse(

                                    id,
                                    rutPaciente,
                                    nombresPaciente,
                                    apellidoPaterno,
                                    apellidoMaterno,
                                    direccionPaciente,
                                    comunaPaciente,
                                    regionPaciente,
                                    rutEntidad,
                                    nombreEntidad,
                                    direccionEntidad,
                                    comunaEntidad,
                                    regionEntidad,
                                    horaAtencion,
                                    fechaAtencion,
                                    fechaAlta,
                                    estado,
                                    diagnostico


                                );

                                fichaPaciente.Add(list);
                            }

                        }
                    }
                }

                return fichaPaciente;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
