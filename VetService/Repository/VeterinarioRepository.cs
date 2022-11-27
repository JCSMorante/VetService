using Microsoft.Extensions.Configuration;
using System;
using VetService.Helpers;
using VetService.Models;
using VetService.Repository.Interface;

namespace VetService.Repository
{
    public class VeterinarioRepository : IVeterinarioRepository
    {
        private readonly IConfiguration configuration;
        public VeterinarioRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public bool AgendarCita(int VeterinarioId, int PacienteId, DateTime Fecha, int SedeId)
        {
            using (DataAccess dataAccess = new(configuration.GetConnectionString("Veterinaria")))
            {
                dataAccess.AddParameter("VeterinarioId", VeterinarioId);
                dataAccess.AddParameter("PacienteId", PacienteId);
                dataAccess.AddParameter("Fecha", Fecha);
                dataAccess.AddParameter("SedeId", SedeId);

                dataAccess.Execute(Procedures.AgendarCita);
           

            }
            return true;
        }
    }
}
