using System.Data;

namespace VetService.Models
{
    public class Paciente
    {
        public int ID { get; set; }
        public string NombreMascota { get; set; }
        public int Edad { get; set; }
        public bool Esterilizado { get; set; }
        public bool Hembra { get; set; }
        public string Raza { get; set; }
        public string Especie { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public TipoDocumento TipoDocumentoId { get; set; }
        public string Documento { get; set; }
        public string NombreDueño { get; set; }
    }
}
