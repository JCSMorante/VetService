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
