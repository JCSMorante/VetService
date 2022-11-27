using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VetService.Models
{
    public class InfoVeterinario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public TipoDocumento TipoDocumentoId { get; set; }
        public string Correo { get; set; }
        public string Documento { get; set; }
        public Collection<string> Especialidades { get; set; }
    }
}
