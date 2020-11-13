using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Evento
    {
        public Evento(int idEvento, string equipoLocal, string equipoVisitante, string fecha)
        {
            this.idEvento = idEvento;
            this.equipoLocal = equipoLocal;
            this.equipoVisitante = equipoVisitante;
            this.fecha = fecha;
        }

        public int idEvento { get; set; }
        public string equipoLocal { get; set; }

        public string equipoVisitante { get; set; }

        public string fecha { get; set; }

    }

    public class EventoDTO
    {
        public EventoDTO(string equipoLocal, string equipoVisitante, string fecha)
        {
            
            this.equipoLocal = equipoLocal;
            this.equipoVisitante = equipoVisitante;
            this.fecha = fecha;
        }

       
        public string equipoLocal { get; set; }

        public string equipoVisitante { get; set; }

        public string fecha { get; set; }

    }

    // ejercicio 1 examen
    public class EventoExamen
    {
        public EventoExamen(string equipoLocal, string equipoVisitante, double tipoMercado)
        {
            this.equipoLocal = equipoLocal;
            this.equipoVisitante = equipoVisitante;
            this.tipoMercado = tipoMercado;
        }

        public string equipoLocal { get; set; }

        public string equipoVisitante { get; set; }

        public double tipoMercado { get; set; }
    }
}