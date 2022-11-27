using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VetService.Models;

namespace VetService.Repository.Interface
{
    public interface IVeterinarioRepository
    {
        bool AgendarCita(int VeterinarioId, int PacienteId, DateTime Fecha, int SedeId);
        Collection<string> EspecialidadVeterinario(TipoDocumento tipoDocumentoId, string documento);
        InfoVeterinario InfoVeterinario(TipoDocumento tipoDocumentoId, string documento);
    }
}
