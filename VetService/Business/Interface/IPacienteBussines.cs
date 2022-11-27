using VetService.Models;

namespace VetService.Business.Interface
{
    public interface IPacienteBussines
    {
        bool AgregarHistoriaClinica(int consultaMedicaId, string formula, string diagnostico, string descripcion, string motivo);
        Paciente InfoPaciente(TipoDocumento tipoDocumentoId, string documento);
        bool RegistrarPaciente(Paciente paciente);
    }
}
