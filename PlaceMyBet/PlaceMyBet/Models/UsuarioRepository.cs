using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class UsuarioRepository
    {

        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=LORENA;password=LORENA2001;SslMode=none";
            MySql.Data.MySqlClient.MySqlConnection con = new MySqlConnection(connString);
            return con;
        }

        internal Usuario Retrieve()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = " Select * from Usuario";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Usuario u = null;
                if (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetString(3) + " " + res.GetInt32(4));
                    u = new Usuario(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetString(3), res.GetInt32(4));
                }
                con.Close();
                return u;

            }
            catch (MySqlException u)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }
        }
    }

}