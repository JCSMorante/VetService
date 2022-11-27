using System;
using VetService.Business.Interface;
using VetService.Repository.Interface;

namespace VetService.Business
{
    public class VeterinarioBusiness : IVeterinarioBusiness
    {
        private readonly IVeterinarioRepository veterinarioRepository;
        public VeterinarioBusiness(IVeterinarioRepository veterinarioRepository)
        {
            this.veterinarioRepository = veterinarioRepository;
        }
        public bool AgendarCita(int VeterinarioId, int PacienteId, DateTime Fecha, int SedeId)
        {
            try
            {
                return veterinarioRepository.AgendarCita(VeterinarioId, PacienteId, Fecha, SedeId);
                
            }
            catch (Exception e) 
            {
                return false;
            }
        }
    }
}
