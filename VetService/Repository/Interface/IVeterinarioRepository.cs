using System;

namespace VetService.Repository.Interface
{
    public interface IVeterinarioRepository
    {
        bool AgendarCita(int VeterinarioId, int PacienteId, DateTime Fecha, int SedeId);
    }
}
