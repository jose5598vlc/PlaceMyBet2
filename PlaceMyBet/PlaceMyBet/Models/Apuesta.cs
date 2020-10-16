using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {
        public Apuesta(int idApuesta, bool tipoApuesta, double cuota, double dineroApostado, string fecha, int idMercado, string Email)
        {
            this.idApuesta = idApuesta;
            this.tipoApuesta = tipoApuesta;
            this.cuota = cuota;
            this.dineroApostado = dineroApostado;
            this.fecha = fecha;
            this.idMercado = idMercado;
            this.Email = Email;
        }

        public int idApuesta { get; set; }

        public bool tipoApuesta { get; set; }

        public double cuota { get; set; }

        public double dineroApostado { get; set; }

        public string fecha { get; set; }


        public int idMercado { get; set; }

        public string Email { get; set; }
    }

    public class ApuestaDTO
    {
        public ApuestaDTO(bool tipoApuesta, double cuota, double dineroApostado, string fecha, int idMercado, string Email)
        {
            
            this.tipoApuesta = tipoApuesta;
            this.cuota = cuota;
            this.dineroApostado = dineroApostado;
            this.fecha = fecha;
            this.idMercado = idMercado;
            this.Email = Email;
        }

       

        public bool tipoApuesta { get; set; }

        public double cuota { get; set; }

        public double dineroApostado { get; set; }

        public string fecha { get; set; }


        public int idMercado { get; set; }

        public string Email { get; set; }
    }
}