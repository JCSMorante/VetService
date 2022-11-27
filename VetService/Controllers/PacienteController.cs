using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using VetService.Models;
using VetService.Business.Interface;

namespace VetService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {
        private IPacienteBussines pacienteBussines;
        public PacienteController(IPacienteBussines pacienteBussines)
        {
            this.pacienteBussines = pacienteBussines;
        }

        [HttpPost("RegistrarPaciente")]
        public bool RegistrarPaciente([FromBody] Paciente paciente)
        {
            return pacienteBussines.RegistrarPaciente(paciente);
        }

        [HttpPut("AgregarHistoriaClinica")]
        public bool AgregarHistoriaClinica(int ConsultaMedicaId, string Formula, string Diagnostico, string Descripcion, string Motivo)
        {
            return pacienteBussines.AgregarHistoriaClinica(ConsultaMedicaId, Formula, Diagnostico, Descripcion, Motivo);
        }

        [HttpGet("InfoPaciente")]
        public Paciente InfoPaciente(TipoDocumento tipoDocumentoId, string documento)
        {
            return pacienteBussines.InfoPaciente(tipoDocumentoId, documento);
        }
    }
}
