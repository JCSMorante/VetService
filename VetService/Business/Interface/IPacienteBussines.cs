using VetService.Models;

namespace VetService.Business.Interface
{
    public interface IPacienteBussines
    {
        bool RegistrarPaciente(Paciente paciente);
    }
}
