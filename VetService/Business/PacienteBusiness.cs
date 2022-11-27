using System;
using VetService.Business.Interface;
using VetService.Models;
using VetService.Repository.Interface;

namespace VetService.Business
{
    public class PacienteBusiness : IPacienteBussines
    {
        private IPacienteRepository pacienteRepository;
        public PacienteBusiness(IPacienteRepository pacienteRepository) {
            this.pacienteRepository = pacienteRepository;
        }

        public bool AgregarHistoriaClinica(int consultaMedicaId, string formula, string diagnostico, string descripcion, string motivo)
        {
            try
            {
                pacienteRepository.AgregarHistoriaClinica(consultaMedicaId, formula, diagnostico, descripcion, motivo);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Paciente InfoPaciente(TipoDocumento tipoDocumentoId, string documento)
        {
            try
            {
                return pacienteRepository.InfoPaciente(tipoDocumentoId, documento);
            } catch (Exception e)
            {
                return null;
            }
        }

        public bool RegistrarPaciente(Paciente paciente)
        {
            try 
            {
                pacienteRepository.Registrar(paciente);
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }
    }
}
