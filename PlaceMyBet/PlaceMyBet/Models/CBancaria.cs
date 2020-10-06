using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class CBancaria
    {
        public CBancaria(int idCBancaria, int saldoBanco, string nombreBanco, int numtarCredito, int idUsuario)
        {
            this.idCBancaria = idCBancaria;
            this.saldoBanco = saldoBanco;
            this.nombreBanco = nombreBanco;
            this.numtarCredito = numtarCredito;
            this.idUsuario = idUsuario;
        }

        public int idCBancaria { get; set; }

        public int saldoBanco { get; set; }

        public string nombreBanco { get; set; }

        public int numtarCredito { get; set; }

        public int idUsuario { get; set; }

    }
}