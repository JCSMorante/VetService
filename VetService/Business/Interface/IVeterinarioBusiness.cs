using System;
using VetService.Models;

namespace VetService.Business.Interface
{
    public interface IVeterinarioBusiness
    {
        bool AgendarCita(int VeterinarioId, int PacienteId, DateTime Fecha, int SedeId);
        InfoVeterinario InfoVeterinario(TipoDocumento tipoDocumentoId, string documento);
    }
}
