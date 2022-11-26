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
    
        [HttpPost]
        public bool RegistrarPaciente([FromBody] Paciente paciente)
        {
            return pacienteBussines.RegistrarPaciente(paciente);
        }
    }
}
