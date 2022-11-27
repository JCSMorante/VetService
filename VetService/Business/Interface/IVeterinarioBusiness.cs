using System;

namespace VetService.Business.Interface
{
    public interface IVeterinarioBusiness
    {
        bool AgendarCita(int VeterinarioId, int PacienteId, DateTime Fecha, int SedeId);
    }
}
