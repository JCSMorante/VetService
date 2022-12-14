using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.PortableExecutable;
using VetService.Helpers;
using VetService.Models;
using VetService.Repository.Interface;

namespace VetService.Repository
{
    public class VeterinarioRepository : IVeterinarioRepository
    {
        private readonly IConfiguration configuration;
        public VeterinarioRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public bool AgendarCita(int VeterinarioId, int PacienteId, DateTime Fecha, int SedeId)
        {
            using (DataAccess dataAccess = new(configuration.GetConnectionString("Veterinaria")))
            {
                dataAccess.AddParameter("VeterinarioId", VeterinarioId);
                dataAccess.AddParameter("PacienteId", PacienteId);
                dataAccess.AddParameter("Fecha", Fecha);
                dataAccess.AddParameter("SedeId", SedeId);

                dataAccess.ExecuteScalar<int>(Procedures.AgendarCita);
           

            }
            return true;
        }

        public Collection<string> EspecialidadVeterinario(TipoDocumento tipoDocumentoId, string documento)
        {
            using (DataAccess dataAccess = new(configuration.GetConnectionString("Veterinaria")))
            {
                dataAccess.AddParameter("TipoDocumento", tipoDocumentoId);
                dataAccess.AddParameter("Documento", documento);

                return dataAccess.GetList<string>(Procedures.EspecialidadVeterinario);

            }
        }

        public Collection<InfoAgenda> InfoAgenda(int veterinarioId, DateTime fecha)
        {
            Collection<InfoAgenda> agenda = new();
            using (DataAccess dataAccess = new(configuration.GetConnectionString("Veterinaria")))
            {
                dataAccess.AddParameter("veterinarioId", veterinarioId);
                dataAccess.AddParameter("fecha", fecha);

                using (var dataReader = dataAccess.Execute(Procedures.VerAgendaVeterinario))
                {
                    while (dataReader.Read())
                    {
                        InfoAgenda evento = new InfoAgenda();
                        evento.Veterinario = dataReader.GetString(0);
                        evento.NombreDueño = dataReader.GetString(1);
                        evento.Mascota = dataReader.GetString(2);
                        evento.Fecha = dataReader.GetDateTime(3);
                        agenda.Add(evento);
                    }
                }

            }
            return agenda;
        }

        public InfoVeterinario InfoVeterinario(TipoDocumento tipoDocumentoId, string documento)
        {
            var infoVeterinario = new InfoVeterinario();

            using (DataAccess dataAccess = new(configuration.GetConnectionString("Veterinaria")))
            {
                dataAccess.AddParameter("TipoDocumento", tipoDocumentoId);
                dataAccess.AddParameter("Documento", documento);

                using (var dataReader = dataAccess.Execute(Procedures.InfoVeterinario))
                {
                    while (dataReader.Read())
                    {
                        infoVeterinario.Nombre = dataReader.GetString(0);
                        infoVeterinario.TipoDocumentoId = (TipoDocumento)dataReader.GetInt32(1);
                        infoVeterinario.Correo = dataReader.GetString(2);
                        infoVeterinario.Documento = dataReader.GetString(3);                      
                    }
                }

            }
            return infoVeterinario;
        }
    }
}
