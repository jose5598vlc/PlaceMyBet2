using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Mercado
    {
        public Mercado(int idMercado, int tipoMercado, double infocuotaOver, double infocuotaUnder, double dineroapostadoOver, double dineroapostadoUnder, int idEvento)
        {
            this.idMercado = idMercado;
            this.tipoMercado = tipoMercado;
            this.infocuotaOver = infocuotaOver;
            this.infocuotaUnder = infocuotaUnder;
            this.dineroapostadoOver = dineroapostadoOver;
            this.dineroapostadoUnder = dineroapostadoUnder;
            this.idEvento = idEvento;
        }

        public int idMercado { get; set; }

        public int tipoMercado { get; set; }
        public double infocuotaOver { get; set; }

        public double infocuotaUnder { get; set; }

        public double dineroapostadoOver { get; set; }

        public double dineroapostadoUnder { get; set; }

        public int idEvento { get; set; }

    }

    public class MercadoDTO
    {
        public MercadoDTO(int tipoMercado, double infocuotaOver, double infocuotaUnder)
        {
            this.tipoMercado = tipoMercado;
            this.infocuotaOver = infocuotaOver;
            this.infocuotaUnder = infocuotaUnder;
            
        }

        public int tipoMercado { get; set; }
        public double infocuotaOver { get; set; }

        public double infocuotaUnder { get; set; }

        



    }

}