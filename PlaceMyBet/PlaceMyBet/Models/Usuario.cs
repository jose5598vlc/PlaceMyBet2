using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Usuario
    {
        public Usuario(int idUsuario, string email, string nombre, string apellidos, int edad)
        {
            this.idUsuario = idUsuario;
            Email = email;
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
        }

        public int idUsuario { get; set; }

        public string Email { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public int Edad { get; set; }
    }
}