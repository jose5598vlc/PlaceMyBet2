using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Mercado
    {
        public Mercado(int idMercado, double infocuotaOver, double infocuotaUnder, double dineroapostadoOver, double dineroapostadoUnder, int idEvento)
        {
            this.idMercado = idMercado;
            this.infocuotaOver = infocuotaOver;
            this.infocuotaUnder = infocuotaUnder;
            this.dineroapostadoOver = dineroapostadoOver;
            this.dineroapostadoUnder = dineroapostadoUnder;
            this.idEvento = idEvento;
        }

        public int idMercado { get; set; }
        public double infocuotaOver { get; set; }

        public double infocuotaUnder { get; set; }

        public double dineroapostadoOver { get; set; }

        public double dineroapostadoUnder { get; set; }

        public int idEvento { get; set; }

    }
}