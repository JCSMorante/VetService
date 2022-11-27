using Microsoft.AspNetCore.Mvc;
using System;
using VetService.Business.Interface;
using VetService.Models;

namespace VetService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeterinarioController: ControllerBase
    {
        private readonly IVeterinarioBusiness veterinarioBusiness;
        public VeterinarioController(IVeterinarioBusiness veterinarioBusiness) 
        {
            this.veterinarioBusiness = veterinarioBusiness;
        }
        [HttpPut("AgendarCita")]
        public bool AgendarCita(int VeterinarioId, int PacienteId, DateTime Fecha, int SedeId)
        {
            return veterinarioBusiness.AgendarCita(VeterinarioId, PacienteId, Fecha, SedeId);
        }

        [HttpGet("InfoVeterinario")]
        public InfoVeterinario InfoVeterinario(TipoDocumento tipoDocumentoId, string documento)
        {
            return veterinarioBusiness.InfoVeterinario(tipoDocumentoId, documento);
        }
    }
}
