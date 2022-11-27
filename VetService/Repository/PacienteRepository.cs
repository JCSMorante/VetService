using Microsoft.Extensions.Configuration;
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
