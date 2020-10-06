using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {
        public Apuesta(int idApuesta, bool tipoApuesta, double cuota, double dineroApostado, string fecha, int idUsuario, int idMercado)
        {
            this.idApuesta = idApuesta;
            this.tipoApuesta = tipoApuesta;
            this.cuota = cuota;
            this.dineroApostado = dineroApostado;
            this.fecha = fecha;
            this.idUsuario = idUsuario;
            this.idMercado = idMercado;
        }

        public int idApuesta { get; set; }

        public bool tipoApuesta { get; set; }

        public double cuota { get; set; }

        public double dineroApostado { get; set; }

        public string fecha { get; set; }

        public int idUsuario { get; set; }

        public int idMercado { get; set; }
    }
}