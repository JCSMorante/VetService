using VetService.Models;

namespace VetService.Repository.Interface
{
    public interface IPacienteRepository
    {
        void AgregarHistoriaClinica(int consultaMedicaId, string formula, string diagnostico, string descripcion, string motivo);
        Paciente InfoPaciente(TipoDocumento tipoDocumentoId, string documento);
        bool Registrar(Paciente paciente);
    }
}
