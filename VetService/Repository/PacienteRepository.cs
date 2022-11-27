using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using VetService.Business.Interface;
using VetService.Helpers;
using VetService.Models;
using VetService.Repository.Interface;

namespace VetService.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly IConfiguration configuration;
        public PacienteRepository(IConfiguration configuration) 
        {
            this.configuration = configuration;
        }

        public void AgregarHistoriaClinica(int consultaMedicaId, string formula, string diagnostico, string descripcion, string motivo)
        {
            using (DataAccess dataAccess = new(configuration.GetConnectionString("Veterinaria")))
            {
                dataAccess.AddParameter("ConsultaMedicaId", consultaMedicaId);
                dataAccess.AddParameter("Formula", formula);
                dataAccess.AddParameter("Diagnostico", diagnostico);
                dataAccess.AddParameter("Descripcion", descripcion);
                dataAccess.AddParameter("Motivo", motivo);
                
                dataAccess.ExecuteScalar<int>(Procedures.AgregarHistoriaClinica);

            }
        }

        public Paciente InfoPaciente(TipoDocumento tipoDocumentoId, string documento)
        {
            Paciente paciente = new();
            using (DataAccess dataAccess = new(configuration.GetConnectionString("Veterinaria")))
            {
                dataAccess.AddParameter("TipoDocumento", tipoDocumentoId);
                dataAccess.AddParameter("Documento", documento);

                using (var dataReader = dataAccess.Execute(Procedures.InfoPaciente))
                {
                    while (dataReader.Read())
                    {
                        paciente.NombreMascota = dataReader.GetString(0);
                        paciente.Edad = dataReader.GetInt32(1);
                        paciente.Esterilizado = dataReader.GetBoolean(2);
                        paciente.Hembra = dataReader.GetBoolean(3);
                        paciente.Raza = dataReader.GetString(4);
                        paciente.Especie = dataReader.GetString(5);
                        paciente.Direccion = dataReader.GetString(6);
                        paciente.Telefono = dataReader.GetString(7);
                        paciente.TipoDocumentoId = (TipoDocumento)dataReader.GetInt32(8);
                        paciente.Documento = dataReader.GetString(9);
                        paciente.NombreDueño = dataReader.GetString(10);
                    }
                }

            }
            return paciente;
        }

        public bool Registrar(Paciente paciente)
        {
            using (DataAccess dataAccess = new(configuration.GetConnectionString("Veterinaria")))
            {
                dataAccess.AddParameter("NombreMascota", paciente.NombreMascota);
                dataAccess.AddParameter("Edad", paciente.Edad);
                dataAccess.AddParameter("Esterilizado", paciente.Esterilizado);
                dataAccess.AddParameter("Hembra", paciente.Hembra);
                dataAccess.AddParameter("Raza", paciente.Raza);
                dataAccess.AddParameter("Especie", paciente.Especie);
                dataAccess.AddParameter("Direccion", paciente.Direccion);
                dataAccess.AddParameter("Telefono", paciente.Telefono);
                dataAccess.AddParameter("TipoDocumento", paciente.TipoDocumentoId);
                dataAccess.AddParameter("Documento", paciente.Documento);
                dataAccess.AddParameter("NombreDueño", paciente.NombreDueño);
                dataAccess.ExecuteScalar<int>(Procedures.RegistroPaciente);

            }
            return true;
        }
    }
}
