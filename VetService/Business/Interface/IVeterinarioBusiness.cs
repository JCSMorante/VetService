using System;
using System.Collections.ObjectModel;
using VetService.Models;

namespace VetService.Business.Interface
{
    public interface IVeterinarioBusiness
    {
        bool AgendarCita(int VeterinarioId, int PacienteId, DateTime Fecha, int SedeId);
        Collection<InfoAgenda> InfoAgenda(int VeterinarioId, DateTime Fecha);
        InfoVeterinario InfoVeterinario(TipoDocumento tipoDocumentoId, string documento);
    }
}
