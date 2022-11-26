using VetService.Models;

namespace VetService.Repository.Interface
{
    public interface IPacienteRepository
    {
        bool Registrar(Paciente paciente);
    }
}
