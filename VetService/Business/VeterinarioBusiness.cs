using System;
using System.Collections.ObjectModel;
using VetService.Business.Interface;
using VetService.Models;
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

        public Collection<InfoAgenda> InfoAgenda(int VeterinarioId, DateTime Fecha)
        {
            Collection<InfoAgenda> infoVeterinario = veterinarioRepository.InfoAgenda(VeterinarioId, Fecha);
            return infoVeterinario;
        }

        public InfoVeterinario InfoVeterinario(TipoDocumento tipoDocumentoId, string documento)
        {
            try
            {
                InfoVeterinario infoVeterinario = veterinarioRepository.InfoVeterinario(tipoDocumentoId, documento);
                infoVeterinario.Especialidades = veterinarioRepository.EspecialidadVeterinario(tipoDocumentoId, documento);
                return infoVeterinario;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
    
}
